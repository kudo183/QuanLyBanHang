CREATE TABLE [dbo].[tChiTietToaHang] (
    [Ma]               INT    IDENTITY (1, 1) NOT NULL,
    [MaToaHang]        INT    NOT NULL,
    [MaChiTietDonHang] INT    NOT NULL,
    [GiaTien]          INT    NOT NULL,
    [TenantID]         INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]       BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime]   BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tChiTietToaHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChiTietToaHang_tChiTietDonHang] FOREIGN KEY ([MaChiTietDonHang]) REFERENCES [dbo].[tChiTietDonHang] ([Ma]),
    CONSTRAINT [FK_tChiTietToaHang_tToaHang] FOREIGN KEY ([MaToaHang]) REFERENCES [dbo].[tToaHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tChiTietToaHang]
	ON [dbo].[tChiTietToaHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		print('trigger [tr_tChiTietToaHang]')
		IF trigger_nestlevel() > 1
			return

		print('update SoTien of tCongNoKhachHang')
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated
		DECLARE @maKhachHang as INT;
		DECLARE @soTien as INT;
		DECLARE @ngay as Date;
		DECLARE @cursorCN as CURSOR;
 
		SET @cursorCN = CURSOR FOR		
			select sum(GiaTien*ctdh.SoLuong) as SoTien, MaKhachHang, Ngay
			from(
				SELECT GiaTien, MaToaHang, MaChiTietDonHang FROM inserted
				union
				SELECT -GiaTien, MaToaHang, MaChiTietDonHang FROM deleted) as t
			JOIN tChiTietDonHang ctdh on ctdh.Ma=t.MaChiTietDonHang
			JOIN tToaHang th on th.Ma=t.MaToaHang
			group by Ngay, MaKhachHang
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