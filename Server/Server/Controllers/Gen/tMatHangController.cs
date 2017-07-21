using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tMatHangController : SmtEntityBaseController<SqlDbContext, tMatHang, tMatHangDto>
    {
        partial void ConvertToDtoPartial(ref tMatHangDto dto, tMatHang entity);
        partial void ConvertToEntityPartial(ref tMatHang entity, tMatHangDto dto);

        public override tMatHangDto ConvertToDto(tMatHang entity)
        {
            var dto = new tMatHangDto()
			{
				Ma = entity.Ma,
				MaLoai = entity.MaLoai,
				TenMatHang = entity.TenMatHang,
				SoKy = entity.SoKy,
				SoMet = entity.SoMet,
				TenMatHangDayDu = entity.TenMatHangDayDu,
				TenMatHangIn = entity.TenMatHangIn,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tMatHang ConvertToEntity(tMatHangDto dto)
        {
            var entity = new tMatHang()
            {
				Ma = dto.Ma,
				MaLoai = dto.MaLoai,
				TenMatHang = dto.TenMatHang,
				SoKy = dto.SoKy,
				SoMet = dto.SoMet,
				TenMatHangDayDu = dto.TenMatHangDayDu,
				TenMatHangIn = dto.TenMatHangIn,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tMatHangController);
        }
    }
}
