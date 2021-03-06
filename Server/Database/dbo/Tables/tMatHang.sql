﻿CREATE TABLE [dbo].[tMatHang] (
    [Ma]              INT            IDENTITY (1, 1) NOT NULL,
    [MaLoai]          INT            NOT NULL,
    [TenMatHang]      NVARCHAR (200) NOT NULL,
    [SoKy]            INT            CONSTRAINT [DF_tMatHang_SoKy] DEFAULT ((0)) NOT NULL,
    [SoMet]           INT            CONSTRAINT [DF_tMatHang_SoMet] DEFAULT ((0)) NOT NULL,
    [TenMatHangDayDu] NVARCHAR (200) CONSTRAINT [DF_tMatHang_TenMatHangDayDu] DEFAULT ('') NOT NULL,
    [TenMatHangIn]    NVARCHAR (50)  CONSTRAINT [DF_tMatHang_TenMatHangIn] DEFAULT ('') NOT NULL,
    [MaHinhAnh]       INT            CONSTRAINT [DF_tMatHang_MaHinhAnh] DEFAULT ((0)) NOT NULL,
    [TenantID]        INT            CONSTRAINT [DF__tMatHang__Tenant__019E3B86] DEFAULT ((1)) NOT NULL,
    [CreateTime]      BIGINT         CONSTRAINT [DF__tMatHang__Create__23F3538A] DEFAULT ((0)) NOT NULL,
    [LastUpdateTime]  BIGINT         CONSTRAINT [DF__tMatHang__LastUp__46486B8E] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Ma] ASC),
    CONSTRAINT [FK_tMatHang_rLoaiHang] FOREIGN KEY ([MaLoai]) REFERENCES [dbo].[rLoaiHang] ([Ma])
);



