CREATE TABLE [dbo].[tToaHang] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [Ngay]           DATE   NOT NULL,
    [MaKhachHang]    INT    NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tToaHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tToaHang_rKhachHang] FOREIGN KEY ([MaKhachHang]) REFERENCES [dbo].[rKhachHang] ([Ma])
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[tr_tToaHang]
	ON [dbo].[tToaHang]
	after insert, delete, UPDATE
	AS 
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		print('trigger [tr_tToaHang]')
		IF trigger_nestlevel() > 1
			return

		print('update SoTien of tCongNoKhachHang')
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated
		DECLARE @maKhachHang as INT;
		DECLARE @ngay as DATE;
		DECLARE @soTien as INT;
		DECLARE @cursorCN as CURSOR;
 
		SET @cursorCN = CURSOR FOR		
			select sum(ctdh.SoLuong*t.GiaTien) as SoTien, t.MaKhachHang, t.Ngay
			from(
				SELECT GiaTien, ctth.MaChiTietDonHang, i.Ngay, i.MaKhachHang FROM inserted i join tChiTietToaHang ctth on i.Ma=ctth.MaToaHang
				union
				SELECT -GiaTien, ctth.MaChiTietDonHang, d.Ngay, d.MaKhachHang FROM deleted d join tChiTietToaHang ctth on d.Ma=ctth.MaToaHang) as t
			join tChiTietDonHang ctdh on ctdh.Ma=t.MaChiTietDonHang
			group by t.Ngay, t.MaKhachHang
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