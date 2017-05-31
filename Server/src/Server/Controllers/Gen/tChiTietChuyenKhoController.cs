using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChiTietChuyenKhoController : SmtEntityBaseController<SqlDbContext, tChiTietChuyenKho, tChiTietChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietChuyenKhoDto dto, tChiTietChuyenKho entity);
        partial void ConvertToEntityPartial(ref tChiTietChuyenKho entity, tChiTietChuyenKhoDto dto);

        public override tChiTietChuyenKhoDto ConvertToDto(tChiTietChuyenKho entity)
        {
            var dto = new tChiTietChuyenKhoDto()
			{
				Ma = entity.Ma,
				MaChuyenKho = entity.MaChuyenKho,
				MaMatHang = entity.MaMatHang,
				SoLuong = entity.SoLuong,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietChuyenKho ConvertToEntity(tChiTietChuyenKhoDto dto)
        {
            var entity = new tChiTietChuyenKho()
            {
				Ma = dto.Ma,
				MaChuyenKho = dto.MaChuyenKho,
				MaMatHang = dto.MaMatHang,
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
            return nameof(tChiTietChuyenKhoController);
        }
    }
}
