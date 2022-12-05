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
        List<TT.ASC.DATA.SinhVien> sinhViens = new List<TT.ASC.DATA.SinhVien>();
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
            string[] mangchuoi = Class1.CatChuoiHoTen(c["chuoihoten"]);
            if (mangchuoi[0] == null && mangchuoi[1] == null)
            {
                ViewBag.ThongBao = "Không tìm thấy họ đệm và tên!";
            }
            else
            {
                if (mangchuoi[0] != null)
                {
                    ViewBag.HoDem = "Họ đệm là: " + mangchuoi[0];
                }
                if (mangchuoi[1] != null)
                {
                    ViewBag.Ten = "Tên là: " + mangchuoi[1];
                }
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

        [HttpGet]
        public ActionResult TimKyTuTrongChuoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TimKyTuTrongChuoi(FormCollection form)
        {
            try
            {
                string chuoi = form["chuoi"];
                char kyTu = Convert.ToChar(form["kytu"]);
                ViewBag.Chuoi = "Chuỗi vừa nhập là: " + chuoi;
                ViewBag.KyTu = "Ký tự vừa nhập là: " + kyTu;
                ViewBag.KetQua = Class1.TimKyTuTrongChuoi(chuoi, kyTu);
            }
            catch
            {
                ViewBag.KetQua = "Lỗi nhập liệu!";
            }
            return View("TimKyTuTrongChuoi");
        }

        public ActionResult RandomHoTen()
        {
            return View();
        }

        public ActionResult Random()
        {
            ViewBag.HoTen = "Kết quả: " + Class1.RandomHoTen();
            return View("RandomHoTen");
        }

        [HttpGet]
        public ActionResult TaoListCoSo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoListCoSo(FormCollection form)
        {
            try
            {
                int soLuong = int.Parse(form["soluong"]);
                List<TT.ASC.DATA.CoSo> listCoSo = Class1.TaoListCoSo(soLuong);
                TempData["CoSo"] = listCoSo;
                return View("TaoListCoSo", listCoSo);
            }
            catch
            {
                ViewBag.ThongBao = "Lỗi nhập liệu!";
            }           
            return View("TaoListCoSo");
        }

        [HttpGet]
        public ActionResult TaoListLopHoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoListLopHoc(FormCollection form)
        {
            try
            {
                int soLuong = int.Parse(form["soluong"]);
                List<TT.ASC.DATA.LopHoc> listLopHoc = Class1.TaoListLopHoc(soLuong, 20);
                TempData["LopHoc"] = listLopHoc;
                return View("TaoListLopHoc", listLopHoc);
            }
            catch
            {
                ViewBag.ThongBao = "Lỗi nhập liệu!";
            }
            return View("TaoListLopHoc");
        }

        [HttpGet]
        public ActionResult TaoListSinhVien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaoListSinhVien(FormCollection form)
        {
            int soLuong = int.Parse(form["soluongsv"]);
            int soLuongNam = int.Parse(form["soluongnam"]);
            int soLuongNu = int.Parse(form["soluongnu"]);
            if (soLuongNam + soLuongNu != soLuong)
            {
                ViewBag.ThongBao = "Tổng số sinh viên nam và sinh viên nữ phải bằng với" +
                    "số lượng sinh viên đã nhập!";
            }
            else
            {
                List<TT.ASC.DATA.SinhVien> listSinhVien = Class1.TaoListSinhVien(
                    soLuongNam, soLuongNu);
                //TempData["SinhVien"] = listSinhVien;
                ViewBag.SoNam = "Số sinh viên nam: " + soLuongNam;
                ViewBag.SoNu = "Số sinh viên nữ: " + soLuongNu;
                return View("TaoListSinhVien", listSinhVien);
            }
            return View("TaoListSinhVien");
        }


        public ActionResult HienThiLopHoc()
        {
            if(TempData["LopHoc"] != null)
            {
                List<TT.ASC.DATA.LopHoc> listLopHoc = (List<TT.ASC.DATA.LopHoc>)TempData["LopHoc"];
                return View(listLopHoc);
            }
            ViewBag.ThongBao = "Chưa tạo danh sách lớp";
            return View();
        }

        [HttpGet]
        public ActionResult XepLopHoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XepLopHoc(FormCollection form)
        {
            int soLuongCoSo = int.Parse(form["soluongcoso"]);
            int soLuongLopHoc = int.Parse(form["soluonglophoc"]);
            int soSVMoiLop = int.Parse(form["sosvmoilop"]);
            int soLuongSinhVien = int.Parse(form["soluongsv"]);
            int soLuongNam = int.Parse(form["soluongnam"]);
            int soLuongNu = int.Parse(form["soluongnu"]);
            if (soLuongNam + soLuongNu != soLuongSinhVien)
            {
                ViewBag.ThongBao = "Tổng số sinh viên nam và sinh viên nữ phải bằng với" +
                    "số lượng sinh viên đã nhập!";
            }
            else
            {
                List<TT.ASC.DATA.CoSo> listCoSo = Class1.TaoListCoSo(soLuongCoSo);
                List<TT.ASC.DATA.LopHoc> listLopHoc = Class1.TaoListLopHoc(soLuongLopHoc,
                    soSVMoiLop);
                listLopHoc = Class1.XepLopVaoCoSo(listLopHoc, listCoSo);
                List<TT.ASC.DATA.SinhVien> listSinhVien = Class1.TaoListSinhVien(soLuongNam,
                     soLuongNu);
                listSinhVien = Class1.XepLopChoSinhVien(listSinhVien, listLopHoc);

                Session["CoSo"] = listCoSo;
                Session["LopHoc"] = listLopHoc;
                Session["SinhVien"] = listSinhVien;

                //ViewBag.SoLop = soLuongLopHoc;
                //ViewBag.SoSVMoiLop = soSVMoiLop;
                return View(listSinhVien);
            }
            return View();
        }

        public ActionResult HTSinhVienTheoLop(int? id)
        {
            if (Session["SinhVien"] != null)
            {
                List<TT.ASC.DATA.SinhVien> listSinhVien = (List<TT.ASC.DATA.SinhVien>)Session["SinhVien"];
                listSinhVien = listSinhVien.Where(n => n.LopHoc == id).ToList();
                if (listSinhVien.Count == 0)
                {
                    ViewBag.ThongBao = "Lớp hiện chưa có sinh viên nào";
                    return View();
                }
                return View(listSinhVien);
            }
            ViewBag.ThongBao = "Chưa tạo lớp sinh viên";
            return View();
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