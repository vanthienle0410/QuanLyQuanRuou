using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangRuou_DAL.Models;


namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmKhachHang : Form
    {
        // Khởi tạo đối tượng Context
        Model1 db = new Model1();

        // Biến lưu Mã KH ban đầu khi chọn (Cần cho Sửa và Xóa)
        private string _originalMaKH = string.Empty;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        // Phương thức tải dữ liệu Khách Hàng
        public void LoadDataKhachHang()
        {
            // Tải lại Context để đảm bảo dữ liệu mới nhất
            db = new Model1();
            try
            {
                var listKhachHang = db.KhachHangs.ToList();
                grdKH.DataSource = listKhachHang;

                // Tùy chỉnh hiển thị các cột
                grdKH.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                grdKH.Columns["TenKH"].HeaderText = "Tên Khách Hàng";
                grdKH.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                grdKH.Columns["DiaChi"].HeaderText = "Địa Chỉ";

                if (grdKH.Columns.Contains("HoaDons"))
                {
                    grdKH.Columns["HoaDons"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu Khách Hàng. Kiểm tra CSDL và chuỗi kết nối: " + ex.Message, "Lỗi Tải Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa trắng các ô nhập liệu (Chuẩn bị cho thao tác Thêm mới)
        private void ClearInputFields()
        {
            txtMaKH.ReadOnly = false; // QUAN TRỌNG: Mở khóa Mã KH khi thêm mới
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            _originalMaKH = string.Empty; // Reset Mã KH gốc
            grdKH.ClearSelection(); // Xóa chọn trên lưới
        }

        // Phương thức TỰ ĐỘNG CHỌN HÀNG vừa thao tác (Thêm/Sửa)
        private void SelectRowByMaKH(string maKhachHang)
        {
            int rowIndex = -1;
            for (int i = 0; i < grdKH.Rows.Count; i++)
            {
                if (grdKH.Rows[i].Cells["MaKH"].Value != null &&
                    grdKH.Rows[i].Cells["MaKH"].Value.ToString() == maKhachHang)
                {
                    rowIndex = i;
                    break;
                }
            }

            if (rowIndex >= 0)
            {
                grdKH.ClearSelection();
                grdKH.Rows[rowIndex].Selected = true;
                grdKH.FirstDisplayedScrollingRowIndex = rowIndex;

                // Cập nhật các ô nhập liệu và Mã KH gốc
                DataGridViewRow row = grdKH.Rows[rowIndex];
                _originalMaKH = row.Cells["MaKH"]?.Value?.ToString() ?? string.Empty;
                txtMaKH.Text = _originalMaKH;
                txtTenKH.Text = row.Cells["TenKH"]?.Value?.ToString() ?? string.Empty;
                txtSDT.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? string.Empty;

                // MỞ KHÓA MÃ KH: Cho phép sửa Mã KH
                txtMaKH.ReadOnly = false;
            }
            else
            {
                ClearInputFields();
            }
        }


        // Sự kiện Form Load
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataKhachHang();
            ClearInputFields();

            // ⛔ KIỂM TRA PHÂN QUYỀN: Nếu là USER, chỉ cho Thêm/Xem, không cho SỬA/XÓA.
            if (Session.MaQuyenHienTai == "USER")
            {
                // btnThem (Thêm mới khách hàng) có thể giữ nguyên (tùy nghiệp vụ bán hàng)
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        // --- Xử lý sự kiện DataGridView CellClick ---

        // Khi click vào 1 hàng bất kỳ, hiển thị thông tin lên các ô TextBox
        private void grdKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ mục hàng hợp lệ (không phải hàng tiêu đề)
            if (e.RowIndex < 0 || grdKH.Rows[e.RowIndex].IsNewRow)
            {
                ClearInputFields();
                return;
            }

            DataGridViewRow row = grdKH.Rows[e.RowIndex];

            // LƯU Mã KH gốc và hiển thị
            _originalMaKH = row.Cells["MaKH"]?.Value?.ToString() ?? string.Empty;
            txtMaKH.Text = _originalMaKH;

            txtTenKH.Text = row.Cells["TenKH"]?.Value?.ToString() ?? string.Empty;
            txtSDT.Text = row.Cells["SoDienThoai"]?.Value?.ToString() ?? string.Empty;
            txtDiaChi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? string.Empty;

            // QUAN TRỌNG: MỞ KHÓA Mã KH để cho phép sửa (cả mã)
            txtMaKH.ReadOnly = false;
        }

        // --- BỎ THÔNG BÁO TRÙNG MÃ KHI TEXT CHANGED ---
        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            // Bỏ toàn bộ logic kiểm tra trùng lặp và MessageBox.Show
            // Việc kiểm tra trùng lặp được thực hiện đầy đủ khi nhấn nút THÊM
        }
        // --- END BỎ THÔNG BÁO ---

        // Nút Thêm (Add)
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Nếu đang ở chế độ xem/sửa, chuyển sang chế độ thêm mới
            if (!string.IsNullOrEmpty(_originalMaKH) && txtMaKH.Text == _originalMaKH)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa trắng để thêm khách hàng mới không?", "Chuyển chế độ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    ClearInputFields();
                    return;
                }
                return;
            }

            // Nếu đang ở chế độ thêm mới, thực hiện thêm vào CSDL
            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Khách Hàng và Tên Khách Hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newMaKH = txtMaKH.Text.Trim();

            try
            {
                // Kiểm tra trùng lặp Mã KH
                if (db.KhachHangs.Any(kh => kh.MaKH == newMaKH))
                {
                    MessageBox.Show("Mã Khách Hàng đã tồn tại. Vui lòng nhập mã khác.", "Lỗi Trùng Mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                KhachHang khachHangMoi = new KhachHang
                {
                    MaKH = newMaKH,
                    TenKH = txtTenKH.Text,
                    SoDienThoai = txtSDT.Text,
                    DiaChi = txtDiaChi.Text
                };

                db.KhachHangs.Add(khachHangMoi);
                db.SaveChanges();

                LoadDataKhachHang();
                SelectRowByMaKH(newMaKH);

                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Sửa (Edit) - CẬP NHẬT ĐỂ CHO PHÉP ĐỔI MÃ KH
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_originalMaKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa trên bảng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Mã Khách Hàng và Tên Khách Hàng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKHCanSua = _originalMaKH;
            string maKH_Moi = txtMaKH.Text.Trim();

            try
            {
                // 1. Nếu Mã KH bị thay đổi, kiểm tra trùng lặp mã mới
                if (maKH_Moi != maKHCanSua && db.KhachHangs.Any(kh => kh.MaKH == maKH_Moi))
                {
                    MessageBox.Show("Mã Khách Hàng mới đã tồn tại. Vui lòng nhập mã khác.", "Lỗi Trùng Mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. TẠO đối tượng Khách Hàng mới
                KhachHang khachHangMoi = new KhachHang
                {
                    MaKH = maKH_Moi,
                    TenKH = txtTenKH.Text,
                    SoDienThoai = txtSDT.Text,
                    DiaChi = txtDiaChi.Text
                };

                // 3. Xử lý trong Context:
                if (maKH_Moi == maKHCanSua)
                {
                    // Trường hợp Mã không đổi: Chỉ update các trường còn lại
                    var khachHangCanSua = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == maKHCanSua);
                    if (khachHangCanSua != null)
                    {
                        khachHangCanSua.TenKH = khachHangMoi.TenKH;
                        khachHangCanSua.SoDienThoai = khachHangMoi.SoDienThoai;
                        khachHangCanSua.DiaChi = khachHangMoi.DiaChi;
                    }
                    db.SaveChanges();
                }
                else
                {
                    // Trường hợp Mã có đổi (Khóa chính): PHƯƠNG PHÁP XÓA CŨ - THÊM MỚI
                    // LƯU Ý: Cách này chỉ hoạt động nếu không có Khóa ngoại (FK) trỏ đến MaKH của bản ghi cũ. 
                    // Nếu có FK, bạn sẽ cần phải cập nhật MaKH trong các bảng liên quan (HoaDon) TRƯỚC khi xóa bản ghi cũ, 
                    // hoặc phải xóa bản ghi cũ và thêm mới (cách này sẽ làm mất FK).

                    var khachHangCanXoa = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == maKHCanSua);

                    if (khachHangCanXoa != null)
                    {
                        // Xóa bản ghi cũ
                        db.KhachHangs.Remove(khachHangCanXoa);

                        // Thêm bản ghi mới
                        db.KhachHangs.Add(khachHangMoi);

                        db.SaveChanges();
                    }
                }


                LoadDataKhachHang();
                SelectRowByMaKH(maKH_Moi); // Tự động chọn lại hàng vừa sửa

                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa khách hàng. Kiểm tra ràng buộc khóa ngoại (ví dụ: khách hàng này có hóa đơn): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Nút Xóa (Delete)
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_originalMaKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trên bảng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKHCanXoa = _originalMaKH;
            string tenKH = txtTenKH.Text;

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng: {tenKH} ({maKHCanXoa})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var khachHangCanXoa = db.KhachHangs.FirstOrDefault(kh => kh.MaKH == maKHCanXoa);

                    if (khachHangCanXoa != null)
                    {
                        db.KhachHangs.Remove(khachHangCanXoa);
                        db.SaveChanges();
                        LoadDataKhachHang();
                        ClearInputFields(); // Xóa thành công thì xóa trắng ô nhập liệu
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Lỗi phổ biến nhất là do Khóa ngoại (khách hàng này có Hóa đơn)
                    MessageBox.Show("Lỗi khi xóa Khách Hàng: " + ex.Message + "\nHãy kiểm tra ràng buộc khóa ngoại (ví dụ: khách hàng này có hóa đơn).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Xử lý Nút Thoát ---
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class KhachHangDTO 
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
        }

        private void grdKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}