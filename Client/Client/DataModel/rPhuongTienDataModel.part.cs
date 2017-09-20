namespace Client.DataModel
{
    public partial class rPhuongTienDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenPhuongTien))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenPhuongTien; }
        }
    }
}
