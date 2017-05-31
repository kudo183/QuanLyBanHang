namespace Shared
{
    public partial class rBaiXeDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(DiaDiemBaiXe))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText
        {
            get { return DiaDiemBaiXe; }
        }
    }
}
