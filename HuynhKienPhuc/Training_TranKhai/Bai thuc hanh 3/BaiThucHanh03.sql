CREATE DATABASE ThucTap
GO
USE ThucTap
GO

--USE master
--DROP DATABASE ThucTap

CREATE TABLE TBLKhoa
(Makhoa char(10)primary key,
 Tenkhoa char(30),
 Dienthoai char(10));

CREATE TABLE TBLGiangVien(
Magv int primary key,
Hotengv char(30),
Luong decimal(5,2),
Makhoa char(10) references TBLKhoa);

CREATE TABLE TBLSinhVien(
Masv int primary key,
Hotensv char(40),
Makhoa char(10)foreign key references TBLKhoa,
Namsinh int,
Quequan char(30));

CREATE TABLE TBLDeTai(
Madt char(10)primary key,
Tendt char(30),
Kinhphi int,
Noithuctap char(30));

CREATE TABLE TBLHuongDan(
Masv int primary key,
Madt char(10)foreign key references TBLDeTai,
Magv int foreign key references TBLGiangVien,
KetQua decimal(5,2));

INSERT INTO TBLKhoa VALUES
('Geo','Dia ly va QLTN',3855413),
('Math','Toan',3855411),
('Bio','Cong nghe Sinh hoc',3855412);

INSERT INTO TBLGiangVien VALUES
(11,'Thanh Binh',700,'Geo'),    
(12,'Thu Huong',500,'Math'),
(13,'Chu Vinh',650,'Geo'),
(14,'Le Thi Ly',500,'Bio'),
(15,'Tran Son',900,'Math');

