CREATE TABLE [dbo].[tNhapHang] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [MaNhanVien]     INT    NOT NULL,
    [MaKhoHang]      INT    NOT NULL,
    [MaNhaCungCap]   INT    NOT NULL,
    [Ngay]           DATE   NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tNhapHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tNhapHang_rKhoHang] FOREIGN KEY ([MaKhoHang]) REFERENCES [dbo].[rKhoHang] ([Ma]),
    CONSTRAINT [FK_tNhapHang_rNhaCungCap] FOREIGN KEY ([MaNhaCungCap]) REFERENCES [dbo].[rNhaCungCap] ([Ma]),
    CONSTRAINT [FK_tNhapHang_rNhanVien] FOREIGN KEY ([MaNhanVien]) REFERENCES [dbo].[rNhanVien] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tNhapHang]
	ON [dbo].[tNhapHang]
	after UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		
		print('trigger [tr_tNhapHang]')
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
			select sum(t.SoLuong) as SoLuong, t.MaKhoHang, t.MaMatHang, t.Ngay
				from(select SoLuong, MaKhoHang, MaMatHang, Ngay from inserted i join tChiTietNhapHang ct on i.Ma = ct.MaNhapHang
					union
					select -SoLuong, MaKhoHang, MaMatHang, Ngay from deleted d join tChiTietNhapHang ct on d.Ma = ct.MaNhapHang) as t
				group by t.MaKhoHang, t.MaMatHang, t.Ngay
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