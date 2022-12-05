using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThucHanhADOCoBan.DATA
{
    public class ThucThi
    {
        public static string connectionString = "Server=(local)\\SQLEXPRESS02; Initial Catalog=ThucTap; User ID=sa; Password=123; Application Name=Bai thuc hanh 04;";
        public void DemSVThucTap()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) " +
                        "FROM TBLSinhVien INNER JOIN TBLHuongDan ON TBLSinhVien.Masv = TBLHuongDan.Masv";
            Console.WriteLine("So sinh vien tham gia thuc tap la: " + command.ExecuteScalar());
            connection.Close();
        }

        public void InHoTenSV()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Hotensv FROM TBLSinhVien";
            var reader = command.ExecuteReader();
            Console.WriteLine("Danh sach ho ten sinh vien:");
            while (reader.Read())
            {
                var hoTenSV = reader["Hotensv"].ToString();
                Console.WriteLine(hoTenSV);
            }
            connection.Close();
        }

        public void InDeTai()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TBLDeTai";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var maDeTai = reader["Madt"].ToString();
                var tenDeTai = reader["Tendt"].ToString();
                var kinhPhi = reader["Kinhphi"];
                var noiThucTap = reader["Noithuctap"].ToString();
                Console.WriteLine("Ma de tai: {0}, Ten de tai: {1}, Kinh phi: {2}, " +
                    "Noi thuc tap: {3};", maDeTai, tenDeTai, kinhPhi, noiThucTap);
            }
            connection.Close();
        }

        public void ThemMotSinhVien()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO TBLSinhVien VALUES(9, N'Trần Nam Dương', 'Geo', 1995, 'Ho Chi Minh');";
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Them sinh vien thanh cong!");
                Console.WriteLine("Danh sach sinh vien sau khi them:");
                InDanhSachSV();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
        }

        public void CapNhatSinhVien()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE TBLSinhVien SET Namsinh = 2018, Quequan = 'Ha nam' WHERE Hotensv = 'Le Thi Van';";
            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Cap nhat sinh vien thanh cong!");
                Console.WriteLine("Danh sach sinh vien sau khi cap nhat:");
                InDanhSachSV();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();            
        }

        public void InDanhSachSV()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TBLSinhVien";
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var maSV = int.Parse(reader["Masv"].ToString());
                var hoTenSV = reader["Hotensv"].ToString();
                var maKhoa = reader["Makhoa"].ToString();
                var namSinh = reader["Namsinh"];
                var queQuan = reader["Quequan"].ToString();
                string sinhVien = "Ma sinh vien: " + maSV + ";Ho ten sinh vien: " + hoTenSV + "" +
                    ";Ma khoa: " + maKhoa + ";Nam sinh: " + namSinh + ";Que quan: " + queQuan;
                Console.WriteLine(sinhVien.Trim());
            }
            connection.Close();
        }

        public void XoaDeTai()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM TBLHuongDan WHERE Madt = 'Dt04';";
            try
            {
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM TBLDeTai WHERE Madt = 'Dt04';";
                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Xoa de tai thanh cong!");
                    Console.WriteLine("Danh sach de tai sau khi xoa:");
                    InDeTai();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
