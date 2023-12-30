use QuanLyPhongKhamNhaKhoa_HQT
go

BULK INSERT KhachHang
FROM 'D:\data_KhachHang.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 ); -- Nếu có header
go
BULK INSERT NhaSi
FROM 'D:\data_NhaSi.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
	)
go
BULK INSERT Thuoc
FROM 'D:\data_Thuoc.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT LichHen
FROM 'D:\data_LichHen.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go

BULK INSERT DonThuoc
FROM 'D:\data_DonThuoc.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT HoSoBenhNhan
FROM 'D:\data_HoSoBenhNhan.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
