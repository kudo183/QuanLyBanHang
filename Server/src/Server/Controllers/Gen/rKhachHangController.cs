using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class rKhachHangController : SmtEntityBaseController<SqlDbContext, rKhachHang, rKhachHangDto>
    {
        partial void ConvertToDtoPartial(ref rKhachHangDto dto, rKhachHang entity);
        partial void ConvertToEntityPartial(ref rKhachHang entity, rKhachHangDto dto);

        public override rKhachHangDto ConvertToDto(rKhachHang entity)
        {
            var dto = new rKhachHangDto()
			{
				Ma = entity.Ma,
				MaDiaDiem = entity.MaDiaDiem,
				TenKhachHang = entity.TenKhachHang,
				KhachRieng = entity.KhachRieng,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override rKhachHang ConvertToEntity(rKhachHangDto dto)
        {
            var entity = new rKhachHang()
            {
				Ma = dto.Ma,
				MaDiaDiem = dto.MaDiaDiem,
				TenKhachHang = dto.TenKhachHang,
				KhachRieng = dto.KhachRieng,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(rKhachHangController);
        }
    }
}
