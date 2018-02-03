using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Windows.Data;

namespace Client.View
{
    public partial class tMatHangView : BaseView<tMatHangDto, tMatHangDataModel>
    {
        partial void InitUIPartial()
        {
            var imageColumn = new SimpleDataGrid.DataGridImageColumn()
            {
                Header = nameof(tMatHangDataModel.MaHinhAnh),
                Binding = new Binding(nameof(tMatHangDataModel.HinhAnhFilePath)),
                ImageStreamBinding = new Binding(nameof(tMatHangDataModel.HinhAnhImageStream))
            };

            GridView.Columns[GridView.FindColumnIndex(nameof(tMatHangDataModel.MaHinhAnh))] = imageColumn;
        }
    }
}
