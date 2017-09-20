using Client.DataModel;
using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ViewModel
{
    public partial class tChiTietDonHangViewModel : BaseViewModel<tChiTietDonHangDto, tChiTietDonHangDataModel>
    {
        Dictionary<int, tDonHangDataModel> donHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.LoadOrUpdate();
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
            donHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaDonHangNavigation = donHangs[dto.MaDonHang];
                dto.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhoHang);
                dto.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhachHang);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(dto.MaMatHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }

            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");
            foreach (var item in Entities)
            {
                item.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(item.MaMatHang);
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
            var dto = sender as tChiTietDonHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietDonHangDto.MaDonHang):
                    {
                        dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietDonHangDataModel dto)
        {
            if (dto.MaDonHang != 0 && dto.MaDonHangNavigation == null)
            {
                dto.MaDonHangNavigation = FindtDonHangDto(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tDonHangDataModel FindtDonHangDto(int maDonHang)
        {
            tDonHangDataModel dh;
            if (donHangs.TryGetValue(maDonHang, out dh) == false)
            {
                dh = DataService.GetByID<tDonHangDto,tDonHangDataModel >(maDonHang);
                dh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
