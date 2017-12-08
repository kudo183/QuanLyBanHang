using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tDonHangDataModel
    {
        protected override void SetPropertiesDependency()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhoHang), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhachHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get
            {
                if (MaKhoHangNavigation != null && MaKhachHangNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaKhachHangNavigation.DisplayText);
                }

                return ID.ToString();
            }
        }
    }
}
