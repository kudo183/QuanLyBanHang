using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChiTietDonHangDataModel
    {
        protected override void SetPropertiesDependency()
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

        public override string DisplayText
        {
            get
            {
                if (MaDonHangNavigation != null && MaMatHangNavigation != null)
                {
                    return string.Format("{0}|{1}", MaDonHangNavigation.DisplayText, MaMatHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
