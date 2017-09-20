namespace Client.DataModel
{
    public partial class rNhaCungCapDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenNhaCungCap))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenNhaCungCap; }
        }
    }
}
