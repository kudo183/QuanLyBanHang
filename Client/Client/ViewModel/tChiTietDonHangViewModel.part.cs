using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto>
    {
        Dictionary<int, tDonHangDto> donHangs;

        partial void LoadReferenceDataPartial()
        {
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
            donHangs = DataService.GetByListInt<tDonHangDto>(nameof(IDto.ID), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaDonHangNavigation = donHangs[dto.MaDonHang];
                dto.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaDonHangNavigation.MaKhoHang);
                dto.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto>.Instance.GetByID(dto.MaDonHangNavigation.MaKhachHang);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(dto.MaMatHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }

            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");
            foreach (var item in Entities)
            {
                item.MaMatHangNavigation = ReferenceDataManager<tMatHangDto>.Instance.GetByID(item.MaMatHang);
                if (item.MaMatHangNavigation == null)
                    continue;

                if (item.MaMatHangNavigation.SoKy == 0)
                {
                    sb.Append(item.MaMatHangNavigation.TenMatHang);
                    sb.Append(", ");
                }
                else
                {
                    tongSoKg += item.SoLuong * item.MaMatHangNavigation.SoKy;
                }
            }

            tongSoKg = tongSoKg / 10;

            Msg = string.Format("Tong trong luong: {0:N0} kg{1}", tongSoKg, sb.ToString(0, sb.Length - 2));
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietDonHangDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietDonHangDto dto)
        {
            if (dto.MaDonHang != 0 && dto.MaDonHangNavigation == null)
            {
                dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
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
