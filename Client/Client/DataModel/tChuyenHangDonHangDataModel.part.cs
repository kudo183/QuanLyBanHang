using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenHangDonHangDataModel
    {
        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(MaChuyenHang), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaDonHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaChuyenHangNavigation != null && MaDonHangNavigation != null)
            {
                _displayText = string.Format("{0}|{1}", MaChuyenHangNavigation.DisplayText, MaDonHangNavigation.DisplayText);
            }
        }
    }
}
