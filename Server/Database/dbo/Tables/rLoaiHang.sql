CREATE TABLE [dbo].[rLoaiHang] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [TenLoai]        NVARCHAR (200) NOT NULL,
    [HangNhaLam]     BIT            CONSTRAINT [DF_rLoaiHang_HangNhaLam] DEFAULT ((0)) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rProductType] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

