﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rNhaCungCapController : SmtEntityBaseController<SqlDbContext, rNhaCungCap, rNhaCungCapDto>
    {
        partial void ConvertToDtoPartial(ref rNhaCungCapDto dto, rNhaCungCap entity);
        partial void ConvertToEntityPartial(ref rNhaCungCap entity, rNhaCungCapDto dto);

        public override rNhaCungCapDto ConvertToDto(rNhaCungCap entity)
        {
            var dto = new rNhaCungCapDto()
			{
				ID = entity.ID,
				TenNhaCungCap = entity.TenNhaCungCap,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNhaCungCap ConvertToEntity(rNhaCungCapDto dto)
        {
            var entity = new rNhaCungCap()
            {
				ID = dto.ID,
				TenNhaCungCap = dto.TenNhaCungCap,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rNhaCungCapController);
        }
    }
}
