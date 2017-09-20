namespace Client.DataModel
{
    public partial class rChanhDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
        {
            switch (basePropertyName)
            {
                case nameof(TenChanh):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
                case nameof(MaBaiXe):
                    OnPropertyChanged(nameof(DisplayText));
                    break;
            }
        }

        public override string DisplayText
        {
            get
            {
                if (MaBaiXeNavigation != null)
                {
                    return string.Format("{0} - {1}", TenChanh, MaBaiXeNavigation.DiaDiemBaiXe);
                }
                return ID.ToString();
            }
        }
    }
}
