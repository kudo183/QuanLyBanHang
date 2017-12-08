using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rLoaiChiPhiDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenLoaiChiPhi), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenLoaiChiPhi; }
        }
    }
}
