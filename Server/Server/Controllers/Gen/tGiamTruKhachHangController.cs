﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tGiamTruKhachHangController : SmtEntityBaseController<SqlDbContext, tGiamTruKhachHang, tGiamTruKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tGiamTruKhachHangDto dto, tGiamTruKhachHang entity);
        partial void ConvertToEntityPartial(ref tGiamTruKhachHang entity, tGiamTruKhachHangDto dto);

        public override tGiamTruKhachHangDto ConvertToDto(tGiamTruKhachHang entity)
        {
            var dto = new tGiamTruKhachHangDto()
			{
				Ma = entity.Ma,
				MaKhachHang = entity.MaKhachHang,
				Ngay = entity.Ngay,
				SoTien = entity.SoTien,
				GhiChu = entity.GhiChu,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tGiamTruKhachHang ConvertToEntity(tGiamTruKhachHangDto dto)
        {
            var entity = new tGiamTruKhachHang()
            {
				Ma = dto.Ma,
				MaKhachHang = dto.MaKhachHang,
				Ngay = dto.Ngay,
				SoTien = dto.SoTien,
				GhiChu = dto.GhiChu,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tGiamTruKhachHangController);
        }
    }
}