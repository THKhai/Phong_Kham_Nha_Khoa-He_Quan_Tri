use QuanLyPhongKhamNhaKhoa_HQT

go
CREATE OR ALTER PROCEDURE p_KtraTKQTV @MAQTV VARCHAR(20), @MATKHAU NVARCHAR(255),
@OK BIT OUT
AS
BEGIN TRANSACTION
	IF EXISTS(SELECT * FROM QuanTriVien WHERE @MAQTV = QuanTriVien.MaQTV AND @MATKHAU = QuanTriVien.MatKhau)
	BEGIN
	SET @OK = 1
	END
	ELSE
	BEGIN
	SET @OK = 0
	END
COMMIT TRANSACTION
--XEM DANH MUC THUOC
go
CREATE OR ALTER PROCEDURE p_Xemdanhmucthuoc
AS
BEGIN TRANSACTION
	SELECT *
	FROM Thuoc
COMMIT TRANSACTION
--Them thuoc
go
CREATE OR ALTER PROCEDURE p_ThemThuoc
	@MaThuoc VARCHAR(10),
	@TenThuoc NVARCHAR(255),
	@DonViTinh NVARCHAR(50),
    @ChiDinh NVARCHAR(MAX),
    @SoLuongTon INT,
    @NgayHetHan DATE,
	@Delay TIME
AS
BEGIN TRANSACTION
	IF EXISTS(SELECT * FROM Thuoc WHERE @MaThuoc = MaThuoc)
	BEGIN
		RAISERROR(N'Mã thuốc đã tồn tại',14,1)
		ROLLBACK
	END
	ElSE
	BEGIN
		INSERT INTO Thuoc(MaThuoc, TenThuoc, DonViTinh, ChiDinh, SoLuongTon, NgayHetHan)
		VALUES (@MaThuoc, @TenThuoc, @DonViTinh, @ChiDinh, @SoLuongTon, @NgayHetHan);
		--WAITFOR DELAY '00:00:10'
	END
	BEGIN
		COMMIT TRANSACTION
	END

--Xoa thuoc
go
CREATE OR ALTER PROCEDURE p_XoaThuoc
	@MaThuoc VARCHAR(10),
	@Delay TIME
AS
BEGIN TRANSACTION
	DELETE Thuoc
	WHERE MaThuoc = @MaThuoc
	--WAITFOR DELAY '00:00:10'
	IF NOT EXISTS(SELECT * FROM Thuoc WHERE @MaThuoc = MaThuoc)
	BEGIN
		RAISERROR(N'Mã thuốc không tồn tại',14,1)
		ROLLBACK
	END
	ElSE
	BEGIN
		COMMIT TRANSACTION
	END

--Sua thuoc
go
CREATE OR ALTER PROCEDURE p_SuaThuoc
	@MaThuocCu VARCHAR(10),
	@MaThuocMoi VARCHAR(10),
	@TenThuoc NVARCHAR(255),
	@DonViTinh NVARCHAR(50),
    @ChiDinh NVARCHAR(MAX),
    @SoLuongTon INT,
    @NgayHetHan DATE,
	@Delay TIME
AS
BEGIN TRANSACTION
	UPDATE Thuoc
	SET MaThuoc = @MaThuocMoi, TenThuoc = @TenThuoc, DonViTinh = @DonViTinh, ChiDinh = @ChiDinh, SoLuongTon = @SoLuongTon, NgayHetHan = @NgayHetHan
	WHERE MaThuoc = MaThuoc
	--WAITFOR DELAY '00:00:10'
	IF NOT EXISTS(SELECT * FROM Thuoc WHERE @MaThuocCu = MaThuoc)
	BEGIN
		RAISERROR(N'Mã thuốc cần chỉnh sửa không tồn tại',14,1)
		ROLLBACK
	END
	ElSE
	IF EXISTS(SELECT * FROM Thuoc WHERE @MaThuocMoi = MaThuoc)
	BEGIN
		RAISERROR(N'Mã thuốc mới đã tồn tại',14,1)
		ROLLBACK
	END
	ElSE
	BEGIN
		COMMIT TRANSACTION
	END

--xem thuoc da het han
go
CREATE OR ALTER PROCEDURE p_Xemthuocdahethan
AS
BEGIN TRANSACTION
	SELECT *
	FROM Thuoc
	WHERE NgayHetHan < GETDATE()
COMMIT TRANSACTION
go

--dang ky tai khoan nhan vien

