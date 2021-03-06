﻿using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChuyenHangController : SmtEntityBaseController<SqlDbContext, tChuyenHang, tChuyenHangDto>
    {
        partial void ConvertToDtoPartial(ref tChuyenHangDto dto, tChuyenHang entity);
        partial void ConvertToEntityPartial(ref tChuyenHang entity, tChuyenHangDto dto);

        public override tChuyenHangDto ConvertToDto(tChuyenHang entity)
        {
            var dto = new tChuyenHangDto()
            {
                ID = entity.ID,
                MaNhanVienGiaoHang = entity.MaNhanVienGiaoHang,
                Ngay = entity.Ngay,
                Gio = entity.Gio,
                TongDonHang = entity.TongDonHang,
                TongSoLuongTheoDonHang = entity.TongSoLuongTheoDonHang,
                TongSoLuongThucTe = entity.TongSoLuongThucTe,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChuyenHang ConvertToEntity(tChuyenHangDto dto)
        {
            var entity = new tChuyenHang()
            {
                ID = dto.ID,
                MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang,
                Ngay = dto.Ngay,
                Gio = dto.Gio,
                //TongDonHang = dto.TongDonHang,
                //TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang,
                //TongSoLuongThucTe = dto.TongSoLuongThucTe,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        public override string GetControllerName()
        {
            return nameof(tChuyenHangController);
        }
        protected override void UpdateEntity(SqlDbContext context, tChuyenHang entity)
        {
            var entry = context.tChuyenHang.Update(entity);
            entry.Property(p => p.TongDonHang).IsModified = false;
            entry.Property(p => p.TongSoLuongTheoDonHang).IsModified = false;
            entry.Property(p => p.TongSoLuongThucTe).IsModified = false;
        }
    }
}
