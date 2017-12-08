using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rBaiXeDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(DiaDiemBaiXe), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get { return DiaDiemBaiXe; }
        }
    }
}
