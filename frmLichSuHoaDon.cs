using QuanLyCuaHangRuou_BUS;
using QuanLyCuaHangRuou_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// Đảm bảo namespace trùng với namespace trong file designer
namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmLichSuHoaDon : Form
    {
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private KhachHangBUS khachHangBUS = new KhachHangBUS();
        private TaiKhoan_NhanVienBUS nhanVienBUS = new TaiKhoan_NhanVienBUS();

        // Danh sách gốc chứa tất cả hóa đơn
        private List<HoaDon> allHoaDons = new List<HoaDon>();

        public frmLichSuHoaDon()
        {
            InitializeComponent();
            // Đảm bảo DataGridView không tự động tạo cột để dễ kiểm soát
            grdHoaDon.AutoGenerateColumns = false;
            grdHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdHoaDon.MultiSelect = false;
        }

        private void frmLichSuHoaDon_Load(object sender, EventArgs e)
        {
            // Tải tất cả hóa đơn khi form mở
            LoadAllHoaDons();
            // Khởi tạo các cột
            SetupDataGridViewColumns();
            // Mặc định hiển thị dữ liệu của tháng hiện tại (hoặc khoảng thời gian mặc định)
            LoadFilteredHoaDons();
        }

        private void SetupDataGridViewColumns()
        {
            if (grdHoaDon.Columns.Count == 0)
            {
                // Thêm các cột cần thiết
                grdHoaDon.Columns.Add("MaHD", "Mã Hóa Đơn");
                grdHoaDon.Columns.Add("NgayHoaDon", "Ngày HĐ");
                grdHoaDon.Columns.Add("TenKH", "Khách Hàng");
                grdHoaDon.Columns.Add("TenNV", "Nhân Viên");
                grdHoaDon.Columns.Add("TongTien", "Tổng Tiền (VNĐ)");
                grdHoaDon.Columns.Add("TrangThai", "Trạng Thái");

                // Cấu hình DataPropertyName
                grdHoaDon.Columns["MaHD"].DataPropertyName = "MaHD";
                grdHoaDon.Columns["NgayHoaDon"].DataPropertyName = "NgayHoaDon";
                grdHoaDon.Columns["TenKH"].DataPropertyName = "TenKH";
                grdHoaDon.Columns["TenNV"].DataPropertyName = "TenNV";
                grdHoaDon.Columns["TongTien"].DataPropertyName = "TongTien";
                grdHoaDon.Columns["TrangThai"].DataPropertyName = "TrangThai";

                // Cấu hình format và width
                grdHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                grdHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdHoaDon.Columns["MaHD"].Width = 80;
                grdHoaDon.Columns["NgayHoaDon"].Width = 120;
                grdHoaDon.Columns["TongTien"].Width = 120;
            }
        }

        private void LoadAllHoaDons()
        {
            try
            {
                // Lấy tất cả hóa đơn từ BUS
                allHoaDons = hoaDonBUS.GetAll();

                // Load dữ liệu Khách hàng và Nhân viên 1 lần để tránh lặp lại truy vấn
                var allKhachHangs = khachHangBUS.GetAll().ToDictionary(kh => kh.MaKH, kh => kh.TenKH);
                // Giả định TaiKhoan_NhanVienBUS có phương thức GetAll()
                var allNhanViens = nhanVienBUS.GetAll().ToDictionary(nv => nv.MaTK_NV, nv => nv.TenNV);

                // Gán tên KH và NV vào Hóa đơn (ViewModel)
                var hoaDonViewList = allHoaDons.Select(hd => new
                {
                    hd.MaHD,
                    NgayHoaDon = hd.NgayHoaDon.HasValue ? hd.NgayHoaDon.Value.ToString("dd/MM/yyyy") : "N/A",
                    TenKH = allKhachHangs.ContainsKey(hd.MaKH) ? allKhachHangs[hd.MaKH] : "N/A",
                    TenNV = allNhanViens.ContainsKey(hd.MaTK_NV) ? allNhanViens[hd.MaTK_NV] : "N/A",
                    hd.TongTien,
                    hd.TrangThai,
                    // Giữ nguyên đối tượng DateTime cho việc lọc
                    NgayHoaDonDateTime = hd.NgayHoaDon
                }).ToList();

                // Lưu danh sách View vào Tag để tái sử dụng
                grdHoaDon.Tag = hoaDonViewList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu gốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilteredHoaDons()
        {
            if (grdHoaDon.Tag == null) return;

            DateTime tuNgay = dateTimePicker1.Value.Date;
            // Lấy đến cuối ngày thứ hai để bao gồm cả ngày đó
            // (LƯU Ý: Lệnh AddSeconds(-1) là cách cũ, nên dùng AddDays(1) rồi kiểm tra < denNgay.Date)
            DateTime denNgay = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

            // Lấy danh sách view từ Tag
            var allData = grdHoaDon.Tag as IEnumerable<dynamic>;
            if (allData == null) return;

            // Ép kiểu an toàn (đã khắc phục lỗi RuntimeBinderException)
            var filteredList = allData
                .Where(hd => ((DateTime?)hd.NgayHoaDonDateTime).HasValue &&
                             ((DateTime?)hd.NgayHoaDonDateTime).Value.Date >= tuNgay.Date &&
                             ((DateTime?)hd.NgayHoaDonDateTime).Value.Date <= denNgay.Date)
                .ToList();

            // ✅ BƯỚC KHẮC PHỤC: Gán filteredList vào DataGridView
            grdHoaDon.DataSource = filteredList;

            // Cập nhật tổng tiền
            UpdateTongTien(filteredList);
        }
        private void UpdateTongTien(IEnumerable<dynamic> filteredList)
        {
            // Kiểm tra và ép kiểu an toàn: Truy cập TongTien, giả định nó là decimal? 
            // và lấy giá trị (nếu null thì là 0m)
            decimal tongTien = filteredList.Sum(hd => (decimal)((decimal?)hd.TongTien).GetValueOrDefault(0m));

            // Hiển thị tổng tiền
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }


        private void btnXem_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nhấn nút "Xem"
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi lọc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadFilteredHoaDons();
        }

        // Thêm phương thức để xem chi tiết hóa đơn (tùy chọn)
        private void grdHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maHD = grdHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

            // Mở form chi tiết hóa đơn, giả định tên lớp là frmHoaDonChiTiet
            // Form frmChiTiet = new frmHoaDonChiTiet(maHD); // Cần constructor nhận mã HD
            // frmChiTiet.ShowDialog();

            MessageBox.Show($"Xem chi tiết hóa đơn: {maHD}", "Chi Tiết Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}