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
    public partial class tChiTietNhapHangViewModel : BaseViewModel<tChiTietNhapHangDto, tChiTietNhapHangDataModel>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.LoadOrUpdate();
        }

        protected override void BeforeLoad()
        {
            foreach (var dto in Entities)
            {
                dto.PropertyChanged -= Item_PropertyChanged;
            }
        }

        partial void AfterLoadPartial()
        {
            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");

            foreach (var dto in Entities)
            {
                dto.MaNhapHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaNhapHangNavigation.MaKhoHang);
                dto.MaNhapHangNavigation.MaNhaCungCapNavigation = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.GetByID(dto.MaNhapHangNavigation.MaNhaCungCap);
                dto.MaMatHangNavigation = ReferenceDataManager<tMatHangDto, tMatHangDataModel>.Instance.GetByID(dto.MaMatHang);

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
            var dto = sender as tChiTietNhapHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietNhapHangDataModel.MaNhapHang):
                    {
                        dto.MaNhapHangNavigation = FindtNhapHangDataModel(dto.MaNhapHang);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietNhapHangDataModel dto)
        {
            if (dto.MaNhapHang != 0 && dto.MaNhapHangNavigation == null)
            {
                dto.MaNhapHangNavigation = FindtNhapHangDataModel(dto.MaNhapHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tNhapHangDataModel FindtNhapHangDataModel(int maNhapHang)
        {
            tNhapHangDataModel nh;
            if (_MaNhapHangs.TryGetValue(maNhapHang, out nh) == false)
            {
                nh = DataService.GetByID<tNhapHangDto, tNhapHangDataModel>(maNhapHang);
                nh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(nh.MaKhoHang);
                nh.MaNhaCungCapNavigation = ReferenceDataManager<rNhaCungCapDto, rNhaCungCapDataModel>.Instance.GetByID(nh.MaNhaCungCap);
                _MaNhapHangs.Add(maNhapHang, nh);
            }

            return nh;
        }
    }
}
