using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChuyenHangDataModel : BaseDataModel<tChuyenHangDto>
    {
        partial void ToDtoPartial(ref tChuyenHangDto dto);
        partial void FromDtoPartial(tChuyenHangDto dto);
		
        public static int DMaNhanVienGiaoHang;
        public static System.DateTime DNgay;
        public static System.TimeSpan? DGio;
        public static int DTongDonHang;
        public static int DTongSoLuongTheoDonHang;
        public static int DTongSoLuongThucTe;

        int oMaNhanVienGiaoHang;
        System.DateTime oNgay;
        System.TimeSpan? oGio;
        int oTongDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;

        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        System.DateTime _Ngay = DNgay;
        System.TimeSpan? _Gio = DGio;
        int _TongDonHang = DTongDonHang;
        int _TongSoLuongTheoDonHang = DTongSoLuongTheoDonHang;
        int _TongSoLuongThucTe = DTongSoLuongThucTe;

        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public System.TimeSpan? Gio { get { return _Gio; } set { _Gio = value; OnPropertyChanged(); } }
        public int TongDonHang { get { return _TongDonHang; } set { _TongDonHang = value; OnPropertyChanged(); } }
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oNgay = Ngay;
            oGio = Gio;
            oTongDonHang = TongDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChuyenHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVienGiaoHang = dataModel.MaNhanVienGiaoHang;
            Ngay = dataModel.Ngay;
            Gio = dataModel.Gio;
            TongDonHang = dataModel.TongDonHang;
            TongSoLuongTheoDonHang = dataModel.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dataModel.TongSoLuongThucTe;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang) ||
            (oNgay != Ngay) ||
            (oGio != Gio) ||
            (oTongDonHang != TongDonHang) ||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang) ||
            (oTongSoLuongThucTe != TongSoLuongThucTe) ;
        }

        public override tChuyenHangDto ToDto()
        {
            var dto = new tChuyenHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhanVienGiaoHang = MaNhanVienGiaoHang;
            dto.Ngay = Ngay;
            dto.Gio = Gio;
            dto.TongDonHang = TongDonHang;
            dto.TongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            dto.TongSoLuongThucTe = TongSoLuongThucTe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChuyenHangDto dto)
        {
            ID = dto.ID;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            Ngay = dto.Ngay;
            Gio = dto.Gio;
            TongDonHang = dto.TongDonHang;
            TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dto.TongSoLuongThucTe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rNhanVienDataModel MaNhanVienGiaoHangNavigation { get; set; }

        object _MaNhanVienGiaoHangDataSource;

        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { _MaNhanVienGiaoHangDataSource = value; OnPropertyChanged(); } }
    }
}
