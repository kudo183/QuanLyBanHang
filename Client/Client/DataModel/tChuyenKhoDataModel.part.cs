using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenKhoDataModel
    {
        public int TongSoLuong { get; set; }

        partial void SetPropertiesDependencyPartial()
        {
            SetDependentProperty(nameof(Ngay), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhoHangXuat), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaKhoHangNhap), new List<string>()
            {
                nameof(DisplayText)
            });
            SetDependentProperty(nameof(MaNhanVien), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        partial void DisplayTextPartial()
        {
            if (MaKhoHangXuatNavigation != null && MaKhoHangNhapNavigation != null && MaNhanVienNavigation != null)
            {
                _displayText = string.Format("{0}|{1}|{2}|{3}", Ngay.ToString("d"),
                        MaKhoHangXuatNavigation.DisplayText, MaKhoHangNhapNavigation.DisplayText, MaNhanVienNavigation.DisplayText);
            }
        }

        partial void FromDtoPartial(tChuyenKhoDto dto)
        {
            TongSoLuong = dto.TongSoLuong;
        }
    }
}
