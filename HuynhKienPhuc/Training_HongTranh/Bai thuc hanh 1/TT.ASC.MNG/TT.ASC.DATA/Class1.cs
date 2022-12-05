using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace TT.ASC.DATA
{
    public static class Class1
    {
        public static string DinhDangNgayThang(DateTime input, string kieuDinhDang)
        {
            string ketQua;
            switch (kieuDinhDang)
            {
                case "Ngày và thời gian":
                    ketQua = input.ToString();
                    break;
                case "yyyy-MM-dd":
                    ketQua = input.ToString("yyyy-MM-dd");
                    break;
                case "dd-MMM-yy":
                    ketQua = input.ToString("dd-MMM-yy");
                    break;
                case "dd/MM/yyyy":
                    ketQua = input.ToString("dd/MM/yyyy");
                    break;
                case "M/d/yy":
                    ketQua = input.ToString("M/d/yy");
                    break;
                case "MM/dd/yyyy":
                    ketQua = input.ToString("MM/dd/yyyy");
                    break;
                case "MM/dd/yy":
                    ketQua = input.ToString("MM/dd/yy");
                    break;
                case "yy/MM/dd":
                    ketQua = input.ToString("yy/MM/dd");
                    break;
                case "Năm":
                    ketQua = String.Format("{0:yyyy}", input);
                    break;
                case "Tháng":
                    ketQua = String.Format("{0:MM}", input);
                    break;
                case "Ngày":
                    ketQua = String.Format("{0:dd}", input);
                    break;
                case "Giờ":
                    ketQua = String.Format("{0:hh}", input);
                    break;
                case "Phút":
                    ketQua = String.Format("{0:mm}", input);
                    break;
                case "Giây":
                    ketQua = String.Format("{0:ss}", input);
                    break;
                case "ShortTime":
                    ketQua = String.Format("{0:t}", input);
                    break;
                case "ShortDate":
                    ketQua = String.Format("{0:d}", input);
                    break;
                case "LongTime":
                    ketQua = String.Format("{0:T}", input);
                    break;
                case "LongDate":
                    ketQua = String.Format("{0:D}", input);
                    break;
                case "LongDate+ShortTime":
                    ketQua = String.Format("{0:f}", input);
                    break;
                case "FullDateTime":
                    ketQua = String.Format("{0:F}", input);
                    break;
                case "ShortDate+ShortTime":
                    ketQua = String.Format("{0:g}", input);
                    break;
                case "ShortDate+LongTime":
                    ketQua = String.Format("{0:G}", input);
                    break;
                case "MonthDay":
                    ketQua = String.Format("{0:m}", input);
                    break;
                case "MonthYear":
                    ketQua = String.Format("{0:y}", input);
                    break;               
                default:
                    ketQua = "";
                    break;
            }

            return ketQua;
        }
        public static string DocDaySoBatKy(double daySo, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", 
                "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // lấy phần nguyên
            string sNumber = daySo.ToString("#");
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

        public static string DocSoTienBatKy(double soTien, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", 
                "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;
            string sNumber = soTien.ToString("#");
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
            return result + (suffix ? " đồng chẵn" : "");
        }

        public static string RandomKyTuVaSo(int chieuDaiChuoi, int soKyTuSo)
        {
            int soKyTuChu = chieuDaiChuoi - soKyTuSo;
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
            int[] mangSo = new int[soKyTuSo];
            for(int i = 0; i < soKyTuSo; i++)
            {
                mangSo[i] = r.Next(0, 9);
                chuoiSo += mangSo[i].ToString();
            }
            //kết hợp hai chuỗi lại
            return String.Concat(chuoiKyTu, chuoiSo);
        }

        public static DateTime TraVeNgayDauTien(int thang, int nam)
        {
            DateTime ngayDauTien = new DateTime(nam, thang, 1);
            ngayDauTien = ngayDauTien.AddDays((-ngayDauTien.Day)+1);
            return ngayDauTien.Date;
        }

        public static DateTime TraVeNgayCuoiThang(int thang, int nam)
        {
            DateTime ngayCuoiThang = new DateTime(nam, thang, 1);
            ngayCuoiThang = ngayCuoiThang.AddMonths(1);
            ngayCuoiThang = ngayCuoiThang.AddDays(-(ngayCuoiThang.Day));
            return ngayCuoiThang.Date;
        }

        public static DateTime TraVeNgayDauTuan(DateTime ngayBatKi)
        {
            //xác định ngày bất kì là thứ mấy trong tuần
            var ngayTrongTuan = ngayBatKi.DayOfWeek;

            //nếu là chủ nhật thì lùi lại 6 ngày
            if(ngayTrongTuan == DayOfWeek.Sunday)
            {
                return ngayBatKi.AddDays(-6);
            }
            //nếu không phải là chủ nhật, lùi lại cho đến thứ 2
            int offSet = DayOfWeek.Monday - ngayTrongTuan;
            return ngayBatKi.AddDays(offSet);
        }

        public static DateTime TraVeNgayCuoiTuan(DateTime ngayBatKi)
        {
            var ngayTrongTuan = ngayBatKi.DayOfWeek;
            if(ngayTrongTuan == DayOfWeek.Monday)
            {
                return ngayBatKi.AddDays(6);
            }
            int offSet = ngayTrongTuan - DayOfWeek.Monday;
            return ngayBatKi.AddDays(6 - offSet);
        }

        public static bool KiemTraEmail(string email)
        {
            try
            {
                if(email == "")
                {
                    return false;
                }
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static int DemSoKhoangTrang(string chuoi)
        {
            int dem = 0;
            for(int i = 0; i < chuoi.Length; i++)
            {
                string chuoiCon = chuoi.Substring(i, 1);
                if(chuoiCon == " ")
                {
                    dem++;
                }
            }
            return dem;
        }

        public static int CatChuoiHoTen(string hoTen)
        {
            return hoTen.LastIndexOf(" ");
        }

        public static double LamTronSoThapPhan(double soThapPhan, string dangLamTron, int soChuSoThapPhan)
        {
            double soLamTron;
            switch (dangLamTron)
            {
                case "Floor":
                    soLamTron = (double)Math.Floor(soThapPhan);
                    break;
                case "Truncate":
                    soLamTron = (double)Math.Truncate(soThapPhan);
                    break;
                case "Round":
                    soLamTron = (double)Math.Round(soThapPhan);
                    break;
                case "RoundVoiSoChuSoThapPhan":
                    soLamTron = (double)Math.Round(soThapPhan, soChuSoThapPhan);
                    break;
                case "Ceiling":
                    soLamTron = (double)Math.Ceiling(soThapPhan);
                    break;
                default:
                    soLamTron = 0;
                    break;
            }
            return soLamTron;
        }

        public static string VietHoaKyTuDauTien(string chuoi)
        {
            chuoi = chuoi.ToLower();
            //thêm khoảng trắng trước chuỗi
            chuoi = String.Concat(" ", chuoi);
            
            //chuyển chuỗi thành mảng ký tự
            char[] mang = chuoi.ToCharArray();
            //kiểm tra khoảng trắng
            bool khoangTrang = false;
            for(int i = 0; i < mang.Length; i++)
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
    }
}
