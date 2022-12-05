namespace BaiThucHanh06
{
    partial class ThemMoiDeTai
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lưuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaDeTai = new System.Windows.Forms.TextBox();
            this.txtTenDeTai = new System.Windows.Forms.TextBox();
            this.txtNoiThucTap = new System.Windows.Forms.TextBox();
            this.txtKinhPhi = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lưuToolStripMenuItem,
            this.đóngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lưuToolStripMenuItem
            // 
            this.lưuToolStripMenuItem.Name = "lưuToolStripMenuItem";
            this.lưuToolStripMenuItem.Size = new System.Drawing.Size(57, 29);
            this.lưuToolStripMenuItem.Text = "Lưu";
            this.lưuToolStripMenuItem.Click += new System.EventHandler(this.lưuToolStripMenuItem_Click);
            // 
            // đóngToolStripMenuItem
            // 
            this.đóngToolStripMenuItem.Name = "đóngToolStripMenuItem";
            this.đóngToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.đóngToolStripMenuItem.Text = "Đóng";
            this.đóngToolStripMenuItem.Click += new System.EventHandler(this.đóngToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "THÊM MỚI ĐỀ TÀI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã đề tài";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đề tài";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kinh phí";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nơi thực tập";
            // 
            // txtMaDeTai
            // 
            this.txtMaDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaDeTai.Location = new System.Drawing.Point(180, 128);
            this.txtMaDeTai.Name = "txtMaDeTai";
            this.txtMaDeTai.Size = new System.Drawing.Size(471, 26);
            this.txtMaDeTai.TabIndex = 6;
            this.txtMaDeTai.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaDeTai_Validating);
            // 
            // txtTenDeTai
            // 
            this.txtTenDeTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDeTai.Location = new System.Drawing.Point(180, 200);
            this.txtTenDeTai.Name = "txtTenDeTai";
            this.txtTenDeTai.Size = new System.Drawing.Size(471, 26);
            this.txtTenDeTai.TabIndex = 7;
            this.txtTenDeTai.Validating += new System.ComponentModel.CancelEventHandler(this.txtTenDeTai_Validating);
            // 
            // txtNoiThucTap
            // 
            this.txtNoiThucTap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoiThucTap.Location = new System.Drawing.Point(180, 358);
            this.txtNoiThucTap.Name = "txtNoiThucTap";
            this.txtNoiThucTap.Size = new System.Drawing.Size(471, 26);
            this.txtNoiThucTap.TabIndex = 8;
            // 
            // txtKinhPhi
            // 
            this.txtKinhPhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKinhPhi.Location = new System.Drawing.Point(180, 281);
            this.txtKinhPhi.Name = "txtKinhPhi";
            this.txtKinhPhi.Size = new System.Drawing.Size(250, 26);
            this.txtKinhPhi.TabIndex = 9;
            this.txtKinhPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextbox);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // frmThemMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtKinhPhi);
            this.Controls.Add(this.txtNoiThucTap);
            this.Controls.Add(this.txtTenDeTai);
            this.Controls.Add(this.txtMaDeTai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmThemMoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm mới/Sửa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lưuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đóngToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaDeTai;
        private System.Windows.Forms.TextBox txtTenDeTai;
        private System.Windows.Forms.TextBox txtNoiThucTap;
        private System.Windows.Forms.TextBox txtKinhPhi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}