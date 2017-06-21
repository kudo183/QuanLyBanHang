using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Linq;
using System;
using System.Collections.Generic;
using huypq.SmtShared;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenHangDonHangViewModel : BaseViewModel<tChiTietChuyenHangDonHangDto>
    {
        Dictionary<int, tChuyenHangDonHangDto> chuyenHangDonHangs;
        Dictionary<int, tChuyenHangDto> chuyenHangs;
        Dictionary<int, tChiTietDonHangDto> chiTietDonHangs;
        Dictionary<int, tDonHangDto> donHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<tMatHangDto>.Instance.LoadOrUpdate();
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
            chuyenHangDonHangs = DataService.GetByListInt<tChuyenHangDonHangDto>(nameof(tChuyenHangDonHangDto.Ma), Entities.Select(p => p.MaChuyenHangDonHang).ToList()).ToDictionary(p => p.ID);
            chuyenHangs = DataService.GetByListInt<tChuyenHangDto>(nameof(tChuyenHangDto.Ma), chuyenHangDonHangs.Select(p => p.Value.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            chiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto>(nameof(tChiTietDonHangDto.Ma), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(tDonHangDto.Ma), chuyenHangDonHangs.Select(p => p.Value.MaDonHang).Union(chiTietDonHangs.Select(p => p.Value.MaDonHang)).ToList()).ToDictionary(p => p.ID);

            foreach (var item in chuyenHangDonHangs)
            {
                var chdh = item.Value;
                chdh.MaChuyenHangNavigation = chuyenHangs[chdh.MaChuyenHang];
                chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                chdh.MaDonHangNavigation = donHangs[chdh.MaDonHang];
                chdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhoHang);
                chdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhachHang);
            }

            foreach (var item in chiTietDonHangs)
            {
                var ctdh = item.Value;
                ctdh.MaDonHangNavigation = donHangs[ctdh.MaDonHang];
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
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
            var dto = sender as tChiTietChuyenHangDonHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietChuyenHangDonHangDto.MaChuyenHangDonHang):
                    {
                        dto.MaChuyenHangDonHangNavigation = FindtChuyenHangDonHangDto(dto.MaChuyenHangDonHang);
                    }
                    break;
                case nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietChuyenHangDonHangDto dto)
        {
            if (dto.MaChuyenHangDonHang != 0 && dto.MaChuyenHangDonHangNavigation == null)
            {
                dto.MaChuyenHangDonHangNavigation = FindtChuyenHangDonHangDto(dto.MaChuyenHangDonHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangNavigation == null)
            {
                dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenHangDonHangDto FindtChuyenHangDonHangDto(int maChuyenHangDonHang)
        {
            tChuyenHangDonHangDto chdh;
            if (chuyenHangDonHangs.TryGetValue(maChuyenHangDonHang, out chdh) == false)
            {
                chdh = DataService.GetByID<tChuyenHangDonHangDto>(maChuyenHangDonHang);
                chdh.MaChuyenHangNavigation = FindtChuyenHangDto(chdh.MaChuyenHang);
                chdh.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(chdh.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                chdh.MaDonHangNavigation = FindtDonHangDto(chdh.MaDonHang);
                chdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhoHang);
                chdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(chdh.MaDonHangNavigation.MaKhachHang);
                chuyenHangDonHangs.Add(maChuyenHangDonHang, chdh);
            }

            return chdh;
        }

        private tChiTietDonHangDto FindtChiTietDonHangDto(int maChiTietDonHang)
        {
            tChiTietDonHangDto ctdh;
            if (chiTietDonHangs.TryGetValue(maChiTietDonHang, out ctdh) == false)
            {
                ctdh = DataService.GetByID<tChiTietDonHangDto>(maChiTietDonHang);
                ctdh.MaDonHangNavigation = FindtDonHangDto(ctdh.MaDonHang);
                ctdh.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhoHang);
                ctdh.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(ctdh.MaDonHangNavigation.MaKhachHang);
                ctdh.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
                chiTietDonHangs.Add(maChiTietDonHang, ctdh);
            }

            return ctdh;
        }

        private tChuyenHangDto FindtChuyenHangDto(int maChuyenHang)
        {
            tChuyenHangDto ch;
            if (chuyenHangs.TryGetValue(maChuyenHang, out ch) == false)
            {
                ch = DataService.GetByID<tChuyenHangDto>(maChuyenHang);
                ch.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(ch.MaNhanVienGiaoHang);
                chuyenHangs.Add(maChuyenHang, ch);
            }

            return ch;
        }

        private tDonHangDto FindtDonHangDto(int maDonHang)
        {
            tDonHangDto dh;
            if (donHangs.TryGetValue(maDonHang, out dh) == false)
            {
                dh = DataService.GetByID<tDonHangDto>(maDonHang);
                dh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
