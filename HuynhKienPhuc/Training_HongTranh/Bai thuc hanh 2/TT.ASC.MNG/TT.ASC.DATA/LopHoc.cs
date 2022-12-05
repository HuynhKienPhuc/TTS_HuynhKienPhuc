using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT.ASC.DATA
{
    public class LopHoc:CoSo
    {
        public string TenLop { get; set; }
        public int SoLuong { get; set; }
        public int NamMoLop { get; set; }
        public int CoSoDaoTao { get; set; }
        public bool HienThi { get; set; }

        public LopHoc() { }

        public LopHoc(int ID, string Ma, string TenLop, int SoLuong, int NamMoLop, int 
            CoSoDaoTao, bool HienThi) : base(ID, Ma)
        {
            this.TenLop = TenLop;
            this.SoLuong = SoLuong;
            this.NamMoLop = NamMoLop;
            this.CoSoDaoTao = CoSoDaoTao;
            this.HienThi = HienThi;
        }

        public void Copy(LopHoc pLopHoc)
        {
            ID = pLopHoc.ID;
            Ma = pLopHoc.Ma;
            TenLop = pLopHoc.TenLop;
            SoLuong = pLopHoc.SoLuong;
            NamMoLop = pLopHoc.NamMoLop;
            CoSoDaoTao = pLopHoc.CoSoDaoTao;
            HienThi = pLopHoc.HienThi;
        }

        public int Compare(LopHoc pLopHoc)
        {
            if(this != pLopHoc)
            {
                return 1;
            }
            return 0;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Tên lớp: {0}, Số lượng: {1}, Năm mở lớp: {2}, Cơ sở đào tạo: " +
                "{3}, Hiển thị: {4};", TenLop, SoLuong, NamMoLop, CoSoDaoTao, HienThi);
        }

        public bool ValidateData()
        {
            if(Ma != null && TenLop != null)
            {
                return true;
            }
            return false;
        }
    }
}
