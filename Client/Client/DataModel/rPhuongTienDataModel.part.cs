using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rPhuongTienDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenPhuongTien), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return TenPhuongTien; }
        }
    }
}
