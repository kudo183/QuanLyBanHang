CREATE TABLE [dbo].[rDiaDiem] (
    [Ma]             INT            IDENTITY (1, 1) NOT NULL,
    [MaNuoc]         INT            NOT NULL,
    [Tinh]           NVARCHAR (200) NOT NULL,
    [TenantID]       INT            DEFAULT ((1)) NOT NULL,
    [CreateTime]     BIGINT         DEFAULT ((0)) NOT NULL,
    [LastUpdateTime] BIGINT         DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_rDiaDiem] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_rDiaDiem_rNuoc] FOREIGN KEY ([MaNuoc]) REFERENCES [dbo].[rNuoc] ([Ma])
);

