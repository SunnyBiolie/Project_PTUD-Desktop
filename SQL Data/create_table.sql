create database QLDLRapPhim
go

use QLDLRapPhim
go

create table CumRap (
	MaCum varchar(5) not null primary key,
	TenCum nvarchar(50) not null,
	DiaChi nvarchar(200) not null
)
go

create table Rap (
	MaRap varchar(5) not null primary key,
	TongGhe int not null,
	MaCum varchar(5) not null
)
go

create table TheLoai (
	MaTheLoai varchar(5) not null primary key,
	TenTheLoai nvarchar(50) not null,
)
go

create table Phim (
	MaPhim varchar(10) not null primary key,
	TenPhim nvarchar(100) not null,
	MaTheLoaiChinh varchar(5) not null,
	ThoiLuong int not null
)
go

create table PhimTheLoaiPhu (
	MaPhim varchar(10) not null,
	MaTheLoai varchar(5) not null,
)
go
-- Tạo khóa chính cho table PhimTheLoaiPhu
alter table PhimTheLoaiPhu add constraint PK_PhimTheLoaiPhu primary key (MaPhim, MaTheLoai)
go

create table KeHoach (
	MaPhim varchar(10) not null,
	MaCum varchar(5) not null,
	NgayKhoiChieu Date not null,
	NgayKetThuc Date not null,
	GhiChu nvarchar(100) default '',
)
go
-- Tạo khóa chính cho table KeHoach
alter table KeHoach add constraint PK_KeHoach primary key (MaPhim, MaCum, NgayKhoiChieu, NgayKetThuc)
go

create table SuatChieu (
	MaSuat varchar(3) not null primary key,
	GioBatDau int not null,
	PhutBatDau int not null
)
go

create table LichChieu (
	MaPhim varchar(10) not null,
	MaRap varchar(5) not null,
	NgayChieu Date not null,
	ChuoiMaSuat nvarchar(100) not null
)
go
-- Tạo khóa chính cho table LichChieu
--alter table LichChieu add constraint PK_LichChieu primary key (MaPhim, MaRap, NgayChieu)
--go

-- Tạo khóa ngoại
alter table Rap add constraint FK_Rap_CumRap foreign key (MaCum) references CumRap (MaCum)
go
alter table Phim add constraint FK_Phim_TheLoai foreign key (MaTheLoaiChinh) references TheLoai (MaTheLoai)
go
alter table PhimTheLoaiPhu add constraint FK_PhimTheLoaiPhu_Phim foreign key (MaPhim) references Phim (MaPhim)
alter table PhimTheLoaiPhu add constraint FK_PhimTheLoaiPhu_TheLoai foreign key (MaTheLoai) references TheLoai (MaTheLoai)
go
alter table KeHoach add constraint FK_KeHoach_Phim foreign key (MaPhim) references Phim (MaPhim)
alter table KeHoach add constraint FK_KeHoach_CumRap foreign key (MaCum) references CumRap (MaCum)
go
alter table LichChieu add constraint FK_LichChieu_Phim foreign key (MaPhim) references Phim (MaPhim)
alter table LichChieu add constraint FK_LichChieu_Rap foreign key (MaRap) references Rap (MaRap)
go