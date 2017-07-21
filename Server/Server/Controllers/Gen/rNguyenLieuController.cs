using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rNguyenLieuController : SmtEntityBaseController<SqlDbContext, rNguyenLieu, rNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rNguyenLieuDto dto, rNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rNguyenLieu entity, rNguyenLieuDto dto);

        public override rNguyenLieuDto ConvertToDto(rNguyenLieu entity)
        {
            var dto = new rNguyenLieuDto()
			{
				Ma = entity.Ma,
				MaLoaiNguyenLieu = entity.MaLoaiNguyenLieu,
				DuongKinh = entity.DuongKinh,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rNguyenLieu ConvertToEntity(rNguyenLieuDto dto)
        {
            var entity = new rNguyenLieu()
            {
				Ma = dto.Ma,
				MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu,
				DuongKinh = dto.DuongKinh,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rNguyenLieuController);
        }
    }
}
