using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto>
    {
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
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(tDonHangDto.Ma), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaDonHangtDonHangDto = donHangs[dto.MaDonHang];
                dto.MaDonHangtDonHangDto.MaKhoHangrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaDonHangtDonHangDto.MaKhoHang);
                dto.MaDonHangtDonHangDto.MaKhachHangrKhachHangDto = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaDonHangtDonHangDto.MaKhachHang);
                dto.MaMatHangtMatHangDto = ReferenceDataManager<tMatHangDto>.Instance.GetByID(dto.MaMatHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietDonHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangtDonHangDto = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietDonHangDto dto)
        {
            if (dto.MaDonHang != 0 && dto.MaDonHangtDonHangDto == null)
            {
                dto.MaDonHangtDonHangDto = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
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
