use QuanLyPhongKhamNhaKhoa_HQT
go

BULK INSERT KhachHang
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_KhachHang.csv'
WITH (
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2 ); -- Nếu có header
go
BULK INSERT NhaSi
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_NhaSi.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2
	)
go
BULK INSERT Thuoc
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_Thuoc.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT LichHen
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_LichHen.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go

BULK INSERT DonThuoc
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_DonThuoc.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT HoSoBenhNhan
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_HoSoBenhNhan.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT NhanVien
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_NhanVien.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go
BULK INSERT QuanTriVien
FROM 'C:\Users\tranh\OneDrive\Desktop\APhong_Kham_Nha_Khoa-He_Quan_Tri\Data\data_QuanTriVien.csv'
with (
	FIELDTERMINATOR = ',',
    ROWTERMINATOR = '\n',
    FIRSTROW = 2,
	CODEPAGE = '65001'
	)
go