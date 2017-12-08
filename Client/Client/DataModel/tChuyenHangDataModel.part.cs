using System;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenHangDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(Gio), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaNhanVienGiaoHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get
            {
                if (MaNhanVienGiaoHangNavigation != null)
                {
                    return string.Format("{0}|{1:hh\\:mm}|{2}", Ngay.ToString("d"), Gio ?? new TimeSpan(0, 0, 0), MaNhanVienGiaoHangNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }
    }
}
