using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rMatHangNguyenLieuController : SmtEntityBaseController<SqlDbContext, rMatHangNguyenLieu, rMatHangNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rMatHangNguyenLieuDto dto, rMatHangNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rMatHangNguyenLieu entity, rMatHangNguyenLieuDto dto);

        public override rMatHangNguyenLieuDto ConvertToDto(rMatHangNguyenLieu entity)
        {
            var dto = new rMatHangNguyenLieuDto()
			{
				Ma = entity.Ma,
				MaMatHang = entity.MaMatHang,
				MaNguyenLieu = entity.MaNguyenLieu,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rMatHangNguyenLieu ConvertToEntity(rMatHangNguyenLieuDto dto)
        {
            var entity = new rMatHangNguyenLieu()
            {
				Ma = dto.Ma,
				MaMatHang = dto.MaMatHang,
				MaNguyenLieu = dto.MaNguyenLieu,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rMatHangNguyenLieuController);
        }
    }
}
