
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InitData]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @LastUpdate date;
	select @LastUpdate=GiaTri from ThamSoNgay where Ma=1;
	print('last update ' + RTRIM(CAST(@LastUpdate AS nvarchar(30))));

	declare @Now date = getdate();
	declare @DayCount Int = DATEDIFF(day, @LastUpdate, @Now);
	print('day count ' + RTRIM(CAST(@DayCount AS nvarchar(30))));

	if(@DayCount <= 0)
		return;
	
	declare @CurrentDay date = @LastUpdate;
	declare @NextDay date = DATEADD(day, 1, @CurrentDay);
	declare @Index Int = 0;
	WHILE @Index < @DayCount
	BEGIN
		print('next day ' + RTRIM(CAST(@NextDay AS nvarchar(30))));

		INSERT INTO tTonKho(MaKhoHang, MaMatHang, Ngay, SoLuong, SoLuongCu, TenantID)
		SELECT MaKhoHang, MaMatHang, @NextDay, SoLuong, SoLuongCu, TenantID FROM tTonKho where Ngay = @CurrentDay;
		
		INSERT INTO tCongNoKhachHang(MaKhachHang, Ngay, SoTien, TenantID)
		SELECT MaKhachHang, @NextDay, SoTien, TenantID FROM tCongNoKhachHang where Ngay = @CurrentDay;
		
		update tk
		set tk.SoLuong = tk.SoLuong - ct.SoLuong
		from tDonHang dh join tChiTietDonHang ct on dh.Ma = ct.MaDonHang
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = dh.MaKhoHang and tk.Ngay=dh.Ngay
		where dh.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong + ct.SoLuong
		from tNhapHang nh join tChiTietNhapHang ct on nh.Ma = ct.MaNhapHang
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = nh.MaKhoHang and tk.Ngay=nh.Ngay
		where nh.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong + ct.SoLuong
		from tChuyenKho ck join tChiTietChuyenKho ct on ck.Ma = ct.MaChuyenKho
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = ck.MaKhoHangNhap and tk.Ngay=ck.Ngay
		where ck.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong - ct.SoLuong
		from tChuyenKho ck join tChiTietChuyenKho ct on ck.Ma = ct.MaChuyenKho
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = ck.MaKhoHangXuat and tk.Ngay=ck.Ngay
		where ck.Ngay = @NextDay
	
		update cn
		set cn.SoTien = cn.SoTien + (ctth.GiaTien * ctdh.SoLuong)
		from tToaHang th join tChiTietToaHang ctth on th.Ma=ctth.MaToaHang
		join tChiTietDonHang ctdh on ctdh.Ma=ctth.MaChiTietDonHang
		join tCongNoKhachHang cn on cn.MaKhachHang = th.MaKhachHang and cn.Ngay=th.Ngay
		where th.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien - nt.SoTien
		from tNhanTienKhachHang nt
		join tCongNoKhachHang cn on cn.MaKhachHang = nt.MaKhachHang and cn.Ngay=nt.Ngay
		where nt.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien - gt.SoTien
		from tGiamTruKhachHang gt
		join tCongNoKhachHang cn on cn.MaKhachHang = gt.MaKhachHang and cn.Ngay=gt.Ngay
		where gt.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien + pt.SoTien
		from tPhuThuKhachHang pt
		join tCongNoKhachHang cn on cn.MaKhachHang = pt.MaKhachHang and cn.Ngay=pt.Ngay
		where pt.Ngay = @NextDay

		set @CurrentDay = @NextDay;
		set @NextDay = DATEADD(day,1,@CurrentDay);
		set @Index = @Index + 1;
	END;
	
	print('current day ' + RTRIM(CAST(@CurrentDay AS nvarchar(30))));
	UPDATE ThamSoNgay
	set GiaTri=@CurrentDay
	where Ma=1

	declare @MinDate date = DATEADD(day, -90, @CurrentDay);
	print('min date ' + RTRIM(CAST(@MinDate AS nvarchar(30))));
	delete from tTonKho where Ngay < @MinDate;
	delete from tCongNoKhachHang where Ngay < @MinDate;
END