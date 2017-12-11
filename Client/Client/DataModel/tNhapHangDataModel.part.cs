using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tNhapHangDataModel
    {
        public int TongSoLuong { get; set; }

        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhoHang), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaNhaCungCap), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaKhoHangNavigation != null && MaNhaCungCapNavigation != null)
            {
                _displayText = string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaNhaCungCapNavigation.DisplayText);
            }
        }

        partial void FromDtoPartial(tNhapHangDto dto)
        {
            TongSoLuong = dto.TongSoLuong;
        }
    }
}
