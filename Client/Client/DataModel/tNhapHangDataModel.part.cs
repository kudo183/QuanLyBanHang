using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tNhapHangDataModel
    {
        public int TongSoLuong { get; set; }

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
            SetDependentProperty(nameof(MaNhaCungCap), new List<string>()
            {
                nameof(DisplayText)
            });
        }

        public override string DisplayText
        {
            get
            {
                if (MaKhoHangNavigation != null && MaNhaCungCapNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}", Ngay.ToString("d"), MaKhoHangNavigation.DisplayText, MaNhaCungCapNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }

        partial void FromDtoPartial(tNhapHangDto dto)
        {
            TongSoLuong = dto.TongSoLuong;
        }
    }
}
