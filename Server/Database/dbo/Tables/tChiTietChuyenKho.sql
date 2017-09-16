CREATE TABLE [dbo].[tChiTietChuyenKho] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [MaChuyenKho]    INT    NOT NULL,
    [MaMatHang]      INT    NOT NULL,
    [SoLuong]        INT    NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tChiTietChuyenKho] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChiTietChuyenKho_tChuyenKho] FOREIGN KEY ([MaChuyenKho]) REFERENCES [dbo].[tChuyenKho] ([Ma]),
    CONSTRAINT [FK_tChiTietChuyenKho_tMatHang] FOREIGN KEY ([MaMatHang]) REFERENCES [dbo].[tMatHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tChiTietChuyenKho]
	ON [dbo].[tChiTietChuyenKho]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tChiTietChuyenKho]')
		IF trigger_nestlevel() > 1
			return

		print('update SoLuong of tTonKho')
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated
		
		
		DECLARE @soLuong as INT;
		DECLARE @maKhoHang as INT;
		DECLARE @maMatHang as INT;
		DECLARE @ngay as Date;
		DECLARE @cursor as CURSOR;

		SET @cursor = CURSOR FOR		
			select sum(t.SoLuong) as SoLuong, t.MaKhoHang, t.MaMatHang, t.Ngay
			from(
				select SoLuong, MaKhoHangNhap as MaKHoHang, MaMatHang, Ngay from inserted i join tChuyenKho ck on i.MaChuyenKho = ck.Ma
				union all
				select -SoLuong, MaKhoHangNhap as MaKHoHang, MaMatHang, Ngay from deleted d join tChuyenKho ck on d.MaChuyenKho = ck.Ma
				union all
				select SoLuong, MaKhoHangXuat as MaKHoHang, MaMatHang, Ngay from deleted d join tChuyenKho ck on d.MaChuyenKho = ck.Ma
				union all
				select -SoLuong, MaKhoHangXuat as MaKHoHang, MaMatHang, Ngay from inserted i join tChuyenKho ck on i.MaChuyenKho = ck.Ma
				) as t
			group by t.MaKHoHang, t.MaMatHang, t.Ngay
		OPEN @cursor;
		FETCH NEXT FROM @cursor INTO @soLuong, @maKhoHang, @maMatHang, @ngay;
 
		WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT 'soluong ' + cast(@soLuong as VARCHAR) + ' maKhoHang ' + cast(@maKhoHang as VARCHAR) + ' maMatHang ' + cast(@maMatHang as VARCHAR) + ' ngay ' + cast(@ngay as VARCHAR);
			
			update tk
			set tk.SoLuong = tk.SoLuong + @soLuong
			from tTonKho tk		
			where tk.Ngay>=@ngay and tk.MaKhoHang=@maKhoHang and tk.MaMatHang=@maMatHang

			FETCH NEXT FROM @cursor INTO @soLuong, @maKhoHang, @maMatHang, @ngay;
		END
 
		CLOSE @cursor;
		DEALLOCATE @cursor;
	END