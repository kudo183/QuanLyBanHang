using Server.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using huypq.SmtMiddleware;
using Shared;

namespace Server.Controllers
{
    public partial class tChuyenKhoController : SmtEntityBaseController<SqlDbContext, tChuyenKho, tChuyenKhoDto>
    {
        partial void ConvertToDtoPartial(ref tChuyenKhoDto dto, tChuyenKho entity)
        {
            dto.TongSoLuong = entity.tChiTietChuyenKhoMaChuyenKhoNavigation
                .Sum(p => p.SoLuong);
        }

        protected override IQueryable<tChuyenKho> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.tChiTietChuyenKhoMaChuyenKhoNavigation);
        }
    }
}
