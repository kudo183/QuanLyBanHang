namespace Client.DataModel
{
    public partial class rLoaiChiPhiDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenLoaiChiPhi))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return TenLoaiChiPhi; }
        }
    }
}
