using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChuyenHangDonHangDataModel : BaseDataModel<tChuyenHangDonHangDto>
    {
        partial void ToDtoPartial(ref tChuyenHangDonHangDto dto);
        partial void FromDtoPartial(tChuyenHangDonHangDto dto);
		
        public static int DMaChuyenHang;
        public static int DMaDonHang;
        public static int DTongSoLuongTheoDonHang;
        public static int DTongSoLuongThucTe;

        int oMaChuyenHang;
        int oMaDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        int _MaChuyenHang = DMaChuyenHang;
        int _MaDonHang = DMaDonHang;
        int _TongSoLuongTheoDonHang = DTongSoLuongTheoDonHang;
        int _TongSoLuongThucTe = DTongSoLuongThucTe;

        public int MaChuyenHang { get { return _MaChuyenHang; } set { _MaChuyenHang = value; OnPropertyChanged(); } }
        public int MaDonHang { get { return _MaDonHang; } set { _MaDonHang = value; OnPropertyChanged(); } }
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenHang = MaChuyenHang;
            oMaDonHang = MaDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChuyenHangDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenHang = dataModel.MaChuyenHang;
            MaDonHang = dataModel.MaDonHang;
            TongSoLuongTheoDonHang = dataModel.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dataModel.TongSoLuongThucTe;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenHang != MaChuyenHang) ||
            (oMaDonHang != MaDonHang) ||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang) ||
            (oTongSoLuongThucTe != TongSoLuongThucTe) ;
        }

        public override tChuyenHangDonHangDto ToDto()
        {
            var dto = new tChuyenHangDonHangDto();
            dto.ID = ID;
            dto.MaChuyenHang = MaChuyenHang;
            dto.MaDonHang = MaDonHang;
            dto.TongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = TongSoLuongThucTe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChuyenHangDonHangDto dto)
        {
            ID = dto.ID;
            MaChuyenHang = dto.MaChuyenHang;
            MaDonHang = dto.MaDonHang;
            TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dto.TongSoLuongThucTe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tChuyenHangDataModel MaChuyenHangNavigation { get; set; }
        public tDonHangDataModel MaDonHangNavigation { get; set; }


    }
}
