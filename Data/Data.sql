CREATE DATABASE QuanLyBanGaRan
GO

USE QuanLyBanGaRan
GO

CREATE TABLE ChiNhanh
(
	MaCN NVARCHAR(20) PRIMARY KEY,
	TenCN NVARCHAR(50) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL,
	isDeleted INT DEFAULT 0
)

CREATE TABLE NhanVien
(
	MaNV NVARCHAR(20) PRIMARY KEY,
	TenNV NVARCHAR(50) NOT NULL,
	NgaySinh DATE NOT NULL,
	GioiTinh NVARCHAR(5) NOT NULL,
	DiaChi NVARCHAR(50) NOT NULL,
	SDT NVARCHAR(11) NOT NULL,
	CMND NVARCHAR(50) NOT NULL,
	Quyen INT NOT NULL DEFAULT 0,   --0: NhanVien 1:QuanLy 2:Admin
	TenDangNhap NVARCHAR(20) NOT NULL,
	MatKhau NVARCHAR(50) NOT NULL,
	MaCN NVARCHAR(20) NOT NULL,
	isDeleted INT DEFAULT 0

	FOREIGN KEY (MaCN) REFERENCES ChiNhanh(MaCN)
)
GO

CREATE TABLE KhachHang
(
	MaKH NVARCHAR(20) PRIMARY KEY,
	TenKH NVARCHAR(50) NOT NULL,
	SDT NVARCHAR(11) NOT NULL,
	isDeleted INT DEFAULT 0
)
GO

CREATE TABLE DanhMuc
(
	MaDM NVARCHAR(20) PRIMARY KEY,
	TenDM NVARCHAR(50) NOT NULL DEFAULT N'Chưa đặt tên',
	isDeleted INT DEFAULT 0
)
GO

CREATE TABLE NguyenLieu
(
	MaNL NVARCHAR(20) PRIMARY KEY,
	TenNL NVARCHAR(50) NOT NULL,
	SoLuongTon INT NOT NULL,
	MaCN NVARCHAR(20) NOT NULL,
	isDeleted INT DEFAULT 0

	FOREIGN KEY (MaCN) REFERENCES dbo.ChiNhanh(MaCN)
)
GO

CREATE TABLE MonAn
(
	MaMon NVARCHAR(20) PRIMARY KEY,
	TenMon NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	DonGia DECIMAL NOT NULL DEFAULT 0,
	MaDM NVARCHAR(20) NOT NULL,
	isDeleted INT DEFAULT 0

	FOREIGN KEY (MaDM) REFERENCES dbo.DanhMuc(MaDM)
)
GO

CREATE TABLE CongThuc
(
	MaMon NVARCHAR(20) NOT NULL,
	MaNL NVARCHAR(20) NOT NULL,
	SoLuong INT NOT NULL,

	FOREIGN KEY (MaMon) REFERENCES dbo.MonAn(MaMon),
	FOREIGN KEY (MaNL) REFERENCES dbo.NguyenLieu(MaNL)
)
GO

CREATE TABLE HoaDon
(
	MaHD NVARCHAR(20) PRIMARY KEY,
	NgayTaoHD DATETIME NOT NULL DEFAULT GETDATE(),
	MaKH NVARCHAR(20) NOT NULL,
	MaNV NVARCHAR(20) NOT NULL,

	FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH),
	FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
)
GO

CREATE TABLE CTHoaDon
(
	MaHD NVARCHAR(20) NOT NULL,
	MaMon NVARCHAR(20) NOT NULL,
	SoLuong INT NOT NULL,
	ThanhTien DECIMAL NOT NULL DEFAULT 0,

	FOREIGN KEY (MaHD) REFERENCES dbo.HoaDon(MaHD),
	FOREIGN KEY (MaMon) REFERENCES dbo.MonAn(MaMon)
)
GO

INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN1', N'KFC LOTTE GÒ VẤP', N'Lô 1F17, tầng 1, Lotte mart Gò Vấp, số 18, Phan Văn Trị, Phường 10, Gò Vấp', DEFAULT)
INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN2', N'KFC LŨY BÁN BÍCH', N'Số 01, Vườn Lài, Phường Phú Thọ Hòa, Quận Tân Phú', DEFAULT)
INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN3', N'KFC AEON MALL TÂN PHÚ', N'Trung tâm mua sắm Aeon, số 30 đường Bờ Bao Tân Thắng, P. Sơn Kỳ, Q. Tân Phú', DEFAULT)
INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN4', N'KFC HÓC MÔN', N'Khu phố 5, Thị trấn Hóc Môn, huyện Hóc Môn', DEFAULT)
INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN5', N'KFC VÕ VĂN NGÂN', N'251 Võ Văn Ngân, Phường Linh Chiểu, Quận Thủ Đức', DEFAULT)
INSERT INTO dbo.ChiNhanh (MaCN, TenCN, DiaChi, isDeleted) VALUES (N'CN6', N'KFC LÊ VĂN VIỆT', N'193 Lê Văn Việt, P. Hiệp Phú, Q.9', DEFAULT)

INSERT INTO dbo.NhanVien (MaNV, TenNV, NgaySinh, GioiTinh, DiaChi, SDT, CMND, Quyen, TenDangNhap, MatKhau, MaCN, isDeleted) VALUES (N'NV1', N'Nguyễn Ngọc Lễ', '2002-06-18', N'Nam', N'Khánh Hòa', N'0337378867', N'225960662', 2, N'admin', N'21232F297A57A5A743894A0E4A801FC3', N'CN1', 1)

INSERT INTO dbo.KhachHang (MaKH, TenKH, SDT, isDeleted) VALUES (N'KH1', N'', N'', 1)

INSERT INTO dbo.NguyenLieu (MaNL, TenNL, SoLuongTon, MaCN, isDeleted) VALUES (N'NL1', N'Đùi Gà', 200, N'CN1', DEFAULT)
INSERT INTO dbo.NguyenLieu (MaNL, TenNL, SoLuongTon, MaCN, isDeleted) VALUES (N'NL2', N'Ức Gà', 200, N'CN1', DEFAULT)
INSERT INTO dbo.NguyenLieu (MaNL, TenNL, SoLuongTon, MaCN, isDeleted) VALUES (N'NL3', N'Mì Ý', 100, N'CN1', DEFAULT)
INSERT INTO dbo.NguyenLieu (MaNL, TenNL, SoLuongTon, MaCN, isDeleted) VALUES (N'NL4', N'Hamburger', 100, N'CN1', DEFAULT)

INSERT INTO dbo.DanhMuc (MaDM, TenDM, isDeleted) VALUES (N'DM1', N'Combo 1 Người', DEFAULT)
INSERT INTO dbo.DanhMuc (MaDM, TenDM, isDeleted) VALUES (N'DM2', N'Combo Nhóm', DEFAULT)

INSERT INTO dbo.MonAn (MaMon, TenMon, DonGia, MaDM, isDeleted) VALUES (N'MA1', N'Combo Gà Rán', 78000, N'DM1', DEFAULT)
INSERT INTO dbo.MonAn (MaMon, TenMon, DonGia, MaDM, isDeleted) VALUES (N'MA2', N'Combo Nhóm 1', 162000, N'DM2', DEFAULT)

INSERT INTO dbo.CongThuc (MaNL, MaMon, SoLuong) VALUES (N'NL1', N'MA1', 1)
INSERT INTO dbo.CongThuc (MaNL, MaMon, SoLuong) VALUES (N'NL2', N'MA1', 1)
INSERT INTO dbo.CongThuc (MaNL, MaMon, SoLuong) VALUES (N'NL1', N'MA2', 2)
INSERT INTO dbo.CongThuc (MaNL, MaMon, SoLuong) VALUES (N'NL2', N'MA2', 1)
INSERT INTO dbo.CongThuc (MaNL, MaMon, SoLuong) VALUES (N'NL4', N'MA2', 1)