using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnThucTap.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using DoAnThucTap.ViewModel;
using System.Net.Mail;
using System.Net;
using System.Web.Services.Description;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.IO;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace DoAnThucTap.Controllers
{
    public class HomeController : Controller
    {
        //Data chung
        ThucTap_DoAnEntities data = new ThucTap_DoAnEntities();
        //Data rieng
        //ThucTap_DoAnEntities1 data = new ThucTap_DoAnEntities1();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        #region Đăng nhập
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XuLyDangNhap(FormCollection pForm)
        {
            if (pForm["mssv"] != "" && pForm["matkhau"] != "")
            {
                string maSV = pForm["mssv"].ToString();
                string matKhau = pForm["matkhau"].ToString();
                //tìm sinh viên theo mã sinh viên và mật khẩu
                var sinhVien = data.sp_Get_SinhVien(maSV, matKhau).FirstOrDefault();
                if (sinhVien != null)
                {
                    //lưu sinh viên
                    Session["sinhvien"] = sinhVien;
                    return View("HienThiPhieuThu");
                }
                else
                {
                    ViewBag.Loi = "Mã số sinh viên/mật khẩu không chính xác!";
                }
            }
            else
            {
                ViewBag.Loi = "Mã số sinh viên/mật khẩu không được để trống";
            }
            return View("DangNhap");
        }
        #endregion

        #region Hiển thị view phiếu thu
        public ActionResult HienThiPhieuThu()
        {
            return View();
        }
        #endregion

        #region Hiện thị view Home
        public ActionResult Home()
        {
            return View();
        }
        #endregion

        #region Gửi mail
        //xử lý gửi mail
        [HttpPost]
        public ActionResult SendMail(string pMssv, string pHotensv, string pSophieu)
        {
            try
            {
                string emailSinhVien = data.sp_Get_EmailSinhVien(pMssv).FirstOrDefault();
                var senderEmail = new MailAddress("kphuc2023@gmail.com", "Phuc");
                var password = "uzla bxdr ncxi mplb";
                var receiverEmail = new MailAddress(emailSinhVien, "Receiver");
                var sub = "Email xác nhận thanh toán"; //subject
                
                //var body = "<i>Đây là email xác nhận!</i>"; //message

                string body = ThemEmailTemplate(pHotensv, pSophieu);

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body,
                    IsBodyHtml = true,                    
                })
                {
                    smtp.Send(mess);
                }
                ViewBag.Result = "Gửi mail thành công!!";
                return View("HienThiPhieuThu");
            }
            catch (Exception ex)
            {
                ViewBag.Result = ex.Message;
            }
            return View("HienThiPhieuThu");
        }

        //thêm template cho email
        public string ThemEmailTemplate(string pHotensv, string pSophieu)
        {
            string body = string.Empty;
            string chitiet = "";
            var listChiTiet = data.sp_Get_ChiTietPhieuThu(pSophieu).ToList();
            int stt = 1;
            decimal? tongTien = 0;
            chitiet = chitiet + "<tr><th>STT</th><th>Mã môn học</th><th>Tên môn học</th><th>Đơn giá (VND)</th></tr>";
            foreach (var item in listChiTiet)
            {               
                chitiet = chitiet + "<tr>";
                chitiet = chitiet + "<td id=\"stt\">" + stt + "</td>";
                chitiet = chitiet + "<td id=\"mamh\">" + item.MaMH + "</td>";
                string tenmh = data.sp_Get_TenMonHocByMaMH(item.MaMH).FirstOrDefault();
                decimal? dongia = data.sp_Get_DonGiaByMaMH(item.MaMH).FirstOrDefault();
                tongTien = tongTien + dongia;
                chitiet = chitiet + "<td>" + tenmh + "</td>";
                chitiet = chitiet + "<td class=\"dongia\">" + String.Format("{0:0,0}", dongia) + "</td>";
                chitiet = chitiet + "</tr>";
                stt++;
            }
            chitiet = chitiet + "<tr><td class=\"tongtien\" colspan=\"3\">Tổng tiền</td><td class=\"number\">" + String.Format("{0:0,0}", tongTien) + "</td></tr>";

            var root = AppDomain.CurrentDomain.BaseDirectory; using (var reader = new System.IO.StreamReader(root + @"/Templates/email.txt"))
            {
                string readFile = reader.ReadToEnd();
                string StrContent = string.Empty;
                StrContent = readFile;
                StrContent = StrContent.Replace("[TenSinhVien]", pHotensv);
                StrContent = StrContent.Replace("[ChiTietPhieuThu]", chitiet);
                body = StrContent.ToString();
            }
            return body;
        }
        #endregion

        #region Export excel
        //xử lý export excel
        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
        #endregion

        #region Lấy list phiếu thu
        //lấy dữ liệu bảng TBL_PhieuThu (phiếu thu mặc định trạng thái là thành công)
        public JsonResult GetAllPhieuThu([DataSourceRequest] DataSourceRequest request)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByTrangThai("Thành công").ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region GetTrangThai
        //lấy trạng thái phiếu thu
        public JsonResult GetTrangThai()
        {
            var listPhieuThu = data.sp_Get_TrangThai().ToList();
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuByMaSV
        //lấy dữ liệu phiếu thu theo mã sinh viên
        public JsonResult GetPhieuThuByMaSV(string pMssv)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByMaSV(pMssv).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuBySoPhieu
        //lấy dữ liệu phiếu thu theo số phiếu
        public JsonResult GetPhieuThuBySoPhieu(string pSophieu)
        {
            var listPhieuThu = data.sp_Get_PhieuThuBySoPhieu(pSophieu).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuByNgayThanhToan
        //lấy dữ liệu phiếu thu theo ngày thanh toán
        public JsonResult GetPhieuThuByNgayThanhToan(DateTime pNgaybatdau, DateTime pNgayketthuc)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByNgayThanhToan(pNgaybatdau, pNgayketthuc).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuByMasvSoPhieu
        //lấy dữ liệu phiếu thu theo mã sinh viên và số phiếu
        public JsonResult GetPhieuThuByMasvAndSoPhieu(string pMssv, string pSophieu)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByMasvAndSoPhieu(pMssv, pSophieu).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuByMaSVSoPhieuNgayThanhToan
        //lấy phiếu thu theo mã sinh viên, số phiếu và ngày thanh toán
        public JsonResult GetPhieuThuByAll(string pMssv, string pSophieu, DateTime pNgaybatdau, DateTime pNgayketthuc)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByAll(pMssv, pSophieu, pNgaybatdau, pNgayketthuc).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetPhieuThuByTrangThai
        //lấy phiếu thu theo trạng thái
        public JsonResult GetPhieuThuByTrangThai(string pTrangThai)
        {
            var listPhieuThu = data.sp_Get_PhieuThuByTrangThai(pTrangThai).ToList().Select(index => new PhieuThu
            {
                soPhieu = index.SoPhieu,
                Mssv = index.Mssv,
                hoTenSV = index.TBL_SinhVien.Hoten,
                matKhau = index.TBL_SinhVien.MatKhau,
                noiDung = index.NoiDung,
                ngayThanhToan = index.NgayThanhToan,
                soTienThu = index.SoTienThu,
                donViThu = index.DonViThu,
                trangThai = index.TrangThai
            }
            );
            return Json(listPhieuThu, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetChiTietPhieuThu
        //lấy chi tiết phiếu thu
        public JsonResult GetChiTietPhieuThu(string pSoPhieu, [DataSourceRequest] DataSourceRequest request)
        {
            List<ChiTietPhieuThu> listCTPhieuThu = new List<ChiTietPhieuThu>();
            int stt = 1;
            foreach(var item in data.sp_Get_ChiTietPhieuThu(pSoPhieu).ToList())
            {
                ChiTietPhieuThu ct = new ChiTietPhieuThu();
                ct.STT = stt;
                ct.MaMH = item.MaMH;
                ct.TenMH = data.sp_Get_TenMonHocByMaMH(item.MaMH).FirstOrDefault();
                ct.DonGia = data.sp_Get_DonGiaByMaMH(item.MaMH).FirstOrDefault();
                listCTPhieuThu.Add(ct);
                stt++;
            }
            return Json(listCTPhieuThu.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}