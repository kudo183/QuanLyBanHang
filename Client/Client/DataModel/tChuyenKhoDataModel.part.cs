using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tChuyenKhoDataModel
    {
        public int TongSoLuong { get; set; }

        protected override void SetPropertiesDependency()
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

        public override string DisplayText
        {
            get
            {
                if (MaKhoHangXuatNavigation != null && MaKhoHangNhapNavigation != null && MaNhanVienNavigation != null)
                {
                    return string.Format("{0}|{1}|{2}|{3}", Ngay.ToString("d"),
                        MaKhoHangXuatNavigation.DisplayText, MaKhoHangNhapNavigation.DisplayText, MaNhanVienNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }

        partial void FromDtoPartial(tChuyenKhoDto dto)
        {
            TongSoLuong = dto.TongSoLuong;
        }
    }
}
