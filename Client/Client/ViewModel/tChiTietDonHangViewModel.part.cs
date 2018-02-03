using Client.DataModel;
using huypq.QueryBuilder;
using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto, tChiTietDonHangDataModel>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();
        }

        protected override void BeforeLoad()
        {
            foreach (var dto in Entities)
            {
                dto.PropertyChanged -= Item_PropertyChanged;
            }
        }

        partial void AfterLoadPartial()
        {
            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");

            foreach (var dto in Entities)
            {
                dto.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhoHang);
                dto.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhachHang);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(dto.MaMatHang);

                if (dto.MaMatHangNavigation != null)
                {
                    if (dto.MaMatHangNavigation.SoKy == 0)
                    {
                        sb.Append(dto.MaMatHangNavigation.TenMatHang);
                        sb.Append(", ");
                    }
                    else
                    {
                        tongSoKg += dto.SoLuong * dto.MaMatHangNavigation.SoKy;
                    }
                }
                dto.PropertyChanged += Item_PropertyChanged;
            }

            tongSoKg = tongSoKg / 10;

            Msg = string.Format("Tong trong luong: {0:N0} kg{1}", tongSoKg, sb.ToString(0, sb.Length - 2));

            if (_MaDonHangFilter.IsUsed == true && _MaDonHangFilter.FilterValue != null && _MaDonHangs.Count == 1)
            {
                var qe = new QueryExpression();
                qe.AddWhereOption<WhereExpression.WhereOptionIntList, List<int>>(
                    WhereExpression.In, nameof(tTonKhoDataModel.MaMatHang), Entities.Select(p => p.MaMatHang).ToList());
                qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                      WhereExpression.Equal, nameof(tTonKhoDataModel.MaKhoHang), _MaDonHangs.Single().Value.MaKhoHang);
                qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                      WhereExpression.Equal, nameof(tTonKhoDataModel.Ngay), System.DateTime.Now);

                var tonKhos = DataService.Get<tTonKhoDto, tTonKhoDataModel>(qe).Items.ToDictionary(p => p.MaMatHang);

                foreach (var dto in Entities)
                {
                    if (tonKhos.TryGetValue(dto.MaMatHang, out tTonKhoDataModel tonKho) == true)
                    {
                        dto.TonKho = tonKho.SoLuong;
                    }
                }
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietDonHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
                case nameof(tChiTietDonHangDto.MaMatHang):
                    {
                        var qe = new QueryExpression();
                        qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                            WhereExpression.Equal, nameof(tTonKhoDataModel.MaMatHang), dto.MaMatHang);
                        qe.AddWhereOption<WhereExpression.WhereOptionInt, int>(
                              WhereExpression.Equal, nameof(tTonKhoDataModel.MaKhoHang), dto.MaDonHangNavigation.MaKhoHang);
                        qe.AddWhereOption<WhereExpression.WhereOptionDate, System.DateTime>(
                              WhereExpression.Equal, nameof(tTonKhoDataModel.Ngay), System.DateTime.Now);

                        var tonKhos = DataService.Get<tTonKhoDto, tTonKhoDataModel>(qe).Items;

                        if (tonKhos.Count == 1)
                        {
                            dto.TonKho = tonKhos[0].SoLuong;
                        }
                        else
                        {
                            dto.TonKho = null;
                        }
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietDonHangDataModel dto)
        {
            if (dto.MaDonHang != 0 && dto.MaDonHangNavigation == null)
            {
                dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tDonHangDataModel FindtDonHangDto(int maDonHang)
        {
            tDonHangDataModel dh;
            if (_MaDonHangs.TryGetValue(maDonHang, out dh) == false)
            {
                dh = DataService.GetByID<tDonHangDto, tDonHangDataModel>(maDonHang);
                dh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dh.MaKhachHang);
                _MaDonHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
