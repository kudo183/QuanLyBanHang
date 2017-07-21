namespace Shared
{
    public partial class tNhapHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(Ngay):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaKhoHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaNhaCungCap):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaKhoHangNavigation != null && MaNhaCungCapNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaNhaCungCapNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
