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
    public partial class tChiTietChuyenKhoViewModel : BaseViewModel<tChiTietChuyenKhoDto, tChiTietChuyenKhoDataModel>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.LoadOrUpdate();
            ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate();
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
                dto.MaChuyenKhoNavigation.MaKhoHangXuatNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaKhoHangXuat);
                dto.MaChuyenKhoNavigation.MaKhoHangNhapNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaKhoHangNhap);
                dto.MaChuyenKhoNavigation.MaNhanVienNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(dto.MaChuyenKhoNavigation.MaNhanVien);
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
            var dto = sender as tChiTietChuyenKhoDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChiTietChuyenKhoDataModel.MaChuyenKho):
                    {
                        dto.MaChuyenKhoNavigation = FindtChuyenKhoDataModel(dto.MaChuyenKho);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDataModelPartial(tChiTietChuyenKhoDataModel dto)
        {
            if (dto.MaChuyenKho != 0 && dto.MaChuyenKhoNavigation == null)
            {
                dto.MaChuyenKhoNavigation = FindtChuyenKhoDataModel(dto.MaChuyenKho);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenKhoDataModel FindtChuyenKhoDataModel(int maChuyenKho)
        {
            tChuyenKhoDataModel ck;
            if (_MaChuyenKhos.TryGetValue(maChuyenKho, out ck) == false)
            {
                ck = DataService.GetByID<tChuyenKhoDto, tChuyenKhoDataModel>(maChuyenKho);
                ck.MaKhoHangXuatNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ck.MaKhoHangXuat);
                ck.MaKhoHangNhapNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(ck.MaKhoHangNhap);
                ck.MaNhanVienNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(ck.MaNhanVien);
                _MaChuyenKhos.Add(maChuyenKho, ck);
            }

            return ck;
        }
    }
}
