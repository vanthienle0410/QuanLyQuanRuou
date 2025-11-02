namespace QuanLyCuaHangRuou_GUI
{
    partial class frmBanHangSua
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTinHD;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;

        /// <summary>
        /// Dọn dẹp tài nguyên đang sử dụng
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTinHD = new System.Windows.Forms.GroupBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grpThongTinHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(784, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SỬA THÔNG TIN HÓA ĐƠN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpThongTinHD
            // 
            this.grpThongTinHD.BackColor = System.Drawing.Color.Silver;
            this.grpThongTinHD.Controls.Add(this.lblMaHD);
            this.grpThongTinHD.Controls.Add(this.txtMaHD);
            this.grpThongTinHD.Controls.Add(this.lblKhachHang);
            this.grpThongTinHD.Controls.Add(this.cboKhachHang);
            this.grpThongTinHD.Controls.Add(this.lblNhanVien);
            this.grpThongTinHD.Controls.Add(this.cboNhanVien);
            this.grpThongTinHD.Controls.Add(this.lblNgayLap);
            this.grpThongTinHD.Controls.Add(this.dtpNgayLap);
            this.grpThongTinHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpThongTinHD.Location = new System.Drawing.Point(12, 60);
            this.grpThongTinHD.Name = "grpThongTinHD";
            this.grpThongTinHD.Size = new System.Drawing.Size(760, 100);
            this.grpThongTinHD.TabIndex = 1;
            this.grpThongTinHD.TabStop = false;
            this.grpThongTinHD.Text = "Thông tin hóa đơn";
            // 
            // lblMaHD
            // 
            this.lblMaHD.BackColor = System.Drawing.Color.White;
            this.lblMaHD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaHD.ForeColor = System.Drawing.Color.Black;
            this.lblMaHD.Location = new System.Drawing.Point(15, 30);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(100, 23);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã hóa đơn:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.BackColor = System.Drawing.Color.White;
            this.txtMaHD.Location = new System.Drawing.Point(130, 27);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(180, 30);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.BackColor = System.Drawing.Color.White;
            this.lblKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblKhachHang.ForeColor = System.Drawing.Color.Black;
            this.lblKhachHang.Location = new System.Drawing.Point(400, 30);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(100, 23);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.BackColor = System.Drawing.Color.White;
            this.cboKhachHang.Location = new System.Drawing.Point(510, 27);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(200, 31);
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.BackColor = System.Drawing.Color.White;
            this.lblNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblNhanVien.Location = new System.Drawing.Point(15, 65);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(100, 23);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(130, 65);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(180, 31);
            this.cboNhanVien.TabIndex = 5;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.BackColor = System.Drawing.Color.White;
            this.lblNgayLap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNgayLap.ForeColor = System.Drawing.Color.Black;
            this.lblNgayLap.Location = new System.Drawing.Point(400, 65);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(100, 23);
            this.lblNgayLap.TabIndex = 6;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(510, 62);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(200, 30);
            this.dtpNgayLap.TabIndex = 7;
            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietHD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietHD.ColumnHeadersHeight = 29;
            this.dgvChiTietHD.Location = new System.Drawing.Point(12, 170);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.RowHeadersWidth = 51;
            this.dgvChiTietHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietHD.Size = new System.Drawing.Size(760, 250);
            this.dgvChiTietHD.TabIndex = 2;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(200, 440);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(340, 440);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "↩️ Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(480, 440);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 40);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "❌ Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmBanHangSua
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpThongTinHD);
            this.Controls.Add(this.dgvChiTietHD);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThoat);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBanHangSua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa hóa đơn bán hàng";
            this.grpThongTinHD.ResumeLayout(false);
            this.grpThongTinHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
