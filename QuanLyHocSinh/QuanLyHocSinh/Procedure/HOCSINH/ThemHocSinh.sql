--RANG BUOC TOAN VEN
--INSERT INTO HOCSINH
CREATE PROCEDURE ThemHocSinh
	@MaHocSinh nvarchar(10),
	@HoTen nvarchar(30),
	@GioiTinh nvarchar(5),
	@NgaySinh smalldatetime,
	@DiaChi nvarchar(50),
	@QueQuan nvarchar(50),
	@DanToc nvarchar(20),
	@TonGiao nvarchar(20),
	@SDT nvarchar(10),
	@Email nvarchar(40),
	@HoTenCha nvarchar (30),
	@NamSinh_Cha smallint,
	@CCCD_Cha nvarchar (12),
	@SDT_Cha nvarchar (10),
	@NgheNghiep_Cha nvarchar (50),
	@HoTenMe nvarchar (30),
	@NamSinh_Me smallint,
	@CCCD_Me nvarchar (12),
	@SDT_Me nvarchar (10),
	@NgheNghiep_Me nvarchar (50)
AS
BEGIN
	DECLARE @TuoiToiThieu TINYINT = (SELECT TuoiToiThieu FROM THAMSO);
	DECLARE @TuoiToiDa TINYINT = (SELECT TuoiToiDa FROM THAMSO);
	IF (
		((YEAR(@NgaySinh) - YEAR(GETDATE())) >= @TuoiToiThieu)
		AND 
		((YEAR(@NgaySinh) - YEAR(GETDATE())) <= @TuoiToiDa)
	)
	BEGIN
		INSERT INTO HOCSINH (
			MaHocSinh,
			HoTen,
			GioiTinh,
			NgaySinh,
			DiaChi,
			QueQuan,
			DanToc,
			TonGiao,
			SDT,
			Email,
			HoTenCha,
			NamSinh_Cha,
			CCCD_Cha,
			SDT_Cha,
			NgheNghiep_Cha,
			HoTenMe,
			NamSinh_Me,
			CCCD_Me,
			SDT_Me,
			NgheNghiep_Me
		)
		VALUES
		(
			@MaHocSinh,
			@HoTen,
			@GioiTinh,
			@NgaySinh,
			@DiaChi,
			@QueQuan,
			@DanToc,
			@TonGiao,
			@SDT,
			@Email,
			@HoTenCha,
			@NamSinh_Cha,
			@CCCD_Cha,
			@SDT_Cha,
			@NgheNghiep_Cha,
			@HoTenMe,
			@NamSinh_Me,
			@CCCD_Me,
			@SDT_Me,
			@NgheNghiep_Me
		)
		PRINT(N'Thêm thông tin học sinh thành công');
	END;
	ELSE
	BEGIN
		PRINT(N'Tuổi học sinh nhập vào không hợp lệ');
		PRINT(N'Tuổi học sinh phải từ ' + @TuoiToiThieu + ' đến ' + @TuoiToiDa);
	END;
END