using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiThucHanh06
{
    public partial class NhapKetQuaDeTai : Form
    {
        ThucTapDataContext thucTap = new ThucTapDataContext();
        public NhapKetQuaDeTai()
        {
            InitializeComponent();
            
        }

        public NhapKetQuaDeTai(string deTai, string sinhVien, string giangVien, string ketQua)
        {
            InitializeComponent();
            txtMaDeTai.Text = deTai;
            txtSinhVien.Text = sinhVien;
            txtGiangVien.Text = giangVien;
            txtKetQua.Text = ketQua;
        }

        private void dongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void NumericTextbox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void NhapKetQuaDeTai_Load(object sender, EventArgs e)
        {
            
        }

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maSinhVien = txtSinhVien.Text.Substring(0, txtSinhVien.Text.IndexOf(" - "));
            var huongDan = thucTap.TBLHuongDans.Where(n 
                => n.Masv == int.Parse(maSinhVien)).SingleOrDefault();
            if(txtKetQua.Text != "")
            {
                huongDan.KetQua = (decimal?)double.Parse(txtKetQua.Text);
            }
            thucTap.SubmitChanges();
            MessageBox.Show("Nhập kết quả thành công", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
