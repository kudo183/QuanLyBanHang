using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tToaHangDataModel
    {
        public int ThanhTien { get; set; }

        protected override void SetPropertiesDependency()
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

        public override string DisplayText
        {
            get
            {
                if (MaKhachHangNavigation != null)
                {
                    return string.Format("{0}|{1}", Ngay.ToString("d"), MaKhachHangNavigation.DisplayText);
                }
                return ID.ToString();
            }
        }

        partial void FromDtoPartial(tToaHangDto dto)
        {
            ThanhTien = dto.ThanhTien;
        }
    }
}
