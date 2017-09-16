CREATE TABLE [dbo].[tChiTietNhapHang] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [MaNhapHang]     INT    NOT NULL,
    [MaMatHang]      INT    NOT NULL,
    [SoLuong]        INT    NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_NhapMatHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChiTietNhapHang_tNhapHang] FOREIGN KEY ([MaNhapHang]) REFERENCES [dbo].[tNhapHang] ([Ma]),
    CONSTRAINT [FK_tNhapMatHang_tMatHang] FOREIGN KEY ([MaMatHang]) REFERENCES [dbo].[tMatHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tChiTietNhapHang]
	ON [dbo].[tChiTietNhapHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		print('trigger [tr_tChiTietNhapHang]')
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
		DECLARE @cursorTK as CURSOR;
 
		SET @cursorTK = CURSOR FOR		
			select sum(t.SoLuong) as SoLuong, dh.MaKhoHang, t.MaMatHang, dh.Ngay
				from(select SoLuong, MaNhapHang, MaMatHang from inserted
					union
					select -SoLuong, MaNhapHang, MaMatHang from deleted) as t
				join tNhapHang dh on t.MaNhapHang = dh.Ma
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
	END