INSERT INTO TBLSinhVien VALUES
(1,'Le Van Son','Bio',1990,'Nghe An'),
(2,'Nguyen Thi Mai','Geo',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Math',1992,'Ha Noi'),
(4,'Nguyen Van Tung','Bio',null,'Ha Tinh'),
(5,'Le Khanh Linh','Bio',1989,'Ha Nam'),
(6,'Tran Khac Trong','Geo',1991,'Thanh Hoa'),
(7,'Le Thi Van','Math',null,'null'),
(8,'Hoang Van Duc','Bio',1992,'Nghe An');

INSERT INTO TBLDeTai VALUES
('Dt01','GIS',100,'Nghe An'),
('Dt02','ARC GIS',500,'Nam Dinh'),
('Dt03','Spatial DB',100, 'Ha Tinh'),
('Dt04','MAP',300,'Quang Binh' );

INSERT INTO TBLHuongDan VALUES
(1,'Dt01',13,8),
(2,'Dt03',14,0),
(3,'Dt03',12,10),
(5,'Dt04',14,7),
(6,'Dt01',13,Null),
(7,'Dt04',11,10),
(8,'Dt03',15,6);

--I
--1.	Đưa ra thông tin gồm mã số, họ tên và tên khoa của tất cả các giảng viên
SELECT Magv, Hotengv, Tenkhoa
FROM TBLGiangVien JOIN TBLKhoa ON TBLGiangVien.Makhoa = TBLKhoa.Makhoa

--2.	Đưa ra thông tin gồm mã số, họ tên và tên khoa của các giảng viên của khoa ‘DIA LY va QLTN’
SELECT Magv, Hotengv, Tenkhoa
FROM TBLGiangVien JOIN TBLKhoa ON TBLGiangVien.Makhoa = TBLKhoa.Makhoa
WHERE TBLKhoa.Tenkhoa = 'Dia ly va QLTN'

--3.	Cho biết số sinh viên của khoa ‘CONG NGHE SINH HOC’
SELECT COUNT(*) AS N'Số sinh viên của khoa Công nghệ Sinh học'
FROM TBLSinhVien JOIN TBLKhoa ON TBLSinhVien.Makhoa = TBLKhoa.Makhoa
WHERE TBLKhoa.Tenkhoa = 'Cong nghe Sinh hoc'

--4.	Đưa ra danh sách gồm mã số, họ tên và tuổi của các sinh viên khoa ‘TOAN’
SELECT Masv, Hotensv, YEAR(GETDATE()) - Namsinh AS N'Tuổi'
FROM TBLSinhVien JOIN TBLKhoa ON TBLSinhVien.Makhoa = TBLKhoa.Makhoa
WHERE TBLKhoa.Tenkhoa = 'Toan'

--5.	Cho biết số giảng viên của khoa ‘CONG NGHE SINH HOC’
SELECT COUNT(*) AS N'Số giảng viên của khoa Công nghệ Sinh học'
FROM TBLGiangVien JOIN TBLKhoa ON TBLGiangVien.Makhoa = TBLKhoa.Makhoa
WHERE TBLKhoa.Tenkhoa = 'Cong nghe Sinh hoc'

--6.	Cho biết thông tin về sinh viên không tham gia thực tập
SELECT *
FROM TBLSinhVien
WHERE NOT EXISTS (SELECT Masv FROM TBLHuongDan WHERE TBLSinhVien.Masv = TBLHuongDan.Masv)

--7.	Đưa ra mã khoa, tên khoa và số giảng viên của mỗi khoa
SELECT TBLKhoa.Makhoa, Tenkhoa, COUNT(Magv) AS N'Số giảng viên của khoa'
FROM TBLKhoa JOIN TBLGiangVien ON TBLKhoa.Makhoa = TBLGiangVien.Makhoa
GROUP BY TBLKhoa.Makhoa, Tenkhoa

--8.	Cho biết số điện thoại của khoa mà sinh viên có tên ‘Le van son’ đang theo học
SELECT Dienthoai
FROM TBLKhoa JOIN TBLSinhVien ON TBLKhoa.Makhoa = TBLSinhVien.Makhoa
WHERE Hotensv = 'Le Van Son'

--II
--1.	Cho biết mã số và tên của các đề tài do giảng viên ‘Tran son’ hướng dẫn
SELECT TBLDeTai.Madt, Tendt
FROM TBLHuongDan JOIN TBLDeTai ON TBLHuongDan.Madt = TBLDeTai.Madt JOIN TBLGiangVien ON TBLHuongDan.Magv = TBLGiangVien.Magv
WHERE TBLGiangVien.Hotengv = 'Tran Son'

--2.	Cho biết tên đề tài không có sinh viên nào thực tập
SELECT Tendt
FROM TBLDeTai
WHERE NOT EXISTS (SELECT Tendt FROM TBLHuongDan WHERE TBLDeTai.Madt = TBLHuongDan.Madt)

--3.	Cho biết mã số, họ tên, tên khoa của các giảng viên hướng dẫn từ 3 sinh viên trở lên.
SELECT TBLGiangVien.Magv, Hotengv, Tenkhoa
FROM TBLGiangVien JOIN TBLKhoa ON TBLGiangVien.Makhoa = TBLKhoa.Makhoa JOIN TBLHuongDan ON TBLGiangVien.Magv = TBLHuongDan.Magv
GROUP BY TBLGiangVien.Magv, Hotengv, Tenkhoa
HAVING COUNT(TBLHuongDan.Masv) >= 3

--4.	Cho biết mã số, tên đề tài của đề tài có kinh phí cao nhất
SELECT Madt, Tendt
FROM TBLDeTai
WHERE Kinhphi = (SELECT MAX(Kinhphi) FROM TBLDeTai)

--5.	Cho biết mã số và tên các đề tài có nhiều hơn 2 sinh viên tham gia thực tập
SELECT TBLDeTai.Madt, Tendt
FROM TBLDeTai JOIN TBLHuongDan ON TBLDeTai.Madt = TBLHuongDan.Madt
GROUP BY TBLDeTai.Madt, Tendt
HAVING COUNT(Masv) > 2

--6.	Đưa ra mã số, họ tên và điểm của các sinh viên khoa ‘DIALY và QLTN’
SELECT TBLSinhVien.Masv, Hotensv, KetQua
FROM TBLSinhVien JOIN TBLHuongDan ON TBLSinhVien.Masv = TBLHuongDan.Masv JOIN TBLKhoa ON TBLSinhVien.Makhoa = TBLKhoa.Makhoa
WHERE TBLKhoa.Tenkhoa = 'Dia ly va QLTN'

--7.	Đưa ra tên khoa, số lượng sinh viên của mỗi khoa
SELECT Tenkhoa, COUNT(Masv) AS N'Số lượng sinh viên của khoa'
FROM TBLKhoa JOIN TBLSinhVien ON TBLKhoa.Makhoa = TBLSinhVien.Makhoa
GROUP BY Tenkhoa

--8.	Cho biết thông tin về các sinh viên thực tập tại quê nhà
SELECT TBLSinhVien.Masv, Hotensv, TBLSinhVien.Makhoa, Namsinh, Quequan
FROM TBLHuongDan JOIN TBLSinhVien ON TBLHuongDan.Masv = TBLSinhVien.Masv JOIN TBLDeTai ON TBLHuongDan.Madt = TBLDeTai.Madt
WHERE TBLDeTai.Noithuctap = Quequan

--9.	Hãy cho biết thông tin về những sinh viên chưa có điểm thực tập
SELECT TBLSinhVien.*
FROM TBLSinhVien JOIN TBLHuongDan ON TBLSinhVien.Masv = TBLHuongDan.Masv
WHERE TBLHuongDan.KetQua IS NULL

--10.	Đưa ra danh sách gồm mã số, họ tên các sinh viên có điểm thực tập bằng 0
SELECT TBLSinhVien.Masv, Hotensv
FROM TBLSinhVien JOIN TBLHuongDan ON TBLSinhVien.Masv = TBLHuongDan.Masv
WHERE TBLHuongDan.KetQua = 0

--SELECT * FROM TBLSinhVien
--SELECT * FROM TBLHuongDan
--DELETE FROM TBLSinhVien WHERE Masv = 9;
--SELECT * FROM TBLDeTai
--USE master
--DROP DATABASE ThucTap
--SELECT * FROM TBLDeTai
--SELECT* FROM TBLHuongDan
