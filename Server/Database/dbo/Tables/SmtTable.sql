CREATE TABLE [dbo].[SmtTable] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [TableName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_SmtTables] PRIMARY KEY CLUSTERED ([ID] ASC)
);

