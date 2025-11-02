namespace QuanLyCuaHangRuou_GUI
{
    partial class frmKyGuiRuou
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKyGui = new System.Windows.Forms.Button();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboDonViTinh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDungTich = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenRuou = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvKyGui = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLayLai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyGui)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(359, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ KÝ GỬI RƯỢU";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Controls.Add(this.btnKyGui);
            this.groupBox1.Controls.Add(this.txtViTri);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboDonViTinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDungTich);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenRuou);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(16, 60);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1035, 156);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Ký gửi Mới";
            // 
            // btnKyGui
            // 
            this.btnKyGui.BackColor = System.Drawing.Color.LimeGreen;
            this.btnKyGui.Location = new System.Drawing.Point(779, 101);
            this.btnKyGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKyGui.Name = "btnKyGui";
            this.btnKyGui.Size = new System.Drawing.Size(167, 47);
            this.btnKyGui.TabIndex = 10;
            this.btnKyGui.Text = "Ký Gửi Rượu";
            this.btnKyGui.UseVisualStyleBackColor = false;
            this.btnKyGui.Click += new System.EventHandler(this.btnKyGui_Click);
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(779, 41);
            this.txtViTri.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(248, 22);
            this.txtViTri.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(705, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Vị trí:";
            // 
            // cboDonViTinh
            // 
            this.cboDonViTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDonViTinh.FormattingEnabled = true;
            this.cboDonViTinh.Items.AddRange(new object[] {
            "ml",
            "chai"});
            this.cboDonViTinh.Location = new System.Drawing.Point(474, 94);
            this.cboDonViTinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDonViTinh.Name = "cboDonViTinh";
            this.cboDonViTinh.Size = new System.Drawing.Size(96, 24);
            this.cboDonViTinh.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(386, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Đơn vị tính:";
            // 
            // txtDungTich
            // 
            this.txtDungTich.Location = new System.Drawing.Point(253, 91);
            this.txtDungTich.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDungTich.Name = "txtDungTich";
            this.txtDungTich.Size = new System.Drawing.Size(92, 22);
            this.txtDungTich.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(168, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dung tích:";
            // 
            // txtTenRuou
            // 
            this.txtTenRuou.Location = new System.Drawing.Point(426, 39);
            this.txtTenRuou.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenRuou.Name = "txtTenRuou";
            this.txtTenRuou.Size = new System.Drawing.Size(175, 22);
            this.txtTenRuou.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(333, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên rượu:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(127, 38);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(175, 22);
            this.txtMaKH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Khách hàng:";
            // 
            // dgvKyGui
            // 
            this.dgvKyGui.AllowUserToAddRows = false;
            this.dgvKyGui.AllowUserToDeleteRows = false;
            this.dgvKyGui.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKyGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKyGui.GridColor = System.Drawing.Color.White;
            this.dgvKyGui.Location = new System.Drawing.Point(4, 19);
            this.dgvKyGui.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvKyGui.Name = "dgvKyGui";
            this.dgvKyGui.ReadOnly = true;
            this.dgvKyGui.RowHeadersWidth = 51;
            this.dgvKyGui.Size = new System.Drawing.Size(1027, 359);
            this.dgvKyGui.TabIndex = 2;
            this.dgvKyGui.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKyGui_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLayLai);
            this.groupBox2.Controls.Add(this.dgvKyGui);
            this.groupBox2.Location = new System.Drawing.Point(16, 224);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1035, 382);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách Rượu đang Ký gửi";
            // 
            // btnLayLai
            // 
            this.btnLayLai.BackColor = System.Drawing.Color.LightCoral;
            this.btnLayLai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLayLai.Location = new System.Drawing.Point(4, 321);
            this.btnLayLai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLayLai.Name = "btnLayLai";
            this.btnLayLai.Size = new System.Drawing.Size(1027, 57);
            this.btnLayLai.TabIndex = 3;
            this.btnLayLai.Text = "Lấy Lại Rượu Đã Chọn";
            this.btnLayLai.UseVisualStyleBackColor = false;
            this.btnLayLai.Click += new System.EventHandler(this.btnLayLai_Click);
            // 
            // frmKyGuiRuou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1067, 620);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmKyGuiRuou";
            this.Text = "Quản lý Ký Gửi Rượu";
            this.Load += new System.EventHandler(this.FormKyGuiRuou_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKyGui)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnKyGui;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboDonViTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDungTich;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenRuou;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvKyGui;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLayLai;
    }
}