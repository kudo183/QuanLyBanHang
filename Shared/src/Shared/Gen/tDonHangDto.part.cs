namespace Shared
{
    public partial class tDonHangDto : huypq.SmtShared.IDisplayText
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
                case nameof(MaKhachHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaKhoHangrKhoHangDto != null && MaKhachHangrKhachHangDto != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangrKhoHangDto.DisplayText, MaKhachHangrKhachHangDto.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
