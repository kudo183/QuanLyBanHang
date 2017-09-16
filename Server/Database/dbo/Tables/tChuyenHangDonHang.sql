CREATE TABLE [dbo].[tChuyenHangDonHang] (
    [Ma]                     INT    IDENTITY (1, 1) NOT NULL,
    [MaChuyenHang]           INT    NOT NULL,
    [MaDonHang]              INT    NOT NULL,
    [TongSoLuongTheoDonHang] INT    CONSTRAINT [DF_tChuyenHangDonHang_TongSoLuongTheoDonHang] DEFAULT ((0)) NOT NULL,
    [TongSoLuongThucTe]      INT    CONSTRAINT [DF_tChuyenHangDonHang_TongSoLuongThucTe] DEFAULT ((0)) NOT NULL,
    [TenantID]               INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]             BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime]         BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_tChuyenHangDonHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChuyenHangDonHang_tChuyenHang] FOREIGN KEY ([MaChuyenHang]) REFERENCES [dbo].[tChuyenHang] ([Ma]),
    CONSTRAINT [FK_tChuyenHangDonHang_tDonHang] FOREIGN KEY ([MaDonHang]) REFERENCES [dbo].[tDonHang] ([Ma])
);


GO

CREATE TRIGGER [dbo].[tr_tChuyenHangDonHang]
	ON [dbo].[tChuyenHangDonHang]
	after DELETE, INSERT, UPDATE
	AS
	BEGIN
		print('trigger [tr_tChuyenHangDonHang]');
		IF trigger_nestlevel() > 1
			return

		SET NOCOUNT ON
		
		print('update TongSoLuongTheoDonHang of tChuyenHangDonHang');
		update tChuyenHangDonHang
		set TongSoLuongTheoDonHang = (select TongSoLuong from tDonHang where Ma = tChuyenHangDonHang.MaDonHang)
		where tChuyenHangDonHang.Ma in (select distinct(Ma) from inserted union select distinct(Ma) from deleted)

		print('update TongSoLuongTheoDonHang, TongDonHang of tChuyenHang')
		update tChuyenHang
		set TongSoLuongTheoDonHang = (select ISNULL(sum(TongSoLuongTheoDonHang), 0) from tChuyenHangDonHang where MaChuyenHang = tChuyenHang.Ma)
			,TongDonHang = (select count(distinct(MaDonHang)) from tChuyenHangDonHang where MaChuyenHang = tChuyenHang.Ma)
		where tChuyenHang.Ma in (select distinct(MaChuyenHang) from inserted union select distinct(MaChuyenHang) from deleted)
	END