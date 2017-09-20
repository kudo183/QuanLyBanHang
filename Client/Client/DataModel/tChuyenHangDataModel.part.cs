using System;

namespace Client.DataModel
{
    public partial class tChuyenHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(Ngay):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(Gio):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaNhanVienGiaoHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public override string DisplayText
        {
            get
            {
                if (MaNhanVienGiaoHangNavigation != null)
                {
                    return string.Format("{0}|{1:hh\\:mm}|{2}", Ngay.ToString("d"), Gio ?? new TimeSpan(0, 0, 0), MaNhanVienGiaoHangNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
