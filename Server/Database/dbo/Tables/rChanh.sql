﻿CREATE TABLE [dbo].[rChanh] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [MaBaiXe]        INT            NOT NULL,
    [TenChanh]       NVARCHAR (200) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rChanh] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_rChanh_rBaiXe] FOREIGN KEY ([MaBaiXe]) REFERENCES [dbo].[rBaiXe] ([Ma])
);

