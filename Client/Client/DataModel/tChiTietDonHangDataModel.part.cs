using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChiTietDonHangDataModel
    {
        int? _TonKho;
        public int? TonKho { get { return _TonKho; } set { SetField(ref _TonKho, value); } }

        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(MaDonHangNavigation), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaMatHangNavigation), new List<string>()
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
