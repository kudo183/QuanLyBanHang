using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rNhanVienController : SmtEntityBaseController<SqlDbContext, rNhanVien, rNhanVienDto>
    {
        partial void ConvertToDtoPartial(ref rNhanVienDto dto, rNhanVien entity);
        partial void ConvertToEntityPartial(ref rNhanVien entity, rNhanVienDto dto);

        public override rNhanVienDto ConvertToDto(rNhanVien entity)
        {
            var dto = new rNhanVienDto()
			{
				Ma = entity.Ma,
				MaPhuongTien = entity.MaPhuongTien,
				TenNhanVien = entity.TenNhanVien,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNhanVien ConvertToEntity(rNhanVienDto dto)
        {
            var entity = new rNhanVien()
            {
				Ma = dto.Ma,
				MaPhuongTien = dto.MaPhuongTien,
				TenNhanVien = dto.TenNhanVien,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rNhanVienController);
        }
    }
}
