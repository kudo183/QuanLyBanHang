namespace Client.DataModel
{
    public partial class tDonHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
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

        public override string DisplayText
        {
            get
            {
                if (MaKhoHangNavigation != null && MaKhachHangNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaKhachHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
