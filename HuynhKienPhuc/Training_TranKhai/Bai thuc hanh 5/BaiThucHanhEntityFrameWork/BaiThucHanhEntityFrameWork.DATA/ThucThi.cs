using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaiThucHanhEntityFrameWork.DATA
{
    public class ThucThi
    {
        ThucTapEntities1 thucTapEntities = new ThucTapEntities1();
        public void InSVDiem0()
        {
            var listSinhVien = thucTapEntities.TBLHuongDans.Where(n => n.KetQua == 0);
            Console.WriteLine("Danh sach sinh vien co diem thuc tap bang 0:");
            foreach(var item in listSinhVien)
            {
                var sinhVien = thucTapEntities.TBLSinhViens.SingleOrDefault(n => n.Masv == item.Masv);
                Console.WriteLine("Ma sinh vien: {0}; Ho ten sinh vien: {1};", sinhVien.Masv, sinhVien.Hotensv);
            }
        }

        public int DemSVThucTap()
        {
            int dem = 0;
            var listSVThucTap = thucTapEntities.TBLHuongDans.Select(n => n.Masv).ToList();
            var listSV = thucTapEntities.TBLSinhViens.Select(n => n.Masv).ToList();
            foreach(var sv in listSVThucTap)
            {
                if (listSV.Contains(sv))
                {
                    dem++;
                }
            }
            return dem;
        }

        public void InHoTenSV()
        {
            var listSinhVien = thucTapEntities.TBLSinhViens;
            Console.WriteLine("Danh sach Hoten sinh vien:");
            foreach(var item in listSinhVien)
            {
                Console.WriteLine(item.Hotensv);
            }
        }

        public void XoaDeTai()
        {
            try
            {
                var deTai = thucTapEntities.TBLDeTais.SingleOrDefault(n => n.Madt == "Dt03");
                if (deTai != null)
                {
                    var check = thucTapEntities.TBLHuongDans.Where(n => n.Madt == "Dt03");
                    if(check != null)
                    {
                        foreach(var item in check)
                        {
                            thucTapEntities.TBLHuongDans.Remove(item);
                        }
                        thucTapEntities.SaveChanges();
                    }
                    thucTapEntities.TBLDeTais.Remove(deTai);
                    thucTapEntities.SaveChanges();
                    Console.WriteLine("Xoa thanh cong!");
                    Console.WriteLine("Danh sach de tai sau khi xoa: ");
                    InDSDeTai();
                }
                else
                {
                    Console.WriteLine("Khong tim thay de tai!");
                }               
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ThemSinhVien()
        {            
            try
            {
                var check = thucTapEntities.TBLSinhViens.Where(n =>
                n.Hotensv == "Ngô Nhật Long").SingleOrDefault();
                if(check != null)
                {
                    Console.WriteLine("Them khong thanh cong. Da ton tai sinh vien nay");
                }
                else
                {
                    TBLSinhVien sv = new TBLSinhVien();
                    sv.Masv = 9;
                    sv.Hotensv = "Ngô Nhật Long";
                    sv.Makhoa = "Bio";
                    sv.Namsinh = 1993;
                    sv.Quequan = "Vung Tau";
                    thucTapEntities.TBLSinhViens.Add(sv);
                    thucTapEntities.SaveChanges();
                    Console.WriteLine("Them sinh vien thanh cong");
                    Console.WriteLine("Danh sach sinh vien sau khi them:");
                    InDSSinhVien();
                }
            }
            catch(SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
            }
        }

        public void CapNhatSinhVien()
        {
            try
            {
                //Tìm sinh viên tên Tran Khac Trong
                var sinhVien = thucTapEntities.TBLSinhViens.Where(n =>
                n.Hotensv == "Tran Khac Trong").SingleOrDefault();
                sinhVien.Namsinh = 2018;
                sinhVien.Quequan = "Ha nam";
                thucTapEntities.SaveChanges();
                Console.WriteLine("Cap nhat sinh vien thanh cong!");
                Console.WriteLine("Danh sach sinh vien sau khi cap nhat:");
                InDSSinhVien();
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine(sqlex.Message);
            }
        }

        public void InDSSinhVien()
        {
            var listSinhVien = thucTapEntities.TBLSinhViens;
            foreach(var sv in listSinhVien)
            {
                Console.WriteLine("Ma sinh vien: {0}, Ho ten sinh vien: {1}, Ma khoa: {2}, " +
                    "Nam sinh: {3}, Que quan: {4};", sv.Masv, sv.Hotensv, sv.Makhoa, sv.Namsinh, 
                    sv.Quequan);
            }
        }

        public void InDSDeTai()
        {
            var listDeTai = thucTapEntities.TBLDeTais;
            foreach(var dt in listDeTai)
            {
                Console.WriteLine("Ma de tai: {0}, Ten de tai: {1}, Kinh phi: {2}, " +
                    "Noi thuc tap: {3};", dt.Madt, dt.Tendt, dt.Kinhphi, dt.Noithuctap);
            }
        }

        public void DemSVMoiDeTai()
        {
            int dem = 0;
            var listDeTai = thucTapEntities.TBLDeTais.Select(n => n.Madt).ToList();
            var listDeTaiCoSVChon = thucTapEntities.TBLHuongDans.Select(n => n.Madt).ToList();

            foreach (var item in listDeTai)
            {
                foreach (var item2 in listDeTaiCoSVChon)
                {
                    if (item2 == item)
                    {
                        dem++;
                    }
                }
                Console.WriteLine("So sinh vien cua de tai {0}: {1}", item, dem);
                dem = 0;
            }
        }
    }
}
