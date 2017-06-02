namespace Shared
{
    public partial class tChiTietDonHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(MaDonHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaMatHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaDonHangtDonHangDto != null && MaMatHangtMatHangDto != null)
                {
                    return string.Format("{0}|{1}", MaDonHangtDonHangDto.DisplayText, MaMatHangtMatHangDto.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
