namespace BaiThucHanh06
{
    partial class QuanLyDanhSachDeTai
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
            this.txtKinhPhiDen = new System.Windows.Forms.TextBox();
            this.txtKinhPhiTu = new System.Windows.Forms.TextBox();
            this.txtNoiThucTap = new System.Windows.Forms.TextBox();
            this.txtDeTai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewHienThi = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuatExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1162, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ DANH SÁCH ĐỀ TÀI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtKinhPhiDen);
            this.groupBox1.Controls.Add(this.txtKinhPhiTu);
            this.groupBox1.Controls.Add(this.txtNoiThucTap);
            this.groupBox1.Controls.Add(this.txtDeTai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1162, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điều kiện tìm kiếm";
            // 
            // txtKinhPhiDen
            // 
            this.txtKinhPhiDen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKinhPhiDen.Location = new System.Drawing.Point(933, 37);
            this.txtKinhPhiDen.Name = "txtKinhPhiDen";
            this.txtKinhPhiDen.Size = new System.Drawing.Size(183, 26);
            this.txtKinhPhiDen.TabIndex = 6;
            this.txtKinhPhiDen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextbox);
            // 
            // txtKinhPhiTu
            // 
            this.txtKinhPhiTu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKinhPhiTu.Location = new System.Drawing.Point(723, 37);
            this.txtKinhPhiTu.Name = "txtKinhPhiTu";
            this.txtKinhPhiTu.Size = new System.Drawing.Size(183, 26);
            this.txtKinhPhiTu.TabIndex = 5;
            this.txtKinhPhiTu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextbox);
            // 
            // txtNoiThucTap
            // 
            this.txtNoiThucTap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiThucTap.Location = new System.Drawing.Point(152, 105);
            this.txtNoiThucTap.Name = "txtNoiThucTap";
            this.txtNoiThucTap.Size = new System.Drawing.Size(964, 26);
            this.txtNoiThucTap.TabIndex = 4;
            // 
            // txtDeTai
            // 
            this.txtDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeTai.Location = new System.Drawing.Point(152, 37);
            this.txtDeTai.Name = "txtDeTai";
            this.txtDeTai.Size = new System.Drawing.Size(466, 26);
            this.txtDeTai.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(652, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kinh phí";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nơi thực tập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đề tài";
            // 
            // dataGridViewHienThi
            // 
            this.dataGridViewHienThi.AllowUserToAddRows = false;
            this.dataGridViewHienThi.AllowUserToDeleteRows = false;
            this.dataGridViewHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHienThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHienThi.Location = new System.Drawing.Point(12, 285);
            this.dataGridViewHienThi.Name = "dataGridViewHienThi";
            this.dataGridViewHienThi.RowHeadersWidth = 62;
            this.dataGridViewHienThi.RowTemplate.Height = 28;
            this.dataGridViewHienThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHienThi.Size = new System.Drawing.Size(1162, 326);
            this.dataGridViewHienThi.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmKiếmToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.thêmMớiToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.inToolStripMenuItem,
            this.xuatExcelToolStripMenuItem,
            this.đóngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1186, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(100, 29);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // thêmMớiToolStripMenuItem
            // 
            this.thêmMớiToolStripMenuItem.Name = "thêmMớiToolStripMenuItem";
            this.thêmMớiToolStripMenuItem.Size = new System.Drawing.Size(108, 29);
            this.thêmMớiToolStripMenuItem.Text = "Thêm mới";
            this.thêmMớiToolStripMenuItem.Click += new System.EventHandler(this.thêmMớiToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(58, 29);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(59, 29);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // inToolStripMenuItem
            // 
            this.inToolStripMenuItem.Name = "inToolStripMenuItem";
            this.inToolStripMenuItem.Size = new System.Drawing.Size(43, 29);
            this.inToolStripMenuItem.Text = "In";
            this.inToolStripMenuItem.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // xuatExcelToolStripMenuItem
            // 
            this.xuatExcelToolStripMenuItem.Name = "xuatExcelToolStripMenuItem";
            this.xuatExcelToolStripMenuItem.Size = new System.Drawing.Size(107, 29);
            this.xuatExcelToolStripMenuItem.Text = "Xuất Excel";
            this.xuatExcelToolStripMenuItem.Click += new System.EventHandler(this.xuatExcelToolStripMenuItem_Click);
            // 
            // đóngToolStripMenuItem
            // 
            this.đóngToolStripMenuItem.Name = "đóngToolStripMenuItem";
            this.đóngToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.đóngToolStripMenuItem.Text = "Đóng";
            this.đóngToolStripMenuItem.Click += new System.EventHandler(this.đóngToolStripMenuItem_Click);
            // 
            // QuanLyDanhSachDeTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 623);
            this.Controls.Add(this.dataGridViewHienThi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QuanLyDanhSachDeTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ DANH SÁCH ĐỀ TÀI";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHienThi)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKinhPhiDen;
        private System.Windows.Forms.TextBox txtKinhPhiTu;
        private System.Windows.Forms.TextBox txtNoiThucTap;
        private System.Windows.Forms.TextBox txtDeTai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewHienThi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuatExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inToolStripMenuItem;
    }
}