CREATE OR ALTER PROCEDURE p_DangKyTKNV @MaNV varchar(10), @HoTen NVARCHAR(255), @MatKhau NVARCHAR(255)
AS
BEGIN TRANSACTION
	IF EXISTS (SELECT * FROM NhanVien WHERE MaNV = @MaNV) 
	BEGIN
		RAISERROR(N'Mã Nhân viên đã tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		INSERT INTO NhanVien VALUES (@MaNV,@HoTen,@MatKhau) 
	END
		--WAITFOR DELAY '00:00:10'
	BEGIN
		COMMIT TRANSACTION
	END
--dang ky tai khoan nha si
--, @Lichlam NVARCHAR(MAX)
GO
CREATE OR ALTER PROCEDURE p_DangKyTKNS @MaNS varchar(10), @HoTen NVARCHAR(255), @SoDienThoai NVARCHAR(20), @MatKhau NVARCHAR(255), @Ban BIT
AS
BEGIN TRANSACTION
	IF EXISTS (SELECT * FROM NhaSi WHERE MaNhaSi = @MaNS) 
	BEGIN
		RAISERROR(N'Mã Nha sĩ đã tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		INSERT INTO NhaSi(MaNhaSi, HoTen, SoDienThoai, MatKhau, Ban) VALUES (@MaNS,@HoTen,@SoDienThoai,@MatKhau,0) 
	END
	BEGIN
		COMMIT TRANSACTION
	END

--khoa tai khoan nhan vien

--danh sach tai khoan nha si da ban
go
CREATE OR ALTER PROCEDURE p_DanhsachTKNSdaban
AS
BEGIN TRANSACTION
	SELECT *
	FROM NhaSi
	WHERE Ban = 1
COMMIT TRANSACTION
---danh sach tai khoan khach hang da ban 
go
CREATE OR ALTER PROCEDURE p_DanhsachTKKHdaban
AS
BEGIN TRANSACTION
	SELECT *
	FROM KhachHang
	WHERE Ban = 1
COMMIT TRANSACTION
-- khoa tai khoan nha si

GO
CREATE OR ALTER PROCEDURE p_BanTKNS @MaNS varchar(10)
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM NhaSi WHERE MaNhaSi = @MaNS) 
	BEGIN
		RAISERROR(N'Mã Nha sĩ không tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	IF EXISTS (SELECT * FROM NhaSi WHERE MaNhaSi = @MaNS AND Ban = 1)
	BEGIN
		RAISERROR(N'Tài khản Nha sĩ đã bị khóa rồi',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		UPDATE NhaSi
		SET Ban = 1
		WHERE MaNhaSi = @MaNS
	END
	BEGIN
		COMMIT TRANSACTION
	END

--khoa tai khoan khach hang
GO
CREATE OR ALTER PROCEDURE p_BanTKKH @MAKH varchar(10)
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM KhachHang WHERE MaBN = @MAKH) 
	BEGIN
		RAISERROR(N'Mã Khách hàng không tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	IF EXISTS (SELECT * FROM KhachHang WHERE MaBN = @MAKH AND Ban = 1)
	BEGIN
		RAISERROR(N'Tài khoản Khách hàng đã bị khóa rồi',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		UPDATE KhachHang
		SET Ban = 1
		WHERE MaBN = @MAKH
	END
	BEGIN
		COMMIT TRANSACTION
	END

--mo khoa tai khoan nha si
GO
CREATE OR ALTER PROCEDURE p_UnbanTKNS @MaNS varchar(10)
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM NhaSi WHERE MaNhaSi = @MaNS) 
	BEGIN
		RAISERROR(N'Mã Nha sĩ không tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	IF NOT EXISTS (SELECT * FROM NhaSi WHERE MaNhaSi = @MaNS AND Ban = 1)
	BEGIN
		RAISERROR(N'Tài khoản Nha sĩ không bị khóa!!!',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		UPDATE NhaSi
		SET Ban = 0
		WHERE MaNhaSi = @MaNS
	END
	BEGIN
		COMMIT TRANSACTION
	END

--mo khoa tai khoan khach hang
GO
CREATE OR ALTER PROCEDURE p_UnbanTKKH @MaKH varchar(10)
AS
BEGIN TRANSACTION
	IF NOT EXISTS (SELECT * FROM KhachHang WHERE MaBN = @MaKH) 
	BEGIN
		RAISERROR(N'Mã Khách hàng không tồn tại',14,1)
		ROLLBACK
	END
	ELSE
	IF NOT EXISTS (SELECT * FROM KhachHang WHERE MaBN = @MaKH AND Ban = 1)
	BEGIN
		RAISERROR(N'Tài khoản Khách hàng không bị khóa!!!',14,1)
		ROLLBACK
	END
	ELSE
	BEGIN
		UPDATE KhachHang
		SET Ban = 0
		WHERE MaBN = @MaKH
	END
	BEGIN
		COMMIT TRANSACTION
	END

/*DKTKMoiQTV
DKTKNVMoiQTV
DKTKNSMoiQTV

KhoaTKQTV
KhoaTKNSQTV
KhoaTKKHQTV*/
