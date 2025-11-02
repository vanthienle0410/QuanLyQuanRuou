using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangRuou_DAL.Models;
using QuanLyCuaHangRuou_BUS; // Cần dùng HoaDonBUS

namespace QuanLyCuaHangRuou
{
    public partial class frmThongKeDoanhThu : Form
    {
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private HoaDon_ChiTietBUS chiTietBUS = new HoaDon_ChiTietBUS();
        private Model1 context = new Model1(); // Dùng context trực tiếp cho truy vấn thống kê phức tạp hơn

        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            // Đặt giá trị mặc định cho DatePicker (ví dụ: 7 ngày trước đến hôm nay)
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
            dateTimePicker2.Value = DateTime.Now;
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            // Thiết lập DataGridView
            SetupDataGridView();

            // Tải dữ liệu mặc định khi form load
            LoadData();
        }

        /// <summary>
        /// Thiết lập cấu hình hiển thị cho DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            // Xóa các cột cũ nếu có
            grdDoanhThu.Columns.Clear();
            grdDoanhThu.AutoGenerateColumns = false;

            // Định nghĩa các cột
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã HĐ", DataPropertyName = "MaHD", Width = 80 });
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày HĐ", DataPropertyName = "NgayHoaDon", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Khách Hàng", DataPropertyName = "TenKH", Width = 150 });
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nhân Viên", DataPropertyName = "TenNV", Width = 150 });
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tổng Tiền", DataPropertyName = "TongTien", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } }); // Định dạng tiền tệ
            grdDoanhThu.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng Thái", DataPropertyName = "TrangThai", Width = 100 });
        }


        /// <summary>
        /// Tải dữ liệu doanh thu và hiển thị lên DataGridView
        /// </summary>
        private void LoadData()
        {
            try
            {
                // Lấy ngày bắt đầu và ngày kết thúc
                // Lấy ngày bắt đầu: chỉ lấy phần ngày (00:00:00)
                DateTime tuNgay = dateTimePicker1.Value.Date;
                // Lấy ngày kết thúc: lấy hết ngày đó (23:59:59)
                DateTime denNgay = dateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1);

                // Kiểm tra logic thời gian
                if (tuNgay > denNgay)
                {
                    MessageBox.Show("❌ Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Truy vấn dữ liệu: Lấy Hóa đơn trong khoảng thời gian và join với Khách hàng, Tài khoản/Nhân viên
                var query = (from hd in context.HoaDons
                             join kh in context.KhachHangs on hd.MaKH equals kh.MaKH
                             join nv in context.TaiKhoan_NhanVien on hd.MaTK_NV equals nv.MaTK_NV
                             where hd.NgayHoaDon >= tuNgay && hd.NgayHoaDon <= denNgay
                             select new
                             {
                                 hd.MaHD,
                                 hd.NgayHoaDon,
                                 TenKH = kh.TenKH, // Lấy tên Khách hàng
                                 TenNV = nv.TenNV, // Lấy tên Nhân viên
                                 hd.TongTien,
                                 hd.TrangThai
                             }).ToList(); // Thực hiện truy vấn và lấy kết quả

                // Tính tổng doanh thu
                decimal tongDoanhThu = query.Sum(x => x.TongTien ?? 0);

                // Hiển thị lên DataGridView
                grdDoanhThu.DataSource = query;

                // Hiển thị tổng tiền
                lblTongTien.Text = $"{tongDoanhThu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}