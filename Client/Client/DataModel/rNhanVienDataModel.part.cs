using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rNhanVienDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenNhanVien), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenNhanVien; }
        }
    }
}
