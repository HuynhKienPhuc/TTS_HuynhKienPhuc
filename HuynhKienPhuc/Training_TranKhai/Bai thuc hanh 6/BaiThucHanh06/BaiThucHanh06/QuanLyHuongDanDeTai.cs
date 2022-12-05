using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace BaiThucHanh06
{
    public partial class QuanLyHuongDanDeTai : Form
    {
        ThucTapDataContext thucTap = new ThucTapDataContext();
        public QuanLyHuongDanDeTai()
        {
            InitializeComponent();
        }

        private void LoadDataGridView()
        {
            var huongDan = from hd in thucTap.TBLHuongDans select new { 
                hd.TBLGiangVien.Makhoa, hd.Masv, Hotensv = (from sv in thucTap.TBLSinhViens where sv.Masv == hd.Masv select sv.Hotensv).FirstOrDefault(), hd.Magv, 
                                                      hd.TBLGiangVien.Hotengv, hd.Madt, 
            hd.TBLDeTai.Tendt, hd.KetQua};
            dataGridViewHienThi.DataSource = huongDan;
        }

        private void timKiemToolStripMenuItem_Click(object sender, EventArgs e)
        {                      
            
            string trangThai = cbbTrangThai.SelectedItem.ToString();
            
            if (trangThai == "Đã có điểm")
            {              
                var huongDan = thucTap.TBLHuongDans.Where(n => n.KetQua != null);
                if(txtDeTai.Text != "")
                {
                    string tenDeTai = txtDeTai.Text;
                    huongDan = huongDan.Where(n => n.TBLDeTai.Tendt.Contains(tenDeTai));
                }               
                if(txtGiangVien.Text != "")
                {
                    string tenGiangVien = txtGiangVien.Text;
                    huongDan = huongDan.Where(n 
                        => n.TBLGiangVien.Hotengv.Contains(tenGiangVien));
                }
                if (txtSinhVien.Text != "")
                {
                    string tenSinhVien = txtSinhVien.Text;

                    var sinhVien = thucTap.TBLSinhViens.Where(n
                    => n.Hotensv.Contains(tenSinhVien));
                    foreach(var sv in sinhVien)
                    {
                        foreach(var hd in huongDan)
                        {
                            if(sv.Masv == hd.Masv)
                            {
                                huongDan = huongDan.Where(n => n.Masv == sv.Masv);
                                break;
                            }
                        }
                    }
                }
                dataGridViewHienThi.DataSource = from hd in huongDan
                                                 select new
                                                 {
                                                     hd.TBLGiangVien.Makhoa,
                                                     hd.Masv,
                                                     Hotensv = (from sv in 
                                                                    thucTap.TBLSinhViens 
                                                                where sv.Masv == hd.Masv 
                                                                select sv.Hotensv)
                                                                .FirstOrDefault(),
                                                     hd.Magv,
                                                     hd.TBLGiangVien.Hotengv,
                                                     hd.Madt,
                                                     hd.TBLDeTai.Tendt,
                                                     hd.KetQua
                                                 };
            }
            else
            {
                var huongDan = thucTap.TBLHuongDans.Where(n => n.KetQua == null);
                if (txtDeTai.Text != "")
                {
                    string tenDeTai = txtDeTai.Text;
                    huongDan = huongDan.Where(n => n.TBLDeTai.Tendt.Contains(tenDeTai));
                }               
                if (txtGiangVien.Text != "")
                {
                    string tenGiangVien = txtGiangVien.Text;
                    huongDan = huongDan.Where(n
                        => n.TBLGiangVien.Hotengv.Contains(tenGiangVien));
                }
                if (txtSinhVien.Text != "")
                {
                    string tenSinhVien = txtSinhVien.Text;

                    var sinhVien = thucTap.TBLSinhViens.Where(n
                    => n.Hotensv.Contains(tenSinhVien));
                    foreach (var sv in sinhVien)
                    {
                        foreach (var hd in huongDan)
                        {
                            if (sv.Masv == hd.Masv)
                            {
                                huongDan = huongDan.Where(n => n.Masv == sv.Masv);
                                break;
                            }
                        }
                    }
                }
                dataGridViewHienThi.DataSource = from hd in huongDan
                                                 select new
                                                 {
                                                     hd.TBLGiangVien.Makhoa,
                                                     hd.Masv,
                                                     Hotensv = (from sv in
                                                                    thucTap.TBLSinhViens
                                                                where sv.Masv == hd.Masv
                                                                select sv.Hotensv)
                                                                .FirstOrDefault(),
                                                     hd.Magv,
                                                     hd.TBLGiangVien.Hotengv,
                                                     hd.Madt,
                                                     hd.TBLDeTai.Tendt,
                                                     hd.KetQua
                                                 };
            }
        }

        private void QuanLyHuongDanDeTai_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            cbbTrangThai.Items.Add("Đã có điểm");
            cbbTrangThai.Items.Add("Chưa có điểm");
            cbbTrangThai.SelectedIndex = 0;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDeTai.Text = "";
            txtGiangVien.Text = "";
            txtSinhVien.Text = "";
            cbbTrangThai.SelectedIndex = 0;
            txtDeTai.Focus();
            LoadDataGridView();
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

        private void themMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemMoiHuongDanDeTai frm = new ThemMoiHuongDanDeTai();
            frm.Show();
        }

        private void nhapKetQuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewHienThi.CurrentCell.RowIndex;
            string deTai = "" + dataGridViewHienThi.Rows[rowindex].Cells[5].Value.ToString().Trim();
            deTai = deTai + " - " + dataGridViewHienThi.Rows[rowindex].Cells[6].Value.ToString();
            string sinhVien = "" + dataGridViewHienThi.Rows[rowindex].Cells[1].Value.ToString();
            sinhVien = sinhVien + " - " + dataGridViewHienThi.Rows[rowindex].Cells[2].Value.ToString();
            string giangVien = "" + dataGridViewHienThi.Rows[rowindex].Cells[3].Value.ToString();
            giangVien = giangVien + " - " + dataGridViewHienThi.Rows[rowindex].Cells[4].Value.ToString();
            string ketQua = "";
            if (dataGridViewHienThi.Rows[rowindex].Cells[7].Value != null)
            {
                ketQua = dataGridViewHienThi.Rows[rowindex].Cells[7].Value.ToString();
            }
            NhapKetQuaDeTai frm = new NhapKetQuaDeTai(deTai.Trim(), sinhVien.Trim(), 
                giangVien.Trim(), ketQua);
            frm.Show();
        }

        private void xoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewHienThi.CurrentCell.RowIndex;
            int maSinhVien = 
                int.Parse(dataGridViewHienThi.Rows[rowindex].Cells[1].Value.ToString());
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn muốn xóa hướng dẫn đề tài " +
                "có mã sinh viên là '" + maSinhVien + "' không?", 
                "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                var huongDan = thucTap.TBLHuongDans.Where(n 
                    => n.Masv == maSinhVien).SingleOrDefault();
                thucTap.TBLHuongDans.DeleteOnSubmit(huongDan);
                thucTap.SubmitChanges();
                MessageBox.Show("Xóa hướng dẫn đề tài thành công", 
                    "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadDataGridView();
            }
        }

        private void xuatExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridViewHienThi.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = 
                    new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for(int i = 1; i < dataGridViewHienThi.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dataGridViewHienThi.Columns[i - 1].HeaderText;
                }
                for(int i = 0; i < dataGridViewHienThi.Rows.Count; i++)
                {
                    for(int j = 0; j < dataGridViewHienThi.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = 
                            dataGridViewHienThi.Rows[i].Cells[j].Value.ToString();
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
        }

        private void ExportGirdToPdf(DataGridView dgv, string fileName)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, 
                BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 
                10, iTextSharp.text.Font.NORMAL);
            //Add header
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Add datarow
            foreach(DataGridViewRow row in dgv.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.DefaultExt = ".pdf";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName, 
                    FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(pdfDoc, fileStream);
                    pdfDoc.Open();
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Close();
                    fileStream.Close();
                    MessageBox.Show("Xuất file pdf thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportGirdToPdf(dataGridViewHienThi, "QuanLyHuongDanDeTai");
        }
    }
}
