using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ViewModel
{
    public partial class tChiTietChuyenKhoViewModel : BaseViewModel<tChiTietChuyenKhoDto>
    {
        Dictionary<int, tChuyenKhoDto> chuyenKhos;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhanVienDto>.Instance.LoadOrUpdate();
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
            chuyenKhos = DataService.GetByListInt<tChuyenKhoDto>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenKho).ToList()).ToDictionary(p => p.ID);

            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");

            foreach (var dto in Entities)
            {
                dto.MaChuyenKhoNavigation = chuyenKhos[dto.MaChuyenKho];
                dto.MaChuyenKhoNavigation.MaKhoHangXuatNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaKhoHangXuat);
                dto.MaChuyenKhoNavigation.MaKhoHangNhapNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaKhoHangNhap);
                dto.MaChuyenKhoNavigation.MaNhanVienNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaNhanVien);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(dto.MaMatHang);

                dto.PropertyChanged += Item_PropertyChanged;

                if (dto.MaMatHangNavigation.SoKy == 0)
                {
                    sb.Append(dto.MaMatHangNavigation.TenMatHang);
                    sb.Append(", ");
                }
                else
                {
                    tongSoKg += dto.SoLuong * dto.MaMatHangNavigation.SoKy;
                }
            }
            
            Msg = string.Format("Tong trong luong: {0:N0} kg{1}", tongSoKg / 10, sb.ToString(0, sb.Length - 2));
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietChuyenKhoDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietChuyenKhoDto.MaChuyenKho):
                    {
                        dto.MaChuyenKhoNavigation = FindtChuyenKhoDto(dto.MaChuyenKho);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietChuyenKhoDto dto)
        {
            if (dto.MaChuyenKho != 0 && dto.MaChuyenKhoNavigation == null)
            {
                dto.MaChuyenKhoNavigation = FindtChuyenKhoDto(dto.MaChuyenKho);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenKhoDto FindtChuyenKhoDto(int maChuyenKho)
        {
            tChuyenKhoDto ck;
            if (chuyenKhos.TryGetValue(maChuyenKho, out ck) == false)
            {
                ck = DataService.GetByID<tChuyenKhoDto>(maChuyenKho);
                ck.MaKhoHangXuatNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ck.MaKhoHangXuat);
                ck.MaKhoHangNhapNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ck.MaKhoHangNhap);
                ck.MaNhanVienNavigation = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(ck.MaNhanVien);
                chuyenKhos.Add(maChuyenKho, ck);
            }

            return ck;
        }
    }
}
