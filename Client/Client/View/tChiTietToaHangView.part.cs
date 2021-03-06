﻿using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietToaHangView : BaseView<tChiTietToaHangDto, tChiTietToaHangDataModel>
    {
        partial void InitUIPartial()
        {
            var columnThanhTien = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.tToaHang_ThanhTien,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(tChiTietToaHangDataModel.ThanhTien)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            columnThanhTien.SetStyleAsRightAlignIntegerNumber();
            GridView.Columns.Insert(GridView.Columns.Count - 2, columnThanhTien);
        }
    }
}
