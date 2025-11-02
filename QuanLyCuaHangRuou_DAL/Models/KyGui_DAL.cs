using System;
using System.Linq;
using QuanLyCuaHangRuou_DAL.Models;
using System.Collections.Generic; // Dùng cho Enumerable.Empty

namespace QuanLyCuaHangRuou_DAL
{
    public class KyGui_DAL
    {
        // Phương thức thêm mới một chai rượu ký gửi
        public bool ThemKyGui(KyGui_Ruou entity)
        {
            try
            {
                using (var db = new Models.Model1())
                {
                    db.KyGui_Ruous.Add(entity);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL (EF) khi thêm ký gửi: " + ex.Message);
                return false;
            }
        }

        // Phương thức cập nhật trạng thái đã lấy lại
        public bool CapNhatDaLayLai(string maKyGui)
        {
            try
            {
                using (var db = new Models.Model1())
                {
                    var kyGui = db.KyGui_Ruous.FirstOrDefault(k => k.MaKyGui == maKyGui && k.TrangThai == "DANG_KY_GUI");

                    if (kyGui != null)
                    {
                        kyGui.TrangThai = "DA_LAY_LAI";
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAL (EF) khi cập nhật trạng thái: " + ex.Message);
                return false;
            }
        }

        // Phương thức lấy mã ký gửi cuối cùng để tạo mã mới
        public string LayMaKyGuiCuoiCung()
        {
            using (var db = new Models.Model1())
            {
                return db.KyGui_Ruous
                         .OrderByDescending(k => k.MaKyGui)
                         .Select(k => k.MaKyGui)
                         .FirstOrDefault();
            }
        }

        // BỔ SUNG: KHẮC PHỤC LỖI CS0161. Phương thức lấy danh sách rượu đang ký gửi
        public IQueryable<KyGui_Ruou> GetAllDangKyGui()
        {
            try
            {
                var db = new Models.Model1();
                // Trả về IQueryable để tầng BUS có thể tiếp tục thao tác truy vấn
                return db.KyGui_Ruous.Where(k => k.TrangThai == "DANG_KY_GUI");
            }
            catch
            {
                // Trả về danh sách rỗng để tránh crash chương trình
                return Enumerable.Empty<KyGui_Ruou>().AsQueryable();
            }
        }
    }
}