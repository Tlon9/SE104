CREATE DATABASE QUANLYHOCSINH
--DROP DATABASE QUANLYHOCSINH 

USE QUANLYHOCSINH

--TAO BANG
CREATE TABLE HOCSINH
(	MaHocSinh nvarchar(10) not null,
	HoTen nvarchar(30),
	GioiTinh nvarchar(5),
	NgaySinh smalldatetime,
	DiaChi nvarchar(50),
	QueQuan nvarchar(50),
	DanToc nvarchar(20),
	TonGiao nvarchar(20),
	SDT nvarchar(10),
	Email nvarchar(40),
	HoTenCha nvarchar (30),
	NamSinh_Cha smallint,
	CCCD_Cha nvarchar (12),
	SDT_Cha nvarchar (10),
	NgheNghiep_Cha nvarchar (50),
	HoTenMe nvarchar (30),
	NamSinh_Me smallint,
	CCCD_Me nvarchar (12),
	SDT_Me nvarchar (10),
	NgheNghiep_Me nvarchar (50),
	constraint pk_mhs primary key(MaHocSinh)
)

CREATE TABLE KHOI	
(	MaKhoi nvarchar(10) not null,
	TenKhoi nvarchar(10),
	constraint pk_mk primary key(MaKhoi)
)

CREATE TABLE NAMHOC (
	MaNamHoc nvarchar(10) not null,
	NamHoc nvarchar(10),
	constraint pk_mnh primary key(MaNamHoc)
)

CREATE TABLE LOP
(	MaLop nvarchar(10) not null,
	TenLop nvarchar(10),
	MaKhoi nvarchar(10) not null,
	SiSo tinyint,
	MaNamHoc nvarchar(10) not null,
	constraint pk_ml primary key(MaLop),
)

CREATE TABLE HOCKY (
	MaHocKy nvarchar(10),
	HocKy nvarchar(10),
	TrongSo float,
	constraint pk_mhk primary key(MaHocKy)
)

CREATE TABLE MONHOC
(	MaMonHoc nvarchar(10) not null,
	TenMonHoc nvarchar(50),
	constraint pk_mmh primary key(MaMonHoc)
)

CREATE TABLE CTLOP
(	MaCTL nvarchar(10) not null,
	MaHocSinh nvarchar(10) not null,
	MaLop nvarchar(10) not null,
	constraint pk_ctl primary key(MaCTL)
)

CREATE TABLE DIEM
(	MaDiem nvarchar(10) not null,
	MaKetQua nvarchar(10) not null,
	MaThanhPhan nvarchar(10),
	Diem float,
	constraint pk_md primary key(MaDiem)
)

CREATE TABLE THANHPHAN (
	MaThanhPhan nvarchar(10) not null,
	TenThanhPhan nvarchar(30),
	TrongSo float,
	constraint pk_mtp primary key(MaThanhPhan)
)

CREATE TABLE KETQUA_MONHOC_HOCSINH (
	MaKetQua nvarchar(10) not null,
	MaHocSinh nvarchar(10) not null,
	MaNamHoc nvarchar(10) not null,
	MaHocKy nvarchar(10) not null,
	MaMonHoc nvarchar(10) not null,
	DiemTB float,
	MaXepLoai nvarchar(10)
	constraint pk_mkq primary key(MaKetQua)
)

CREATE TABLE XEPLOAI
(
	MaXepLoai nvarchar (10) not null,
	TenXepLoai nvarchar (20),
	DiemToiThieu float,
	DiemToiDa float,
	DiemKhongChe float, -- Ap dung khi xet Diem
	Constraint pk_xl primary key (MaXepLoai)
)

CREATE TABLE THAMSO
(	
	MaThamSo nvarchar (50) not null,
	TuoiToiThieu tinyint default 15,
	TuoiToiDa tinyint default 20,
	SiSoToiDa smallint default 40,
	DiemToiDaMH float default 10.0,
	DiemToiThieu float default 0.0,
	Constraint pk_ts primary key (MaThamSo)
)

--TAO KHOA NGOAI
--Bang LOP
ALTER TABLE LOP ADD CONSTRAINT fk_lop_mk
	FOREIGN KEY(MaKhoi) REFERENCES KHOI(MaKhoi)
ALTER TABLE LOP ADD CONSTRAINT fk_lop_mnh
	FOREIGN KEY(MaNamHoc) REFERENCES NAMHOC(MaNamHoc)

--Bang CTLOP
ALTER TABLE CTLOP ADD CONSTRAINT fk_ctl_hs
	FOREIGN KEY(MaHocSinh) REFERENCES HOCSINH(MaHocSinh)
ALTER TABLE CTLOP ADD CONSTRAINT fk_ctl_ml
	FOREIGN KEY(MaLop) REFERENCES LOP(MaLop)

--Bang KETQUA_MONHOC_HOCSINH
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_hs
	FOREIGN KEY(MaHocSinh) REFERENCES HOCSINH(MaHocSinh)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_xl
	FOREIGN KEY(MaXepLoai) REFERENCES XEPLOAI(MaXepLoai)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_nh
	FOREIGN KEY(MaNamHoc) REFERENCES NAMHOC(MaNamHoc)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_hk
	FOREIGN KEY(MaHocKy) REFERENCES HOCKY(MaHocKy)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_mh
	FOREIGN KEY(MaMonHoc) REFERENCES MONHOC(MaMonHoc)

--Bang DIEM
ALTER TABLE DIEM ADD CONSTRAINT fk_diem_kq
	FOREIGN KEY(MaKetQua) REFERENCES KETQUA_MONHOC_HOCSINH(MaKetQua)
ALTER TABLE DIEM ADD CONSTRAINT fk_diem_tp
	FOREIGN KEY(MaThanhPhan) REFERENCES THANHPHAN(MaThanhPhan)