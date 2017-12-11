using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChiTietDonHangDataModel
    {
        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(MaDonHang), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaMatHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaDonHangNavigation != null && MaMatHangNavigation != null)
            {
                _displayText = string.Format("{0}|{1}", MaDonHangNavigation.DisplayText, MaMatHangNavigation.DisplayText);
            }
        }
    }
}
