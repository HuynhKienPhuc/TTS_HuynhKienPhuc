﻿CREATE DATABASE ThucTap_DoAn
GO
USE ThucTap_DoAn
GO

--USE master
--DROP DATABASE ThucTap_DoAn

CREATE TABLE TBL_SinhVien
(
	Mssv VARCHAR(10) NOT NULL,
	Hoten NVARCHAR(30),
	Gioitinh NVARCHAR(10),
	Ngaysinh DATE,
	Lophoc VARCHAR(10),
	Mail VARCHAR(50),
	MatKhau NVARCHAR(100),
	PRIMARY KEY (Mssv)
)

CREATE TABLE TBL_KhoanThuMonHoc
(
	Id int identity(1,1) PRIMARY KEY NOT NULL,
	MaMH VARCHAR(100),
	TenMH NVARCHAR(200),
	SoTC INT,
	SoTiet INT,
	DonGia DECIMAL
)

CREATE TABLE TBL_DangKy
(
	MaDangKy VARCHAR(30) NOT NULL,
	Mssv VARCHAR(10),
	HocKi VARCHAR(30),
	NgayDK DATE,
	MaMH VARCHAR(100)
)

CREATE TABLE TBL_PhieuThu
(
	SoPhieu VARCHAR(100) PRIMARY KEY NOT NULL,
	Mssv VARCHAR(10),
	NoiDung NVARCHAR(100),
	NgayThanhToan DATE,
	SoTienThu DECIMAL,
	DonViThu NVARCHAR(100),
	TrangThai NVARCHAR(20),
)
ALTER TABLE TBL_PhieuThu
ADD CONSTRAINT fk_TBL_PhieuThu_TBL_SinhVien foreign key (Mssv) references TBL_SinhVien(Mssv)

CREATE TABLE TBL_ChiTietPhieuThu
(
	SoPhieu VARCHAR(100) NOT NULL,
	MaMH VARCHAR(100) NOT NULL,
	PRIMARY KEY(SoPhieu,MaMH)
)

CREATE TABLE TBL_ThanhToan
(
	Idtt VARCHAR(100) PRIMARY KEY NOT NULL,
	Mssv VARCHAR(10),
	SoPhieu VARCHAR(100),
	SoThe INT,
	TenThe VARCHAR(100),
	So INT,
	NgayHetHan DATE
)

INSERT INTO TBL_SinhVien VALUES
('SV001', N'Huỳnh Kiến Phúc', N'Nam', '05/19/2001', '10DHTH2', 'kphuc2015@gmail.com', '123'),
('SV002', N'Nguyễn Thị Thu Hà', N'Nữ', '11/09/1998', '10DHTH1', 'thuha1998@gmail.com', '123'),
('SV003', N'Phạm Thu Anh', N'Nữ', '10/19/1998', '10DHTH2', 'thuanh1998@gmail.com', '123'),
('SV004', N'Nguyễn Gia Huy', N'Nam', '09/01/2002', '10DHTH3', 'giahuy2002@gmail.com', '123'),
('SV005', N'Tạ Quang Anh', N'Nam', '05/19/1999', '10DHTH4', 'quanganh1999@gmail.com', '123'),
('SV006', N'Huỳnh Văn Quyết', N'Nam', '08/20/2000', '10DHTH5', 'vanquyet2000@gmail.com', '123');

SET DATEFORMAT mdy
INSERT INTO TBL_PhieuThu VALUES
('5647383', 'SV001', N'Thu học phí', '11/13/2022', 7020000, N'Ngân hàng Phương Đông', N'Thành công'),
('6957963', 'SV002', N'Thu học phí', '11/12/2022', 9700000, N'Ngân hàng OCB', N'Thành công'),
('4685836', 'SV003', N'Thu học phí', '11/11/2022', 12478250, N'Ngân hàng Agribank', N'Giao dịch đã hủy'),
('8564387', 'SV004', N'Thu học phí', '11/10/2022', 14230000, N'Ngân hàng Phương Đông', N'Thành công'),
('7089568', 'SV005', N'Thu học phí', '11/09/2022', 563220, N'Ngân hàng ABC', N'Giao dịch đã hủy');

