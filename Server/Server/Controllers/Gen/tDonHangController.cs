using huypq.SmtMiddleware;
using Server.Entities;
using huypq.SmtMiddleware.Entities;
using Shared;

namespace Server.Controllers
{
    public partial class tDonHangController : SmtEntityBaseController<SqlDbContext, tDonHang, tDonHangDto>
    {
        partial void ConvertToDtoPartial(ref tDonHangDto dto, tDonHang entity);
        partial void ConvertToEntityPartial(ref tDonHang entity, tDonHangDto dto);

        public override tDonHangDto ConvertToDto(tDonHang entity)
        {
            var dto = new tDonHangDto()
			{
				ID = entity.ID,
				MaKhachHang = entity.MaKhachHang,
				MaChanh = entity.MaChanh,
				Ngay = entity.Ngay,
				Xong = entity.Xong,
				MaKhoHang = entity.MaKhoHang,
				TongSoLuong = entity.TongSoLuong,
				TenantID = entity.TenantID,
				CreateTime = entity.CreateTime,
				LastUpdateTime = entity.LastUpdateTime
            };

            ConvertToDtoPartial(ref dto, entity);

            return dto;
        }

        public override tDonHang ConvertToEntity(tDonHangDto dto)
        {
            var entity = new tDonHang()
            {
				ID = dto.ID,
				MaKhachHang = dto.MaKhachHang,
				MaChanh = dto.MaChanh,
				Ngay = dto.Ngay,
				Xong = dto.Xong,
				MaKhoHang = dto.MaKhoHang,
				TongSoLuong = dto.TongSoLuong,
				TenantID = dto.TenantID,
				CreateTime = dto.CreateTime,
				LastUpdateTime = dto.LastUpdateTime
			};

            ConvertToEntityPartial(ref entity, dto);

            return entity;
        }
		
		public override string GetControllerName()
        {
            return nameof(tDonHangController);
        }
    }
}
