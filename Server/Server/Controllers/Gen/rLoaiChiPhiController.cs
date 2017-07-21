using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rLoaiChiPhiController : SmtEntityBaseController<SqlDbContext, rLoaiChiPhi, rLoaiChiPhiDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiChiPhiDto dto, rLoaiChiPhi entity);
        partial void ConvertToEntityPartial(ref rLoaiChiPhi entity, rLoaiChiPhiDto dto);

        public override rLoaiChiPhiDto ConvertToDto(rLoaiChiPhi entity)
        {
            var dto = new rLoaiChiPhiDto()
			{
				Ma = entity.Ma,
				TenLoaiChiPhi = entity.TenLoaiChiPhi,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiChiPhi ConvertToEntity(rLoaiChiPhiDto dto)
        {
            var entity = new rLoaiChiPhi()
            {
				Ma = dto.Ma,
				TenLoaiChiPhi = dto.TenLoaiChiPhi,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rLoaiChiPhiController);
        }
    }
}
