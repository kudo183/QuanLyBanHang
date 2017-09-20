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
        Dictionary<int, tToaHangDataModel> toaHangs;
        Dictionary<int, tChiTietDonHangDataModel> chiTietDonHangs;
        Dictionary<int, tDonHangDataModel> donHangs;

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

        protected override void AfterLoad()
        {
            toaHangs = DataService.GetByListInt<tToaHangDto, tToaHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaToaHang).ToList()).ToDictionary(p => p.ID);
            chiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto, tChiTietDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), chiTietDonHangs.Select(p => p.Value.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var item in chiTietDonHangs)
            {
                var ctdh = item.Value;
                ctdh.MaDonHangNavigation = donHangs[ctdh.MaDonHang];
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
            }

            foreach (var dto in Entities)
            {
                dto.MaToaHangNavigation = toaHangs[dto.MaToaHang];
                dto.MaChiTietDonHangNavigation = chiTietDonHangs[dto.MaChiTietDonHang];
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
            if (toaHangs.TryGetValue(maToaHang, out th) == false)
            {
                th = DataService.GetByID<tToaHangDto, tToaHangDataModel>(maToaHang);
                th.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(th.MaKhachHang);
                toaHangs.Add(maToaHang, th);
            }

            return th;
        }

        private tChiTietDonHangDataModel FindtChiTietDonHangDataModel(int maChiTietDonHang)
        {
            tChiTietDonHangDataModel ctdh;
            if (chiTietDonHangs.TryGetValue(maChiTietDonHang, out ctdh) == false)
            {
                ctdh = DataService.GetByID<tChiTietDonHangDto, tChiTietDonHangDataModel>(maChiTietDonHang);
                ctdh.MaDonHangNavigation = FindtDonHangDataModel(ctdh.MaDonHang);
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(ctdh.MaMatHang);
                chiTietDonHangs.Add(maChiTietDonHang, ctdh);
            }

            return ctdh;
        }

        private tDonHangDataModel FindtDonHangDataModel(int maDonHang)
        {
            tDonHangDataModel dh;
            if (donHangs.TryGetValue(maDonHang, out dh) == false)
            {
                dh = DataService.GetByID<tDonHangDto, tDonHangDataModel>(maDonHang);
                dh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
