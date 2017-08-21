using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tNhanTienKhachHangController : SmtEntityBaseController<SqlDbContext, tNhanTienKhachHang, tNhanTienKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref tNhanTienKhachHangDto dto, tNhanTienKhachHang entity);
        partial void ConvertToEntityPartial(ref tNhanTienKhachHang entity, tNhanTienKhachHangDto dto);

        public override tNhanTienKhachHangDto ConvertToDto(tNhanTienKhachHang entity)
        {
            var dto = new tNhanTienKhachHangDto()
            {
                ID = entity.ID,
                MaKhachHang = entity.MaKhachHang,
                Ngay = entity.Ngay,
                SoTien = entity.SoTien,
                TenantID = entity.TenantID,
                CreateTime = entity.CreateTime,
                LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tNhanTienKhachHang ConvertToEntity(tNhanTienKhachHangDto dto)
        {
            var entity = new tNhanTienKhachHang()
            {
                ID = dto.ID,
                MaKhachHang = dto.MaKhachHang,
                Ngay = dto.Ngay,
                SoTien = dto.SoTien,
                TenantID = dto.TenantID,
                CreateTime = dto.CreateTime,
                LastUpdateTime = dto.LastUpdateTime
            };

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }

        public override string GetControllerName()
        {
            return nameof(tNhanTienKhachHangController);
        }
    }
}
