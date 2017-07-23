﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tNhapNguyenLieuController : SmtEntityBaseController<SqlDbContext, tNhapNguyenLieu, tNhapNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref tNhapNguyenLieuDto dto, tNhapNguyenLieu entity);
        partial void ConvertToEntityPartial(ref tNhapNguyenLieu entity, tNhapNguyenLieuDto dto);

        public override tNhapNguyenLieuDto ConvertToDto(tNhapNguyenLieu entity)
        {
            var dto = new tNhapNguyenLieuDto()
			{
				Ma = entity.Ma,
				Ngay = entity.Ngay,
				MaNguyenLieu = entity.MaNguyenLieu,
				MaNhaCungCap = entity.MaNhaCungCap,
				SoLuong = entity.SoLuong,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tNhapNguyenLieu ConvertToEntity(tNhapNguyenLieuDto dto)
        {
            var entity = new tNhapNguyenLieu()
            {
				Ma = dto.Ma,
				Ngay = dto.Ngay,
				MaNguyenLieu = dto.MaNguyenLieu,
				MaNhaCungCap = dto.MaNhaCungCap,
				SoLuong = dto.SoLuong,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tNhapNguyenLieuController);
        }
    }
}