using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tDonHangDataModel
    {
        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhoHangNavigation), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhachHangNavigation), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaKhoHangNavigation != null && MaKhachHangNavigation != null)
            {
                _displayText = string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaKhachHangNavigation.DisplayText);
            }
        }
    }
}
