using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChiTietDonHangController : SmtEntityBaseController<SqlDbContext, tChiTietDonHang, tChiTietDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietDonHangDto dto, tChiTietDonHang entity);
        partial void ConvertToEntityPartial(ref tChiTietDonHang entity, tChiTietDonHangDto dto);

        public override tChiTietDonHangDto ConvertToDto(tChiTietDonHang entity)
        {
            var dto = new tChiTietDonHangDto()
			{
				ID = entity.ID,
				MaDonHang = entity.MaDonHang,
				MaMatHang = entity.MaMatHang,
				SoLuong = entity.SoLuong,
				Xong = entity.Xong,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietDonHang ConvertToEntity(tChiTietDonHangDto dto)
        {
            var entity = new tChiTietDonHang()
            {
				ID = dto.ID,
				MaDonHang = dto.MaDonHang,
				MaMatHang = dto.MaMatHang,
				SoLuong = dto.SoLuong,
				Xong = dto.Xong,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tChiTietDonHangController);
        }
    }
}
