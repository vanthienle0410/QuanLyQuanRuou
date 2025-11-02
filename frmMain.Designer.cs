namespace QuanLyCuaHangRuou_GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đồUốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnToolStripMenuItem;

        // BỔ SUNG: Khai báo Menu Ký Gửi Rượu
        private System.Windows.Forms.ToolStripMenuItem kyGuiRuouToolStripMenuItem;

        private System.Windows.Forms.Label lblTieuDe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đồUốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kyGuiRuouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.kyGuiRuouToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1287, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đăngXuấtToolStripMenuItem.Image")));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem.Image")));
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đồUốngToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.hóaĐơnToolStripMenuItem,
            this.bánHàngToolStripMenuItem,
            this.thôngTinNhânViênToolStripMenuItem});
            this.quảnLýToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.quảnLýToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quảnLýToolStripMenuItem.Image")));
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // đồUốngToolStripMenuItem
            // 
            this.đồUốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đồUốngToolStripMenuItem.Image")));
            this.đồUốngToolStripMenuItem.Name = "đồUốngToolStripMenuItem";
            this.đồUốngToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.đồUốngToolStripMenuItem.Text = "Đồ uống";
            this.đồUốngToolStripMenuItem.Click += new System.EventHandler(this.đồUốngToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kháchHàngToolStripMenuItem.Image")));
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // hóaĐơnToolStripMenuItem
            // 
            this.hóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hóaĐơnToolStripMenuItem.Image")));
            this.hóaĐơnToolStripMenuItem.Name = "hóaĐơnToolStripMenuItem";
            this.hóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.hóaĐơnToolStripMenuItem.Text = "Hóa đơn";
            this.hóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnToolStripMenuItem_Click);
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bánHàngToolStripMenuItem.Image")));
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.bánHàngToolStripMenuItem.Text = "Bán Hàng";
            this.bánHàngToolStripMenuItem.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // thôngTinNhânViênToolStripMenuItem
            // 
            this.thôngTinNhânViênToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thôngTinNhânViênToolStripMenuItem.Image")));
            this.thôngTinNhânViênToolStripMenuItem.Name = "thôngTinNhânViênToolStripMenuItem";
            this.thôngTinNhânViênToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.thôngTinNhânViênToolStripMenuItem.Text = "Thông Tin Nhân Viên";
            this.thôngTinNhânViênToolStripMenuItem.Click += new System.EventHandler(this.thôngTinNhânViênToolStripMenuItem_Click);
            // 
            // kyGuiRuouToolStripMenuItem
            // 
            this.kyGuiRuouToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.kyGuiRuouToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.kyGuiRuouToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kyGuiRuouToolStripMenuItem.Image")));
            this.kyGuiRuouToolStripMenuItem.Name = "kyGuiRuouToolStripMenuItem";
            this.kyGuiRuouToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.kyGuiRuouToolStripMenuItem.Text = "Ký gửi Rượu";
            this.kyGuiRuouToolStripMenuItem.Click += new System.EventHandler(this.kyGuiRuouToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuToolStripMenuItem});
            this.thốngKêToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.thốngKêToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thốngKêToolStripMenuItem.Image")));
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doanhThuToolStripMenuItem.Image")));
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.Color.Black;
            this.lblTieuDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Location = new System.Drawing.Point(265, 41);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(753, 57);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG RƯỢU";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1287, 642);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "Trang chính - Quản lý cửa hàng rượu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
    }
}