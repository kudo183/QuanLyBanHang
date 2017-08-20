namespace Shared
{
    public partial class tChuyenKhoDto : huypq.SmtShared.IDisplayText
    {
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(50)]
        public int TongSoLuong { get; set; }

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
                if (MaKhoHangXuatNavigation != null && MaKhoHangNhapNavigation != null && MaNhanVienNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}|{3}", Ngay.ToString("d"),
                        MaKhoHangXuatNavigation.DisplayText, MaKhoHangNhapNavigation.DisplayText, MaNhanVienNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
