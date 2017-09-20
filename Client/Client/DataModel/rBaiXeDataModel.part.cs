namespace Client.DataModel
{
    public partial class rBaiXeDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(DiaDiemBaiXe))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public override string DisplayText
        {
            get { return DiaDiemBaiXe; }
        }
    }
}
