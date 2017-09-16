CREATE TABLE [dbo].[ThamSoNgay] (
    [Ma]             INT           IDENTITY (1, 1) NOT NULL,
    [Ten]            NVARCHAR (50) NOT NULL,
    [GiaTri]         DATE          NOT NULL,
    [TenantID]       INT           DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT        DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT        DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ThamSoNgay] PRIMARY KEY CLUSTERED ([Ma] ASC)
);

