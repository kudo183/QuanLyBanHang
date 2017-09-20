namespace Client.DataModel
{
    public partial class rLoaiNguyenLieuDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenLoai))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenLoai; }
        }
    }
}
