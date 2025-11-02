using System;
using System.Linq;
using QuanLyCuaHangRuou_DAL;
using QuanLyCuaHangRuou_DAL.Models; // Quan trọng để sử dụng KyGui_Ruou

namespace QuanLyCuaHangRuou_BUS
{
    public class KyGui_BUS
    {
        private KyGui_DAL kyGuiDAL = new KyGui_DAL();

        // Phương thức tạo mã ký gửi tự động
        private string TaoMaKyGuiMoi()
        {
            string maCuoi = kyGuiDAL.LayMaKyGuiCuoiCung();

            if (string.IsNullOrEmpty(maCuoi))
            {
                return "KG00001";
            }

            string phanSo = maCuoi.Substring(2);
            int soMoi = int.Parse(phanSo) + 1;
            return "KG" + soMoi.ToString("D5");
        }

        public bool XuLyKyGuiMoi(string maKH, string tenRuou, decimal dungTichConLai, string donViTinh, string viTri)
        {
            if (string.IsNullOrWhiteSpace(maKH) || string.IsNullOrWhiteSpace(tenRuou) || dungTichConLai <= 0)
            {
                return false;
            }

            var newKyGui = new KyGui_Ruou
            {
                MaKyGui = TaoMaKyGuiMoi(),
                MaKH = maKH,
                TenRuou = tenRuou,
                DungTichConLai = dungTichConLai,
                DonViTinh = donViTinh,
                NgayKyGui = DateTime.Now,
                HanKyGui = DateTime.Now.AddDays(30),
                ViTriLuuTru = viTri,
                TrangThai = "DANG_KY_GUI"
            };

            return kyGuiDAL.ThemKyGui(newKyGui);
        }

        public bool XuLyKhachHangLayLaiRuou(string maKyGui)
        {
            if (string.IsNullOrWhiteSpace(maKyGui))
            {
                return false;
            }

            return kyGuiDAL.CapNhatDaLayLai(maKyGui);
        }

        // BỔ SUNG: KHẮC PHỤC LỖI CS0161. Phương thức gọi DAL để lấy danh sách đang ký gửi
        public IQueryable<KyGui_Ruou> GetAllDangKyGui()
        {
            return kyGuiDAL.GetAllDangKyGui();
        }
    }
}