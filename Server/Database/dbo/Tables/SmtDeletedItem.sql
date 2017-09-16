CREATE TABLE [dbo].[SmtDeletedItem] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [DeletedID]  INT           NOT NULL,
    [TableID]    INT           NOT NULL,
    [CreateTime] BIGINT        NOT NULL,
    [CreateDate] DATETIME2 (7) CONSTRAINT [DF_SmtDeletedItems_CreateDate] DEFAULT (getutcdate()) NOT NULL,
    [TenantID]   INT           NOT NULL,
    CONSTRAINT [PK_SmtDeletedItems] PRIMARY KEY CLUSTERED ([ID] ASC)
);

