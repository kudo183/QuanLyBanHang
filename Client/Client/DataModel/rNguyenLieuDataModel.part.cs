using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rNguyenLieuDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(DuongKinh), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return DuongKinh.ToString(); }
        }
    }
}
