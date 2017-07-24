using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.View
{
    public partial class tChiTietToaHangView : BaseView<tChiTietToaHangDto>
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
                    Path = new System.Windows.PropertyPath(nameof(tChiTietToaHangDto.ThanhTien)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            columnThanhTien.SetStyleAsRightAlignIntegerNumber();
            GridView.Columns.Insert(GridView.Columns.Count - 2, columnThanhTien);
        }
    }
}
