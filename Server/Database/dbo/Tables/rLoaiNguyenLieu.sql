CREATE TABLE [dbo].[rLoaiNguyenLieu] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [TenLoai]        NVARCHAR (100) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rLoaiNguyenLieu] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

