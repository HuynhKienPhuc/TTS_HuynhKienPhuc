namespace BaiThucHanh06
{
    partial class NhapKetQuaDeTai
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.luuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDeTai = new System.Windows.Forms.TextBox();
            this.txtSinhVien = new System.Windows.Forms.TextBox();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luuToolStripMenuItem,
            this.dongToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // luuToolStripMenuItem
            // 
            this.luuToolStripMenuItem.Name = "luuToolStripMenuItem";
            this.luuToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.luuToolStripMenuItem.Text = "Lưu";
            this.luuToolStripMenuItem.Click += new System.EventHandler(this.luuToolStripMenuItem_Click);
            // 
            // dongToolStripMenuItem
            // 
            this.dongToolStripMenuItem.Name = "dongToolStripMenuItem";
            this.dongToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.dongToolStripMenuItem.Text = "Đóng";
            this.dongToolStripMenuItem.Click += new System.EventHandler(this.dongToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "NHẬP KẾT QUẢ ĐỀ TÀI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã đề tài";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giảng viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 404);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Kết quả";
            // 
            // txtMaDeTai
            // 
            this.txtMaDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaDeTai.Enabled = false;
            this.txtMaDeTai.Location = new System.Drawing.Point(195, 148);
            this.txtMaDeTai.Name = "txtMaDeTai";
            this.txtMaDeTai.ReadOnly = true;
            this.txtMaDeTai.Size = new System.Drawing.Size(376, 26);
            this.txtMaDeTai.TabIndex = 6;
            // 
            // txtSinhVien
            // 
            this.txtSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSinhVien.Enabled = false;
            this.txtSinhVien.Location = new System.Drawing.Point(195, 234);
            this.txtSinhVien.Name = "txtSinhVien";
            this.txtSinhVien.ReadOnly = true;
            this.txtSinhVien.Size = new System.Drawing.Size(376, 26);
            this.txtSinhVien.TabIndex = 7;
            // 
            // txtGiangVien
            // 
            this.txtGiangVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiangVien.Enabled = false;
            this.txtGiangVien.Location = new System.Drawing.Point(195, 316);
            this.txtGiangVien.Name = "txtGiangVien";
            this.txtGiangVien.ReadOnly = true;
            this.txtGiangVien.Size = new System.Drawing.Size(376, 26);
            this.txtGiangVien.TabIndex = 8;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKetQua.Location = new System.Drawing.Point(195, 401);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(249, 26);
            this.txtKetQua.TabIndex = 9;
            this.txtKetQua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKetQua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextbox);
            // 
            // NhapKetQuaDeTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 481);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.txtGiangVien);
            this.Controls.Add(this.txtSinhVien);
            this.Controls.Add(this.txtMaDeTai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "NhapKetQuaDeTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập kết quả đề tài";
            this.Load += new System.EventHandler(this.NhapKetQuaDeTai_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem luuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dongToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaDeTai;
        private System.Windows.Forms.TextBox txtSinhVien;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.TextBox txtKetQua;
    }
}