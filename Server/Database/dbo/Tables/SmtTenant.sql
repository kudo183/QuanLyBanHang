CREATE TABLE [dbo].[SmtTenant] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [CreateDate]     DATETIME2 (7) NOT NULL,
    [Email]          VARCHAR (256) NOT NULL,
    [PasswordHash]   VARCHAR (128) NOT NULL,
    [TenantName]     VARCHAR (256) NOT NULL,
    [TokenValidTime] BIGINT        NOT NULL,
    [LastUpdateTime] BIGINT        CONSTRAINT [DF_SmtTenant_LastUpdateTime] DEFAULT ((0)) NOT NULL,
    [IsConfirmed]    BIT           CONSTRAINT [DF_SmtTenant_IsConfirmed] DEFAULT ((0)) NOT NULL,
    [IsLocked]       BIT           CONSTRAINT [DF_SmtTenant_IsLocked] DEFAULT ((0)) NOT NULL,
    [CreateTime]     BIGINT        NOT NULL,
    CONSTRAINT [PK_SmtTenant] PRIMARY KEY CLUSTERED ([ID] ASC)
);

