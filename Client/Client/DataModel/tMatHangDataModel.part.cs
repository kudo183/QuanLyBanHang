using System.Collections.Generic;
using System.IO;

namespace Client.DataModel
{
    public partial class tMatHangDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenMatHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        private string hinhAnhFilePath;

        public string HinhAnhFilePath
        {
            get { return hinhAnhFilePath; }
            set
            {
                SetField(ref hinhAnhFilePath, value);
            }
        }

        private Stream hinhAnhImageStream;

        public Stream HinhAnhImageStream
        {
            get { return hinhAnhImageStream; }
            set
            {
                SetField(ref hinhAnhImageStream, value);
            }
        }

        public override string DisplayText
        {
            get { return TenMatHang; }
        }
    }
}
