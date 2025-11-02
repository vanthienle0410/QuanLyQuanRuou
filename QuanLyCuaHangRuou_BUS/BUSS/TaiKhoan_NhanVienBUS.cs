using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHangRuou_DAL.Models;
using QuanLyCuaHangRuou_BUS;


namespace QuanLyCuaHangRuou_BUS
{
    public class TaiKhoan_NhanVienBUS
    {
        private Model1 context = new Model1();

        public List<TaiKhoan_NhanVien> GetAll()
        {
            // context.TaiKhoan_NhanVien là DbSet tương ứng trong Model1
            return context.TaiKhoan_NhanVien.ToList();
        }

        public TaiKhoan_NhanVien DangNhap(string tenDangNhap, string matKhau)
        {
            return context.TaiKhoan_NhanVien
                .FirstOrDefault(x => x.TenDangNhap == tenDangNhap && x.MatKhau == matKhau);
        }

        public bool KiemTraTenDangNhapTonTai(string tenDangNhap)
        {
            return context.TaiKhoan_NhanVien.Any(x => x.TenDangNhap == tenDangNhap);
        }

        public void DoiMatKhau(string maTK, string matKhauMoi)
        {
            var tk = context.TaiKhoan_NhanVien.FirstOrDefault(x => x.MaTK_NV == maTK);
            if (tk != null)
            {
                tk.MatKhau = matKhauMoi;
                context.SaveChanges();
            }
        }
    }
}
