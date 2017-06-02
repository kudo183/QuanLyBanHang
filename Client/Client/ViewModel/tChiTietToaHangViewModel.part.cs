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
            toaHangs = DataService.GetByListInt<tToaHangDto>(nameof(tToaHangDto.Ma), Entities.Select(p => p.MaToaHang).ToList()).ToDictionary(p => p.ID);
            chiTietDonHangs = DataService.GetByListInt<tChiTietDonHangDto>(nameof(tChiTietDonHangDto.Ma), Entities.Select(p => p.MaChiTietDonHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(tDonHangDto.Ma), chiTietDonHangs.Select(p => p.Value.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var item in chiTietDonHangs)
            {
                var ctdh = item.Value;
                ctdh.MaDonHangtDonHangDto = donHangs[ctdh.MaDonHang];
                ctdh.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhoHang);
                ctdh.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhachHang);
                ctdh.MaMatHangtMatHangDto = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
            }

            foreach (var dto in Entities)
            {
                dto.MaToaHangtToaHangDto = toaHangs[dto.MaToaHang];
                dto.MaChiTietDonHangtChiTietDonHangDto = chiTietDonHangs[dto.MaChiTietDonHang];
                dto.MaToaHangtToaHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaToaHangtToaHangDto.MaKhachHang);
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
                        dto.MaToaHangtToaHangDto = FindtToaHangDto(dto.MaToaHang);
                    }
                    break;
                case nameof(tChiTietToaHangDto.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangtChiTietDonHangDto = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietToaHangDto dto)
        {
            if (dto.MaToaHang != 0 && dto.MaToaHangtToaHangDto == null)
            {
                dto.MaToaHangtToaHangDto = FindtToaHangDto(dto.MaToaHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangtChiTietDonHangDto == null)
            {
                dto.MaChiTietDonHangtChiTietDonHangDto = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tToaHangDto FindtToaHangDto(int maToaHang)
        {
            tToaHangDto th;
            if (toaHangs.TryGetValue(maToaHang, out th) == false)
            {
                th = DataService.GetByID<tToaHangDto>(maToaHang);
                th.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(th.MaKhachHang);
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
                ctdh.MaDonHangtDonHangDto = FindtDonHangDto(ctdh.MaDonHang);
                ctdh.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhoHang);
                ctdh.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhachHang);
                ctdh.MaMatHangtMatHangDto = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
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
                dh.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
