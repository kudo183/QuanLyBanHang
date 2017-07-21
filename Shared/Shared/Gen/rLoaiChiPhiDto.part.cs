namespace Shared
{
    public partial class rLoaiChiPhiDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenLoaiChiPhi))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText
        {
            get { return TenLoaiChiPhi; }
        }
    }
}
