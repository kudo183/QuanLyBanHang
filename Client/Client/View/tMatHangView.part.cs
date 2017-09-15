using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Windows.Data;

namespace Client.View
{
    public partial class tMatHangView : BaseView<tMatHangDto>
    {
        partial void InitUIPartial()
        {
            var imageColumn = new SimpleDataGrid.DataGridImageColumn()
            {
                Header = nameof(tMatHangDto.MaHinhAnh),
                Binding = new Binding(nameof(tMatHangDto.HinhAnhFilePath)),
                ImageStreamBinding = new Binding(nameof(tMatHangDto.HinhAnhImageStream))
            };

            GridView.Columns[GridView.FindColumnIndex(nameof(tMatHangDto.MaHinhAnh))] = imageColumn;
        }
    }
}
