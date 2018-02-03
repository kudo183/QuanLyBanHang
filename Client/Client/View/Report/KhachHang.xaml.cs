using Client.DataModel;
using Client.ViewModel.Report;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using huypq.wpf.Utils;
using Shared;
using Shared.Report;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Client.View.Report
{
    /// <summary>
    /// Interaction logic for KhachHang.xaml
    /// </summary>
    public partial class KhachHang : UserControl
    {
        KhachHangViewModel vm;
        IDataService _dataService = ServiceLocator.Get<IDataService>();
        NameValueCollection parameters = new NameValueCollection();
        List<KhachHangDto> reportData = new List<KhachHangDto>();

        public KhachHang()
        {
            InitializeComponent();

            vm = new KhachHangViewModel();
            vm.DateRangePickerViewModel = new huypq.wpf.controls.DateRangePickerViewModel();
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();
            vm.KhachHangs = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.Get().ToList();
            DataContext = vm;
        }

        private void Button_OkClick(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Report()
        {
            parameters["dateFrom"] = DateToString(vm.DateRangePickerViewModel.DateFrom);
            parameters["dateTo"] = DateToString(vm.DateRangePickerViewModel.DateTo);
            parameters["maKhachHang"] = vm.KhachHangs[vm.KhachHangIndex].ID.ToString();
            reportData = _dataService.Report<KhachHangDto>("khachhang", parameters).Items;

            var result = new List<KhachHangViewModel.RowData>();
            var dictionaryGroupByMaMatHang = new Dictionary<int, KhachHangViewModel.RowData>();

            foreach (var kh in reportData)
            {
                var isFirst = true;
                foreach (var ct in kh.ChiTiet)
                {
                    if (isFirst == true)
                    {
                        result.Add(new KhachHangViewModel.RowData()
                        {
                            Ngay = kh.Ngay.ToShortDateString(),
                            TenKho = kh.TenKho,
                            TenMatHang = ct.TenMatHang,
                            SoLuong = ct.SoLuong
                        });
                        isFirst = false;
                    }
                    else
                    {
                        result.Add(new KhachHangViewModel.RowData()
                        {
                            Ngay = "",
                            TenKho = "",
                            TenMatHang = ct.TenMatHang,
                            SoLuong = ct.SoLuong
                        });
                    }

                    KhachHangViewModel.RowData r;
                    if (dictionaryGroupByMaMatHang.TryGetValue(ct.MaMatHang, out r) == false)
                    {
                        r = new KhachHangViewModel.RowData()
                        {
                            Ngay = "",
                            TenKho = "",
                            TenMatHang = ct.TenMatHang,
                            SoLuong = 0
                        };
                        dictionaryGroupByMaMatHang.Add(ct.MaMatHang, r);
                    }
                    r.SoLuong = r.SoLuong + ct.SoLuong;
                }
                result.Add(new KhachHangViewModel.RowData());
            }

            foreach (var item in dictionaryGroupByMaMatHang)
            {
                result.Add(item.Value);
            }
            vm.Items = result;
            vm.Msg = string.Format("");
        }

        private string DateToString(DateTime date)
        {
            return string.Format("{0:0000}{1:00}{2:00}", date.Year, date.Month, date.Day);
        }
    }
}
