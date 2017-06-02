using System;

namespace Shared
{
    public partial class tChuyenHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
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

        public string DisplayText
        {
            get
            {
                if (MaNhanVienGiaoHangrNhanVienDto != null)
                {
                    return string.Format("{0}|{1:hh\\:mm}|{2}", Ngay.ToString("d"), Gio ?? new TimeSpan(0, 0, 0), MaNhanVienGiaoHangrNhanVienDto.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
