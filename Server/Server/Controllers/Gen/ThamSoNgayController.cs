using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class ThamSoNgayController : SmtEntityBaseController<SqlDbContext, ThamSoNgay, ThamSoNgayDto>
    {
        partial void ConvertToDtoPartial(ref ThamSoNgayDto dto, ThamSoNgay entity);
        partial void ConvertToEntityPartial(ref ThamSoNgay entity, ThamSoNgayDto dto);

        public override ThamSoNgayDto ConvertToDto(ThamSoNgay entity)
        {
            var dto = new ThamSoNgayDto()
			{
				ID = entity.ID,
				Ten = entity.Ten,
				GiaTri = entity.GiaTri,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override ThamSoNgay ConvertToEntity(ThamSoNgayDto dto)
        {
            var entity = new ThamSoNgay()
            {
				ID = dto.ID,
				Ten = dto.Ten,
				GiaTri = dto.GiaTri,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(ThamSoNgayController);
        }
    }
}
