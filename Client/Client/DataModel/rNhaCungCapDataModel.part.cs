using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rNhaCungCapDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenNhaCungCap), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenNhaCungCap; }
        }
    }
}
