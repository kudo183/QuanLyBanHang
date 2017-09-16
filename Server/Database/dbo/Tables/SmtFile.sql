CREATE TABLE [dbo].[SmtFile] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [TenantID]       INT            NOT NULL,
    [FileName]       NVARCHAR (256) NOT NULL,
    [FileSize]       BIGINT         NOT NULL,
    [MimeType]       VARCHAR (128)  NOT NULL,
    [CreateTime]     BIGINT         NOT NULL,
    [LastUpdateTime] BIGINT         NOT NULL,
    CONSTRAINT [PK_SmtFile] PRIMARY KEY CLUSTERED ([ID] ASC)
);

