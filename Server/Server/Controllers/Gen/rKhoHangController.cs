﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rKhoHangController : SmtEntityBaseController<SqlDbContext, rKhoHang, rKhoHangDto>
    {
        partial void ConvertToDtoPartial(ref rKhoHangDto dto, rKhoHang entity);
        partial void ConvertToEntityPartial(ref rKhoHang entity, rKhoHangDto dto);

        public override rKhoHangDto ConvertToDto(rKhoHang entity)
        {
            var dto = new rKhoHangDto()
            {
                ID = entity.ID,
                TenKho = entity.TenKho,
                TrangThai = entity.TrangThai,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rKhoHang ConvertToEntity(rKhoHangDto dto)
        {
            var entity = new rKhoHang()
            {
                ID = dto.ID,
                TenKho = dto.TenKho,
                TrangThai = dto.TrangThai,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        public override string GetControllerName()
        {
            return nameof(rKhoHangController);
        }
    }
}
