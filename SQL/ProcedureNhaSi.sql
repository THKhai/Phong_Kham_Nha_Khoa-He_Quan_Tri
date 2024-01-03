use QuanLyPhongKhamNhaKhoa_HQT
go	

-- read table
create or alter procedure p_Read_HoSoBenhNhan
as
begin transaction
	select*
	from HoSoBenhNhan
commit transaction
go
create or alter procedure p_Read_BenhNhan
as
begin transaction
	select*
	from KhachHang
commit transaction
go


CREATE OR ALTER PROCEDURE p_Read_CuocHenNhaSi
    @MaNhaSi VARCHAR(10)
AS
BEGIN TRANSACTION
    SELECT *
    FROM LichHen
    WHERE MaNhaSi = @MaNhaSi
COMMIT TRANSACTION
go
--select*
--from LichHen
--where MaNhaSi = '02'
-- Find 
	-- find khách hàng
go
create or alter procedure Tim_KH @MaBN varchar(10)
as
begin transaction
	select*
	from KhachHang kh
	where kh.MaBN = @MaBN
commit transaction

go
	-- find HoSoBenhNhan
create or alter procedure Tim_HoSoBenhNhan @MaBN varchar(10)
as
begin transaction
	select*
	from HoSoBenhNhan hsbn
	where hsbn.MaBN = @MaBN
commit transaction

go
	-- Find Cuộc Hẹn
create or alter procedure Tim_CuocHen @MaNhaSi varchar(10)
as
begin transaction
	select*
	from LichHen lh
	where lh.MaNhaSi = @MaNhaSi
commit transaction

go

-- Lấy STT tiếp thep
create or alter procedure Take_NewSTT @MaBN varchar(10), @res int output
as
begin transaction
	select @res = MAX(hsbn.STT)
	from HoSoBenhNhan hsbn
	where hsbn.MaBN = @MaBN
	set @res =	ISNULL(@res,0) + 1
	if (@res = 1)
		raiserror (N'Không tồn tại Hồ Sơ Bệnh Nhân',14,1)
commit transaction
go
--declare @p_res int
--exec Take_NewSTT '02',@p_res
--print @p_res
-- Lấy Don Thuoc Tiep Theo
go

-- Tìm Mã Bác Sĩ Theo tên
create or alter procedure Tim_Ten_NhaSi @Ten nvarchar(MAX), @res varchar(10) output
as
begin transaction
	select @res = MaNhaSi from NhaSi where HoTen = @Ten
commit transaction
go

-- Xem Danh sách Thuốc

create or alter procedure XemDanhSachThuoc
as
begin transaction
	select* from Thuoc
commit transaction
go

-- Tim thuốc
create or alter procedure Tim_Thuoc @MaThuoc varchar(10)
as
begin transaction
	select* from Thuoc where MaThuoc = @MaThuoc
commit transaction
go
go

-- Xem DonTHuoc
create or alter procedure XemDonThuoc  @DonThuoc varchar(10)
as
begin
	select*
	from DonThuoc dt
	where dt.DonThuoc = @DonThuoc
end
go

--select *
--from HoSoBenhNhan
--where MaBN = '03'
--go
-- Tạo Đơn Thuốc
create or alter procedure ThemDonThuoc 
    @DonThuoc varchar(10), 
    @MaThuoc varchar(10),
	@SoLuong int,
    @ErrorOccurred bit output
as
begin
    begin transaction
	update DonThuoc set SoLuong = SoLuong + @SoLuong where DonThuoc = @DonThuoc and MaThuoc = @MaThuoc
    set @ErrorOccurred = 0; -- Mặc định không có lỗi
    if (not exists (select * from DonThuoc t where t.DonThuoc = @DonThuoc and t.MaThuoc = @MaThuoc))
    begin
        insert DonThuoc(DonThuoc, MaThuoc,SoLuong) values (@DonThuoc, @MaThuoc,@SoLuong)
    end
    else if ((select SoLuong from DonThuoc t where t.DonThuoc = @DonThuoc and t.MaThuoc = @MaThuoc ) < @SoLuong)
    begin
        raiserror (N'Không đủ thuốc trong kho', 14, 1)
        set @ErrorOccurred = 1; -- Đánh dấu có 
		rollback
    end
    commit transaction
end
go
create or alter procedure Them_HSBN 
	@MaBN varchar(10),
	@STT int,
	@Ngay_Kham date,
	@MaNhaSi varchar(10),
	@PhiKham float,
	@DichVu nvarchar(MAX),
	@DonThuoc varchar(10)
