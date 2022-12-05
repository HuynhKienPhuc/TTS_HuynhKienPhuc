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
    public partial class ThemMoiDeTai : Form
    {
        ThucTapDataContext thucTap = new ThucTapDataContext();
        bool isUpdate = false;
        public ThemMoiDeTai()
        {
            InitializeComponent();
        }

        public ThemMoiDeTai(string maDeTai, string tenDeTai, string kinhPhi, string noiThucTap)
        {
            InitializeComponent();
            txtMaDeTai.Text = maDeTai;
            txtTenDeTai.Text = tenDeTai;
            txtKinhPhi.Text = kinhPhi;
            txtNoiThucTap.Text = noiThucTap;
            txtMaDeTai.Enabled = false;
            isUpdate = true;
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

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc muốn đóng cửa sổ này?", "Thông báo", MessageBoxButtons.YesNo
                , MessageBoxIcon.Warning);
            if(ret == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtMaDeTai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã đề tài", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (txtTenDeTai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đề tài", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            var checkDeTai = thucTap.TBLDeTais.Where(n 
                => n.Madt == txtMaDeTai.Text).SingleOrDefault();
            if(checkDeTai == null)
            {
                TBLDeTai deTai = new TBLDeTai();
                deTai.Madt = txtMaDeTai.Text;
                deTai.Tendt = txtTenDeTai.Text;
                if(txtKinhPhi.Text != "")
                {
                    deTai.Kinhphi = int.Parse(txtKinhPhi.Text);
                }               
                deTai.Noithuctap = txtNoiThucTap.Text;
                thucTap.TBLDeTais.InsertOnSubmit(deTai);
                thucTap.SubmitChanges();
                MessageBox.Show("Thêm đề tài thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (isUpdate)
                {
                    DialogResult ret = MessageBox.Show("Sửa thông tin đề tài '" +
                        txtMaDeTai.Text + "'?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ret == DialogResult.Yes)
                    {
                        var deTai = thucTap.TBLDeTais.Where(n => n.Madt == txtMaDeTai.Text).SingleOrDefault();
                        deTai.Tendt = txtTenDeTai.Text;
                        if (txtKinhPhi.Text != "")
                        {
                            deTai.Kinhphi = int.Parse(txtKinhPhi.Text);
                        }
                        deTai.Noithuctap = txtNoiThucTap.Text;
                        thucTap.SubmitChanges();
                        MessageBox.Show("Sửa đề tài thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Đề tài đã tồn tại", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }               
            }
        }

        private bool ValidateData()
        {
            if(txtMaDeTai.Text == "")
            {
                errorProvider1.SetError(txtMaDeTai, "Vui lòng nhập mã đề tài");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtMaDeTai, "");
            }
            if (txtTenDeTai.Text == "")
            {
                errorProvider2.SetError(txtTenDeTai, "Vui lòng nhập tên đề tài");
                return false;
            }
            else
            {
                errorProvider2.SetError(txtTenDeTai, "");
            }
            return true;
        }

        private void txtMaDeTai_Validating(object sender, CancelEventArgs e)
        {
            ValidateData();
        }

        private void txtTenDeTai_Validating(object sender, CancelEventArgs e)
        {
            ValidateData();
        }
    }
}
