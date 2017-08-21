using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChiTietChuyenHangDonHangController : SmtEntityBaseController<SqlDbContext, tChiTietChuyenHangDonHang, tChiTietChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietChuyenHangDonHangDto dto, tChiTietChuyenHangDonHang entity);
        partial void ConvertToEntityPartial(ref tChiTietChuyenHangDonHang entity, tChiTietChuyenHangDonHangDto dto);

        public override tChiTietChuyenHangDonHangDto ConvertToDto(tChiTietChuyenHangDonHang entity)
        {
            var dto = new tChiTietChuyenHangDonHangDto()
			{
				ID = entity.ID,
				MaChuyenHangDonHang = entity.MaChuyenHangDonHang,
				MaChiTietDonHang = entity.MaChiTietDonHang,
				SoLuong = entity.SoLuong,
				SoLuongTheoDonHang = entity.SoLuongTheoDonHang,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietChuyenHangDonHang ConvertToEntity(tChiTietChuyenHangDonHangDto dto)
        {
            var entity = new tChiTietChuyenHangDonHang()
            {
				ID = dto.ID,
				MaChuyenHangDonHang = dto.MaChuyenHangDonHang,
				MaChiTietDonHang = dto.MaChiTietDonHang,
				SoLuong = dto.SoLuong,
				SoLuongTheoDonHang = dto.SoLuongTheoDonHang,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tChiTietChuyenHangDonHangController);
        }
    }
}
