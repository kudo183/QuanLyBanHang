using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class rChanhDataModel
    {
        partial void SetPropertiesDependencyPartial()
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

        partial void DisplayTextPartial()
        {
            if (MaBaiXeNavigation != null)
            {
                _displayText = string.Format("{0} - {1}", TenChanh, MaBaiXeNavigation.DiaDiemBaiXe);
            }
        }
    }
}
