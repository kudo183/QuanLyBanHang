using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rBaiXeController : SmtEntityBaseController<SqlDbContext, rBaiXe, rBaiXeDto>
    {
        partial void ConvertToDtoPartial(ref rBaiXeDto dto, rBaiXe entity);
        partial void ConvertToEntityPartial(ref rBaiXe entity, rBaiXeDto dto);

        public override rBaiXeDto ConvertToDto(rBaiXe entity)
        {
            var dto = new rBaiXeDto()
			{
				Ma = entity.Ma,
				DiaDiemBaiXe = entity.DiaDiemBaiXe,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rBaiXe ConvertToEntity(rBaiXeDto dto)
        {
            var entity = new rBaiXe()
            {
				Ma = dto.Ma,
				DiaDiemBaiXe = dto.DiaDiemBaiXe,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rBaiXeController);
        }
    }
}
