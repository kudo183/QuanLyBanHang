using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiTietToaHangViewModel : BaseViewModel<tChiTietToaHangDto>
    {
        Dictionary<int, tToaHangDto> toaHangs;
        Dictionary<int, tChiTietDonHangDto> chiTietDonHangs;
        Dictionary<int, tDonHangDto> donHangs;

        partial void LoadReferenceDataPartial()
        {
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
            toaHangs = DataService.GetByListInt<tToaHangDto>(nameof(IDto.ID), Entities.Select(p => p.MaToaHang).ToList()).ToDictionary(p => p.ID);
            chiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto>(nameof(IDto.ID), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(IDto.ID), chiTietDonHangs.Select(p => p.Value.MaDonHang).ToList()).ToDictionary(p => p.ID);

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
                dto.MaToaHangNavigation = toaHangs[dto.MaToaHang];
                dto.MaChiTietDonHangNavigation = chiTietDonHangs[dto.MaChiTietDonHang];
                dto.MaToaHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaToaHangNavigation.MaKhachHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietToaHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietToaHangDto.MaToaHang):
                    {
                        dto.MaToaHangNavigation = FindtToaHangDto(dto.MaToaHang);
                    }
                    break;
                case nameof(tChiTietToaHangDto.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietToaHangDto dto)
        {
            if (dto.MaToaHang != 0 && dto.MaToaHangNavigation == null)
            {
                dto.MaToaHangNavigation = FindtToaHangDto(dto.MaToaHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangNavigation == null)
            {
                dto.MaChiTietDonHangNavigation = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tToaHangDto FindtToaHangDto(int maToaHang)
        {
            tToaHangDto th;
            if (toaHangs.TryGetValue(maToaHang, out th) == false)
            {
                th = DataService.GetByID<tToaHangDto>(maToaHang);
                th.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(th.MaKhachHang);
                toaHangs.Add(maToaHang, th);
            }

            return th;
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
