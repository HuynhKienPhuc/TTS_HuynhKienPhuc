using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiThucHanhADOCoBan.DATA;

namespace BaiThucHanhADOCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ThucThi thucThi = new ThucThi();

            Console.WriteLine("1. Dem so luong sinh vien thuc tap");
            Console.WriteLine("2. In ra man hinh danh sach HoTen sinh vien");
            Console.WriteLine("3. Them mot sinh vien ten: Tran Nam Duong/Geo/1995/Ho Chi Minh");
            Console.WriteLine("4. Cap nhat sinh vien Le Thi Van nam sinh 2018, Que quan Ha nam");
            Console.WriteLine("5. Xoa de tai Dt04");
            Console.WriteLine("0. Thoat khoi chuong trinh");
            string yeuCau;
            bool isExit = true;
            do
            {
                Console.WriteLine("Nhap yeu cau: ");
                yeuCau = Console.ReadLine();
                switch (yeuCau)
                {
                    case "1":
                        thucThi.DemSVThucTap();
                        break;
                    case "2":
                        thucThi.InHoTenSV();
                        break;
                    case "3":
                        thucThi.ThemMotSinhVien();
                        break;
                    case "4":
                        thucThi.CapNhatSinhVien();
                        break;
                    case "5":
                        thucThi.XoaDeTai();
                        break;
                    case "0":
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("Khong co yeu cau tren");
                        break;
                }
                Console.ReadKey();
            }
            while(isExit);
        }
    }
}
