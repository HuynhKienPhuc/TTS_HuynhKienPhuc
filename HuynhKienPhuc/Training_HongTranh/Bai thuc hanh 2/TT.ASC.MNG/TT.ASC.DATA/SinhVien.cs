using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class SinhVien: CoSo
    {
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public int GioiTinh { get; set; }
        public int LopHoc { get; set; }

        public SinhVien() { }

        public SinhVien(int ID, string Ma, string hoDem, string ten, 
            int gioiTinh, int lopHoc) : base(ID, Ma)
        {
            HoDem = hoDem;
            Ten = ten;
            GioiTinh = gioiTinh;
            LopHoc = lopHoc;
        }

        public void Copy(SinhVien pSinhVien)
        {
            ID = pSinhVien.ID;
            Ma = pSinhVien.Ma;
            HoDem = pSinhVien.HoDem;
            Ten = pSinhVien.Ten;
            GioiTinh = pSinhVien.GioiTinh;
            LopHoc = pSinhVien.LopHoc;
        }

        public int Compare(SinhVien pSinhVien)
        {
            if(this != pSinhVien)
            {
                return 1;
            }
            return 0;
        }

        public override void Print()
        {
            base.Print();
            switch (GioiTinh)
            {
                case 1:
                    Console.WriteLine("Họ đệm: {0}, Tên: {1}, Giới tính: Nam, Lớp học: {2}",
                        HoDem, Ten, GioiTinh, LopHoc);
                    break;
                case 2:
                    Console.WriteLine("Họ đệm: {0}, Tên: {1}, Giới tính: Nữ, Lớp học: {2}",
                        HoDem, Ten, GioiTinh, LopHoc);
                    break;
                case 3:
                    Console.WriteLine("Họ đệm: {0}, Tên: {1}, Giới tính: Khác, Lớp học: {2}",
                        HoDem, Ten, GioiTinh, LopHoc);
                    break;
                default:
                    break;
            }
        }

        //public bool ValidateData()
        //{
        //    if(Ma != null && HoDem != null && Ten != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
