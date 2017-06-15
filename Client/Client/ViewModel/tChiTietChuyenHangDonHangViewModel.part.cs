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
                chdh.MaChuyenHangtChuyenHangDto = chuyenHangs[chdh.MaChuyenHang];
                chdh.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHangrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(chdh.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHang);
                chdh.MaDonHangtDonHangDto = donHangs[chdh.MaDonHang];
                chdh.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(chdh.MaDonHangtDonHangDto.MaKhoHang);
                chdh.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(chdh.MaDonHangtDonHangDto.MaKhachHang);
            }

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
                dto.MaChuyenHangDonHangtChuyenHangDonHangDto = chuyenHangDonHangs[dto.MaChuyenHangDonHang];
                dto.MaChiTietDonHangtChiTietDonHangDto = chiTietDonHangs[dto.MaChiTietDonHang];
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
                        dto.MaChuyenHangDonHangtChuyenHangDonHangDto = FindtChuyenHangDonHangDto(dto.MaChuyenHangDonHang);
                    }
                    break;
                case nameof(tChiTietChuyenHangDonHangDto.MaChiTietDonHang):
                    {
                        dto.MaChiTietDonHangtChiTietDonHangDto = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietChuyenHangDonHangDto dto)
        {
            if (dto.MaChuyenHangDonHang != 0 && dto.MaChuyenHangDonHangtChuyenHangDonHangDto == null)
            {
                dto.MaChuyenHangDonHangtChuyenHangDonHangDto = FindtChuyenHangDonHangDto(dto.MaChuyenHangDonHang);
            }
            if (dto.MaChiTietDonHang != 0 && dto.MaChiTietDonHangtChiTietDonHangDto == null)
            {
                dto.MaChiTietDonHangtChiTietDonHangDto = FindtChiTietDonHangDto(dto.MaChiTietDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenHangDonHangDto FindtChuyenHangDonHangDto(int maChuyenHangDonHang)
        {
            tChuyenHangDonHangDto chdh;
            if (chuyenHangDonHangs.TryGetValue(maChuyenHangDonHang, out chdh) == false)
            {
                chdh = DataService.GetByID<tChuyenHangDonHangDto>(maChuyenHangDonHang);
                chdh.MaChuyenHangtChuyenHangDto = FindtChuyenHangDto(chdh.MaChuyenHang);
                chdh.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHangrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(chdh.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHang);
                chdh.MaDonHangtDonHangDto = FindtDonHangDto(chdh.MaDonHang);
                chdh.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(chdh.MaDonHangtDonHangDto.MaKhoHang);
                chdh.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(chdh.MaDonHangtDonHangDto.MaKhachHang);
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
                ctdh.MaDonHangtDonHangDto = FindtDonHangDto(ctdh.MaDonHang);
                ctdh.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhoHang);
                ctdh.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(ctdh.MaDonHangtDonHangDto.MaKhachHang);
                ctdh.MaMatHangtMatHangDto = ReferenceDataManager<tMatHangDto>.Instance.GetByID(ctdh.MaMatHang);
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
                ch.MaNhanVienGiaoHangrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(ch.MaNhanVienGiaoHang);
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
                dh.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
