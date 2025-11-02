using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHangRuou_BUS;
using QuanLyCuaHangRuou_DAL.Models;

namespace QuanLyCuaHangRuou_GUI
{
    public partial class frmDoUong : Form
    {
        private readonly DoUongBUS doUongBUS = new DoUongBUS();

        public frmDoUong()
        {
            InitializeComponent();
        }

        private void frmDoUong_Load(object sender, EventArgs e)
        {
            CaiDatGiaoDien();
            LoadData();
            if (Session.MaQuyenHienTai == "USER")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;

                // Tùy chọn: Ẩn luôn nút để gọn gàng hơn
                // btnThem.Visible = false;
                // btnSua.Visible = false;
                // btnXoa.Visible = false;
            }
        }

        private void CaiDatGiaoDien()
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#2C0B0E");
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10);

            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#800020");
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = System.Drawing.Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            }

            dgvDoUong.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#F8F0F0");
            dgvDoUong.GridColor = System.Drawing.ColorTranslator.FromHtml("#800020");
            dgvDoUong.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvDoUong.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        }

        private void LoadData()
        {
            dgvDoUong.DataSource = doUongBUS.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                DoUong du = new DoUong()
                {
                    MaDo_Uong = txtMa.Text.Trim(),
                    TenDo_Uong = txtTen.Text.Trim(),
                    DonGia = decimal.Parse(txtGia.Text),
                    SoLuongTon = decimal.Parse(txtSoLuong.Text),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                doUongBUS.Add(du);
                LoadData();
                MessageBox.Show("✅ Thêm đồ uống thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DoUong du = new DoUong()
                {
                    MaDo_Uong = txtMa.Text.Trim(),
                    TenDo_Uong = txtTen.Text.Trim(),
                    DonGia = decimal.Parse(txtGia.Text),
                    SoLuongTon = decimal.Parse(txtSoLuong.Text),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                doUongBUS.Update(du);
                LoadData();
                MessageBox.Show("✅ Sửa thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text.Trim();
                doUongBUS.Delete(ma);
                LoadData();
                MessageBox.Show("🗑️ Xóa thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi xóa: " + ex.Message);
            }
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvDoUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMa.Text = dgvDoUong.Rows[e.RowIndex].Cells["MaDo_Uong"].Value.ToString();
                txtTen.Text = dgvDoUong.Rows[e.RowIndex].Cells["TenDo_Uong"].Value.ToString();
                txtGia.Text = dgvDoUong.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
                txtSoLuong.Text = dgvDoUong.Rows[e.RowIndex].Cells["SoLuongTon"].Value.ToString();
                txtGhiChu.Text = dgvDoUong.Rows[e.RowIndex].Cells["GhiChu"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát toàn bộ ứng dụng
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
