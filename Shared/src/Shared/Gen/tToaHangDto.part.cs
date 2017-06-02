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
                if (MaKhachHangrKhachHangDto != null)
                {
                    return string.Format("{0}|{1}", Ngay.ToString("d"), MaKhachHangrKhachHangDto.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
