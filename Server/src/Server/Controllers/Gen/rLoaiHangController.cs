using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rLoaiHangController : SmtEntityBaseController<SqlDbContext, rLoaiHang, rLoaiHangDto>
    {
        partial void ConvertToDtoPartial(ref rLoaiHangDto dto, rLoaiHang entity);
        partial void ConvertToEntityPartial(ref rLoaiHang entity, rLoaiHangDto dto);

        public override rLoaiHangDto ConvertToDto(rLoaiHang entity)
        {
            var dto = new rLoaiHangDto()
			{
				Ma = entity.Ma,
				TenLoai = entity.TenLoai,
				HangNhaLam = entity.HangNhaLam,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rLoaiHang ConvertToEntity(rLoaiHangDto dto)
        {
            var entity = new rLoaiHang()
            {
				Ma = dto.Ma,
				TenLoai = dto.TenLoai,
				HangNhaLam = dto.HangNhaLam,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rLoaiHangController);
        }
    }
}
