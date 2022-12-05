using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaiThucHanhEntityFrameWork.DATA;

namespace BaiThucHanhEntityFrameWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThucThi thucThi = new ThucThi();
            Console.WriteLine("1. Dua ra danh sach gom ma so, ho ten cac sinh vien co diem " +
                "thuc tap bang 0");
            Console.WriteLine("2. Dem so luong sinh vien thuc tap");
            Console.WriteLine("3. In ra man hinh danh sach HoTen sinh vien");
            Console.WriteLine("4. Them mot sinh vien ten: Ngo Nhat Long/Bio/1993/VungTau");
            Console.WriteLine("5. Cap nhat sinh vien 'Tran Khac Trong' nam sinh 2018, " +
                "que quan Ha nam");
            Console.WriteLine("6. Xoa de tai 'Dt03'");
            Console.WriteLine("7. Dem so luong sinh vien cua moi de tai.");
            Console.WriteLine("0. Thoat khoi chuong trinh.");
            string yeuCau;
            bool isExit = true;
            do
            {
                Console.WriteLine("Nhap yeu cau: ");
                yeuCau = Console.ReadLine();
                switch (yeuCau)
                {
                    case "1":
                        thucThi.InSVDiem0();
                        break;
                    case "2":
                        int soSVThucTap = thucThi.DemSVThucTap();
                        Console.WriteLine("So sinh vien thuc tap: {0}", soSVThucTap);
                        break;
                    case "3":
                        thucThi.InHoTenSV();
                        break;
                    case "4":
                        thucThi.ThemSinhVien();
                        break;
                    case "5":
                        thucThi.CapNhatSinhVien();
                        break;
                    case "6":
                        thucThi.XoaDeTai();
                        break;
                    case "7":
                        thucThi.DemSVMoiDeTai();
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
            while (isExit);
                                  
        }
    }
}
