using Client.DataModel;
using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiTietToaHangViewModel : BaseViewModel<tChiTietToaHangDto, tChiTietToaHangDataModel>
    {
        Dictionary<int, tDonHangDataModel> _MaDonHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.LoadOrUpdate();
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
            _MaDonHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), _MaChiTietDonHangs.Select(p => p.Value.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var item in _MaChiTietDonHangs)
            {
                var ctdh = item.Value;
                ctdh.MaDonHangNavigation = _MaDonHangs[ctdh.MaDonHang];
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
            }

            foreach (var dto in Entities)
            {
                dto.MaToaHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dto.MaToaHangNavigation.MaKhachHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietToaHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietToaHangDataModel.MaToaHang):
                    {
                        dto.MaToaHangNavigation = FindtToaHangDataModel(dto.MaToaHang);
                    }
                    break;
                case nameof(tChiTietToaHangDataModel.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDataModel(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietToaHangDataModel dto)
        {
            if (dto.MaToaHang != 0 && dto.MaToaHangNavigation == null)
            {
                dto.MaToaHangNavigation = FindtToaHangDataModel(dto.MaToaHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangNavigation == null)
            {
                dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDataModel(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tToaHangDataModel FindtToaHangDataModel(int maToaHang)
        {
            tToaHangDataModel th;
            if (_MaToaHangs.TryGetValue(maToaHang, out th) == false)
            {
                th = DataService.GetByID<tToaHangDto, tToaHangDataModel>(maToaHang);
                th.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(th.MaKhachHang);
                _MaToaHangs.Add(maToaHang, th);
            }

            return th;
        }

        private tChiTietDonHangDataModel FindtChiTietDonHangDataModel(int maChiTietDonHang)
        {
            tChiTietDonHangDataModel ctdh;
            if (_MaChiTietDonHangs.TryGetValue(maChiTietDonHang, out ctdh) == false)
            {
                ctdh = DataService.GetByID<tChiTietDonHangDto, tChiTietDonHangDataModel>(maChiTietDonHang);
                ctdh.MaDonHangNavigation = FindtDonHangDataModel(ctdh.MaDonHang);
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
                _MaChiTietDonHangs.Add(maChiTietDonHang, ctdh);
            }

            return ctdh;
        }

        private tDonHangDataModel FindtDonHangDataModel(int maDonHang)
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
