using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rKhoHangDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenKho), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenKho; }
        }
    }
}
