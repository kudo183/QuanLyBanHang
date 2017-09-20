namespace Client.DataModel
{
    public partial class tChuyenKhoDataModel
    {
        public int TongSoLuong { get; set; }

        protected override void RaiseDependentPropertyChanged(string basePropertyName)
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

        public override string DisplayText
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
