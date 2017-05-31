create procedure dbo.sp_DropDefaultConstraint
      @tableName varchar(128),
      @columnName varchar(128)
      as

set nocount on
   
declare @constraintName varchar(128)
set @constraintName = (
    select top 1 dc.NAME
    from sys.default_constraints dc
    JOIN sys.columns c
        ON c.default_object_id = dc.object_id
    WHERE
		c.name = @columnName and
        dc.parent_object_id = OBJECT_ID(@tableName) )
if @constraintName is not null
begin
	print ('alter table ' + @tableName + ' drop constraint "' + @constraintName+'"')
	exec ('alter table ' + @tableName + ' drop constraint "' + @constraintName+'"')
end

go

drop table SwaUserGroup
go
drop table SwaGroup
go
drop table SwaUser
go

exec sp_msforeachtable 'exec dbo.sp_DropDefaultConstraint ''?'', ''GroupID''; ';
go
exec sp_msforeachtable 'alter table ? drop column GroupID';
go
exec sp_msforeachtable 'alter table ? add TenantID int not null default 1';
go
exec sp_msforeachtable 'alter table ? add CreateTime bigint not null default 0';
go
exec sp_msforeachtable 'alter table ? add LastUpdateTime bigint not null default 0';

GO
/****** Object:  Table [dbo].[SmtDeletedItem]    Script Date: 4/29/2017 3:11:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmtDeletedItem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DeletedID] [int] NOT NULL,
	[TableID] [int] NOT NULL,
	[CreateTime] [bigint] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_SmtDeletedItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SmtTable]    Script Date: 4/29/2017 3:11:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmtTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SmtTables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SmtTenant]    Script Date: 4/29/2017 3:11:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmtTenant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[PasswordHash] [varchar](128) NOT NULL,
	[TenantName] [varchar](256) NOT NULL,
	[TokenValidTime] [bigint] NOT NULL,
	[LastUpdateTime] [bigint] NOT NULL,
	[IsConfirmed] [bit] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[CreateTime] [bigint] NOT NULL,
 CONSTRAINT [PK_SmtTenant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SmtUser]    Script Date: 4/29/2017 3:11:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmtUser](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Email] [varchar](256) NOT NULL,
	[PasswordHash] [varchar](128) NOT NULL,
	[UserName] [varchar](256) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TokenValidTime] [bigint] NOT NULL,
	[LastUpdateTime] [bigint] NOT NULL,
	[IsConfirmed] [bit] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[CreateTime] [bigint] NOT NULL,
 CONSTRAINT [PK_SmtUser] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SmtUserClaim]    Script Date: 4/29/2017 3:11:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmtUserClaim](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Claim] [varchar](256) NOT NULL,
	[TenantID] [int] NOT NULL,
	[LastUpdateTime] [bigint] NOT NULL,
	[CreateTime] [bigint] NOT NULL,
 CONSTRAINT [PK_SmtUserClaim] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SmtDeletedItem] ADD  CONSTRAINT [DF_SmtDeletedItems_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[SmtTenant] ADD  CONSTRAINT [DF_SmtTenant_LastUpdateTime]  DEFAULT ((0)) FOR [LastUpdateTime]
GO
ALTER TABLE [dbo].[SmtTenant] ADD  CONSTRAINT [DF_SmtTenant_IsConfirmed]  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[SmtTenant] ADD  CONSTRAINT [DF_SmtTenant_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[SmtUser] ADD  CONSTRAINT [DF_SmtUser_LastUpdateTime]  DEFAULT ((0)) FOR [LastUpdateTime]
GO
ALTER TABLE [dbo].[SmtUser] ADD  CONSTRAINT [DF_SmtUser_IsConfirmed]  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[SmtUser] ADD  CONSTRAINT [DF_SmtUser_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[SmtUserClaim] ADD  CONSTRAINT [DF_SmtUserClaim_LastUpdateTime]  DEFAULT ((0)) FOR [LastUpdateTime]
GO
ALTER TABLE [dbo].[SmtUser]  WITH CHECK ADD  CONSTRAINT [FK_SmtUser_SmtTenant] FOREIGN KEY([TenantID])
REFERENCES [dbo].[SmtTenant] ([ID])
GO
ALTER TABLE [dbo].[SmtUser] CHECK CONSTRAINT [FK_SmtUser_SmtTenant]
GO
ALTER TABLE [dbo].[SmtUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_SmtUserClaim_SmtTenant] FOREIGN KEY([TenantID])
REFERENCES [dbo].[SmtTenant] ([ID])
GO
ALTER TABLE [dbo].[SmtUserClaim] CHECK CONSTRAINT [FK_SmtUserClaim_SmtTenant]
GO
ALTER TABLE [dbo].[SmtUserClaim]  WITH CHECK ADD  CONSTRAINT [FK_SmtUserClaim_SmtUserClaim] FOREIGN KEY([UserID])
REFERENCES [dbo].[SmtUser] ([ID])
GO
ALTER TABLE [dbo].[SmtUserClaim] CHECK CONSTRAINT [FK_SmtUserClaim_SmtUserClaim]
GO

insert into SmtTable (TableName)
SELECT TABLE_NAME
FROM PhuDinh.INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
go

GO
SET IDENTITY_INSERT [dbo].[SmtTenant] ON 

GO
INSERT [dbo].[SmtTenant] ([ID], [CreateDate], [Email], [PasswordHash], [TenantName], [TokenValidTime], [LastUpdateTime], [IsConfirmed], [IsLocked], [CreateTime]) VALUES (1, CAST(N'2017-05-16T11:20:36.1670410' AS DateTime2), N'test', N'chhZGYNC0qlzIkXwIMmCNH2SMg+ZgmflHd6A47VBK+1i1MUmYp9Bnvx2UjvthBSz', N'test', 636305304556291592, 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[SmtTenant] OFF
GO
