CREATE TABLE [dbo].[tChiPhi] (
    [Ma]                 INT            IDENTITY (1, 1) NOT NULL,
    [MaNhanVienGiaoHang] INT            NOT NULL,
    [MaLoaiChiPhi]       INT            NOT NULL,
    [SoTien]             INT            NOT NULL,
    [Ngay]               DATE           NOT NULL,
    [GhiChu]             NVARCHAR (MAX) NULL,
    [TenantID]           INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]         BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ChiPhiNhanVienGiaoHang] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tChiPhiNhanVienGiaoHang_rLoaiChiPhi] FOREIGN KEY ([MaLoaiChiPhi]) REFERENCES [dbo].[rLoaiChiPhi] ([Ma]),
    CONSTRAINT [FK_tChiPhiNhanVienGiaoHang_rNhanVienGiaoHang] FOREIGN KEY ([MaNhanVienGiaoHang]) REFERENCES [dbo].[rNhanVien] ([Ma])
);

