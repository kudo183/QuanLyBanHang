using Client.ViewModel;
using huypq.SmtWpfClient.Abstraction;
using QueryBuilder;
using Shared;
using System;
using System.Linq;

namespace Client.View
{
    public partial class ToaHangComplexView : BaseComplexView
    {
        protected override void OnMoveFocus(IBaseView currentView, IBaseView nextView)
        {
            if (currentView is tToaHangView)
            {
                System.Windows.Input.Keyboard.Focus(nextView.GridView.dataGrid);
                return;
            }

            base.OnMoveFocus(currentView, nextView);
        }

        protected override void OnSelectedIndexChanged(IBaseView currentView, IBaseView nextView, object selectedValue)
        {
            base.OnSelectedIndexChanged(currentView, nextView, selectedValue);

            if (currentView is tToaHangView)
            {
                var view = nextView as tChiTietToaHangView;
                var viewModel = view.DataContext as tChiTietToaHangViewModel;
                var th = viewModel.ParentItem as tToaHangDto;
                if (th != null && viewModel.Entities.Any(p => p.ID != 0) == false)
                {
                    viewModel.Entities.Clear();
                    var qe = new QueryExpression();
                    var path = nameof(tChiTietDonHangDto.MaDonHangNavigation) + "." + nameof(tDonHangDto.MaKhachHang);
                    qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                        WhereExpression.Equal, path, th.MaKhachHang);
                    path = nameof(tChiTietDonHangDto.MaDonHangNavigation) + "." + nameof(tDonHangDto.Ngay);
                    qe.AddWhereOption<WhereExpression.WhereOptionDate, DateTime>(
                        WhereExpression.Equal, path, th.Ngay);
                    var ctdhs = viewModel.DataService.Get<tChiTietDonHangDto>(qe).Items;

                    foreach (var ctdh in ctdhs)
                    {
                        var ct = new tChiTietToaHangDto
                        {
                            MaToaHang = th.Ma,
                            MaChiTietDonHang = ctdh.Ma,
                            GiaTien = 0
                        };

                        viewModel.Entities.Add(ct);
                    }
                }
            }
        }
    }
}
