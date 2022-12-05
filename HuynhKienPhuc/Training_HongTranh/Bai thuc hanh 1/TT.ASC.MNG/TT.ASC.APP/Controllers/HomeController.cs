using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TT.ASC.DATA;

namespace TT.ASC.APP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DinhDangNgayThang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DinhDangNgayThang(FormCollection c)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(c["input"]);
                string kieuDinhDang = c["kieudinhdang"];
                ViewBag.Input = "Kết quả trước khi định dạng: " + dt;
                ViewBag.KieuDinhDang = "Kiểu định dạng đã chọn: " + kieuDinhDang;
                ViewBag.KetQua = "Kết quả sau khi định dạng: " + Class1.DinhDangNgayThang(dt, kieuDinhDang);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }            

            return View("DinhDangNgayThang");
        }

        [HttpGet]
        public ActionResult DocDaySoBatKi()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult DocDaySoBatKi(FormCollection c)
        {
            try
            {
                double daySo = Convert.ToDouble(c["dayso"]);
                ViewBag.DaySo = "Dãy số bạn vừa nhập là: " + daySo;
                ViewBag.KetQua = "Dãy số đọc là: " + Class1.DocDaySoBatKy(daySo);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("DocDaySoBatKi");
        }

        [HttpGet]
        public ActionResult DocSoTienBatKi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DocSoTienBatKi(FormCollection c)
        {
            try
            {
                double soTien = Convert.ToDouble(c["sotien"]);
                ViewBag.SoTien = "Số tiền bạn vừa nhập là: " + soTien;
                ViewBag.KetQua = "Số tiền đọc là: " + Class1.DocSoTienBatKy(soTien);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("DocSoTienBatKi");
        }

        [HttpGet]
        public ActionResult RandomKyTuVaSo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RandomKyTuVaSo(FormCollection c)
        {
            try
            {
                int chieuDaiChuoi = int.Parse(c["chieudai"]);
                int soKyTuSo = int.Parse(c["sokytuso"]);
                if(soKyTuSo > chieuDaiChuoi)
                {
                    ViewBag.KetQua = "Số ký tự số phải nhỏ hơn hoặc bằng chiều dài chuỗi!";
                    return View("RandomKyTuVaSo");
                }

                ViewBag.ChieuDaiChuoi = "Chiều dài chuỗi vừa nhập là: " + chieuDaiChuoi;
                ViewBag.SoKyTuSo = "Số ký tự số là: " + soKyTuSo;
                ViewBag.KetQua = "Chuỗi ngẫu nhiên là: " + Class1.RandomKyTuVaSo(chieuDaiChuoi, soKyTuSo);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("RandomKyTuVaSo");
        }

        [HttpGet]
        public ActionResult TraVeNgayDauTien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraVeNgayDauTien(FormCollection c)
        {
            int thang = int.Parse(c["thang"]);
            int nam = int.Parse(c["nam"]);
            ViewBag.Thang = "Tháng đã chọn: " + thang;
            ViewBag.Nam = "Năm đã chọn: " + nam;

            DateTime ngayDauTien = Class1.TraVeNgayDauTien(thang, nam);
            ViewBag.NgayDauTien = "Ngày đầu tiên của tháng là: " + 
                String.Format("{0:dd/MM/yyyy}", ngayDauTien);

            return View("TraVeNgayDauTien");
        }

        [HttpGet]
        public ActionResult TraVeNgayCuoiThang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraVeNgayCuoiThang(FormCollection c)
        {
            int thang = int.Parse(c["thang"]);
            int nam = int.Parse(c["nam"]);
            DateTime ngayCuoiThang = Class1.TraVeNgayCuoiThang(thang, nam);

            ViewBag.Thang = "Tháng đã chọn: " + thang;
            ViewBag.Nam = "Năm đã chọn: " + nam;
            ViewBag.NgayCuoiThang = "Ngày cuối cùng của tháng là: " + String.Format("{0:dd/MM/yyyy}", ngayCuoiThang);
            return View("TraVeNgayCuoiThang");
        }

        [HttpGet]
        public ActionResult TraVeNgayDauTuan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraVeNgayDauTuan(FormCollection c)
        {
            try
            {
                DateTime ngayBatKi = Convert.ToDateTime(c["ngaybatki"]);
                DateTime ngayDauTuan = Class1.TraVeNgayDauTuan(ngayBatKi).Date;
                ViewBag.NgayDaChon = "Ngày đã chọn là: " + String.Format("{0:dd/MM/yyyy}", ngayBatKi);
                ViewBag.KetQua = "Ngày đầu tuần là: " + String.Format("{0:dd/MM/yyyy}", ngayDauTuan);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }           
            return View();
        }

        [HttpGet]
        public ActionResult TraVeNgayCuoiTuan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraVeNgayCuoiTuan(FormCollection c)
        {
            try
            {
                DateTime ngayBatKi = Convert.ToDateTime(c["ngaybatki"]);
                DateTime ngayCuoiTuan = Class1.TraVeNgayCuoiTuan(ngayBatKi).Date;
                ViewBag.NgayDaChon = "Ngày đã chọn là: " + String.Format("{0:dd/MM/yyyy}", ngayBatKi);
                ViewBag.KetQua = "Ngày cuối tuần là: " + String.Format("{0:dd/MM/yyyy}", ngayCuoiTuan);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("TraVeNgayCuoiTuan");
        }

        [HttpGet]
        public ActionResult KiemTraEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KiemTraEmail(FormCollection c)
        {
            try
            {
                bool kiemTra = Class1.KiemTraEmail(c["email"]);
                if (kiemTra)
                {
                    ViewBag.KetQua = "Email hợp lệ!";
                }
                else
                {
                    ViewBag.KetQua = "Email không hợp lệ!";
                }
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            
            return View("KiemTraEmail");
        }

        [HttpGet]
        public ActionResult DemSoKhoangTrang()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DemSoKhoangTrang(FormCollection c)
        {
            int dem = Class1.DemSoKhoangTrang(c["chuoi"]);
            ViewBag.Chuoi = "Chuỗi dữ liệu vừa nhập là: " + c["chuoi"];
            ViewBag.SoKhoangTrang = "Số khoảng trắng của chuỗi dữ liệu là: " + dem;
            return View("DemSoKhoangTrang");
        }

        [HttpGet]
        public ActionResult CatChuoiHoTen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CatChuoiHoTen(FormCollection c)
        {
            int chiSo = Class1.CatChuoiHoTen(c["chuoihoten"]);
            if(chiSo > 0)
            {
                ViewBag.HoDem = "Họ đệm là: " + c["chuoihoten"].Substring(0, chiSo);
                ViewBag.Ten = "Tên là: " + c["chuoihoten"].Substring(chiSo);
            }
            else
            {
                ViewBag.ThongBao = "Không tìm thấy họ đệm và tên";
            }
            return View("CatChuoiHoTen");
        }

        [HttpGet]
        public ActionResult LamTronSoThapPhan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LamTronSoThapPhan(FormCollection c)
        {
            try
            {
                double soThapPhan = Convert.ToDouble(c["sothapphan"]);
                string dangLamTron = c["danglamtron"];
                int soChuSoThapPhan = int.Parse(c["sochusothapphan"]);
                double soLamTron = Class1.LamTronSoThapPhan(soThapPhan, dangLamTron, soChuSoThapPhan);
                ViewBag.SoThapPhan = "Kết quả trước khi làm tròn: " + soThapPhan;
                ViewBag.DangLamTron = "Dạng làm tròn đã chọn: " + dangLamTron;
                ViewBag.KetQua = "Kết quả sau khi làm tròn: " + soLamTron;
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("LamTronSoThapPhan");
        }

        [HttpGet]
        public ActionResult VietHoaKyTuDau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VietHoaKyTuDau(FormCollection c)
        {
            try
            {
                string chuoiVietHoa = Class1.VietHoaKyTuDauTien(c["chuoi"]);
                ViewBag.ChuoiVietHoa = "Kết quả: " + chuoiVietHoa;
            }
            catch
            {
                ViewBag.ThongBao = "Lỗi nhập liệu!";
            }
            return View("VietHoaKyTuDau");
        }
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
    }
}