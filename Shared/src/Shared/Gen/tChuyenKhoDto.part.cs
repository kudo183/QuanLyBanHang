namespace Shared
{
    public partial class tChuyenKhoDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(Ngay):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaKhoHangXuat):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaKhoHangNhap):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaNhanVien):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public string DisplayText
        {
            get
            {
                if (MaKhoHangXuatrKhoHangDto != null && MaKhoHangNhaprKhoHangDto != null && MaNhanVienrNhanVienDto != null)
                {
                    return string.Format("{0}|{1}|{2}|{3}", Ngay.ToString("d"),
                        MaKhoHangXuatrKhoHangDto.DisplayText, MaKhoHangNhaprKhoHangDto.DisplayText, MaNhanVienrNhanVienDto.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
