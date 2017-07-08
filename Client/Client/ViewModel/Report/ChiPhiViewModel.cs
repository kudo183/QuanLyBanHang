using huypq.wpf.controls;
using Shared.Report;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class ChiPhiViewModel : INotifyPropertyChanged
    {
        public DateRangePickerViewModel DateRangePickerViewModel { get; set; }
    
        private string msg;

        public string Msg
        {
            get { return msg; }
            set
            {
                if (msg == value)
                    return;

                msg = value;
                OnPropertyChanged();
            }
        }
        
        private ReportChiPhiDto selectedItem;

        public ReportChiPhiDto SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;

                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private List<ReportChiPhiDto> groupByLoaiChiPhiItems = new List<ReportChiPhiDto>();

        public List<ReportChiPhiDto> GroupByLoaiChiPhiItems
        {
            get { return groupByLoaiChiPhiItems; }
            set
            {
                groupByLoaiChiPhiItems = value;
                OnPropertyChanged();
            }
        }

        private List<ReportChiPhiDto> detailItems = new List<ReportChiPhiDto>();

        public List<ReportChiPhiDto> DetailItems
        {
            get { return detailItems; }
            set
            {
                detailItems = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
