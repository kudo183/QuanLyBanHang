using System.Collections.Generic;
using System.IO;

namespace Client.DataModel
{
    public partial class tMatHangDataModel
    {
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
    }
}
