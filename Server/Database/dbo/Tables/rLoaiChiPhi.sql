CREATE TABLE [dbo].[rLoaiChiPhi] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [TenLoaiChiPhi]  NVARCHAR (200) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rLoaiChiPhi] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

