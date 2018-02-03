using Client.ViewModel;
using huypq.SmtWpfClient.Abstraction;
using huypq.QueryBuilder;
using Shared;
using System;
using System.Linq;
using Client.DataModel;

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
                var th = viewModel.ParentItem as tToaHangDataModel;
                if (th != null && viewModel.Entities.Any(p => p.ID != 0) == false)
                {
                    viewModel.Entities.Clear();
                    var qe = new QueryExpression();
                    var path = nameof(tChiTietDonHangDataModel.MaDonHangNavigation) + "." + nameof(tDonHangDataModel.MaKhachHang);
                    qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                        WhereExpression.Equal, path, th.MaKhachHang);
                    path = nameof(tChiTietDonHangDataModel.MaDonHangNavigation) + "." + nameof(tDonHangDataModel.Ngay);
                    qe.AddWhereOption<WhereExpression.WhereOptionDate, DateTime>(
                        WhereExpression.Equal, path, th.Ngay);
                    var ctdhs = viewModel.DataService.GetAll<tChiTietDonHangDto, tChiTietDonHangDataModel>(qe.WhereOptions).Items;

                    foreach (var ctdh in ctdhs)
                    {
                        qe = new QueryExpression();
                        path = nameof(tChiTietToaHangDataModel.MaChiTietDonHangNavigation) + "." + nameof(tChiTietDonHangDataModel.MaDonHangNavigation) + "." + nameof(tDonHangDataModel.MaKhachHang);
                        qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                            WhereExpression.Equal, path, th.MaKhachHang);
                        path = nameof(tChiTietToaHangDataModel.MaChiTietDonHangNavigation) + "." + nameof(tChiTietDonHangDataModel.MaMatHang);
                        qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                            WhereExpression.Equal, path, ctdh.MaMatHang);
                        qe.AddOrderByOption(nameof(tChiTietToaHangDataModel.MaChiTietDonHangNavigation) + "." + nameof(tChiTietDonHangDataModel.MaDonHangNavigation) + "." + nameof(tDonHangDataModel.Ngay), false);
                        qe.PageSize = 1;

                        var ctths = viewModel.DataService.Get<tChiTietToaHangDto, tChiTietToaHangDataModel>(qe).Items;

                        var ct = new tChiTietToaHangDataModel
                        {
                            MaToaHang = th.ID,
                            MaChiTietDonHang = ctdh.ID,
                            GiaTien = ctths.Count == 1 ? ctths[0].GiaTien : 0
                        };

                        viewModel.Entities.Add(ct);
                    }
                }
            }
        }
    }
}