as
begin transaction
	if(exists (select* from HoSoBenhNhan hsbn where hsbn.MaBN = @MaBN and hsbn.STT = @STT))
	begin
		raiserror (N'Đã Tồn Tại Hóa Đơn',14,1)
	end
	else
	begin
	insert HoSoBenhNhan(MaBN,STT,NgayKham,MaNhaSi,PhiKham,DichVu, DonThuoc)
			values(@MaBN,@STT,@Ngay_Kham,@MaNhaSi,@PhiKham,@DichVu,@DonThuoc)
	end
commit transaction
go
CREATE OR ALTER PROCEDURE Xem_LH_Ngay
    @MaNhaSi VARCHAR(10),
    @Ngay DATETIME
AS
BEGIN TRANSACTION
	select*
	from LichHen lh
	where lh.MaNhaSi = @MaNhaSi and NgayGio = @Ngay
COMMIT TRANSACTION
go
create or alter procedure CapNhatLichHenNS @MaNhaSi varchar(10),@NgayGio date,@MaBN varchar(10),@NgayGio_Old date
as
begin transaction
	IF EXISTS (SELECT * FROM LichHen WHERE LichHen.MaBN <> @MaBN AND LichHen.MaNhaSi = @MaNhaSi AND LichHen.NgayGio = @NgayGio)
	BEGIN
		RAISERROR(N'Lịch hẹn đặt đã bị trùng giờ với một lịch hẹn khác',14,1)
		ROLLBACK
	END
	ElSE
	Begin
		update LichHen Set NgayGio = @NgayGio where MaNhaSi = @MaNhaSi and MaBN = @MaBN and NgayGio = @NgayGio_Old 
		COMMIT TRANSACTION
	END
go
-------------
create or alter procedure CapNhat_SoLuong_Thuoc_FIX 
    @MaThuoc varchar(10), 
    @SoLuong int
as
Set transaction isolation level	repeatable read
begin transaction
    if ((select t.SoLuongTon from Thuoc t where t.MaThuoc = @MaThuoc) >= @SoLuong)
    begin
		-- lấy giá trị ra
        declare @Slg int
		select @Slg = t.SoLuongTon
		from Thuoc t
		where t.MaThuoc = @MaThuoc
		-- tính toán
		update THuoc set SoLuongTon = @Slg - @SoLuong where MaThuoc = @MaThuoc
		commit tran
    end
    else    
	begin
        raiserror (N'Không Đủ Số Lượng Thuốc', 14, 1);
		commit tran
    end
go
CREATE OR ALTER PROCEDURE p_DangKyLichHenNS_FIX @NGAYGIO DATETIME, @MABN VARCHAR(10), @MANHASI VARCHAR(10)
AS
Set transaction isolation level	read committed
BEGIN TRANSACTION
	INSERT INTO LichHen VALUES (@NGAYGIO,@MABN,@MANHASI,1)

	waitfor delay '00:00:10'

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

-------------
-- có lỗi
-- Cap Số Lượng  Thuốc Tồn kho -- Lost update and unrepeateable read
create or alter procedure CapNhat_SoLuong_Thuoc 
    @MaThuoc varchar(10), 
    @SoLuong int,
	@TimeDelay varchar(10)
as
Set transaction isolation level	read uncommitted
begin transaction
    if ((select t.SoLuongTon from Thuoc t where t.MaThuoc = @MaThuoc) >= @SoLuong)
    begin
		-- lấy giá trị ra
        declare @Slg int
		select @Slg = t.SoLuongTon
		from Thuoc t
		where t.MaThuoc = @MaThuoc
		-- delay
		waitfor delay @TimeDelay
		-- tính toán
		update THuoc set SoLuongTon = @Slg - @SoLuong where MaThuoc = @MaThuoc
		commit tran
    end
    else    
	begin
        raiserror (N'Không Đủ Số Lượng Thuốc', 14, 1);
		commit tran
    end
go

--Dang Ky Lich Hen-- dirty read
CREATE OR ALTER PROCEDURE p_DangKyLichHenNS @NGAYGIO DATETIME, @MABN VARCHAR(10), @MANHASI VARCHAR(10)
AS
Set transaction isolation level	read uncommitted
BEGIN TRANSACTION
	INSERT INTO LichHen VALUES (@NGAYGIO,@MABN,@MANHASI,1)

	waitfor delay '00:00:10'

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
-- dirty read
CREATE OR ALTER PROCEDURE p_DangKyTKKH_Error @MABN varchar(10), @HoTen NVARCHAR(255), @NgaySinh DATE, @DiaChi NVARCHAR(255),@SoDienThoai NVARCHAR(20), @MatKhau NVARCHAR(255)
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
		waitfor delay '00:00:10'
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