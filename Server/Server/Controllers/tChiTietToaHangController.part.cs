using Server.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shared;
using huypq.SmtMiddleware;

namespace Server.Controllers
{
    public partial class tChiTietToaHangController : SmtEntityBaseController<SqlDbContext, tChiTietToaHang, tChiTietToaHangDto>
    {
        partial void ConvertToDtoPartial(ref tChiTietToaHangDto dto, tChiTietToaHang entity)
        {
            dto.ThanhTien = entity.GiaTien * entity.MaChiTietDonHangNavigation.SoLuong;
        }

        protected override IQueryable<tChiTietToaHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaChiTietDonHangNavigation);
        }
    }
}
