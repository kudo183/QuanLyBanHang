namespace Client.DataModel
{
    public partial class rKhoHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenKho))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenKho; }
        }
    }
}
