using Client.ViewModel;
using huypq.SmtWpfClient.Abstraction;
using huypq.QueryBuilder;
using Shared;
using System.Linq;

namespace Client.View
{
    public partial class ChuyenHangComplexView : BaseComplexView
    {
        protected override void OnMoveFocus(IBaseView currentView, IBaseView nextView)
        {
            if (currentView is tChuyenHangDonHangView)
            {
                System.Windows.Input.Keyboard.Focus(nextView.GridView.dataGrid);
                return;
            }

            base.OnMoveFocus(currentView, nextView);
        }

        protected override void OnSelectedIndexChanged(IBaseView currentView, IBaseView nextView, object selectedValue)
        {
            base.OnSelectedIndexChanged(currentView, nextView, selectedValue);

            if (currentView is tChuyenHangDonHangView)
            {
                var view = nextView as tChiTietChuyenHangDonHangView;
                var viewModel = view.DataContext as tChiTietChuyenHangDonHangViewModel;
                var chdh = viewModel.ParentItem as tChuyenHangDonHangDto;
                if (chdh != null && viewModel.Entities.Any(p => p.ID != 0) == false)
                {
                    viewModel.Entities.Clear();
                    var qe = new QueryExpression();
                    qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                        WhereExpression.Equal, nameof(tChiTietDonHangDto.MaDonHang), chdh.MaDonHang);
                    qe.AddWhereOption<WhereExpression.WhereOptionBool, bool>(
                          WhereExpression.Equal, nameof(tChiTietDonHangDto.Xong), false);
                    var chiTietDonHangsChuaXong = viewModel.DataService.Get<tChiTietDonHangDto>(qe).Items;

                    var ctchdh = viewModel.DataService.GetByListInt<tChiTietChuyenHangDonHangDto>(
                        nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHang), chiTietDonHangsChuaXong.Select(p => p.Ma).ToList());

                    foreach (var ctdh in chiTietDonHangsChuaXong)
                    {
                        var soLuongConLai = ctdh.SoLuong - ctchdh.Where(p => p.MaChiTietDonHang == ctdh.Ma).Sum(p => p.SoLuong);
                        var ct = new tChiTietChuyenHangDonHangDto
                        {
                            MaChiTietDonHang = ctdh.Ma,
                            MaChuyenHangDonHang = chdh.Ma,
                            SoLuong = soLuongConLai
                        };

                        viewModel.Entities.Add(ct);
                    }
                }
            }
        }
    }
}
