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
    public partial class ThemMoiHuongDanDeTai : Form
    {
        ThucTapDataContext thucTap = new ThucTapDataContext();
        public ThemMoiHuongDanDeTai()
        {
            InitializeComponent();
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

        private void LoadCombobox()
        {
            var listDeTai = thucTap.TBLDeTais;
            var litstSinhVien = thucTap.TBLSinhViens;           
            var listGiangVien = thucTap.TBLGiangViens;
            foreach(var dt in listDeTai)
            {
                string deTai = "" + dt.Madt + " - " + dt.Tendt;
                cbbDeTai.Items.Add(deTai);
            }
            foreach(var sv in litstSinhVien)
            {
                string sinhVien = "" + sv.Masv + " - " + sv.Hotensv;
                cbbSinhVien.Items.Add(sinhVien);
            }
            foreach(var gv in listGiangVien)
            {
                string giangVien = "" + gv.Magv + " - " + gv.Hotengv;
                cbbGiangVien.Items.Add(giangVien);
            }
            cbbDeTai.SelectedIndex = 0;
            cbbSinhVien.SelectedIndex = 0;
            cbbGiangVien.SelectedIndex = 0;
        }

        private void ThemMoiHuongDanDeTai_Load(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string deTai = cbbDeTai.SelectedItem.ToString().Trim();
            string sinhVien = cbbSinhVien.SelectedItem.ToString().Trim();
            string giangVien = cbbGiangVien.SelectedItem.ToString().Trim();
            string maDeTai = deTai.Substring(0, deTai.IndexOf(" - "));
            string maSinhVien = sinhVien.Substring(0, sinhVien.IndexOf(" - "));
            string maGiangVien = giangVien.Substring(0, giangVien.IndexOf(" - "));
            var check = thucTap.TBLHuongDans.Where(n => n.Masv == int.Parse(maSinhVien)).SingleOrDefault();
            if(check == null)
            {
                TBLHuongDan huongDan = new TBLHuongDan();
                huongDan.Masv = int.Parse(maSinhVien);
                huongDan.Madt = maDeTai;
                huongDan.Magv = int.Parse(maGiangVien);
                thucTap.TBLHuongDans.InsertOnSubmit(huongDan);
                thucTap.SubmitChanges();
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại. " +
                    "Đã tòn tại dữ liệu này!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
