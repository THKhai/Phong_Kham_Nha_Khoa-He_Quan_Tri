use QuanLyPhongKhamNhaKhoa_HQT
go	

CREATE OR ALTER PROCEDURE p_KtraTKNS @MANS VARCHAR(20), @MATKHAU NVARCHAR(255),
@OK BIT OUT
AS
BEGIN TRANSACTION
	IF EXISTS(SELECT * FROM NhaSi WHERE @MANS = NhaSi.MaNhaSi AND @MATKHAU = NhaSi.MatKhau AND NhaSi.Ban = 0)
	BEGIN
	SET @OK = 1
	END
	ELSE
	BEGIN
	SET @OK = 0
	END
COMMIT TRANSACTION
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
create or alter procedure p_Read_CuocHenNhaSi
as
begin transaction
	select*
	from LichHen
commit transaction
go
-- Find 
	-- find khách hàng
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
declare @p_res int
exec Take_NewSTT '02',@p_res
print @p_res
-- Lấy Don Thuoc Tiep Theo
go


-- Thêm Hồ Sơ bệnh Nhân
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
		raiserror (N'Đã tồn tại Hồ Sơ Bệnh Nhân này',14,1)
		rollback
	end
	else
	begin
		insert HoSoBenhNhan(MaBN,STT,NgayKham,MaNhaSi,PhiKham,DichVu, DonThuoc)
		values(@MaBN,@STT,@Ngay_Kham,@MaNhaSi,@PhiKham,@DichVu,@DonThuoc)
	end
commit transaction
go
-- Tìm Mã Bác Sĩ Theo tên
create or alter procedure Tim_Ten_NhaSi @Ten nvarchar(MAX), @res varchar(10) output
as
begin transaction
	select @res = MaNhaSi from NhaSi where HoTen = @Ten
	print @res
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

-- Tạo Đơn Thuốc
create or alter procedure ThemDonThuoc 
    @DonThuoc varchar(10), 
    @MaThuoc varchar(10),
	@SoLuong int,
    @ErrorOccurred bit output
as
begin
    begin transaction

    set @ErrorOccurred = 0; -- Mặc định không có lỗi

    if (not exists (select * from DonThuoc t where t.DonThuoc = @DonThuoc and t.MaThuoc = @MaThuoc))
    begin
        insert DonThuoc(DonThuoc, MaThuoc,SoLuong) values (@DonThuoc, @MaThuoc,@SoLuong)
    end
    else
    begin
        raiserror (N'Đã tồn tại đơn thuốc này', 14, 1)
        set @ErrorOccurred = 1; -- Đánh dấu có lỗi
        rollback
    end

    commit transaction
end
go


Set transaction isolation level read uncommitted
go
-- Cap Số Lượng  Thuốc Tồn kho
create or alter procedure CapNhat_SoLuong_Thuoc 
    @MaThuoc varchar(10), 
    @SoLuong int,
	@TimeDelay time
as
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
		update THuoc set SoLuongTon = @Slg - @SoLuong

		-- kiểm tra
		select* 
		from Thuoc t
		where t.MaThuoc = @MaThuoc
		commit transaction
    end
    else    
	begin
        raiserror (N'Không Đủ Số Lượng Thuốc', 14, 1);
    end
go
Set transaction isolation level read committed
go

-- tinh phi


--CapNhatLichHen
create or alter procedure CapNhatLichHenNS @MaNhaSi varchar(10),@NgayGio date,@MaBN varchar(10)
as
begin transaction
	INSERT INTO LichHen VALUES (@NgayGio,@MaBN,@MaNhaSi,1)
	IF EXISTS (SELECT * FROM LichHen WHERE LichHen.MaBN <> @MaBN AND LichHen.MaNhaSi = @MaNhaSi AND LichHen.NgayGio LIKE @NgayGio)
	BEGIN
		RAISERROR(N'Lịch hẹn đặt đã bị trùng giờ với một lịch hẹn khác',14,1)
		ROLLBACK
	END
	ElSE
	Begin
		COMMIT TRANSACTION
	END
go