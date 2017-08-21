using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rNuocController : SmtEntityBaseController<SqlDbContext, rNuoc, rNuocDto>
    {
        partial void ConvertToDtoPartial(ref rNuocDto dto, rNuoc entity);
        partial void ConvertToEntityPartial(ref rNuoc entity, rNuocDto dto);

        public override rNuocDto ConvertToDto(rNuoc entity)
        {
            var dto = new rNuocDto()
            {
                ID = entity.ID,
                TenNuoc = entity.TenNuoc,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNuoc ConvertToEntity(rNuocDto dto)
        {
            var entity = new rNuoc()
            {
                ID = dto.ID,
                TenNuoc = dto.TenNuoc,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        public override string GetControllerName()
        {
            return nameof(rNuocController);
        }
    }
}
