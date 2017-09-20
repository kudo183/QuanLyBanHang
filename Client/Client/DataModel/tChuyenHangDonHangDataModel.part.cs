namespace Client.DataModel
{
    public partial class tChuyenHangDonHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
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

        public override string DisplayText
        {
            get
            {
                if (MaChuyenHangNavigation != null && MaDonHangNavigation != null)
                {
                    return string.Format("{0}|{1}", MaChuyenHangNavigation.DisplayText, MaDonHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
