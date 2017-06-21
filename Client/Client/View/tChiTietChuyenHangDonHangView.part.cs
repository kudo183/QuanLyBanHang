using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;

namespace Client.View
{
    public partial class tChiTietChuyenHangDonHangView : BaseView<tChiTietChuyenHangDonHangDto>
    {
        tChiTietChuyenHangDonHangDto selectedDto;

        partial void InitUIPartial()
        {
            GridView.dataGrid.SelectionChanged += DataGrid_SelectionChanged;
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (sender != e.OriginalSource)
            {
                return;
            }

            selectedDto = ViewModel.GetSelectedItem() as tChiTietChuyenHangDonHangDto;
            if (selectedDto == null)
            {
                return;
            }

            if (selectedDto.MaChuyenHangDonHangNavigation == null)
            {
                return;
            }

            Logger.Instance.Info("selected MaChuyenHangDonHangNavigation changed: UpdateDonHangForeignKeyPicker", Logger.Categories.UI);
            UpdateChiTietDonHangForeignKeyPicker();

            selectedDto.PropertyChanged -= SelectedDto_PropertyChanged;
            selectedDto.PropertyChanged += SelectedDto_PropertyChanged;
        }

        private void SelectedDto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tChiTietChuyenHangDonHangDto.MaChuyenHangDonHang))
            {
                Logger.Instance.Info("MaChuyenHangDonHang changed: UpdateDonHangForeignKeyPicker", Logger.Categories.UI);
                UpdateChiTietDonHangForeignKeyPicker();
            }
        }

        private void UpdateChiTietDonHangForeignKeyPicker()
        {
            var column = GridView.FindColumn(nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHang));
            var ctdhFKP = (column as DataGridForeignKeyColumn).PopupView as tChiTietDonHangView;

            var maDonHang = selectedDto.MaChuyenHangDonHangNavigation.MaDonHang;
            var filter = ctdhFKP.GridView.FindHeaderFilter(nameof(tChiTietDonHangDto.MaDonHang));
            filter.DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = maDonHang; p.IsHitTestVisible = false; });

            if (ctdhFKP.IsLoaded == true)
            {
                ctdhFKP.ViewModel.Load();
            }
        }
    }
}
