namespace Client.DataModel
{
    public partial class rNuocDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenNuoc))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenNuoc; }
        }
    }
}
