CREATE TABLE [dbo].[rNuoc] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [TenNuoc]        NVARCHAR (100) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rNuoc] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

