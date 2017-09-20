using System.IO;

namespace Client.DataModel
{
    public partial class tMatHangDataModel
    {
        protected override void RaiseDependentPropertyChanged(string basePropertyName)
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

        public override string DisplayText
        {
            get { return TenMatHang; }
        }
    }
}
