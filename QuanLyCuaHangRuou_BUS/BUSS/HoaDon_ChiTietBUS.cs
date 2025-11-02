using QuanLyCuaHangRuou_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCuaHangRuou_BUS
{
    public class HoaDon_ChiTietBUS
    {
        private Model1 context = new Model1();

        public List<HoaDon_ChiTiet> GetAll()
        {
            return context.HoaDon_ChiTiet
                          .Include("DoUong") 
                          .Include("HoaDon")
                          .ToList();
        }

    
        public List<HoaDon_ChiTiet> GetByHoaDon(string maHD)
        {
            return context.HoaDon_ChiTiet
                          .Where(x => x.MaHD == maHD)
                          .Include("DoUong")
                          .ToList();
        }

        
        public void Add(HoaDon_ChiTiet ct)
        {
            if (ct == null)
                throw new ArgumentNullException("Chi tiết hóa đơn không được null.");

            var existed = context.HoaDon_ChiTiet
                                 .FirstOrDefault(x => x.MaHD == ct.MaHD && x.MaDo_Uong == ct.MaDo_Uong);
            if (existed != null)
                throw new Exception($"Mặt hàng '{ct.MaDo_Uong}' đã tồn tại trong hóa đơn {ct.MaHD}.");

            context.HoaDon_ChiTiet.Add(ct);
            context.SaveChanges();
        }

        
        public void Delete(string maHD, string maDoUong)
        {
            var cthd = context.HoaDon_ChiTiet
                .FirstOrDefault(x => x.MaHD == maHD && x.MaDo_Uong == maDoUong);

            if (cthd == null)
                throw new Exception($"Không tìm thấy chi tiết hóa đơn {maHD} – {maDoUong}");

            context.HoaDon_ChiTiet.Remove(cthd);
            context.SaveChanges();
        }

       
        public void Update(HoaDon_ChiTiet updated)
        {
            var existing = context.HoaDon_ChiTiet
                .FirstOrDefault(x => x.MaHD == updated.MaHD && x.MaDo_Uong == updated.MaDo_Uong);

            if (existing == null)
                throw new Exception($"Không tìm thấy chi tiết hóa đơn {updated.MaHD} – {updated.MaDo_Uong}");

            existing.SoLuong = updated.SoLuong;
            existing.DonGia = updated.DonGia;
            existing.ThanhTien = updated.SoLuong * updated.DonGia;

            context.SaveChanges();
        }

       
        public decimal TinhTongTien(string maHD)
        {
            var list = context.HoaDon_ChiTiet
                              .Where(x => x.MaHD == maHD)
                              .ToList();

            if (!list.Any())
                return 0;

            return list.Sum(x => x.DonGia * x.SoLuong);
        }

        
        public bool Exists(string maHD, string maDoUong)
        {
            return context.HoaDon_ChiTiet
                          .Any(x => x.MaHD == maHD && x.MaDo_Uong == maDoUong);
        }
        public List<object> GetByHoaDonForReport(string maHD)
        {
            return context.HoaDon_ChiTiet
                .Where(x => x.MaHD == maHD)
                .Select(x => new
                {
                    x.MaHD,
                    x.DoUong.TenDo_Uong,
                    x.SoLuong,
                    x.DonGia,
                    ThanhTien = x.SoLuong * x.DonGia
                })
                .ToList<object>();
        }
        public List<HoaDon_ChiTiet> GetByMaHD(string maHD)
        {
            return GetAll().Where(ct => ct.MaHD == maHD).ToList();
        }
    }
}