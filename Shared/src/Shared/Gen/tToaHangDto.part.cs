namespace Shared
{
    public partial class tToaHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(Ngay):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaKhachHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaKhachHangNavigation != null)
                {
                    return string.Format("{0}|{1}", Ngay.ToString("d"), MaKhachHangNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
