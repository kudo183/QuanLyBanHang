using Server.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared;
using huypq.SmtMiddleware;

namespace Server.Controllers
{
    public partial class tToaHangController : SmtEntityBaseController<SqlDbContext, tToaHang, tToaHangDto>
    {
        partial void ConvertToDtoPartial(ref tToaHangDto dto, tToaHang entity)
        {
            dto.ThanhTien = entity.tChiTietToaHangMaToaHangNavigation
                .Sum(p => p.GiaTien * p.MaChiTietDonHangNavigation.SoLuong);
        }

        protected override IQueryable<tToaHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.tChiTietToaHangMaToaHangNavigation)
                .ThenInclude(p => p.MaChiTietDonHangNavigation);
        }
    }
}
