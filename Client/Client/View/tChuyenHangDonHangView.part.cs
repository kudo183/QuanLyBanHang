using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;

namespace Client.View
{
    public partial class tChuyenHangDonHangView : BaseView<tChuyenHangDonHangDto>
    {
        partial void InitUIPartial()
        {
            var column = GridView.FindColumn(nameof(tChuyenHangDonHangDto.MaDonHang));
            var donhangFKP = (column as DataGridForeignKeyColumn).PopupView as tDonHangView;

            var filter = donhangFKP.GridView.FindHeaderFilter(nameof(tDonHangDto.Xong));
            filter.DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = false; p.IsHitTestVisible = false; });

            if (donhangFKP.IsLoaded == true)
            {
                donhangFKP.ViewModel.Load();
            }
        }
    }
}