INSERT INTO TBL_KhoanThuMonHoc VALUES
('MH1',N'Nhập môn lập trình',3,45,1695000),
('MH2',N'Xác suất thống kê',3,45,1695000),
('MH3',N'Chủ nghĩa xã hội khoa học',2,30,1130000),
('MH4',N'Cấu trúc dữ liệu và giải thuật',2,30,1170000),
('MH5',N'Hệ điều hành',3,45,1755000),
('MH6',N'Lập trình Web',3,45,2095000),
('MH7',N'Công nghệ .NET',3,45,1990250),
('MH8',N'Kho dữ liệu và OLAP',2,30,1170000),
('MH9',N'Khoá luận tốt nghiệp',8,240,4680000),
('MH10',N'Thực tập nghề nghiệp',4,0,2340000);

insert into TBL_ChiTietPhieuThu values('1001','MH1'),
('5647383','MH2'),
('5647383','MH3'),
('6957963','MH1'),
('6957963','MH2'),
('6957963','MH4'),
('4685836','MH1'),
('4685836','MH2'),
('8564387','MH6');

--Phúc
GO
CREATE PROC sp_GetAllPhieuThu
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
END;
GO

CREATE PROC sp_GetEmailSinhVien(@mssv VARCHAR(20))
AS
DECLARE @email VARCHAR(20)
BEGIN
	SET @email = (SELECT sv.Mail
	FROM TBL_SinhVien sv
	WHERE sv.Mssv = @mssv)
	SELECT @email
END;
GO

CREATE PROC sp_GetSinhVien @mssv VARCHAR(20), @matkhau NVARCHAR(100)
AS
BEGIN
	SELECT sv.Mssv, sv.Hoten, sv.Gioitinh, sv.Ngaysinh, sv.Lophoc, sv.Mail, sv.MatKhau
	FROM TBL_SinhVien sv
	WHERE sv.Mssv = @mssv AND sv.MatKhau = @matkhau
END;
GO

CREATE PROC sp_GetTrangThai
AS
BEGIN
	SELECT DISTINCT pt.TrangThai
	FROM TBL_PhieuThu pt
END;
GO

CREATE PROC sp_GetPhieuThuBySoPhieu
@sophieu VARCHAR(100)
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.SoPhieu = @sophieu
END;
GO

CREATE PROC sp_GetPhieuThuByMaSV
@masv VARCHAR(10)
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.Mssv = @masv 
END;
GO

CREATE PROC sp_GetPhieuThuByMasvAndSoPhieu
@masv VARCHAR(10), @sophieu VARCHAR(100)
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.Mssv = @masv AND pt.SoPhieu = @sophieu 
END;
GO

CREATE PROC sp_GetPhieuThuByNgayThanhToan
@ngaybatdau DATETIME, @ngayketthuc DATETIME
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.NgayThanhToan >= @ngaybatdau AND pt.NgayThanhToan <= @ngayketthuc
END;
GO

CREATE PROC sp_GetPhieuThuByAll
@masv VARCHAR(10), @sophieu VARCHAR(100), @ngaybatdau DATETIME, @ngayketthuc DATETIME
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.SoPhieu = @sophieu AND pt.Mssv = @masv AND pt.NgayThanhToan >= @ngaybatdau AND pt.NgayThanhToan <= @ngayketthuc
END;
GO

CREATE PROC sp_GetPhieuThuByTrangThai
@trangthai NVARCHAR(50)
AS
BEGIN
	SELECT pt.SoPhieu, pt.Mssv, pt.NoiDung, pt.NgayThanhToan, pt.SoTienThu, pt.DonViThu, pt.TrangThai
	FROM TBL_PhieuThu pt
	WHERE pt.TrangThai LIKE @trangthai
END;
GO

CREATE PROC sp_ChiTietPhieuThu @soPhieu VARCHAR(100)
AS
BEGIN
    SELECT ct.SoPhieu,ct.MaMH,pt.NoiDung,mh.DonGia
	FROM TBL_ChiTietPhieuThu ct 
	INNER JOIN TBL_KhoanThuMonHoc mh on ct.MaMH=mh.MaMH 
	INNER JOIN TBL_PhieuThu pt on ct.SoPhieu=pt.SoPhieu
	WHERE ct.SoPhieu=@soPhieu
END
GO

