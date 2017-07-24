using Server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Shared;
using huypq.SmtMiddleware;

namespace Server.Controllers
{
    public partial class tNhapHangController : SmtEntityBaseController<SqlDbContext, tNhapHang, tNhapHangDto>
    {
        partial void ConvertToDtoPartial(ref tNhapHangDto dto, tNhapHang entity)
        {
            dto.TongSoLuong = entity.tChiTietNhapHangMaNhapHangNavigation
                .Sum(p => p.SoLuong);
        }

        protected override IQueryable<tNhapHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.tChiTietNhapHangMaNhapHangNavigation);
        }
    }
}
