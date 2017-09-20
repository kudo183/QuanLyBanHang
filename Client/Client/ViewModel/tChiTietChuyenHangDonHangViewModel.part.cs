using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Linq;
using System;
using System.Collections.Generic;
using huypq.SmtShared;
using Client.DataModel;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenHangDonHangViewModel : BaseViewModel<tChiTietChuyenHangDonHangDto, tChiTietChuyenHangDonHangDataModel>
    {
        Dictionary<int, tChuyenHangDonHangDataModel> chuyenHangDonHangs;
        Dictionary<int, tChuyenHangDataModel> chuyenHangs;
        Dictionary<int, tChiTietDonHangDataModel> chiTietDonHangs;
        Dictionary<int, tDonHangDataModel> donHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate();
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
            chuyenHangDonHangs = DataService.GetByListInt<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenHangDonHang).ToList()).ToDictionary(p => p.ID);
            chuyenHangs = DataService.GetByListInt<tChuyenHangDto, tChuyenHangDataModel>(nameof(IDto.ID), chuyenHangDonHangs.Select(p => p.Value.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            chiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto, tChiTietDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), chuyenHangDonHangs.Select(p => p.Value.MaDonHang).Union(chiTietDonHangs.Select(p => p.Value.MaDonHang)).ToList()).ToDictionary(p => p.ID);

            foreach (var item in chuyenHangDonHangs)
            {
                var chdh = item.Value;
                chdh.MaChuyenHangNavigation = chuyenHangs[chdh.MaChuyenHang];
                chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                chdh.MaDonHangNavigation = donHangs[chdh.MaDonHang];
                chdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhoHang);
                chdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhachHang);
            }

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
                dto.MaChuyenHangDonHangNavigation = chuyenHangDonHangs[dto.MaChuyenHangDonHang];
                dto.MaChiTietDonHangNavigation = chiTietDonHangs[dto.MaChiTietDonHang];
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietChuyenHangDonHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietChuyenHangDonHangDataModel.MaChuyenHangDonHang):
                    {
                        dto.MaChuyenHangDonHangNavigation = FindtChuyenHangDonHangDataModel(dto.MaChuyenHangDonHang);
                    }
                    break;
                case nameof(tChiTietChuyenHangDonHangDataModel.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDataModel(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietChuyenHangDonHangDataModel dto)
        {
            if (dto.MaChuyenHangDonHang != 0 && dto.MaChuyenHangDonHangNavigation == null)
            {
                dto.MaChuyenHangDonHangNavigation = FindtChuyenHangDonHangDataModel(dto.MaChuyenHangDonHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangNavigation == null)
            {
                dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDataModel(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenHangDonHangDataModel FindtChuyenHangDonHangDataModel(int maChuyenHangDonHang)
        {
            tChuyenHangDonHangDataModel chdh;
            if (chuyenHangDonHangs.TryGetValue(maChuyenHangDonHang, out chdh) == false)
            {
                chdh = DataService.GetByID<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>(maChuyenHangDonHang);
                chdh.MaChuyenHangNavigation = FindtChuyenHangDataModel(chdh.MaChuyenHang);
                chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                chdh.MaDonHangNavigation = FindtDonHangDataModel(chdh.MaDonHang);
                chdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhoHang);
                chdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhachHang);
                chuyenHangDonHangs.Add(maChuyenHangDonHang, chdh);
            }

            return chdh;
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

        private tChuyenHangDataModel FindtChuyenHangDataModel(int maChuyenHang)
        {
            tChuyenHangDataModel ch;
            if (chuyenHangs.TryGetValue(maChuyenHang, out ch) == false)
            {
                ch = DataService.GetByID<tChuyenHangDto, tChuyenHangDataModel>(maChuyenHang);
                ch.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(ch.MaNhanVienGiaoHang);
                chuyenHangs.Add(maChuyenHang, ch);
            }

            return ch;
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
