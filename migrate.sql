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

USE [PhuDinh]
GO
/****** Object:  StoredProcedure [dbo].[InitData]    Script Date: 7/11/2017 6:18:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[InitData]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @LastUpdate date;
	select @LastUpdate=GiaTri from ThamSoNgay where Ma=1;
	print('last update ' + RTRIM(CAST(@LastUpdate AS nvarchar(30))));

	declare @Now date = getdate();
	declare @DayCount Int = DATEDIFF(day, @LastUpdate, @Now);
	print('day count ' + RTRIM(CAST(@DayCount AS nvarchar(30))));

	if(@DayCount <= 0)
		return;
	
	declare @CurrentDay date = @LastUpdate;
	declare @NextDay date = DATEADD(day, 1, @CurrentDay);
	declare @Index Int = 0;
	WHILE @Index < @DayCount
	BEGIN
		print('next day ' + RTRIM(CAST(@NextDay AS nvarchar(30))));

		INSERT INTO tTonKho(MaKhoHang, MaMatHang, Ngay, SoLuong, SoLuongCu, TenantID)
		SELECT MaKhoHang, MaMatHang, @NextDay, SoLuong, SoLuongCu, TenantID FROM tTonKho where Ngay = @CurrentDay;
		
		INSERT INTO tCongNoKhachHang(MaKhachHang, Ngay, SoTien, TenantID)
		SELECT MaKhachHang, @NextDay, SoTien, TenantID FROM tCongNoKhachHang where Ngay = @CurrentDay;
		
		update tk
		set tk.SoLuong = tk.SoLuong - ct.SoLuong
		from tDonHang dh join tChiTietDonHang ct on dh.Ma = ct.MaDonHang
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = dh.MaKhoHang and tk.Ngay=dh.Ngay
		where dh.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong + ct.SoLuong
		from tNhapHang nh join tChiTietNhapHang ct on nh.Ma = ct.MaNhapHang
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = nh.MaKhoHang and tk.Ngay=nh.Ngay
		where nh.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong + ct.SoLuong
		from tChuyenKho ck join tChiTietChuyenKho ct on ck.Ma = ct.MaChuyenKho
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = ck.MaKhoHangNhap and tk.Ngay=ck.Ngay
		where ck.Ngay = @NextDay
		
		update tk
		set tk.SoLuong = tk.SoLuong - ct.SoLuong
		from tChuyenKho ck join tChiTietChuyenKho ct on ck.Ma = ct.MaChuyenKho
		join tTonKho tk on tk.MaMatHang = ct.MaMatHang and tk.MaKhoHang = ck.MaKhoHangXuat and tk.Ngay=ck.Ngay
		where ck.Ngay = @NextDay
	
		update cn
		set cn.SoTien = cn.SoTien + (ctth.GiaTien * ctdh.SoLuong)
		from tToaHang th join tChiTietToaHang ctth on th.Ma=ctth.MaToaHang
		join tChiTietDonHang ctdh on ctdh.Ma=ctth.MaChiTietDonHang
		join tCongNoKhachHang cn on cn.MaKhachHang = th.MaKhachHang and cn.Ngay=th.Ngay
		where th.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien - nt.SoTien
		from tNhanTienKhachHang nt
		join tCongNoKhachHang cn on cn.MaKhachHang = nt.MaKhachHang and cn.Ngay=nt.Ngay
		where nt.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien - gt.SoTien
		from tGiamTruKhachHang gt
		join tCongNoKhachHang cn on cn.MaKhachHang = gt.MaKhachHang and cn.Ngay=gt.Ngay
		where gt.Ngay = @NextDay
		
		update cn
		set cn.SoTien = cn.SoTien + pt.SoTien
		from tPhuThuKhachHang pt
		join tCongNoKhachHang cn on cn.MaKhachHang = pt.MaKhachHang and cn.Ngay=pt.Ngay
		where pt.Ngay = @NextDay

		set @CurrentDay = @NextDay;
		set @NextDay = DATEADD(day,1,@CurrentDay);
		set @Index = @Index + 1;
	END;
	
	print('current day ' + RTRIM(CAST(@CurrentDay AS nvarchar(30))));
	UPDATE ThamSoNgay
	set GiaTri=@CurrentDay
	where Ma=1

	declare @MinDate date = DATEADD(day, -90, @CurrentDay);
	print('min date ' + RTRIM(CAST(@MinDate AS nvarchar(30))));
	delete from tTonKho where Ngay < @MinDate;
	delete from tCongNoKhachHang where Ngay < @MinDate;
END