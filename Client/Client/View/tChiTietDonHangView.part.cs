using Client.DataModel;

namespace Client.View
{
    public partial class tChiTietDonHangView
    {
        partial void InitUIPartial()
        {
            var columnTonKho = new SimpleDataGrid.DataGridTextColumnExt()
            {
                Width = 150,
                IsReadOnly = true,
                Header = TextManager.tChiTietDonHang_TonKho,
                Binding = new System.Windows.Data.Binding()
                {
                    Path = new System.Windows.PropertyPath(nameof(tChiTietDonHangDataModel.TonKho)),
                    Mode = System.Windows.Data.BindingMode.OneWay
                }
            };
            columnTonKho.SetStyleAsRightAlignIntegerNumber();
            GridView.Columns.Insert(GridView.Columns.Count - 3, columnTonKho);
        }
    }
}
