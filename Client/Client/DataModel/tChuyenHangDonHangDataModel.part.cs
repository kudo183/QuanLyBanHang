using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenHangDonHangDataModel
    {
        protected override void SetPropertiesDependency()
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

        public override string DisplayText
        {
            get
            {
                if (MaChuyenHangNavigation != null && MaDonHangNavigation != null)
                {
                    return string.Format("{0}|{1}", MaChuyenHangNavigation.DisplayText, MaDonHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
