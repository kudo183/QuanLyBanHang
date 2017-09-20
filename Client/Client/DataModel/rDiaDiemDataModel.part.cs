namespace Client.DataModel
{
    public partial class rDiaDiemDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(Tinh))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return Tinh; }
        }
    }
}
