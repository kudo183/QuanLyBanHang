using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tCongNoKhachHangController : SmtEntityBaseController<SqlDbContext, tCongNoKhachHang, tCongNoKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tCongNoKhachHangDto dto, tCongNoKhachHang entity);
        partial void ConvertToEntityPartial(ref tCongNoKhachHang entity, tCongNoKhachHangDto dto);

        public override tCongNoKhachHangDto ConvertToDto(tCongNoKhachHang entity)
        {
            var dto = new tCongNoKhachHangDto()
			{
				Ma = entity.Ma,
				MaKhachHang = entity.MaKhachHang,
				Ngay = entity.Ngay,
				SoTien = entity.SoTien,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tCongNoKhachHang ConvertToEntity(tCongNoKhachHangDto dto)
        {
            var entity = new tCongNoKhachHang()
            {
				Ma = dto.Ma,
				MaKhachHang = dto.MaKhachHang,
				Ngay = dto.Ngay,
				SoTien = dto.SoTien,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tCongNoKhachHangController);
        }
    }
}
