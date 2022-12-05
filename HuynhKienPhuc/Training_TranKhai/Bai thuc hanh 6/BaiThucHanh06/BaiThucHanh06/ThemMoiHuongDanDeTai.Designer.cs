namespace BaiThucHanh06
{
    partial class ThemMoiHuongDanDeTai
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
            this.cbbDeTai = new System.Windows.Forms.ComboBox();
            this.cbbSinhVien = new System.Windows.Forms.ComboBox();
            this.cbbGiangVien = new System.Windows.Forms.ComboBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(736, 33);
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
            this.label1.Location = new System.Drawing.Point(0, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(736, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÊM MỚI HƯỚNG DẪN ĐỀ TÀI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã đề tài";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sinh viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Giảng viên";
            // 
            // cbbDeTai
            // 
            this.cbbDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDeTai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDeTai.FormattingEnabled = true;
            this.cbbDeTai.Location = new System.Drawing.Point(208, 147);
            this.cbbDeTai.Name = "cbbDeTai";
            this.cbbDeTai.Size = new System.Drawing.Size(428, 28);
            this.cbbDeTai.TabIndex = 5;
            // 
            // cbbSinhVien
            // 
            this.cbbSinhVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSinhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSinhVien.FormattingEnabled = true;
            this.cbbSinhVien.Location = new System.Drawing.Point(208, 239);
            this.cbbSinhVien.Name = "cbbSinhVien";
            this.cbbSinhVien.Size = new System.Drawing.Size(428, 28);
            this.cbbSinhVien.TabIndex = 6;
            // 
            // cbbGiangVien
            // 
            this.cbbGiangVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGiangVien.FormattingEnabled = true;
            this.cbbGiangVien.Location = new System.Drawing.Point(208, 342);
            this.cbbGiangVien.Name = "cbbGiangVien";
            this.cbbGiangVien.Size = new System.Drawing.Size(428, 28);
            this.cbbGiangVien.TabIndex = 7;
            // 
            // ThemMoiHuongDanDeTai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 425);
            this.Controls.Add(this.cbbGiangVien);
            this.Controls.Add(this.cbbSinhVien);
            this.Controls.Add(this.cbbDeTai);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThemMoiHuongDanDeTai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới";
            this.Load += new System.EventHandler(this.ThemMoiHuongDanDeTai_Load);
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
        private System.Windows.Forms.ComboBox cbbDeTai;
        private System.Windows.Forms.ComboBox cbbSinhVien;
        private System.Windows.Forms.ComboBox cbbGiangVien;
    }
}