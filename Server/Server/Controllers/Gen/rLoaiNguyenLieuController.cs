using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rLoaiNguyenLieuController : SmtEntityBaseController<SqlDbContext, rLoaiNguyenLieu, rLoaiNguyenLieuDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiNguyenLieuDto dto, rLoaiNguyenLieu entity);
        partial void ConvertToEntityPartial(ref rLoaiNguyenLieu entity, rLoaiNguyenLieuDto dto);

        public override rLoaiNguyenLieuDto ConvertToDto(rLoaiNguyenLieu entity)
        {
            var dto = new rLoaiNguyenLieuDto()
			{
				Ma = entity.Ma,
				TenLoai = entity.TenLoai,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiNguyenLieu ConvertToEntity(rLoaiNguyenLieuDto dto)
        {
            var entity = new rLoaiNguyenLieu()
            {
				Ma = dto.Ma,
				TenLoai = dto.TenLoai,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rLoaiNguyenLieuController);
        }
    }
}
