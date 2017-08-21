using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChuyenHangDonHangController : SmtEntityBaseController<SqlDbContext, tChuyenHangDonHang, tChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChuyenHangDonHangDto dto, tChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref tChuyenHangDonHang entity, tChuyenHangDonHangDto dto);

        public override tChuyenHangDonHangDto ConvertToDto(tChuyenHangDonHang entity)
        {
            var dto = new tChuyenHangDonHangDto()
            {
                ID = entity.ID,
                MaChuyenHang = entity.MaChuyenHang,
                MaDonHang = entity.MaDonHang,
                TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang,
                TongSoLuongThucTe = entity.TongSoLuongThucTe,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChuyenHangDonHang ConvertToEntity(tChuyenHangDonHangDto dto)
        {
            var entity = new tChuyenHangDonHang()
            {
                ID = dto.ID,
                MaChuyenHang = dto.MaChuyenHang,
                MaDonHang = dto.MaDonHang,
                TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang,
                TongSoLuongThucTe = dto.TongSoLuongThucTe,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        public override string GetControllerName()
        {
            return nameof(tChuyenHangDonHangController);
        }
    }
}
