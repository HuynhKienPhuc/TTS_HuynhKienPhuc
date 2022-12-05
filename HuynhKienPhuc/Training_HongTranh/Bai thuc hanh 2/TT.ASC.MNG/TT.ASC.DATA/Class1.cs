using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Runtime.Serialization.Formatters;

namespace TT.ASC.DATA
{
    public static class Class1
    {

        #region string
        public static string DinhDangNgayThang(DateTime pInput, string pKieuDinhDang)
        {
            string ketQua;
            switch (pKieuDinhDang)
            {
                case "Ngày và thời gian":
                    ketQua = pInput.ToString();
                    break;
                case "yyyy-MM-dd":
                    ketQua = pInput.ToString("yyyy-MM-dd");
                    break;
                case "dd-MMM-yy":
                    ketQua = pInput.ToString("dd-MMM-yy");
                    break;
                case "dd/MM/yyyy":
                    ketQua = pInput.ToString("dd/MM/yyyy");
                    break;
                case "M/d/yy":
                    ketQua = pInput.ToString("M/d/yy");
                    break;
                case "MM/dd/yyyy":
                    ketQua = pInput.ToString("MM/dd/yyyy");
                    break;
                case "MM/dd/yy":
                    ketQua = pInput.ToString("MM/dd/yy");
                    break;
                case "yy/MM/dd":
                    ketQua = pInput.ToString("yy/MM/dd");
                    break;
                case "Năm":
                    ketQua = String.Format("{0:yyyy}", pInput);
                    break;
                case "Tháng":
                    ketQua = String.Format("{0:MM}", pInput);
                    break;
                case "Ngày":
                    ketQua = String.Format("{0:dd}", pInput);
                    break;
                case "Giờ":
                    ketQua = String.Format("{0:hh}", pInput);
                    break;
                case "Phút":
                    ketQua = String.Format("{0:mm}", pInput);
                    break;
                case "Giây":
                    ketQua = String.Format("{0:ss}", pInput);
                    break;
                case "ShortTime":
                    ketQua = String.Format("{0:t}", pInput);
                    break;
                case "ShortDate":
                    ketQua = String.Format("{0:d}", pInput);
                    break;
                case "LongTime":
                    ketQua = String.Format("{0:T}", pInput);
                    break;
                case "LongDate":
                    ketQua = String.Format("{0:D}", pInput);
                    break;
                case "LongDate+ShortTime":
                    ketQua = String.Format("{0:f}", pInput);
                    break;
                case "FullDateTime":
                    ketQua = String.Format("{0:F}", pInput);
                    break;
                case "ShortDate+ShortTime":
                    ketQua = String.Format("{0:g}", pInput);
                    break;
                case "ShortDate+LongTime":
                    ketQua = String.Format("{0:G}", pInput);
                    break;
                case "MonthDay":
                    ketQua = String.Format("{0:m}", pInput);
                    break;
                case "MonthYear":
                    ketQua = String.Format("{0:y}", pInput);
                    break;               
                default:
                    ketQua = "";
                    break;
            }

            return ketQua;
        }
        public static string DocDaySoBatKy(double pDaySo)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", 
                "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // lấy phần nguyên
            string sNumber = pDaySo.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }
            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    // lấy số hàng đơn vị
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        // lấy số hàng chục
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            // lấy số hàng trăm
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result;
        }

        public static string DocSoTienBatKy(double pSoTien, bool pSuffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", 
                "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;
            string sNumber = pSoTien.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }
            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (pSuffix ? " đồng chẵn" : "");
        }

        public static string RandomKyTuVaSo(int pChieuDaiChuoi, int pSoKyTuSo)
        {
            int soKyTuChu = pChieuDaiChuoi - pSoKyTuSo;
            string chuoiKyTu = "";
            string chuoiSo = "";

            string[] mangKyTu = new string[soKyTuChu];
            //tạo hàm random
            Random r = new Random();
            //tạo chuỗi ký tự ngẫu nhiên
            for(int i = 0; i < soKyTuChu; i++)
            {
                mangKyTu[i] = Convert.ToChar(Convert.ToInt32(r.Next(65, 87))).ToString();
                chuoiKyTu += mangKyTu[i].ToString();
            }
            //tạo chuỗi ký tự số ngẫu nhiên
            int[] mangSo = new int[pSoKyTuSo];
            for(int i = 0; i < pSoKyTuSo; i++)
            {
                mangSo[i] = r.Next(0, 9);
                chuoiSo += mangSo[i].ToString();
            }
            //kết hợp hai chuỗi lại
            return String.Concat(chuoiKyTu, chuoiSo);
        }

        public static string[] CatChuoiHoTen(string pHoTen)
        {
            string[] mangChuoi = new string[2];
            int viTriKhoangTrang = pHoTen.LastIndexOf(" ");

            mangChuoi[0] = pHoTen.Substring(0, viTriKhoangTrang);
            mangChuoi[1] = pHoTen.Substring(viTriKhoangTrang);

            return mangChuoi;
        }

        public static string VietHoaKyTuDauTien(string pChuoi)
        {
            pChuoi = pChuoi.ToLower();
            //thêm khoảng trắng trước chuỗi
            pChuoi = String.Concat(" ", pChuoi);

            //chuyển chuỗi thành mảng ký tự
            char[] mang = pChuoi.ToCharArray();
            //kiểm tra khoảng trắng
            bool khoangTrang = false;
            for (int i = 0; i < mang.Length; i++)
            {
                if (Char.IsLetter(mang[i]))
                {
                    if (khoangTrang)
                    {
                        mang[i] = Char.ToUpper(mang[i]);
                        khoangTrang = false;
                    }
                }
                else if (!Char.IsDigit(mang[i]))
                {
                    khoangTrang = true;
                }
                else
                {
                    khoangTrang = false;
                }
            }
            string chuoiVietHoa = new string(mang);
            //xóa khoảng trắng trước chuỗi
            chuoiVietHoa = chuoiVietHoa.Substring(1);

            return chuoiVietHoa;
        }

        public static string TimKyTuTrongChuoi(string pChuoi, char pKyTu)
        {
            string ketQua = "";
            int dem = 0;
            string cacViTri = "";
            for(int i = 0; i < pChuoi.Length; i++)
            {
                char kyTu = Convert.ToChar(pChuoi.Substring(i, 1));
                if(kyTu == pKyTu)
                {
                    dem++;
                    cacViTri = cacViTri + i + ", ";
                }
            }
            ketQua = "Số lượng: " + dem + "; Vị trí thứ " + cacViTri;
            return ketQua;
        }

        public static string RandomHoTen()
        {
            string hoTen = "";
            string[] ho = { "Nguyễn", "Trần", "Lê", "Hồ" };
            string[] dem = { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc"};
            string[] ten = { "Nhân", "Hậu", "Nghĩa", "Lê", "Trí", "Tín", "Trang", "Thúy", 
            "Phương", "Hiếu"};
            Random r = new Random();
            hoTen = hoTen + ho[r.Next(0, ho.Length)]+ " " + dem[r.Next(0, ho.Length)]
                + " " + ten[r.Next(0, ho.Length)];
            return hoTen;
        }

        #endregion

        #region DateTime
        public static DateTime TraVeNgayDauTien(int pThang, int pNam)
        {
            DateTime ngayDauTien = new DateTime(pNam, pThang, 1);
            ngayDauTien = ngayDauTien.AddDays((-ngayDauTien.Day)+1);
            return ngayDauTien.Date;
        }

        public static DateTime TraVeNgayCuoiThang(int pThang, int pNam)
        {
            DateTime ngayCuoiThang = new DateTime(pNam, pThang, 1);
            ngayCuoiThang = ngayCuoiThang.AddMonths(1);
            ngayCuoiThang = ngayCuoiThang.AddDays(-(ngayCuoiThang.Day));
            return ngayCuoiThang.Date;
        }

        public static DateTime TraVeNgayDauTuan(DateTime pNgayBatKi)
        {
            //xác định ngày bất kì là thứ mấy trong tuần
            var ngayTrongTuan = pNgayBatKi.DayOfWeek;

            //nếu là chủ nhật thì lùi lại 6 ngày
            if(ngayTrongTuan == DayOfWeek.Sunday)
            {
                return pNgayBatKi.AddDays(-6);
            }
            //nếu không phải là chủ nhật, lùi lại cho đến thứ 2
            int offSet = DayOfWeek.Monday - ngayTrongTuan;
            return pNgayBatKi.AddDays(offSet);
        }

        public static DateTime TraVeNgayCuoiTuan(DateTime pNgayBatKi)
        {
            var ngayTrongTuan = pNgayBatKi.DayOfWeek;
            if(ngayTrongTuan == DayOfWeek.Monday)
            {
                return pNgayBatKi.AddDays(6);
            }
            int offSet = ngayTrongTuan - DayOfWeek.Monday;
            return pNgayBatKi.AddDays(6 - offSet);
        }
        #endregion

        public static bool KiemTraEmail(string pEmail)
        {
            try
            {
                if(pEmail == "")
                {
                    return false;
                }
                MailAddress mail = new MailAddress(pEmail);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int DemSoKhoangTrang(string pChuoi)
        {
            int dem = 0;
            for(int i = 0; i < pChuoi.Length; i++)
            {
                string chuoiCon = pChuoi.Substring(i, 1);
                if(chuoiCon == " ")
                {
                    dem++;
                }
            }
            return dem;
        }

        public static double LamTronSoThapPhan(double pSoThapPhan, string pDangLamTron, int pSoChuSoThapPhan)
        {
            double soLamTron;
            switch (pDangLamTron)
            {
                case "Floor":
                    soLamTron = (double)Math.Floor(pSoThapPhan);
                    break;
                case "Truncate":
                    soLamTron = (double)Math.Truncate(pSoThapPhan);
                    break;
                case "Round":
                    soLamTron = (double)Math.Round(pSoThapPhan);
                    break;
                case "RoundVoiSoChuSoThapPhan":
                    soLamTron = (double)Math.Round(pSoThapPhan, pSoChuSoThapPhan);
                    break;
                case "Ceiling":
                    soLamTron = (double)Math.Ceiling(pSoThapPhan);
                    break;
                default:
                    soLamTron = 0;
                    break;
            }
            return soLamTron;
        }

        #region List
        public static List<CoSo> TaoListCoSo(int pSoLuong)
        {
            List<CoSo> listCoSo = new List<CoSo>();
            Random r = new Random();
            for (int i = 0; i < pSoLuong; i++)
            {
                CoSo coSo = new CoSo();               
                coSo.ID = r.Next(1000, 9999);
                coSo.Ma = "CS" + r.Next(1000, 9999);
                coSo.Ten = "Cơ sở số " + r.Next(100, 999);
                listCoSo.Add(coSo);
            }
            return listCoSo;
        }

        public static List<LopHoc> TaoListLopHoc(int pSoLuong, int soSVMoiLop)
        {
            List<LopHoc> listLopHoc = new List<LopHoc>();
            Random r = new Random();
            for(int i = 0; i < pSoLuong; i++)
            {
                LopHoc lopHoc = new LopHoc();
                lopHoc.ID = r.Next(1000, 9999);
                lopHoc.Ma = "LOP" + r.Next(1000, 9999);
                lopHoc.TenLop = "Lớp học số " + lopHoc.ID;
                lopHoc.SoLuong = soSVMoiLop;
                lopHoc.NamMoLop = r.Next(2000, DateTime.Now.Year);
                lopHoc.CoSoDaoTao = -1;
                lopHoc.HienThi = true;
                listLopHoc.Add(lopHoc);
            }
            return listLopHoc;
        }

        public static List<SinhVien> TaoListSinhVien(int pSoSVNam, int pSoSVNu)
        {
            List<SinhVien> listSinhVien = new List<SinhVien>();
            Random r = new Random();
            for(int i = 0; i < pSoSVNam; i++)
            {
                SinhVien sinhVien = new SinhVien();
                sinhVien.ID = r.Next(1000, 9999);
                sinhVien.Ma = "SV" + r.Next(100, 999);

                string hoTen = "";
                string[] ho = { "Nguyễn", "Trần", "Lê", "Hồ", "Phạm", "Huỳnh", "Đặng", 
                "Lý", "Quế"};
                string[] dem = { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc", "Gia", 
                };
                string[] ten = { "Nhân", "Hậu", "Nghĩa", "Lê", "Trí", "Tín", "Trang", "Thúy",
                "Phương", "Hiếu", "Phúc", "Huy", "Chí", "Thanh", "Dũng", "Phong", "Phương", 
                "Nhi", "Đạt", "Tài", "Đức", "Minh", "Khang", "Thái"};
                //Random r = new Random();
                hoTen = hoTen + ho[r.Next(0, ho.Length)] + " " + dem[r.Next(0, dem.Length)]
                    + " " + ten[r.Next(0, ten.Length)];

                string[] mangHoTen = CatChuoiHoTen(hoTen);
                sinhVien.HoDem = mangHoTen[0];
                sinhVien.Ten = mangHoTen[1];
                sinhVien.GioiTinh = 1;
                sinhVien.LopHoc = -1;
                listSinhVien.Add(sinhVien);
            }
            for (int i = 0; i < pSoSVNu; i++)
            {
                SinhVien sinhVien = new SinhVien();
                sinhVien.ID = r.Next(1000, 9999);
                sinhVien.Ma = "SV" + r.Next(100, 999);

                string hoTen = "";
                string[] ho = { "Nguyễn", "Trần", "Lê", "Hồ", "Phạm", "Huỳnh", "Đặng",
                "Lý", "Quế"};
                string[] dem = { "Văn", "Thanh", "Hoàng", "Thị", "Kim", "Ngọc", "Gia",
                };
                string[] ten = { "Nhân", "Hậu", "Nghĩa", "Lê", "Trí", "Tín", "Trang", "Thúy",
                "Phương", "Hiếu", "Phúc", "Huy", "Chí", "Thanh", "Dũng", "Phong", "Phương",
                "Nhi", "Đạt", "Tài", "Đức", "Minh", "Khang", "Thái"};
                //Random r = new Random();
                hoTen = hoTen + ho[r.Next(0, ho.Length)] + " " + dem[r.Next(0, dem.Length)]
                    + " " + ten[r.Next(0, ten.Length)];

                string[] mangHoTen = CatChuoiHoTen(hoTen);
                sinhVien.HoDem = mangHoTen[0];
                sinhVien.Ten = mangHoTen[1];
                sinhVien.GioiTinh = 2;
                sinhVien.LopHoc = -1;
                listSinhVien.Add(sinhVien);
            }

            return listSinhVien;
        }

        public static List<LopHoc> XepLopVaoCoSo(List<LopHoc> pListLopHoc, List<CoSo> pListCoSo)
        {
            List<LopHoc> listLopHoc = pListLopHoc;
            int index = 0;

            foreach(var lh in listLopHoc)
            {
                while(lh.CoSoDaoTao == -1)
                {
                    if (index < pListCoSo.Count)
                    {
                        lh.CoSoDaoTao = pListCoSo[index].ID;
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }               
            }
            return listLopHoc;
        }

        public static List<SinhVien> XepLopChoSinhVien(List<SinhVien> pListSinhVien, List<LopHoc> 
            pListLopHoc)
        {
            List<SinhVien> listSinhVien = pListSinhVien;
            int index = 0;

            foreach(var sv in pListSinhVien)
            {
                while(sv.LopHoc == -1)
                {
                    if (index < pListLopHoc.Count)
                    {
                        int dem = 0;
                        //đếm số sinh viên trong lớp
                        foreach (var sv1 in pListSinhVien)
                        {
                            if (sv1.LopHoc == pListLopHoc[index].ID)
                            {
                                dem++;
                            }
                        }
                        if (dem < pListLopHoc[index].SoLuong)
                        {
                            sv.LopHoc = pListLopHoc[index].ID;
                        }
                        else
                        {
                            break;
                        }
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }
            return listSinhVien;
        }

        #endregion
    }
}
