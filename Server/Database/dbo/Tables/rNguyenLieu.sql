CREATE TABLE [dbo].[rNguyenLieu] (
    [Ma]               INT    IDENTITY (1, 1) NOT NULL,
    [MaLoaiNguyenLieu] INT    NOT NULL,
    [DuongKinh]        INT    NOT NULL,
    [TenantID]         INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]       BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime]   BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rNguyenLieu] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_rNguyenLieu_rLoaiNguyenLieu] FOREIGN KEY ([MaLoaiNguyenLieu]) REFERENCES [dbo].[rLoaiNguyenLieu] ([Ma])
);

