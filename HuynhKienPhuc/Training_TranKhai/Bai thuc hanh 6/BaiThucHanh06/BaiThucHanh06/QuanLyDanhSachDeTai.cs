using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BaiThucHanh06
{
    public partial class QuanLyDanhSachDeTai : Form
    {
        ThucTapDataContext thucTap = new ThucTapDataContext();
        public QuanLyDanhSachDeTai()
        {
            InitializeComponent();
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            var detais = from dt in thucTap.TBLDeTais
                         select
                         new
                         {
                             dt.Madt,
                             dt.Tendt,
                             dt.Kinhphi,
                             dt.Noithuctap
                         };

            dataGridViewHienThi.DataSource = detais;
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tenDeTai = txtDeTai.Text;
            string noiThucTap = txtNoiThucTap.Text;
            int kinhPhiBatDau;
            int kinhPhiKetThuc;

            if (txtKinhPhiTu.Text != "" && txtKinhPhiDen.Text != "")
            {
                kinhPhiBatDau = int.Parse(txtKinhPhiTu.Text);
                kinhPhiKetThuc = int.Parse(txtKinhPhiDen.Text);
                if(kinhPhiBatDau > kinhPhiKetThuc)
                {
                    MessageBox.Show("Kinh phí bắt đầu phải nhỏ hơn kinh phí đến"
                        , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var detais = thucTap.TBLDeTais.Where(n => n.Kinhphi >= kinhPhiBatDau 
                    && n.Kinhphi <= kinhPhiKetThuc).ToList();
                    detais = detais.Where(n => n.Tendt.Contains(tenDeTai) 
                    && n.Noithuctap.Contains(noiThucTap)).ToList();
                    dataGridViewHienThi.DataSource = detais;
                }
            }
            else if(txtKinhPhiTu.Text != "")
            {
                kinhPhiBatDau = int.Parse(txtKinhPhiTu.Text);
                var detais = thucTap.TBLDeTais.Where(n => n.Kinhphi >= kinhPhiBatDau).ToList();
                detais = detais.Where(n => n.Tendt.Contains(tenDeTai) 
                && n.Noithuctap.Contains(noiThucTap)).ToList();
                dataGridViewHienThi.DataSource = detais;
            }
            else if(txtKinhPhiDen.Text != "")
            {
                kinhPhiKetThuc = int.Parse(txtKinhPhiDen.Text);
                var detais = thucTap.TBLDeTais.Where(n => n.Kinhphi <= kinhPhiKetThuc).ToList();
                detais = detais.Where(n => n.Tendt.Contains(tenDeTai) 
                && n.Noithuctap.Contains(noiThucTap)).ToList();
                dataGridViewHienThi.DataSource = detais;
            }
            else
            {
                var detais = thucTap.TBLDeTais.Where(n => n.Tendt.Contains(tenDeTai) 
                && n.Noithuctap.Contains(noiThucTap)).ToList();
                dataGridViewHienThi.DataSource = detais;
            }
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDeTai.Text = "";
            txtKinhPhiTu.Text = "";
            txtKinhPhiDen.Text = "";
            txtNoiThucTap.Text = "";
            txtDeTai.Focus();
            LoadDataGridView();
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemMoiDeTai frm = new ThemMoiDeTai();
            frm.Show();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewHienThi.CurrentCell.RowIndex;
            string maDeTai = dataGridViewHienThi.Rows[rowindex].Cells[0].Value.ToString();
            string tenDeTai = dataGridViewHienThi.Rows[rowindex].Cells[1].Value.ToString();
            string kinhPhi = "";
            if(dataGridViewHienThi.Rows[rowindex].Cells[2].Value != null)
            {
                kinhPhi = dataGridViewHienThi.Rows[rowindex].Cells[2].Value.ToString();
            }
            string noiThucTap = dataGridViewHienThi.Rows[rowindex].Cells[3].Value.ToString();

            ThemMoiDeTai frm = new ThemMoiDeTai(maDeTai, tenDeTai, kinhPhi, noiThucTap);
            frm.Show();
        
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridViewHienThi.CurrentCell.RowIndex;
            string maDeTai = dataGridViewHienThi.Rows[rowindex].Cells[0].Value.ToString();
            DialogResult ret = MessageBox.Show("Bạn có muốn xóa đề tài '" +
                maDeTai + "'?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(ret == DialogResult.Yes)
            {
                var checkDeTai = thucTap.TBLHuongDans.Where(n
                    => n.Madt == maDeTai);
                if(checkDeTai.Count() > 0)
                {
                    DialogResult xacNhan = MessageBox.Show("Đề tài này có dữ liệu nằm " +
                        "ở bảng Hướng dẫn đề tài. Xóa đồng nghĩa với việc xóa các dòng dữ liệu ở " +
                        "bảng có chứa đề tài này, bạn vẫn muốn tiếp tục?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(xacNhan == DialogResult.Yes)
                    {
                        foreach(var dt in checkDeTai)
                        {
                            thucTap.TBLHuongDans.DeleteOnSubmit(dt);
                        }                       
                    }
                    else
                    {
                        return;
                    }                  
                }
                var deTai = thucTap.TBLDeTais.Where(n
                        => n.Madt == maDeTai).SingleOrDefault();
                thucTap.TBLDeTais.DeleteOnSubmit(deTai);
                thucTap.SubmitChanges();
                MessageBox.Show("Xóa đề tài thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                LoadDataGridView();
            }
        }

        private void đóngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void xuatExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewHienThi.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp =
                    new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dataGridViewHienThi.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dataGridViewHienThi.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridViewHienThi.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewHienThi.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] =
                            dataGridViewHienThi.Rows[i].Cells[j].Value.ToString();
                    }
                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportGirdToPdf(dataGridViewHienThi, "QuanLyDanhSachDeTai");
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
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Add datarow
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.DefaultExt = ".pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fileStream = new FileStream(saveFileDialog.FileName,
                    FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
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
    }
}
