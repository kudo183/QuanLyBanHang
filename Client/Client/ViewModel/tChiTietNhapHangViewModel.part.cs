using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChiTietNhapHangViewModel : BaseViewModel<tChiTietNhapHangDto>
    {
        Dictionary<int, tNhapHangDto> nhapHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto>.Instance.LoadOrUpdate();
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
            nhapHangs = DataService.GetByListInt<tNhapHangDto>(nameof(tNhapHangDto.Ma), Entities.Select(p => p.MaNhapHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaNhapHangNavigation = nhapHangs[dto.MaNhapHang];
                dto.MaNhapHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaNhapHangNavigation.MaKhoHang);
                dto.MaNhapHangNavigation.MaNhaCungCapNavigation = ReferenceDataManager<rNhaCungCapDto>.Instance.GetByID(dto.MaNhapHangNavigation.MaNhaCungCap);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(dto.MaMatHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietNhapHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietNhapHangDto.MaNhapHang):
                    {
                        dto.MaNhapHangNavigation = FindtNhapHangDto(dto.MaNhapHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietNhapHangDto dto)
        {
            if (dto.MaNhapHang != 0 && dto.MaNhapHangNavigation == null)
            {
                dto.MaNhapHangNavigation = FindtNhapHangDto(dto.MaNhapHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tNhapHangDto FindtNhapHangDto(int maNhapHang)
        {
            tNhapHangDto nh;
            if (nhapHangs.TryGetValue(maNhapHang, out nh) == false)
            {
                nh = DataService.GetByID<tNhapHangDto>(maNhapHang);
                nh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(nh.MaKhoHang);
                nh.MaNhaCungCapNavigation = ReferenceDataManager<rNhaCungCapDto>.Instance.GetByID(nh.MaNhaCungCap);
                nhapHangs.Add(maNhapHang, nh);
            }

            return nh;
        }
    }
}
