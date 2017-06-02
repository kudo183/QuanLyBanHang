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
                if (MaKhoHangrKhoHangDto != null && MaNhaCungCaprNhaCungCapDto != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangrKhoHangDto.DisplayText, MaNhaCungCaprNhaCungCapDto.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
