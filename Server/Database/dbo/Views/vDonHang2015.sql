﻿CREATE VIEW dbo.vDonHang2015
AS
SELECT        dbo.tDonHang.Ngay, dbo.rKhoHang.Ma AS MaKho, dbo.rKhoHang.TenKho, dbo.rKhachHang.Ma AS MaKH, dbo.rKhachHang.TenKhachHang, 
                         dbo.tMatHang.Ma AS MaMatHang, dbo.tMatHang.TenMatHang, dbo.tChiTietDonHang.SoLuong, dbo.rLoaiHang.Ma AS MaLoaiHang, dbo.rLoaiHang.TenLoai, 
                         dbo.tChiTietDonHang.SoLuong * dbo.tMatHang.SoKy AS SoKy, dbo.rLoaiHang.HangNhaLam, dbo.rKhachHang.KhachRieng
FROM            dbo.tDonHang INNER JOIN
                         dbo.tChiTietDonHang ON dbo.tDonHang.Ma = dbo.tChiTietDonHang.MaDonHang INNER JOIN
                         dbo.tMatHang ON dbo.tChiTietDonHang.MaMatHang = dbo.tMatHang.Ma INNER JOIN
                         dbo.rKhachHang ON dbo.tDonHang.MaKhachHang = dbo.rKhachHang.Ma INNER JOIN
                         dbo.rKhoHang ON dbo.tDonHang.MaKhoHang = dbo.rKhoHang.Ma INNER JOIN
                         dbo.rLoaiHang ON dbo.tMatHang.MaLoai = dbo.rLoaiHang.Ma
WHERE        (dbo.tDonHang.Ngay BETWEEN '20150224' AND '20160229')
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDonHang2015';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDonHang2015';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tDonHang"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tChiTietDonHang"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tMatHang"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rKhachHang"
            Begin Extent = 
               Top = 138
               Left = 270
               Bottom = 267
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rKhoHang"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 382
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rLoaiHang"
            Begin Extent = 
               Top = 270
               Left = 246
               Bottom = 382
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 144', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'vDonHang2015';

