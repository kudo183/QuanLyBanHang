CREATE TABLE [dbo].[SmtUser] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [CreateDate]     DATETIME2 (7) NOT NULL,
    [Email]          VARCHAR (256) NOT NULL,
    [PasswordHash]   VARCHAR (128) NOT NULL,
    [UserName]       VARCHAR (256) NOT NULL,
    [TenantID]       INT           NOT NULL,
    [TokenValidTime] BIGINT        NOT NULL,
    [LastUpdateTime] BIGINT        CONSTRAINT [DF_SmtUser_LastUpdateTime] DEFAULT ((0)) NOT NULL,
    [IsConfirmed]    BIT           CONSTRAINT [DF_SmtUser_IsConfirmed] DEFAULT ((0)) NOT NULL,
    [IsLocked]       BIT           CONSTRAINT [DF_SmtUser_IsLocked] DEFAULT ((0)) NOT NULL,
    [CreateTime]     BIGINT        NOT NULL,
    CONSTRAINT [PK_SmtUser] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SmtUser_SmtTenant] FOREIGN KEY ([TenantID]) REFERENCES [dbo].[SmtTenant] ([ID])
);

