namespace Shared
{
    public partial class tChuyenHangDonHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(MaChuyenHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaDonHang):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaChuyenHangtChuyenHangDto != null && MaDonHangtDonHangDto != null)
                {
                    return string.Format("{0}|{1}", MaChuyenHangtChuyenHangDto.DisplayText, MaDonHangtDonHangDto.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
