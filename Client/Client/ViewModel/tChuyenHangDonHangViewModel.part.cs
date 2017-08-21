using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChuyenHangDonHangViewModel : BaseViewModel<tChuyenHangDonHangDto>
    {
        Dictionary<int, tChuyenHangDto> chuyenHangs;
        Dictionary<int, tDonHangDto> donHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto>.Instance.LoadOrUpdate();
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
            chuyenHangs = DataService.GetByListInt<tChuyenHangDto>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(IDto.ID), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaChuyenHangNavigation = chuyenHangs[dto.MaChuyenHang];
                dto.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(dto.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                dto.MaDonHangNavigation = donHangs[dto.MaDonHang];
                dto.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaDonHangNavigation.MaKhoHang);
                dto.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaDonHangNavigation.MaKhachHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChuyenHangDonHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChuyenHangDonHangDto.MaChuyenHang):
                    {
                        dto.MaChuyenHangNavigation = FindtChuyenHangDto(dto.MaChuyenHang);
                    }
                    break;
                case nameof(tChuyenHangDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
            }
        }
        
        partial void ProcessNewAddedDtoPartial(tChuyenHangDonHangDto dto)
        {
            if (dto.MaChuyenHang != 0 && dto.MaChuyenHangNavigation == null)
            {
                dto.MaChuyenHangNavigation = FindtChuyenHangDto(dto.MaChuyenHang);
            }
            if (dto.MaDonHang != 0 && dto.MaDonHangNavigation == null)
            {
                dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
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
