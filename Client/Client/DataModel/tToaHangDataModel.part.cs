using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tToaHangDataModel
    {
        public int ThanhTien { get; set; }

        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhachHang), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaKhachHangNavigation != null)
            {
                _displayText = string.Format("{0}|{1}", Ngay.ToString("d"), MaKhachHangNavigation.DisplayText);
            }
        }

        partial void FromDtoPartial(tToaHangDto dto)
        {
            ThanhTien = dto.ThanhTien;
        }
    }
}
