CREATE TABLE [dbo].[tGiamTruKhachHang] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [MaKhachHang]    INT            NOT NULL,
    [Ngay]           DATE           NOT NULL,
    [SoTien]         INT            NOT NULL,
    [GhiChu]         NVARCHAR (300) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tGiamTruKhachHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tGiamTruKhachHang_rKhachHang] FOREIGN KEY ([MaKhachHang]) REFERENCES [dbo].[rKhachHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tGiamTruKhachHang]
	ON [dbo].[tGiamTruKhachHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		SET NOCOUNT ON

		print('trigger [tr_tGiamTruKhachHang]')
		IF trigger_nestlevel() > 1
			return
		
		print('update SoTien of tCongNoKhachHang')
		--https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql
		--The results of an UPDATE statement are undefined if the statement includes a FROM clause that is not specified in such a way
		--that only one value is available for each column occurrence that is updated
		DECLARE @maKhachHang as INT;
		DECLARE @soTien as INT;
		DECLARE @ngay as DATE;
		DECLARE @cursorCN as CURSOR;
 
		SET @cursorCN = CURSOR FOR		
			select sum(SoTien) as SoTien, MaKhachHang, Ngay
			from(
				SELECT SoTien, Ngay, MaKhachHang FROM deleted
				union
				SELECT -SoTien, Ngay, MaKhachHang FROM inserted) as t
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