namespace Client.DataModel
{
    public partial class tChiTietDonHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
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

        public override string DisplayText
        {
            get
            {
                if (MaDonHangNavigation != null && MaMatHangNavigation != null)
                {
                    return string.Format("{0}|{1}", MaDonHangNavigation.DisplayText, MaMatHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
