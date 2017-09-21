using Shared;

namespace Client.DataModel
{
    public partial class tChiTietToaHangDataModel
    {
        public int ThanhTien { get; set; }

        partial void FromDtoPartial(tChiTietToaHangDto dto)
        {
            ThanhTien = dto.ThanhTien;
        }
    }
}
