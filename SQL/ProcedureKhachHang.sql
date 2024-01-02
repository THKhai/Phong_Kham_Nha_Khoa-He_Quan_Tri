﻿USE QuanLyPhongKhamNhaKhoa_HQT

GO
--NONREPEATABLE READ
CREATE OR ALTER PROCEDURE p_KtraTKKH @SDT NVARCHAR(20), @MATKHAU NVARCHAR(255),@Delay DATETIME,
@OK BIT OUT,@MAKH NVARCHAR(20) OUT,@SoDienThoai NVARCHAR(255) OUT
AS
BEGIN TRANSACTION
	IF EXISTS(SELECT * FROM KhachHang WHERE @SDT = KhachHang.SoDienThoai AND @MATKHAU = KhachHang.MatKhau AND KhachHang.Ban = 0)
	BEGIN
	SET @OK = 1
	WAITFOR DELAY @Delay 
	SELECT @MAKH = KhachHang.MaBN FROM KhachHang Where KhachHang.SoDienThoai = @SDT
	SELECT @SoDienThoai = KhachHang.SoDienThoai FROM KhachHang Where KhachHang.MaBN = @MAKH
	END
	ELSE
	BEGIN
	SET @OK = 0
	SET @MAKH = ''
	END
COMMIT TRANSACTION

GO

CREATE OR ALTER PROCEDURE p_KtraTKKH_Fix @SDT NVARCHAR(20), @MATKHAU NVARCHAR(255),@Delay DATETIME,
@OK BIT OUT,@MAKH NVARCHAR(20) OUT,@SoDienThoai NVARCHAR(255) OUT
AS
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ 
BEGIN TRANSACTION
	IF EXISTS(SELECT * FROM KhachHang WHERE @SDT = KhachHang.SoDienThoai AND @MATKHAU = KhachHang.MatKhau AND KhachHang.Ban = 0)
	BEGIN
	SET @OK = 1
	WAITFOR DELAY @Delay 
	SELECT @MAKH = KhachHang.MaBN FROM KhachHang Where KhachHang.SoDienThoai = @SDT
	SELECT @SoDienThoai = KhachHang.SoDienThoai FROM KhachHang Where KhachHang.MaBN = @MAKH
	END
	ELSE
	BEGIN
	SET @OK = 0
	SET @MAKH = ''
	END
COMMIT TRANSACTION
GO

CREATE OR ALTER PROCEDURE p_DangKyTKKH @MABN varchar(10), @HoTen NVARCHAR(255), @NgaySinh DATE, @DiaChi NVARCHAR(255),@SoDienThoai NVARCHAR(20), @MatKhau NVARCHAR(255)
AS
BEGIN TRANSACTION
	IF EXISTS (SELECT * FROM KhachHang WHERE KhachHang.MaBN = @MABN) 
	BEGIN
		RAISERROR(N'Mã Bệnh Nhân đã tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		INSERT INTO KhachHang VALUES (@MABN,@HoTen,@NgaySinh,@DiaChi,@SoDienThoai,@MatKhau,0) 
		IF EXISTS (SELECT * FROM KhachHang WHERE KhachHang.SoDienThoai = @SoDienThoai AND KhachHang.MaBN <> @MABN)
		BEGIN
			RAISERROR(N'Không được đặt trùng số điện thoại',14,1)
			ROLLBACK
		END
		ELSE
		BEGIN
			COMMIT TRANSACTION
		END
	END

GO

CREATE OR ALTER PROCEDURE p_DangKyLichHenKH @NGAYGIO DATETIME, @MABN VARCHAR(10), @MANHASI VARCHAR(10)
AS
BEGIN TRANSACTION
INSERT INTO LichHen VALUES (@NGAYGIO,@MABN,@MANHASI,0)
	IF EXISTS (SELECT * FROM LichHen WHERE LichHen.MaBN <> @MABN AND LichHen.MaNhaSi = @MANHASI AND LichHen.NgayGio LIKE @NGAYGIO)
	BEGIN
		RAISERROR(N'Lịch hẹn đặt đã bị trùng giờ với một lịch hẹn khác',14,1)
		ROLLBACK
	END
	ElSE
	Begin
		COMMIT TRANSACTION
	END


GO
CREATE OR ALTER PROCEDURE p_XemInfoBn @MABN VARCHAR(10)
AS
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM KhachHang WHERE KhachHang.MaBN = @MABN)
	BEGIN
		RAISERROR(N'Thông tin cá nhân không tồn tại',14,1)
	END
	ELSE
	BEGIN
		SELECT * FROM KhachHang WHERE KhachHang.MaBN = @MABN
	END
COMMIT TRANSACTION

GO

CREATE OR ALTER PROCEDURE p_XemInfoBn_Fix @MABN VARCHAR(10)
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM KhachHang WHERE KhachHang.MaBN = @MABN)
	BEGIN
		RAISERROR(N'Thông tin cá nhân không tồn tại',14,1)
	END
	ELSE
	BEGIN
		SELECT * FROM KhachHang WHERE KhachHang.MaBN = @MABN
	END
COMMIT TRANSACTION

GO

CREATE OR ALTER PROCEDURE p_XemHoSoBn @MABN VARCHAR(10)
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM HoSoBenhNhan WHERE HoSoBenhNhan.MaBN = @MABN)
	BEGIN
		RAISERROR(N'Hồ sơ không tồn tại',14,1)
	END
	ELSE
	BEGIN
		SELECT * FROM HoSoBenhNhan WHERE HoSoBenhNhan.MaBN = @MABN
	END

COMMIT TRANSACTION

GO
CREATE OR ALTER PROCEDURE p_ViewNhaSiCoTheHen @THOIGIAN DATETIME
AS
BEGIN TRANSACTION
	SELECT * FROM NhaSi WHERE  NhaSi.lichlam LIKE '%' + CAST(DATEPART(dw,@THOIGIAN) AS NVARCHAR(255)) + '%'
COMMIT TRANSACTION

GO




CREATE OR ALTER PROCEDURE p_ViewLHBenhNhan @MABN VARCHAR(10)
AS
BEGIN TRAN
	SELECT * FROM LichHen WHERE LichHen.MaBN = @MABN	
COMMIT TRAN
GO

CREATE OR ALTER PROCEDURE p_UpdateInfoBN @MABN VARCHAR(10), @HOTEN NVARCHAR(255),@NGAYSINH DATETIME,@DIACHI NVARCHAR(255),@SODIENTHOAI NVARCHAR(255),@MATKHAU NVARCHAR (255), @Delay DATETIME
AS
BEGIN TRAN
	UPDATE KhachHang 
	SET HoTen = @HOTEN, NgaySinh = @NGAYSINH, DiaChi = @DIACHI, SoDienThoai = @SODIENTHOAI, MatKhau = @MATKHAU
	WHERE KhachHang.MaBN = @MABN
	WAITFOR DELAY @Delay
	IF EXISTS (SELECT * FROM KhachHang WHERE KhachHang.MaBN <> @MABN AND KhachHang.SoDienThoai = @SODIENTHOAI)
	BEGIN
		RAISERROR(N'Số điện thoại trên đã được đăng ký',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		COMMIT TRAN
	END


