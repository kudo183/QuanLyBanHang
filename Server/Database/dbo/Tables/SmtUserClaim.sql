CREATE TABLE [dbo].[SmtUserClaim] (
    [ID]             INT           IDENTITY (1, 1) NOT NULL,
    [UserID]         INT           NOT NULL,
    [Claim]          VARCHAR (256) NOT NULL,
    [TenantID]       INT           NOT NULL,
    [LastUpdateTime] BIGINT        CONSTRAINT [DF_SmtUserClaim_LastUpdateTime] DEFAULT ((0)) NOT NULL,
    [CreateTime]     BIGINT        NOT NULL,
    CONSTRAINT [PK_SmtUserClaim] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_SmtUserClaim_SmtTenant] FOREIGN KEY ([TenantID]) REFERENCES [dbo].[SmtTenant] ([ID]),
    CONSTRAINT [FK_SmtUserClaim_SmtUserClaim] FOREIGN KEY ([UserID]) REFERENCES [dbo].[SmtUser] ([ID])
);

