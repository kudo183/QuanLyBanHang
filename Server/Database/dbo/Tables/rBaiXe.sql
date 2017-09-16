CREATE TABLE [dbo].[rBaiXe] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [DiaDiemBaiXe]   NVARCHAR (300) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rBaiXe] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

