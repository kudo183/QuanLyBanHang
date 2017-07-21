using huypq.SmtMiddleware;
using huypq.SmtShared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Shared.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class ReportController : SmtAbstractController, IDisposable
    {
        private SqlDbContext _context;

        public override void Init(TokenManager.LoginToken token, IApplicationBuilder app, HttpContext context, string requestType)
        {
            base.Init(token, app, context, requestType);
            _context = (SqlDbContext)Context.RequestServices.GetService(typeof(SqlDbContext));
        }

        public override SmtActionResult ActionInvoker(string actionName, Dictionary<string, object> parameter)
        {
            SmtActionResult result = null;

            switch (actionName)
            {
                case "daily":
                    var date = ParseDateFromString(parameter["date"].ToString());
                    result = Daily(date);
                    break;
                case "chiphi":
                    var dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    var dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    result = ChiPhi(dateFrom, dateTo);
                    break;
                case "xuat":
                    dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    result = Xuat(dateFrom, dateTo);
                    break;
                case "khachhang":
                    dateFrom = ParseDateFromString(parameter["dateFrom"].ToString());
                    dateTo = ParseDateFromString(parameter["dateTo"].ToString());
                    var maKhachHang = int.Parse(parameter["maKhachHang"].ToString());
                    result = KhachHang(dateFrom, dateTo, maKhachHang);
                    break;
                default:
                    break;
            }

            return result;
        }

        public SmtActionResult Daily(DateTime date)
        {
            var q = GetQuery<tDonHang>().Where(p => p.Ngay == date)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.MaKhachHangNavigation)
                .Include(p => p.tChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p1 => p1.MaMatHangNavigation)
                .Include(p => p.tChuyenHangDonHangMaDonHangNavigation)
                .ThenInclude(p => p.MaChuyenHangNavigation)
                .ThenInclude(p => p.MaNhanVienGiaoHangNavigation);

            var result = new PagingResultDto<DailyDto>();

            foreach (var donHang in q)
            {
                var sb = new System.Text.StringBuilder();
                sb.Append(" (");
                foreach (var chdh in donHang.tChuyenHangDonHangMaDonHangNavigation)
                {
                    sb.Append(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation.TenNhanVien);
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - 2, 2);
                sb.Append(")");

                var isFirst = true;
                foreach (var ctDonHang in donHang.tChiTietDonHangMaDonHangNavigation)
                {
                    if (isFirst == true)
                    {
                        result.Items.Add(new DailyDto()
                        {
                            TenKho = donHang.MaKhoHangNavigation.TenKho,
                            TenKhachHang = donHang.MaKhachHangNavigation.TenKhachHang + sb.ToString(),
                            TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangIn,
                            SoLuong = ctDonHang.SoLuong,
                            SoKg = ctDonHang.MaMatHangNavigation.SoKy
                        });
                        isFirst = false;
                        continue;
                    }

                    result.Items.Add(new DailyDto()
                    {
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangIn,
                        SoLuong = ctDonHang.SoLuong,
                        SoKg = ctDonHang.MaMatHangNavigation.SoKy
                    });
                }
                result.Items.Add(new DailyDto());
            }
            return CreateObjectResult(result);
        }

        public SmtActionResult ChiPhi(DateTime dateFrom, DateTime dateTo)
        {
            var q = GetQuery<tChiPhi>().Where(p => p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaLoaiChiPhiNavigation)
                .Include(p => p.MaNhanVienGiaoHangNavigation);

            var result = new PagingResultDto<ReportChiPhiDto>();

            foreach (var chiPhi in q)
            {
                result.Items.Add(new ReportChiPhiDto()
                {
                    MaLoaiChiPhi = chiPhi.MaLoaiChiPhi,
                    TenLoaiChiPhi = chiPhi.MaLoaiChiPhiNavigation.TenLoaiChiPhi,
                    MaNhanVien = chiPhi.MaNhanVienGiaoHang,
                    TenNhanVien = chiPhi.MaNhanVienGiaoHangNavigation.TenNhanVien,
                    Ngay = chiPhi.Ngay,
                    SoTien = chiPhi.SoTien,
                    GhiChu = chiPhi.GhiChu
                });
            }

            return CreateObjectResult(result);
        }

        public SmtActionResult Xuat(DateTime dateFrom, DateTime dateTo)
        {
            var q = GetQuery<tDonHang>().Where(p => p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.MaKhachHangNavigation)
                .Include(p => p.tChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p1 => p1.MaMatHangNavigation.MaLoaiNavigation);

            var result = new PagingResultDto<XuatDto>();

            foreach (var donHang in q)
            {
                var xuat = new XuatDto()
                {
                    MaKho = donHang.MaKhoHang,
                    TenKho = donHang.MaKhoHangNavigation.TenKho,
                    MaKhachHang = donHang.MaKhachHang,
                    TenKhachHang = donHang.MaKhachHangNavigation.TenKhachHang,
                    ChiTietXuat = new List<ChiTietXuatDto>(),
                    Ngay = donHang.Ngay
                };

                foreach (var ctDonHang in donHang.tChiTietDonHangMaDonHangNavigation)
                {
                    xuat.ChiTietXuat.Add(new ChiTietXuatDto()
                    {
                        MaLoaiHang = ctDonHang.MaMatHangNavigation.MaLoai,
                        TenLoaiHang = ctDonHang.MaMatHangNavigation.MaLoaiNavigation.TenLoai,
                        MaMatHang = ctDonHang.MaMatHang,
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangDayDu,
                        SoLuong = ctDonHang.SoLuong,
                        SoKg = ctDonHang.MaMatHangNavigation.SoKy
                    });
                }

                result.Items.Add(xuat);
            }

            return CreateObjectResult(result);
        }

        public SmtActionResult KhachHang(DateTime dateFrom, DateTime dateTo, int maKhachHang)
        {
            var q = GetQuery<tDonHang>().Where(p => p.MaKhachHang == maKhachHang && p.Ngay >= dateFrom && p.Ngay <= dateTo)
                .Include(p => p.MaKhoHangNavigation)
                .Include(p => p.tChiTietDonHangMaDonHangNavigation)
                .ThenInclude(p => p.MaMatHangNavigation);

            var result = new PagingResultDto<KhachHangDto>();

            foreach (var donHang in q)
            {
                var khachHang = new KhachHangDto()
                {
                    MaKho = donHang.MaKhoHang,
                    TenKho = donHang.MaKhoHangNavigation.TenKho,
                    Ngay = donHang.Ngay,
                    ChiTiet = new List<ChiTietKhachHangDto>()
                };

                foreach (var ctDonHang in donHang.tChiTietDonHangMaDonHangNavigation)
                {
                    khachHang.ChiTiet.Add(new ChiTietKhachHangDto()
                    {
                        MaMatHang = ctDonHang.MaMatHang,
                        TenMatHang = ctDonHang.MaMatHangNavigation.TenMatHangDayDu,
                        SoLuong = ctDonHang.SoLuong
                    });
                }

                result.Items.Add(khachHang);
            }

            return CreateObjectResult(result);
        }

        private DateTime ParseDateFromString(string date)
        {
            int year = int.Parse(date.Substring(0, 4));
            int mon = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));

            return new DateTime(year, mon, day);
        }

        private string DateToString(DateTime date)
        {
            return date.ToString("yyyy/MM/dd");
        }

        public IQueryable<T> GetQuery<T>() where T : class, IEntity
        {
            return _context.Set<T>().Where(p => p.TenantID == TokenModel.TenantID);
        }

        public override string GetControllerName()
        {
            return nameof(ReportController);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
