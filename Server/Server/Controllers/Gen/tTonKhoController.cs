using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tTonKhoController : SmtEntityBaseController<SqlDbContext, tTonKho, tTonKhoDto>
    {
        partial void ConvertToDtoPartial(ref tTonKhoDto dto, tTonKho entity);
        partial void ConvertToEntityPartial(ref tTonKho entity, tTonKhoDto dto);

        public override tTonKhoDto ConvertToDto(tTonKho entity)
        {
            var dto = new tTonKhoDto()
			{
				ID = entity.ID,
				MaKhoHang = entity.MaKhoHang,
				MaMatHang = entity.MaMatHang,
				Ngay = entity.Ngay,
				SoLuong = entity.SoLuong,
				SoLuongCu = entity.SoLuongCu,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tTonKho ConvertToEntity(tTonKhoDto dto)
        {
            var entity = new tTonKho()
            {
				ID = dto.ID,
				MaKhoHang = dto.MaKhoHang,
				MaMatHang = dto.MaMatHang,
				Ngay = dto.Ngay,
				SoLuong = dto.SoLuong,
				SoLuongCu = dto.SoLuongCu,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tTonKhoController);
        }
    }
}
