using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rKhachHangDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenKhachHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenKhachHang; }
        }
    }
}
