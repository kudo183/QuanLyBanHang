using Client.DataModel;
using huypq.wpf.controls;
using Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class KhachHangViewModel : INotifyPropertyChanged
    {
        public DateRangePickerViewModel DateRangePickerViewModel { get; set; }

        public List<rKhachHangDataModel> KhachHangs { get; set; }

        private int khachHangIndex;

        public int KhachHangIndex
        {
            get { return khachHangIndex; }
            set
            {
                if (khachHangIndex == value)
                    return;

                khachHangIndex = value;
                OnPropertyChanged();
            }
        }


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

        private List<RowData> items;

        public List<RowData> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public class RowData
        {
            public string Ngay { get; set; }
            public string TenKho { get; set; }
            public string TenMatHang { get; set; }
            public int SoLuong { get; set; }
            public string SoLuongString
            {
                get
                {
                    if (TenMatHang != null) return SoLuong.ToString();
                    return string.Empty;
                }
            }
        }
    }
}
