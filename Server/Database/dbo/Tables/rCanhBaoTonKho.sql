CREATE TABLE [dbo].[rCanhBaoTonKho] (
    [Ma]             INT    IDENTITY (1, 1) NOT NULL,
    [MaMatHang]      INT    NOT NULL,
    [MaKhoHang]      INT    NOT NULL,
    [TonCaoNhat]     INT    NOT NULL,
    [TonThapNhat]    INT    NOT NULL,
    [TenantID]       INT    DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rCanhBaoTonKho] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_rCanhBaoTonKho_rKhoHang] FOREIGN KEY ([MaKhoHang]) REFERENCES [dbo].[rKhoHang] ([Ma]),
    CONSTRAINT [FK_rCanhBaoTonKho_tMatHang] FOREIGN KEY ([MaMatHang]) REFERENCES [dbo].[tMatHang] ([Ma])
);

