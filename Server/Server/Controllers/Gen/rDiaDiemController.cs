using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rDiaDiemController : SmtEntityBaseController<SqlDbContext, rDiaDiem, rDiaDiemDto>
    {
        partial void ConvertToDtoPartial(ref rDiaDiemDto dto, rDiaDiem entity);
        partial void ConvertToEntityPartial(ref rDiaDiem entity, rDiaDiemDto dto);

        public override rDiaDiemDto ConvertToDto(rDiaDiem entity)
        {
            var dto = new rDiaDiemDto()
			{
				Ma = entity.Ma,
				MaNuoc = entity.MaNuoc,
				Tinh = entity.Tinh,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rDiaDiem ConvertToEntity(rDiaDiemDto dto)
        {
            var entity = new rDiaDiem()
            {
				Ma = dto.Ma,
				MaNuoc = dto.MaNuoc,
				Tinh = dto.Tinh,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rDiaDiemController);
        }
    }
}
