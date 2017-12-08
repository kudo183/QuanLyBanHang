using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rChanhDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(TenChanh), new List<string>()
            {
                nameof(DisplayText)
            });

            SetDependentProperty(nameof(MaBaiXe), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get
            {
                if (MaBaiXeNavigation != null)
                {
                    return string.Format("{0} - {1}", TenChanh, MaBaiXeNavigation.DiaDiemBaiXe);
                }
                return ID.ToString();
            }
        }
    }
}
