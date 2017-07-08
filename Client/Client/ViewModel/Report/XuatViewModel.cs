using huypq.wpf.controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Client.ViewModel.Report
{
    public class XuatViewModel : INotifyPropertyChanged
    {
        public XuatViewModel()
        {
            GroupBys = new List<string>() { "LoaiHang", "MatHang", "KhachHang", "KhoHang" };
        }

        public DateRangePickerViewModel DateRangePickerViewModel { get; set; }

        public List<string> GroupBys { get; set; }

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

        private int groupByIndex = 0;

        public int GroupByIndex
        {
            get { return groupByIndex; }
            set
            {
                if (groupByIndex == value)
                    return;

                groupByIndex = value;
                OnPropertyChanged();
            }
        }

        private object items;

        public object Items
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

        public class GroupByLoaiHang 
        {
            public string TenLoaiHang { get; set; }
            public int SoLuong { get; set; }
            public int SoKy { get; set; }
            public List<GroupByMatHang> Details { get; set; }
            public Dictionary<int, GroupByMatHang> DictionaryDetails { get; set; }
        }

        public class GroupByMatHang
        {
            public string TenMatHang { get; set; }
            public int SoLuong { get; set; }
            public int SoKy { get; set; }
            public List<GroupByKhachHang> Details { get; set; }
            public Dictionary<int, GroupByKhachHang> DictionaryDetails { get; set; }
        }

        public class GroupByKhachHang
        {
            public string TenKhachHang { get; set; }
            public int SoLuong { get; set; }
            public int SoKy { get; set; }
            public List<GroupByLoaiHang> Details { get; set; }
            public Dictionary<int, GroupByLoaiHang> DictionaryDetails { get; set; }
        }

        public class GroupByKhoHang
        {
            public string TenKhoHang { get; set; }
            public int SoLuong { get; set; }
            public int SoKy { get; set; }
            public List<GroupByLoaiHang> Details { get; set; }
            public Dictionary<int, GroupByLoaiHang> DictionaryDetails { get; set; }
        }
    }
}
