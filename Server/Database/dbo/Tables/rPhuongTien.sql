CREATE TABLE [dbo].[rPhuongTien] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [TenPhuongTien]  NVARCHAR (200) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_LoaiPhuongTien] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

