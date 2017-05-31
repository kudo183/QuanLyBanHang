using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tChiTietNhapHangController : SmtEntityBaseController<SqlDbContext, tChiTietNhapHang, tChiTietNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietNhapHangDto dto, tChiTietNhapHang entity);
        partial void ConvertToEntityPartial(ref tChiTietNhapHang entity, tChiTietNhapHangDto dto);

        public override tChiTietNhapHangDto ConvertToDto(tChiTietNhapHang entity)
        {
            var dto = new tChiTietNhapHangDto()
			{
				Ma = entity.Ma,
				MaNhapHang = entity.MaNhapHang,
				MaMatHang = entity.MaMatHang,
				SoLuong = entity.SoLuong,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tChiTietNhapHang ConvertToEntity(tChiTietNhapHangDto dto)
        {
            var entity = new tChiTietNhapHang()
            {
				Ma = dto.Ma,
				MaNhapHang = dto.MaNhapHang,
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
            return nameof(tChiTietNhapHangController);
        }
    }
}
