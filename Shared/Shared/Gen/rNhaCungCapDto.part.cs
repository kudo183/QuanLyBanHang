namespace Shared
{
    public partial class rNhaCungCapDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenNhaCungCap))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText
        {
            get { return TenNhaCungCap; }
        }
    }
}
