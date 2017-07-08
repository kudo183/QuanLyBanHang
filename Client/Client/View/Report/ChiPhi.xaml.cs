using Client.ViewModel.Report;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
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
    /// Interaction logic for ChiPhi.xaml
    /// </summary>
    public partial class ChiPhi : UserControl
    {
        ChiPhiViewModel vm;
        IDataService _dataService = ServiceLocator.Get<IDataService>();
        NameValueCollection parameters = new NameValueCollection();
        List<ReportChiPhiDto> chiPhis = new List<ReportChiPhiDto>();

        public ChiPhi()
        {
            InitializeComponent();

            vm = new ChiPhiViewModel();
            vm.DateRangePickerViewModel = new huypq.wpf.controls.DateRangePickerViewModel();

            vm.PropertyChanged += Vm_PropertyChanged;

            DataContext = vm;

            parameters.Add("dateFrom", DateToString(vm.DateRangePickerViewModel.DateFrom));
            parameters.Add("dateTo", DateToString(vm.DateRangePickerViewModel.DateTo));

            Report();
        }

        private void Vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChiPhiViewModel.SelectedItem))
            {
                if (vm.SelectedItem != null)
                {
                    vm.DetailItems = chiPhis.Where(p => p.MaLoaiChiPhi == vm.SelectedItem.MaLoaiChiPhi).ToList();
                }
                else
                {
                    vm.DetailItems = new List<ReportChiPhiDto>();
                }
            }
        }

        private void Button_OkClick(object sender, RoutedEventArgs e)
        {
            Report();
        }

        private void Report()
        {
            parameters["dateFrom"] = DateToString(vm.DateRangePickerViewModel.DateFrom);
            parameters["dateTo"] = DateToString(vm.DateRangePickerViewModel.DateTo);
            chiPhis = _dataService.Report<ReportChiPhiDto>("chiphi", parameters).Items;

            var groupByLoaiChiPhi = new List<ReportChiPhiDto>();
            foreach (var item in chiPhis.GroupBy(p => p.MaLoaiChiPhi))
            {
                var tenLoaiChiPhi = item.First().TenLoaiChiPhi;
                var soTien = item.Sum(p => p.SoTien);
                groupByLoaiChiPhi.Add(new ReportChiPhiDto()
                {
                    MaLoaiChiPhi = item.Key,
                    TenLoaiChiPhi = tenLoaiChiPhi,
                    SoTien = soTien,
                });
            }

            vm.GroupByLoaiChiPhiItems = groupByLoaiChiPhi;

            vm.Msg = string.Format("Tổng số tiền {0:N0}", groupByLoaiChiPhi.Sum(p => p.SoTien));
        }

        private string DateToString(DateTime date)
        {
            return string.Format("{0:0000}{1:00}{2:00}", date.Year, date.Month, date.Day);
        }
    }
}
