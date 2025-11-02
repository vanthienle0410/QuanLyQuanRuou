using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangRuou_DAL.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
// Bạn có thể cần thêm using cho DoUongBUS nếu muốn gọi hàm từ đó
// using QuanLyCuaHangRuou_BUS; 

namespace QuanLyCuaHangRuou_BUS
{
    public class HoaDonBUS
    {
        private Model1 context = new Model1();

        // ... (Các hàm GetAll, GetById, Add, Update, Delete) ...

        /// <summary>
        /// ✅ Hàm thanh toán hóa đơn kèm chi tiết — Đã thêm Transaction, xử lý lỗi chi tiết VÀ TRỪ TỒN KHO
        /// </summary>
        public void ThanhToan(HoaDon hoaDon, List<HoaDon_ChiTiet> chiTietList)
        {
            // Sử dụng DbContextTransaction để đảm bảo tính toàn vẹn (Transaction)
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    // 1. Thêm hóa đơn
                    context.HoaDons.Add(hoaDon);

                    // 2. Thêm chi tiết hóa đơn
                    foreach (var ct in chiTietList)
                    {
                        ct.MaHD = hoaDon.MaHD; // gán mã hóa đơn
                        context.HoaDon_ChiTiet.Add(ct);
                    }

                    // 3. Lưu Hóa đơn và Chi tiết vào CSDL
                    context.SaveChanges();

                    // ==========================================================
                    // 4. TRỪ TỒN KHO (LOGIC MỚI)
                    // ==========================================================
                    foreach (var ct in chiTietList)
                    {
                        var doUong = context.DoUongs.FirstOrDefault(d => d.MaDo_Uong == ct.MaDo_Uong);

                        if (doUong == null)
                        {
                            // Nếu không tìm thấy đồ uống, rollback và báo lỗi
                            throw new Exception("Lỗi: Không tìm thấy Mã Đồ Uống " + ct.MaDo_Uong + " để trừ tồn kho.");
                        }

                        // Kiểm tra tồn kho trước khi trừ
                        if (doUong.SoLuongTon < ct.SoLuong)
                        {
                            // Nếu thiếu hàng, rollback và báo lỗi
                            throw new Exception("LỖI: Mặt hàng " + doUong.TenDo_Uong + " chỉ còn " + doUong.SoLuongTon + " sản phẩm. Không đủ để bán.");
                        }

                        // Thực hiện trừ tồn kho
                        doUong.SoLuongTon -= ct.SoLuong;
                    }

                    // 5. Lưu lại các thay đổi về tồn kho
                    context.SaveChanges();

                    // 6. Commit transaction nếu không có lỗi
                    transaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    // Lỗi Validation
                    transaction.Rollback();
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => $"{x.PropertyName}: {x.ErrorMessage}");

                    var fullErrorMessage = string.Join("\n", errorMessages);
                    throw new Exception("LỖI VALIDATION dữ liệu Entity: \n" + fullErrorMessage);
                }
                catch (DbUpdateException ex)
                {
                    // Lỗi DB Update (Khóa ngoại, ràng buộc duy nhất...)
                    transaction.Rollback();

                    var sqlException = ex.InnerException?.InnerException as SqlException;
                    if (sqlException != null && sqlException.Number == 547)
                    {
                        throw new Exception("LỖI CƠ SỞ DỮ LIỆU (Khóa ngoại)! \nVui lòng kiểm tra Mã NV (" + hoaDon.MaTK_NV + ") và Mã KH, Mã Đồ Uống đã tồn tại trong các bảng tương ứng chưa.");
                    }

                    string innerMessage = ex.InnerException != null && ex.InnerException.InnerException != null
                        ? ex.InnerException.InnerException.Message
                        : ex.Message;

                    throw new Exception("LỖI CẬP NHẬT CSDL:\n" + innerMessage);
                }
                catch (Exception ex)
                {
                    // Lỗi Logic (ví dụ: Không đủ tồn kho) hoặc lỗi hệ thống khác
                    transaction.Rollback();
                    throw new Exception("Lỗi khi lưu hóa đơn: " + ex.Message);
                }
            }
        }
        public List<HoaDon> GetAll() // ✅ Phương thức GetAll
        {
            return context.HoaDons.ToList();
        }
        public void Delete(string ma) // ✅ Phương thức Delete
        {
            var hd = context.HoaDons.FirstOrDefault(x => x.MaHD == ma);
            if (hd != null)
            {
                // Xóa chi tiết hóa đơn trước khi xóa hóa đơn chính
                var chiTietList = context.HoaDon_ChiTiet.Where(x => x.MaHD == ma).ToList();
                if (chiTietList.Any())
                {
                    context.HoaDon_ChiTiet.RemoveRange(chiTietList);
                }

                context.HoaDons.Remove(hd);
                context.SaveChanges();
            }
            else
            {
                throw new Exception($"❌ Không tìm thấy hóa đơn có mã '{ma}' để xóa!");
            }

            { 
            }
        }
        public object GetReportData(string maHD)
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKH equals kh.MaKH
                        join nv in context.TaiKhoan_NhanVien on hd.MaTK_NV equals nv.MaTK_NV
                        where hd.MaHD == maHD
                        select new
                        {
                            hd.MaHD,
                            hd.NgayHoaDon,
                            hd.TongTien,
                            KhachHang = kh.TenKH,
                            NhanVien = nv.TenNV,
                            ChiTiet = from ct in context.HoaDon_ChiTiet
                                      join du in context.DoUongs on ct.MaDo_Uong equals du.MaDo_Uong
                                      where ct.MaHD == hd.MaHD
                                      select new
                                      {
                                          du.TenDo_Uong,
                                          ct.SoLuong,
                                          ct.DonGia,
                                          ThanhTien = ct.SoLuong * ct.DonGia
                                      }
                        };

            return query.FirstOrDefault();
        }


        // ... (Các hàm khác như XoaHoaDon) ...
    }
}