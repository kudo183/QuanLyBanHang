using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;

namespace Client.View
{
    public partial class tChuyenHangDonHangView : BaseView<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>
    {
        partial void InitUIPartial()
        {
            var column = GridView.FindColumn(nameof(tChuyenHangDonHangDataModel.MaDonHang));
            var donhangFKP = (column as DataGridForeignKeyColumn).PopupView as tDonHangView;

            var filter = donhangFKP.GridView.FindHeaderFilter(nameof(tDonHangDataModel.Xong));
            filter.DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = false; p.IsHitTestVisible = false; });

            if (donhangFKP.IsLoaded == true)
            {
                donhangFKP.ViewModel.Load();
            }
        }
    }
}
