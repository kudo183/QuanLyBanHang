﻿using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChuyenKhoView : BaseView<tChuyenKhoDto>
    {
        partial void InitUIPartial()
        {
            var columnTongSoLuong = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.tChuyenKho_TongSoLuong,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(tChuyenKhoDto.TongSoLuong)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            columnTongSoLuong.SetStyleAsRightAlignIntegerNumber();
            GridView.Columns.Insert(GridView.Columns.Count - 2, columnTongSoLuong);
        }
    }
}
