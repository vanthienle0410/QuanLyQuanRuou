using QuanLyCuaHangRuou_BUS;
using QuanLyCuaHangRuou_DAL.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmHoaDon : Form
    {
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        public frmHoaDon()
        {
            InitializeComponent();
            this.Load += FrmHoaDon_Load;

            // Thiết lập DataGridView
            dgvHoaDon.AutoGenerateColumns = false;
        }

        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();

            // ⛔ KIỂM TRA PHÂN QUYỀN: Nếu là USER, không cho SỬA/XÓA hóa đơn.
            if (Session.MaQuyenHienTai == "USER")
            {
                btnSua.Enabled = false; // Nút Sửa
                btnXoa.Enabled = false; // Nút Xóa
            }
        }

        private void LoadDanhSachHoaDon()
        {
            try
            {
                // Lấy danh sách hóa đơn
                List<HoaDon> listHoaDon = hoaDonBUS.GetAll();

                // Tạo đối tượng tạm thời chứa thông tin cần hiển thị
                var dataDisplay = listHoaDon.Select(hd => new
                {
                    MaHD = hd.MaHD,
                    NgayHoaDon = hd.NgayHoaDon.HasValue ? hd.NgayHoaDon.Value.ToString("dd/MM/yyyy HH:mm:ss") : "N/A",
                    MaKH = hd.MaKH,
                    MaTK_NV = hd.MaTK_NV,
                    TongTien = hd.TongTien.HasValue ? hd.TongTien.Value.ToString("N0") : "0", // Định dạng tiền tệ
                    TrangThai = hd.TrangThai
                }).ToList();

                dgvHoaDon.DataSource = dataDisplay;

                // Thêm các cột cho DataGridView nếu chưa có (chỉ cần chạy lần đầu)
                if (dgvHoaDon.Columns.Count == 0)
                {
                    dgvHoaDon.Columns.Add("MaHD", "Mã HĐ");
                    dgvHoaDon.Columns.Add("NgayHoaDon", "Ngày Hóa Đơn");
                    dgvHoaDon.Columns.Add("MaKH", "Mã KH");
                    dgvHoaDon.Columns.Add("MaTK_NV", "Mã NV");
                    dgvHoaDon.Columns.Add("TongTien", "Tổng Tiền (VNĐ)");
                    dgvHoaDon.Columns.Add("TrangThai", "Trạng Thái");

                    // Gán DataPropertyName để DataGridView biết lấy dữ liệu từ trường nào
                    dgvHoaDon.Columns["MaHD"].DataPropertyName = "MaHD";
                    dgvHoaDon.Columns["NgayHoaDon"].DataPropertyName = "NgayHoaDon";
                    dgvHoaDon.Columns["MaKH"].DataPropertyName = "MaKH";
                    dgvHoaDon.Columns["MaTK_NV"].DataPropertyName = "MaTK_NV";
                    dgvHoaDon.Columns["TongTien"].DataPropertyName = "TongTien";
                    dgvHoaDon.Columns["TrangThai"].DataPropertyName = "TrangThai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Xử lý sự kiện các nút ---
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Mở form bán hàng (frmBanHang) để tạo hóa đơn mới
            Form frmBanHangMoi = new Form();
            try
            {
                frmBanHangMoi = (Form)Activator.CreateInstance(Type.GetType("QuanLyCuaHangRuou_GUI.frmBanHang"));
                frmBanHangMoi.ShowDialog();
                LoadDanhSachHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy form frmBanHang.cs!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDonCanSua = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();

            // Giả định bạn có frmBanHangSua.cs
            Form frmSuaHoaDon = new Form();
            try
            {
                // Thay đổi tên lớp nếu bạn dùng frmBanHangSua.cs
                frmSuaHoaDon = (Form)Activator.CreateInstance(Type.GetType("QuanLyCuaHangRuou_GUI.frmBanHangSua"), maHoaDonCanSua);
                frmSuaHoaDon.ShowDialog();
                LoadDanhSachHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show($"Không tìm thấy form frmBanHangSua.cs hoặc lỗi khi khởi tạo với mã '{maHoaDonCanSua}'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maHoaDonCanXoa = dgvHoaDon.SelectedRows[0].Cells["MaHD"].Value.ToString();

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn '{maHoaDonCanXoa}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    hoaDonBUS.Delete(maHoaDonCanXoa);
                    MessageBox.Show($"Đã xóa thành công hóa đơn '{maHoaDonCanXoa}'.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnLichSuHoaDon_Click(object sender, EventArgs e)
        {
            // Mở form lịch sử hóa đơn (frmLichSuHoaDon)
            Form frmLichSu = new Form();
            try
            {
                frmLichSu = (Form)Activator.CreateInstance(Type.GetType("QuanLyCuaHangRuou_GUI.frmLichSuHoaDon"));
                frmLichSu.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy form frmLichSuHoaDon.cs!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PHƯƠNG THỨC XỬ LÝ SỰ KIỆN MỚI
        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            // Mở form Thống kê Doanh thu (frmThongKeDoanhThu)
            Form frmThongKe = new Form();
            try
            {
                frmThongKe = (Form)Activator.CreateInstance(Type.GetType("QuanLyCuaHangRuou_GUI.frmThongKeDoanhThu"));
                frmThongKe.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Không tìm thấy form frmThongKeDoanhThu.cs!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHoaDon.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Lấy mã hóa đơn từ dòng được chọn trong DataGridView
                string maHD = dgvHoaDon.CurrentRow.Cells["MaHD"].Value.ToString();

                // ✅ Mở form report và truyền mã hóa đơn qua constructor
                frmReportHoaDon frm = new frmReportHoaDon(maHD);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở báo cáo: " + ex.Message);
            }
        }
    }
    }
