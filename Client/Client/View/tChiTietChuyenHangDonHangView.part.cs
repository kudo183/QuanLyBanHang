using Client.ViewModel;
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

            if (selectedDto.MaChuyenHangDonHangtChuyenHangDonHangDto == null)
            {
                return;
            }

            Logger.Instance.Info("selected tChiTietChuyenHangDonHangDto changed: UpdateDonHangForeignKeyPicker", Logger.Categories.UI);
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
            var vm = (GridView.dataGrid.Columns[2] as DataGridForeignKeyColumn).PopupView.DataContext as tChiTietDonHangViewModel;
            var maDonHang = selectedDto.MaChuyenHangDonHangtChuyenHangDonHangDto.MaDonHang;
            vm.HeaderFilters[1].DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = maDonHang; });
            if (_isLoaded == true)
            {
                vm.Load();
            }
        }
    }
}
