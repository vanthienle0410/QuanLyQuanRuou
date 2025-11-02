using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangRuou_DAL.Models;

namespace QuanLyCuaHangRuou_BUS
{
    public class KhachHangBUS
    {
        private Model1 context = new Model1();

        public List<KhachHang> GetAll()
        {
            return context.KhachHangs.ToList();
        }

        public KhachHang GetById(string ma)
        {
            return context.KhachHangs.FirstOrDefault(x => x.MaKH == ma);
        }

        public void Add(KhachHang kh)
        {
            context.KhachHangs.Add(kh);
            context.SaveChanges();
        }

        public void Update(KhachHang kh)
        {
            var existing = context.KhachHangs.FirstOrDefault(x => x.MaKH == kh.MaKH);
            if (existing != null)
            {
                existing.TenKH = kh.TenKH;
                existing.SoDienThoai = kh.SoDienThoai;
                existing.DiaChi = kh.DiaChi;
                context.SaveChanges();
            }
        }

        public void Delete(string ma)
        {
            var kh = context.KhachHangs.FirstOrDefault(x => x.MaKH == ma);
            if (kh != null)
            {
                context.KhachHangs.Remove(kh);
                context.SaveChanges();
            }
        }
    }
}
