using System;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenHangDataModel
    {
        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(Gio), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaNhanVienGiaoHangNavigation), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaNhanVienGiaoHangNavigation != null)
            {
                _displayText = string.Format("{0}|{1:hh\\:mm}|{2}", Ngay.ToString("d"), Gio ?? new TimeSpan(0, 0, 0), MaNhanVienGiaoHangNavigation.DisplayText);
            }
        }
    }
}
