using Client.DataModel;
using huypq.SmtShared;
using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModel
{
    public partial class tChuyenHangDonHangViewModel : BaseViewModel<tChuyenHangDonHangDto, tChuyenHangDonHangDataModel>
    {
        Dictionary<int, tChuyenHangDataModel> chuyenHangs;
        Dictionary<int, tDonHangDataModel> donHangs;

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.LoadOrUpdate();
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
            chuyenHangs = DataService.GetByListInt<tChuyenHangDto, tChuyenHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaChuyenHang).ToList()).ToDictionary(p => p.ID);
            donHangs = DataService.GetByListInt<tDonHangDto, tDonHangDataModel>(nameof(IDto.ID), Entities.Select(p => p.MaDonHang).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaChuyenHangNavigation = chuyenHangs[dto.MaChuyenHang];
                dto.MaChuyenHangNavigation.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(dto.MaChuyenHangNavigation.MaNhanVienGiaoHang);
                dto.MaDonHangNavigation = donHangs[dto.MaDonHang];
                dto.MaDonHangNavigation.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhoHang);
                dto.MaDonHangNavigation.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dto.MaDonHangNavigation.MaKhachHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChuyenHangDonHangDataModel;
            switch (e.PropertyName)
            {
                case nameof(tChuyenHangDonHangDataModel.MaChuyenHang):
                    {
                        dto.MaChuyenHangNavigation = FindtChuyenHangDataModel(dto.MaChuyenHang);
                    }
                    break;
                case nameof(tChuyenHangDonHangDataModel.MaDonHang):
                    {
                        dto.MaDonHangNavigation = FindtDonHangDataModel(dto.MaDonHang);
                    }
                    break;
            }
        }
        
        partial void ProcessNewAddedDataModelPartial(tChuyenHangDonHangDataModel dto)
        {
            if (dto.MaChuyenHang != 0 && dto.MaChuyenHangNavigation == null)
            {
                dto.MaChuyenHangNavigation = FindtChuyenHangDataModel(dto.MaChuyenHang);
            }
            if (dto.MaDonHang != 0 && dto.MaDonHangNavigation == null)
            {
                dto.MaDonHangNavigation = FindtDonHangDataModel(dto.MaDonHang);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenHangDataModel FindtChuyenHangDataModel(int maChuyenHang)
        {
            tChuyenHangDataModel ch;
            if (chuyenHangs.TryGetValue(maChuyenHang, out ch) == false)
            {
                ch = DataService.GetByID<tChuyenHangDto, tChuyenHangDataModel>(maChuyenHang);
                ch.MaNhanVienGiaoHangNavigation = ReferenceDataManager<rNhanVienDto, rNhanVienDataModel>.Instance.GetByID(ch.MaNhanVienGiaoHang);
                chuyenHangs.Add(maChuyenHang, ch);
            }

            return ch;
        }

        private tDonHangDataModel FindtDonHangDataModel(int maDonHang)
        {
            tDonHangDataModel dh;
            if (donHangs.TryGetValue(maDonHang, out dh) == false)
            {
                dh = DataService.GetByID<tDonHangDto, tDonHangDataModel>(maDonHang);
                dh.MaKhoHangNavigation = ReferenceDataManager<rKhoHangDto, rKhoHangDataModel>.Instance.GetByID(dh.MaKhoHang);
                dh.MaKhachHangNavigation = ReferenceDataManager<rKhachHangDto, rKhachHangDataModel>.Instance.GetByID(dh.MaKhachHang);
                donHangs.Add(maDonHang, dh);
            }

            return dh;
        }
    }
}
