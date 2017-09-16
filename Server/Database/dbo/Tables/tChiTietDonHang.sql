CREATE TABLE [dbo].[tChiTietDonHang] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [MaDonHang]      INT    NOT NULL,
    [MaMatHang]      INT    NOT NULL,
    [SoLuong]        INT    NOT NULL,
    [Xong]           BIT    CONSTRAINT [DF_tChiTietDonHang_Xong] DEFAULT ((0)) NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tChiTietDonHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChiTietDonHang_tDonHang] FOREIGN KEY ([MaDonHang]) REFERENCES [dbo].[tDonHang] ([Ma]),
    CONSTRAINT [FK_tChiTietDonHang_tMatHang] FOREIGN KEY ([MaMatHang]) REFERENCES [dbo].[tMatHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tChiTietDonHang]
	ON [dbo].[tChiTietDonHang]
	after insert, delete, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tChiTietDonHang]')
		IF trigger_nestlevel() > 1
			return

		if(update(SoLuong))
		begin
			print('update Xong of tChiTietDonHang')
			update tChiTietDonHang
			set Xong = case when SoLuong = (select isnull(Sum(SoLuong),-1) from tChiTietChuyenHangDonHang where MaChiTietDonHang = tChiTietDonHang.Ma)
							then 1
							else 0
						end
			where Ma in (select distinct(Ma) from inserted)
		end

		print('update Xong, TongSoLuong of tDonHang')		
		update tDonHang
		set Xong = case when exists(select * from tChiTietDonHang where MaDonHang=tDonHang.Ma and Xong=0)
						then 0
						else 1
					end
			,TongSoLuong = (select ISNULL(sum(SoLuong), 0) from tChiTietDonHang where MaDonHang=tDonHang.Ma)
		where Ma in (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted)

		print('update SoLuongTheoDonHang of tChiTietChuyenHangDonHang')
		update tChiTietChuyenHangDonHang
		set SoLuongTheoDonHang = i.SoLuong
		from inserted as i
		where tChiTietChuyenHangDonHang.MaChiTietDonHang = i.Ma
		
		print('update TongSoLuongTheoDonHang of tChuyenHangDonHang')
		update tChuyenHangDonHang
		set TongSoLuongTheoDonHang = dh.TongSoLuong
		from (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted) t
			join tDonHang dh on t.MaDonHang=dh.Ma
		where tChuyenHangDonHang.MaDonHang = dh.Ma
		
		print('update TongSoLuongTheoDonHang of tChuyenHang')
		;with cte as(
			select chdh.MaChuyenHang, isnull(sum(TongSoLuongTheoDonHang),0) as TongSoLuongTheoDonHang
			from (select distinct(MaDonHang) from inserted union select distinct(MaDonHang) from deleted) t
				join tDonHang dh on t.MaDonHang=dh.Ma
				join tChuyenHangDonHang chdh on chdh.MaDonHang=dh.Ma
			group by chdh.MaChuyenHang
		)
		update ch
		set TongSoLuongTheoDonHang = cte.TongSoLuongTheoDonHang
		from tChuyenHang ch, cte
		where ch.Ma=cte.MaChuyenHang

		print('update SoLuong of tTonKho')		
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated

		DECLARE @soLuong as INT;
		DECLARE @maKhoHang as INT;
		DECLARE @maMatHang as INT;
		DECLARE @ngay as Date;
		DECLARE @cursorTK as CURSOR;
 
		SET @cursorTK = CURSOR FOR		
			select sum(t.SoLuong) as SoLuong, dh.MaKhoHang, t.MaMatHang, dh.Ngay
			from(select SoLuong, MaDonHang, MaMatHang from deleted
				union
				select -SoLuong, MaDonHang, MaMatHang from inserted) as t
			join tDonHang dh on t.MaDonHang = dh.Ma
			group by dh.MaKhoHang, t.MaMatHang, dh.Ngay
		OPEN @cursorTK;
		FETCH NEXT FROM @cursorTK INTO @soLuong, @maKhoHang, @maMatHang, @ngay;
 
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'soluong ' + cast(@soLuong as VARCHAR) + ' maKhoHang ' + cast(@maKhoHang as VARCHAR) + ' maMatHang ' + cast(@maMatHang as VARCHAR) + ' ngay ' + cast(@ngay as VARCHAR);
			
			update tk
			set tk.SoLuong = tk.SoLuong + @soLuong
			from tTonKho tk		
			where tk.Ngay>=@ngay and tk.MaKhoHang=@maKhoHang and tk.MaMatHang=@maMatHang

			FETCH NEXT FROM @cursorTK INTO @soLuong, @maKhoHang, @maMatHang, @ngay;
		END
 
		CLOSE @cursorTK;
		DEALLOCATE @cursorTK;

		print('update SoTien of tCongNoKhachHang')
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated
		DECLARE @maKhachHang as INT;
		DECLARE @soTien as INT;
		DECLARE @cursorCN as CURSOR;
 
		SET @cursorCN = CURSOR FOR		
			select sum(ctth.GiaTien*t.SoLuong) as SoTien, th.MaKhachHang, th.Ngay
			from(
				SELECT SoLuong, Ma FROM inserted
				union
				SELECT -SoLuong, Ma FROM deleted) as t
			join tChiTietToaHang ctth on ctth.MaChiTietDonHang=t.Ma
			join tToaHang th on th.Ma=ctth.MaToaHang
			group by th.Ngay, th.MaKhachHang
		OPEN @cursorCN;
		FETCH NEXT FROM @cursorCN INTO @soTien, @maKhachHang,  @ngay;
 
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'soTien ' + cast(@soTien as VARCHAR) + ' maKhachHang ' + cast(@maKhachHang as VARCHAR) + ' ngay ' + cast(@ngay as VARCHAR);
			
			update cn
			set cn.SoTien = cn.SoTien + @soTien
			from tCongNoKhachHang cn
			where cn.Ngay>=@ngay and cn.MaKhachHang=@maKhachHang

			FETCH NEXT FROM @cursorCN INTO @soTien, @maKhachHang, @ngay;
		END
 
		CLOSE @cursorCN;
		DEALLOCATE @cursorCN;
	END