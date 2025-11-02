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
    public partial class frmThongTinNhanVien : Form
    {
        private Model1 db = new Model1();

        public frmThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadQuyen();
        }

        private void LoadData()
        {
            dgvNhanVien.DataSource = db.TaiKhoan_NhanVien
                .Select(nv => new
                {
                    nv.MaTK_NV,
                    nv.TenNV,
                    nv.TenDangNhap,
                    nv.MatKhau,
                    nv.SoDienThoai,
                    nv.DiaChi,
                    nv.MaQuyen
                })
                .ToList();
        }

        private void LoadQuyen()
        {
            cboMaQuyen.DataSource = db.Quyens.ToList();
            cboMaQuyen.DisplayMember = "TenQuyen";
            cboMaQuyen.ValueMember = "MaQuyen";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MaTK_NV"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
                txtTenDangNhap.Text = dgvNhanVien.Rows[e.RowIndex].Cells["TenDangNhap"].Value.ToString();
                txtMatKhau.Text = dgvNhanVien.Rows[e.RowIndex].Cells["MatKhau"].Value.ToString();
                txtSoDT.Text = dgvNhanVien.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                cboMaQuyen.SelectedValue = dgvNhanVien.Rows[e.RowIndex].Cells["MaQuyen"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = new TaiKhoan_NhanVien
                {
                    MaTK_NV = txtMaNV.Text,
                    TenNV = txtTenNV.Text,
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                    SoDienThoai = txtSoDT.Text,
                    DiaChi = txtDiaChi.Text,
                    MaQuyen = cboMaQuyen.SelectedValue.ToString()
                };

                db.TaiKhoan_NhanVien.Add(nv);
                db.SaveChanges();
                LoadData();
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = db.TaiKhoan_NhanVien.Find(txtMaNV.Text);
                if (nv != null)
                {
                    nv.TenNV = txtTenNV.Text;
                    nv.TenDangNhap = txtTenDangNhap.Text;
                    nv.MatKhau = txtMatKhau.Text;
                    nv.SoDienThoai = txtSoDT.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.MaQuyen = cboMaQuyen.SelectedValue.ToString();
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Cập nhật thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var nv = db.TaiKhoan_NhanVien.Find(txtMaNV.Text);
                if (nv != null)
                {
                    db.TaiKhoan_NhanVien.Remove(nv);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            txtSoDT.Clear();
            txtDiaChi.Clear();
            cboMaQuyen.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}