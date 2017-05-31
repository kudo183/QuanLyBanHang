namespace Shared
{
    public partial class rNguyenLieuDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(ID))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        public string DisplayText
        {
            get { return ID.ToString(); }
        }
    }
}
