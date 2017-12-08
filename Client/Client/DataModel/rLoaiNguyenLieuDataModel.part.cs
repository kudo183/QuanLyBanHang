using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rLoaiNguyenLieuDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenLoai), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenLoai; }
        }
    }
}
