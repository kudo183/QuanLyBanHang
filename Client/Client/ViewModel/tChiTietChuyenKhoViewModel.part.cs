using huypq.SmtWpfClient;
using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;
using System.Linq;

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
            chuyenKhos = DataService.GetByListInt<tChuyenKhoDto>(nameof(tChuyenKhoDto.Ma), Entities.Select(p => p.MaChuyenKho).ToList()).ToDictionary(p => p.ID);

            foreach (var dto in Entities)
            {
                dto.MaChuyenKhotChuyenKhoDto = chuyenKhos[dto.MaChuyenKho];
                dto.MaChuyenKhotChuyenKhoDto.MaKhoHangXuatrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaChuyenKhotChuyenKhoDto.MaKhoHangXuat);
                dto.MaChuyenKhotChuyenKhoDto.MaKhoHangNhaprKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(dto.MaChuyenKhotChuyenKhoDto.MaKhoHangNhap);
                dto.MaChuyenKhotChuyenKhoDto.MaNhanVienrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(dto.MaChuyenKhotChuyenKhoDto.MaNhanVien);
                dto.MaMatHangtMatHangDto = ReferenceDataManager<tMatHangDto>.Instance.GetByID(dto.MaMatHang);
                dto.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var dto = sender as tChiTietChuyenKhoDto;
            switch (e.PropertyName)
            {
                case nameof(tChiTietChuyenKhoDto.MaChuyenKho):
                    {
                        dto.MaChuyenKhotChuyenKhoDto = FindtChuyenKhoDto(dto.MaChuyenKho);
                    }
                    break;
            }
        }

        partial void ProcessNewAddedDtoPartial(tChiTietChuyenKhoDto dto)
        {
            if (dto.MaChuyenKho != 0 && dto.MaChuyenKhotChuyenKhoDto == null)
            {
                dto.MaChuyenKhotChuyenKhoDto = FindtChuyenKhoDto(dto.MaChuyenKho);
            }
            dto.PropertyChanged += Item_PropertyChanged;
        }

        private tChuyenKhoDto FindtChuyenKhoDto(int maChuyenKho)
        {
            tChuyenKhoDto ck;
            if (chuyenKhos.TryGetValue(maChuyenKho, out ck) == false)
            {
                ck = DataService.GetByID<tChuyenKhoDto>(maChuyenKho);
                ck.MaKhoHangXuatrKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ck.MaKhoHangXuat);
                ck.MaKhoHangNhaprKhoHangDto = ReferenceDataManager<rKhoHangDto>.Instance.GetByID(ck.MaKhoHangNhap);
                ck.MaNhanVienrNhanVienDto = ReferenceDataManager<rNhanVienDto>.Instance.GetByID(ck.MaNhanVien);
                chuyenKhos.Add(maChuyenKho, ck);
            }

            return ck;
        }
    }
}
