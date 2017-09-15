using System.IO;

namespace Shared
{
    public partial class tMatHangDto : huypq.SmtShared.IDisplayText
    {
        partial void RaiseDependentPropertyChanged(string basePropertyName)
        {
            if (basePropertyName == nameof(TenMatHang))
            {
                OnPropertyChanged(nameof(DisplayText));
            }
        }

        private string hinhAnhFilePath;

        public string HinhAnhFilePath
        {
            get { return hinhAnhFilePath; }
            set
            {
                if (hinhAnhFilePath == value)
                    return;

                hinhAnhFilePath = value;
                OnPropertyChanged();
            }
        }

        private Stream hinhAnhImageStream;

        public Stream HinhAnhImageStream
        {
            get { return hinhAnhImageStream; }
            set
            {
                if (hinhAnhImageStream == value)
                    return;

                hinhAnhImageStream = value;
                OnPropertyChanged();
            }
        }

        public string DisplayText
        {
            get { return TenMatHang; }
        }
    }
}