CREATE PROC sp_GetTenMonHocByMaMH
@mamh VARCHAR(100)
AS
DECLARE @tenmh NVARCHAR(50)
BEGIN
	SET @tenmh = (SELECT mh.TenMH FROM TBL_KhoanThuMonHoc mh WHERE mh.MaMH = @mamh) 
	SELECT @tenmh AS N'Tên môn học'
END
GO

CREATE PROC sp_GetDonGiaByMaMH
@mamh VARCHAR(100)
AS
DECLARE @dongia DECIMAL
BEGIN
	SET @dongia = (SELECT mh.DonGia FROM TBL_KhoanThuMonHoc mh WHERE mh.MaMH = @mamh)
	SELECT @dongia AS N'Đơn giá'
END
GO
--Tân
--SELECT 
	CREATE PROC sp_KhoanThu
	AS
	SELECT * FROM TBL_KhoanThuMonHoc 


-- INSERT
	CREATE PROC sp_Insert_KhoanThu
	   @Mamh VARCHAR(100) , 
       @Tenmh NVARCHAR(200) ,
	   @Sotc INT, 
       @Sotiet INT, 
       @Dongia DECIMAL  
	AS
	BEGIN
		IF EXISTS(SELECT *FROM TBL_KhoanThuMonHoc WHERE MaMH=@Mamh)
			BEGIN
				RETURN -1 
			END
		INSERT INTO TBL_KhoanThuMonHoc(MaMH,TenMH,SoTC,SoTiet,DonGia) VALUES
		(@Mamh,@Tenmh,@Sotc,@Sotiet,@Dongia)
	END
	
--Update
	CREATE PROC sp_Update_KhoanThu
	   @id int,
	   @Mamh VARCHAR(100) , 
       @Tenmh NVARCHAR(200) ,
	   @Sotc INT, 
       @Sotiet INT, 
       @Dongia DECIMAL 
	AS
	BEGIN
		UPDATE TBL_KhoanThuMonHoc
		SET MaMH= @Mamh , TenMH = @TenMH, SoTC=@Sotc,SoTiet=@Sotiet,DonGia=@Dongia
		WHERE Id=@id
	END

--Delete
	CREATE PROC sp_Delete_KhoanThu
	   @id int
	AS
	BEGIN
		DELETE TBL_KhoanThuMonHoc
		WHERE Id=@id
	END

--Danh
create function getgiaTienMH(@MaMH nchar(10))
returns decimal
as
begin
	declare @tien  decimal
	select @tien = DonGia
	from TBL_KhoanThuMonHoc 
	where MaMH = @MaMH
	return @tien
end

create function [dbo].[GetTBLSoPhieu_CT](@SoPhieu VARCHAR(20))
returns table
AS
	return(select ct.MaMH,TenMH,SoTC,SoTiet,DonGia,HocKi,NgayDK from TBL_ChiTietPhieuThu ct
	inner join TBL_KhoanThuMonHoc kt on ct.MaMH = kt.MaMH
	inner join TBL_DangKy dk on kt.MaMH = dk.MaMH 
	where  SoPhieu =@SoPhieu)

create function [dbo].[GetDangKySinhVien](@mssv VARCHAR(20))
returns table
AS
	return(select kt.MaMH,kt.TenMH,kt.DonGia,dk.NgayDK,kt.SoTC,dk.HocKi from TBL_DangKy dk,TBL_KhoanThuMonHoc kt where dk.MaMH = kt.MaMH AND dk.Mssv = @mssv)

create PROC [dbo].[sp_SinhVien] @Mssv VARCHAR(10),@matkhau VARCHAR(50)
AS
BEGIN
	select Mssv
	from TBL_SinhVien
	where Mssv = @Mssv and matkhau = @matkhau
END;

--EXEC sp_GetDonGiaByMaMH 'MH1'
--exec sp_ChiTietPhieuThu '5647383'
--EXEC sp_GetAllPhieuThu
--EXEC sp_GetEmailSinhVien 'SV001'
--DROP PROC IF EXISTS sp_GetEmailSinhVien
--EXEC sp_GetSinhVien 'SV001', '123'
--EXEC sp_GetTrangThai
--EXEC sp_GetPhieuThuByHoTenAndSoPhieu '5647383', N'Huỳnh Kiến Phúc'
--DROP PROC IF EXISTS sp_GetPhieuThuByTrangThai
--SELECT* FROM TBL_DangKy
