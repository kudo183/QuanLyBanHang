﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rChanhController : SmtEntityBaseController<SqlDbContext, rChanh, rChanhDto>
    {
        partial void ConvertToDtoPartial(ref rChanhDto dto, rChanh entity);
        partial void ConvertToEntityPartial(ref rChanh entity, rChanhDto dto);

        public override rChanhDto ConvertToDto(rChanh entity)
        {
            var dto = new rChanhDto()
			{
				Ma = entity.Ma,
				MaBaiXe = entity.MaBaiXe,
				TenChanh = entity.TenChanh,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rChanh ConvertToEntity(rChanhDto dto)
        {
            var entity = new rChanh()
            {
				Ma = dto.Ma,
				MaBaiXe = dto.MaBaiXe,
				TenChanh = dto.TenChanh,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rChanhController);
        }
    }
}