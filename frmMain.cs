using System;

using System.Collections.Generic;

using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;

using QuanLyCuaHangRuou;

using QuanLyCuaHangRuou_GUI;



namespace QuanLyCuaHangRuou_GUI

{

    public partial class frmMain : Form

    {

        public frmMain()

        {

            InitializeComponent();

        }



        private void frmMain_Load(object sender, EventArgs e)

        {

            CaiDatGiaoDien();

        }



        private void CaiDatGiaoDien()

        {

            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#2C0B0E"); // đỏ rượu vang

            this.ForeColor = System.Drawing.Color.White;

            this.Font = new System.Drawing.Font("Segoe UI", 10);



            menuStrip1.BackColor = System.Drawing.ColorTranslator.FromHtml("#800020");

            menuStrip1.ForeColor = System.Drawing.Color.White;

        }



        // ---- MENU HỆ THỐNG ----

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)

        {

            DialogResult result = MessageBox.Show(

                "Bạn có chắc chắn muốn đăng xuất không?",

                "Xác nhận",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Question);



            if (result == DialogResult.Yes)

            {

                this.Hide();

                frmDangNhap dn = new frmDangNhap();

                dn.ShowDialog();

                this.Close();

            }

        }



        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)

        {

            DialogResult result = MessageBox.Show(

                "Bạn có chắc chắn muốn thoát chương trình không?",

                "Thoát",

                MessageBoxButtons.YesNo,

                MessageBoxIcon.Warning);



            if (result == DialogResult.Yes)

            {

                Application.Exit();

            }

        }



        // ---- MENU QUẢN LÝ ----

        private void đồUốngToolStripMenuItem_Click(object sender, EventArgs e)

        {

            frmDoUong f = new frmDoUong();

            f.ShowDialog();

        }



        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)

        {

            frmKhachHang f = new frmKhachHang();

            f.ShowDialog();

        }







        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)

        {

            frmHoaDon f = new frmHoaDon();

            f.ShowDialog();

        }



        // ---- MENU THỐNG KÊ ----

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)

        {

            if (Session.MaQuyenHienTai == "ADMIN")
            {
                // Do Form thống kê nằm trong namespace QuanLyCuaHangRuou, cần đảm bảo nó được import hoặc gọi đúng.
                // Dựa trên code của bạn, tên lớp là frmThongKeDoanhThu và nó nằm ngoài namespace GUI.
                // Giả sử bạn đã sửa namespace của frmThongKeDoanhThu thành QuanLyCuaHangRuou_GUI hoặc sử dụng Activator.

                // Cách an toàn nhất là dùng tên lớp đầy đủ:
                Form frmThongKe = new Form();
                try
                {
                    frmThongKe = (Form)Activator.CreateInstance(Type.GetType("QuanLyCuaHangRuou.frmThongKeDoanhThu"));
                    frmThongKe.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tìm thấy form thống kê: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng Thống Kê!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }



        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)

        {

            frmBanHang f = new frmBanHang();

            f.Show();

        }



        private void thôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)

        {

            if (Session.MaQuyenHienTai == "ADMIN")
            {
                frmThongTinNhanVien f = new frmThongTinNhanVien();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Lỗi phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void kyGuiRuouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở Form quản lý Ký Gửi Rượu
            // FormKyGuiRuou là Form đã được thiết kế ở các bước trước
            frmKyGuiRuou f = new frmKyGuiRuou();
            f.ShowDialog();
        }

    }
}



 