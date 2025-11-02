namespace QuanLyCuaHangRuou_GUI
{
    partial class frmBanHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBoxThongTin;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.DateTimePicker dtpNgayHD;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblNgayHD;
        private System.Windows.Forms.TextBox txtTimDoUong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThanhToan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.groupBoxThongTin = new System.Windows.Forms.GroupBox();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.dtpNgayHD = new System.Windows.Forms.DateTimePicker();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNgayHD = new System.Windows.Forms.Label();
            this.txtTimDoUong = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.groupBoxThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxThongTin
            // 
            this.groupBoxThongTin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBoxThongTin.Controls.Add(this.cboKhachHang);
            this.groupBoxThongTin.Controls.Add(this.txtNhanVien);
            this.groupBoxThongTin.Controls.Add(this.dtpNgayHD);
            this.groupBoxThongTin.Controls.Add(this.lblKhachHang);
            this.groupBoxThongTin.Controls.Add(this.lblNhanVien);
            this.groupBoxThongTin.Controls.Add(this.lblNgayHD);
            this.groupBoxThongTin.ForeColor = System.Drawing.Color.White;
            this.groupBoxThongTin.Location = new System.Drawing.Point(-4, -3);
            this.groupBoxThongTin.Name = "groupBoxThongTin";
            this.groupBoxThongTin.Size = new System.Drawing.Size(1273, 121);
            this.groupBoxThongTin.TabIndex = 0;
            this.groupBoxThongTin.TabStop = false;
            this.groupBoxThongTin.Text = "Thông tin khách hàng";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.BackColor = System.Drawing.Color.White;
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.ForeColor = System.Drawing.Color.Black;
            this.cboKhachHang.Location = new System.Drawing.Point(141, 58);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(194, 24);
            this.cboKhachHang.TabIndex = 0;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BackColor = System.Drawing.Color.White;
            this.txtNhanVien.ForeColor = System.Drawing.Color.Black;
            this.txtNhanVien.Location = new System.Drawing.Point(521, 61);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(177, 22);
            this.txtNhanVien.TabIndex = 1;
            // 
            // dtpNgayHD
            // 
            this.dtpNgayHD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHD.Location = new System.Drawing.Point(915, 61);
            this.dtpNgayHD.Name = "dtpNgayHD";
            this.dtpNgayHD.Size = new System.Drawing.Size(171, 22);
            this.dtpNgayHD.TabIndex = 2;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.BackColor = System.Drawing.Color.White;
            this.lblKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKhachHang.ForeColor = System.Drawing.Color.Black;
            this.lblKhachHang.Location = new System.Drawing.Point(32, 64);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(82, 18);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.BackColor = System.Drawing.Color.White;
            this.lblNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblNhanVien.Location = new System.Drawing.Point(395, 64);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(90, 18);
            this.lblNhanVien.TabIndex = 5;
            this.lblNhanVien.Text = "NV bán hàng:";
            // 
            // lblNgayHD
            // 
            this.lblNgayHD.AutoSize = true;
            this.lblNgayHD.BackColor = System.Drawing.Color.White;
            this.lblNgayHD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNgayHD.ForeColor = System.Drawing.Color.Black;
            this.lblNgayHD.Location = new System.Drawing.Point(814, 64);
            this.lblNgayHD.Name = "lblNgayHD";
            this.lblNgayHD.Size = new System.Drawing.Size(67, 18);
            this.lblNgayHD.TabIndex = 6;
            this.lblNgayHD.Text = "Ngày HĐ:";
            // 
            // txtTimDoUong
            // 
            this.txtTimDoUong.BackColor = System.Drawing.Color.White;
            this.txtTimDoUong.ForeColor = System.Drawing.Color.Black;
            this.txtTimDoUong.Location = new System.Drawing.Point(17, 152);
            this.txtTimDoUong.Name = "txtTimDoUong";
            this.txtTimDoUong.Size = new System.Drawing.Size(216, 22);
            this.txtTimDoUong.TabIndex = 1;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BackColor = System.Drawing.Color.White;
            this.txtSoLuong.ForeColor = System.Drawing.Color.Black;
            this.txtSoLuong.Location = new System.Drawing.Point(254, 152);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(75, 22);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.Text = "1";
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.BackColor = System.Drawing.Color.Transparent;
            this.btnThemMoi.ForeColor = System.Drawing.Color.Black;
            this.btnThemMoi.Location = new System.Drawing.Point(358, 141);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(98, 45);
            this.btnThemMoi.TabIndex = 3;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = false;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(516, 136);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(97, 50);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHD.GridColor = System.Drawing.Color.White;
            this.dgvChiTietHD.Location = new System.Drawing.Point(-19, 192);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.RowHeadersWidth = 51;
            this.dgvChiTietHD.Size = new System.Drawing.Size(1288, 382);
            this.dgvChiTietHD.TabIndex = 5;
            // 
            // lblTongTien
            // 
            this.lblTongTien.BackColor = System.Drawing.Color.Crimson;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(12, 580);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(423, 40);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "TỔNG:  0 VNĐ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Red;
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(1073, 580);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(176, 72);
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1270, 664);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.dgvChiTietHD);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtTimDoUong);
            this.Controls.Add(this.groupBoxThongTin);
            this.DoubleBuffered = true;
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo phiếu bán hàng";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.groupBoxThongTin.ResumeLayout(false);
            this.groupBoxThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}