namespace Shared
{
    public partial class rChanhDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
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

        public string DisplayText
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
