namespace Client.DataModel
{
    public partial class rNguyenLieuDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(DuongKinh))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return DuongKinh.ToString(); }
        }
    }
}
