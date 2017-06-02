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
            chuyenHangs = DataService.GetByListInt<tChuyenHangDto>(nameof(tChuyenHangDto.Ma), Entities.Select(p => p.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(tDonHangDto.Ma), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaChuyenHangtChuyenHangDto = chuyenHangs[dto.MaChuyenHang];
                dto.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHangrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(dto.MaChuyenHangtChuyenHangDto.MaNhanVienGiaoHang);
                dto.MaDonHangtDonHangDto = donHangs[dto.MaDonHang];
                dto.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaDonHangtDonHangDto.MaKhoHang);
                dto.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaDonHangtDonHangDto.MaKhachHang);
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
                        dto.MaChuyenHangtChuyenHangDto = FindtChuyenHangDto(dto.MaChuyenHang);
                    }
                    break;
                case nameof(tChuyenHangDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangtDonHangDto = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
            }
        }
        
        partial void ProcessNewAddedDtoPartial(tChuyenHangDonHangDto dto)
        {
            if (dto.MaChuyenHang != 0 && dto.MaChuyenHangtChuyenHangDto == null)
            {
                dto.MaChuyenHangtChuyenHangDto = FindtChuyenHangDto(dto.MaChuyenHang);
            }
            if (dto.MaDonHang != 0 && dto.MaDonHangtDonHangDto == null)
            {
                dto.MaDonHangtDonHangDto = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
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
