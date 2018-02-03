using Client.DataModel;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using SimpleDataGrid;

namespace Client.View
{
    public partial class tChiTietChuyenHangDonHangView : BaseView<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        tChiTietChuyenHangDonHangDataModel selectedDataModel;

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

            selectedDataModel = ViewModel.GetSelectedItem() as tChiTietChuyenHangDonHangDataModel;
            if (selectedDataModel == null)
            {
                return;
            }

            if (selectedDataModel.MaChuyenHangDonHangNavigation == null)
            {
                return;
            }

            UpdateChiTietDonHangForeignKeyPicker();

            selectedDataModel.PropertyChanged -= SelectedDto_PropertyChanged;
            selectedDataModel.PropertyChanged += SelectedDto_PropertyChanged;
        }

        private void SelectedDto_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(tChiTietChuyenHangDonHangDataModel.MaChuyenHangDonHang))
            {
                UpdateChiTietDonHangForeignKeyPicker();
            }
        }

        private void UpdateChiTietDonHangForeignKeyPicker()
        {
            var column = GridView.FindColumn(nameof(tChiTietChuyenHangDonHangDataModel.MaChiTietDonHang));
            var ctdhFKP = (column as DataGridForeignKeyColumn).PopupView as tChiTietDonHangView;

            var maDonHang = selectedDataModel.MaChuyenHangDonHangNavigation.MaDonHang;
            var filter = ctdhFKP.GridView.FindHeaderFilter(nameof(tChiTietDonHangDataModel.MaDonHang));
            filter.DisableChangedAction(p => { p.IsUsed = true; p.FilterValue = maDonHang; p.IsHitTestVisible = false; });

            if (ctdhFKP.IsLoaded == true)
            {
                ctdhFKP.ViewModel.Load();
            }
        }
    }
}
