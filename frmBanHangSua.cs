using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangRuou_DAL.Models;

namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmBanHangSua : Form
    {
        private readonly Model1 db = new Model1();
        private readonly string _maHD;

        public frmBanHangSua(string maHD)
        {
            InitializeComponent();
            _maHD = maHD;
            this.Load += FrmBanHangSua_Load;
        }

        private void FrmBanHangSua_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadKhachHang();
            LoadHoaDon(_maHD);
        }

        private void LoadNhanVien()
        {
            var nhanVienList = db.TaiKhoan_NhanVien
                .Select(nv => new { nv.MaTK_NV, nv.TenNV })
                .ToList();

            cboNhanVien.DataSource = nhanVienList;
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaTK_NV";
        }

        private void LoadKhachHang()
        {
            var khList = db.KhachHangs
                .Select(kh => new { kh.MaKH, kh.TenKH })
                .ToList();

            cboKhachHang.DataSource = khList;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }

        private void LoadHoaDon(string maHD)
        {
            var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);
            if (hd == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtMaHD.Text = hd.MaHD;
            cboKhachHang.SelectedValue = hd.MaKH;
            cboNhanVien.SelectedValue = hd.MaTK_NV;
            dtpNgayLap.Value = hd.NgayHoaDon ?? DateTime.Now;

            // Load chi tiết hóa đơn
            var chiTiet = db.HoaDon_ChiTiet
                .Where(ct => ct.MaHD == maHD)
                .Select(ct => new
                {
                    ct.MaDo_Uong,
                    TenDoUong = ct.DoUong.TenDo_Uong,
                    ct.DonGia,
                    ct.SoLuong,
                    ct.ThanhTien
                })
                .ToList();

            dgvChiTietHD.DataSource = chiTiet;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == _maHD);
                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hd.MaKH = cboKhachHang.SelectedValue.ToString();
                hd.MaTK_NV = cboNhanVien.SelectedValue.ToString();
                hd.NgayHoaDon = dtpNgayLap.Value;

                db.SaveChanges();

                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}