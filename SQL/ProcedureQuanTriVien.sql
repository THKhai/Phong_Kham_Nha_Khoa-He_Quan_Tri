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
--Xem danh muc thuoc
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
	INSERT INTO Thuoc(MaThuoc, TenThuoc, DonViTinh, ChiDinh, SoLuongTon, NgayHetHan)
	VALUES (@MaThuoc, @TenThuoc, @DonViTinh, @ChiDinh, @SoLuongTon, @NgayHetHan);
	--WAITFOR DELAY '00:00:10'
	IF EXISTS(SELECT * FROM Thuoc WHERE @MaThuoc = MaThuoc)
	BEGIN
		RAISERROR(N'Mã thuốc đã tồn tại',14,1)
		ROLLBACK
	END
	ElSE
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