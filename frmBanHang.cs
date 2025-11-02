using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangRuou_BUS;
using QuanLyCuaHangRuou_DAL.Models;

namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmBanHang : Form
    {
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();
        // Đã loại bỏ: private HoaDon_ChiTietBUS cthdBUS = new HoaDon_ChiTietBUS();
        private DoUongBUS doUongBUS = new DoUongBUS();

        private decimal tongTien = 0;

        public frmBanHang()
        {
            InitializeComponent();
        }

        private void frmBanHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            txtNhanVien.Text = "NV01"; // Mã NV mặc định
            dtpNgayHD.Value = DateTime.Now;

            dgvChiTietHD.AutoGenerateColumns = false;
            dgvChiTietHD.Columns.Clear();

            dgvChiTietHD.Columns.Add("MaDoUong", "Mã đồ uống");
            dgvChiTietHD.Columns["MaDoUong"].DataPropertyName = "MaDo_Uong";

            dgvChiTietHD.Columns.Add("TenDoUong", "Tên đồ uống");
            dgvChiTietHD.Columns["TenDoUong"].DataPropertyName = "TenDoUong";

            dgvChiTietHD.Columns.Add("SoLuong", "Số lượng");
            dgvChiTietHD.Columns["SoLuong"].DataPropertyName = "SoLuong";

            dgvChiTietHD.Columns.Add("DonGia", "Đơn giá");
            dgvChiTietHD.Columns["DonGia"].DataPropertyName = "DonGia";

            dgvChiTietHD.Columns.Add("ThanhTien", "Thành tiền");
            dgvChiTietHD.Columns["ThanhTien"].DataPropertyName = "ThanhTien";

            dgvChiTietHD.DataSource = new List<ChiTietView>();
        }

        private void LoadKhachHang()
        {
            using (var ctx = new Model1())
            {
                var dsKH = ctx.KhachHangs
                              .Select(x => new KhachHangDTO { MaKH = x.MaKH, TenKH = x.TenKH })
                              .ToList();

                cboKhachHang.DisplayMember = "TenKH";
                cboKhachHang.ValueMember = "MaKH";

                cboKhachHang.DataSource = dsKH;

                if (dsKH.Count == 0)
                    cboKhachHang.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 🔸 Tìm đồ uống theo tên hoặc mã
        /// </summary>
        private DoUong TimDoUong(string keyword)
        {
            keyword = keyword.ToLower();
            var all = doUongBUS.GetAll();
            return all.FirstOrDefault(x =>
                x.MaDo_Uong.ToLower().Contains(keyword) ||
                x.TenDo_Uong.ToLower().Contains(keyword));
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string keyword = txtTimDoUong.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc mã đồ uống.");
                return;
            }
            var douong = TimDoUong(keyword);
            if (douong == null)
            {
                MessageBox.Show("Không tìm thấy đồ uống.");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            decimal donGia = douong.DonGia;
            decimal thanhTien = donGia * soLuong;

            var list = (List<ChiTietView>)dgvChiTietHD.DataSource;

            var existing = list.FirstOrDefault(x => x.MaDo_Uong == douong.MaDo_Uong);

            // LOGIC SỬA: Gán số lượng mới thay vì cộng dồn
            if (existing != null)
            {
                existing.SoLuong = soLuong;
                existing.ThanhTien = existing.SoLuong * existing.DonGia;
            }
            else
            {
                list.Add(new ChiTietView
                {
                    MaDo_Uong = douong.MaDo_Uong,
                    TenDoUong = douong.TenDo_Uong,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = thanhTien
                });
            }

            dgvChiTietHD.DataSource = null;
            dgvChiTietHD.DataSource = list;

            tongTien = list.Sum(x => x.ThanhTien);
            lblTongTien.Text = "TỔNG:  " + tongTien.ToString("N0") + " VNĐ";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.SelectedRows.Count == 0) return;
            if (dgvChiTietHD.SelectedRows[0].Cells["MaDoUong"].Value == null) return;

            var ma = dgvChiTietHD.SelectedRows[0].Cells["MaDoUong"].Value.ToString();
            var list = (List<ChiTietView>)dgvChiTietHD.DataSource;
            var item = list.FirstOrDefault(x => x.MaDo_Uong == ma);
            if (item != null)
            {
                list.Remove(item);
                dgvChiTietHD.DataSource = null;
                dgvChiTietHD.DataSource = list;

                tongTien = list.Sum(x => x.ThanhTien);
                lblTongTien.Text = "TỔNG:  " + tongTien.ToString("N0") + " VNĐ";
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn khách hàng.");
                return;
            }

            var list = (List<ChiTietView>)dgvChiTietHD.DataSource;
            if (list == null || list.Count == 0)
            {
                MessageBox.Show("Chưa có mặt hàng nào trong hóa đơn.");
                return;
            }

            try
            {
                string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

                // 1. Tạo đối tượng HoaDon
                HoaDon hd = new HoaDon
                {
                    MaHD = maHD,
                    MaKH = cboKhachHang.SelectedValue.ToString(),
                    MaTK_NV = txtNhanVien.Text,
                    NgayHoaDon = dtpNgayHD.Value,
                    TongTien = tongTien,
                    TrangThai = "Đã thanh toán" // <<< SỬA: Khắc phục lỗi độ dài 1 ký tự
                };

                // 2. Tạo danh sách Chi Tiết Hóa Đơn
                List<HoaDon_ChiTiet> chiTietList = list.Select(ctView => new HoaDon_ChiTiet
                {
                    MaDo_Uong = ctView.MaDo_Uong,
                    SoLuong = ctView.SoLuong,
                    DonGia = ctView.DonGia
                }).ToList();

                // 3. Gọi hàm ThanhToan trong BUS (đảm bảo transaction và bắt lỗi)
                hoaDonBUS.ThanhToan(hd, chiTietList);

                MessageBox.Show("Thanh toán thành công!");

                // 4. Reset giao diện
                dgvChiTietHD.DataSource = new List<ChiTietView>();
                tongTien = 0;
                lblTongTien.Text = "TỔNG:  0 VNĐ";
                txtTimDoUong.Clear();
                txtSoLuong.Text = "1";
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi chi tiết từ BUS
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi");
            }
        }

        private class ChiTietView
        {
            public string MaDo_Uong { get; set; }
            public string TenDoUong { get; set; }
            public int SoLuong { get; set; }
            public decimal DonGia { get; set; }
            public decimal ThanhTien { get; set; }
        }


        private class KhachHangDTO
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
        }
    }
}
