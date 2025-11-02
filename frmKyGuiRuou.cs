using System;
using System.Windows.Forms;
using QuanLyCuaHangRuou_BUS; // Tham chiếu đến tầng nghiệp vụ
using QuanLyCuaHangRuou_DAL.Models; // Tham chiếu đến Model (Entity KyGui_Ruou)
using System.Linq;
using System.Data;

namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmKyGuiRuou : Form
    {
        // 🔑 BƯỚC 1: KHỞI TẠO OBJECT (INSTANCE) CỦA LỚP BUS
        // Lỗi của bạn xảy ra nếu dòng này bị thiếu hoặc nếu bạn cố gọi KyGui_BUS.GetAllDangKyGui()
        private KyGui_BUS kyGuiBUS = new KyGui_BUS();
        private string selectedMaKyGui = null;

        public frmKyGuiRuou()
        {
            InitializeComponent();
        }

        private void FormKyGuiRuou_Load(object sender, EventArgs e)
        {
            LoadDanhSachKyGui();
        }

        // Phương thức hiển thị danh sách rượu đang ký gửi
        private void LoadDanhSachKyGui()
        {
            try
            {
                // 🔑 BƯỚC 2: GỌI PHƯƠNG THỨC THÔNG QUA OBJECT 'kyGuiBUS'
                var danhSach = kyGuiBUS.GetAllDangKyGui()
                                       .Select(k => new
                                       {
                                           k.MaKyGui,
                                           k.MaKH,
                                           k.TenRuou,
                                           DungTich = k.DungTichConLai + " " + k.DonViTinh,
                                           k.NgayKyGui,
                                           k.HanKyGui,
                                           k.ViTriLuuTru
                                       }).ToList();

                dgvKyGui.DataSource = danhSach;

                // Định dạng hiển thị DGV
                dgvKyGui.Columns["MaKyGui"].HeaderText = "Mã Ký Gửi";
                dgvKyGui.Columns["MaKH"].HeaderText = "Mã KH";
                dgvKyGui.Columns["TenRuou"].HeaderText = "Tên Rượu";
                dgvKyGui.Columns["DungTich"].HeaderText = "Dung Tích Còn Lại";
                dgvKyGui.Columns["NgayKyGui"].HeaderText = "Ngày Ký Gửi";
                dgvKyGui.Columns["HanKyGui"].HeaderText = "Hạn Lấy Lại";
                dgvKyGui.Columns["ViTriLuuTru"].HeaderText = "Vị Trí";

                selectedMaKyGui = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ký gửi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện Ký Gửi Rượu
        private void btnKyGui_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string tenRuou = txtTenRuou.Text.Trim();
            string viTri = txtViTri.Text.Trim();
            string donViTinh = cboDonViTinh.SelectedItem?.ToString() ?? "";

            if (!decimal.TryParse(txtDungTich.Text, out decimal dungTichConLai) || dungTichConLai <= 0)
            {
                MessageBox.Show("Dung tích phải là số dương!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(tenRuou))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Khách Hàng và Tên Rượu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (kyGuiBUS.XuLyKyGuiMoi(maKH, tenRuou, dungTichConLai, donViTinh, viTri))
            {
                MessageBox.Show("Ký gửi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachKyGui();
            }
            else
            {
                MessageBox.Show("Ký gửi thất bại. Vui lòng kiểm tra lại Mã KH và kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện Lấy Lại Rượu
        private void btnLayLai_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaKyGui))
            {
                MessageBox.Show("Vui lòng chọn một dòng rượu cần lấy lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Xác nhận khách hàng đã lấy lại rượu có Mã Ký Gửi: {selectedMaKyGui}?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (kyGuiBUS.XuLyKhachHangLayLaiRuou(selectedMaKyGui))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKyGui();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Vui lòng kiểm tra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Lưu Mã Ký Gửi khi người dùng click vào DataGridView
        private void dgvKyGui_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedMaKyGui = dgvKyGui.Rows[e.RowIndex].Cells["MaKyGui"].Value.ToString();
            }
        }
    }
}