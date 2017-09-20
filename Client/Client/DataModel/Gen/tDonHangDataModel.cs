using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tDonHangDataModel : BaseDataModel<tDonHangDto>
    {
        partial void ToDtoPartial(ref tDonHangDto dto);
        partial void FromDtoPartial(tDonHangDto dto);
		
        public static int DMaKhachHang;
        public static int? DMaChanh;
        public static System.DateTime DNgay;
        public static bool DXong;
        public static int DMaKhoHang;
        public static int DTongSoLuong;

        int oMaKhachHang;
        int? oMaChanh;
        System.DateTime oNgay;
        bool oXong;
        int oMaKhoHang;
        int oTongSoLuong;

        int _MaKhachHang = DMaKhachHang;
        int? _MaChanh = DMaChanh;
        System.DateTime _Ngay = DNgay;
        bool _Xong = DXong;
        int _MaKhoHang = DMaKhoHang;
        int _TongSoLuong = DTongSoLuong;

        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        public int? MaChanh { get { return _MaChanh; } set { _MaChanh = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public bool Xong { get { return _Xong; } set { _Xong = value; OnPropertyChanged(); } }
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        public int TongSoLuong { get { return _TongSoLuong; } set { _TongSoLuong = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oMaChanh = MaChanh;
            oNgay = Ngay;
            oXong = Xong;
            oMaKhoHang = MaKhoHang;
            oTongSoLuong = TongSoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            MaChanh = dataModel.MaChanh;
            Ngay = dataModel.Ngay;
            Xong = dataModel.Xong;
            MaKhoHang = dataModel.MaKhoHang;
            TongSoLuong = dataModel.TongSoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oMaChanh != MaChanh) ||
            (oNgay != Ngay) ||
            (oXong != Xong) ||
            (oMaKhoHang != MaKhoHang) ||
            (oTongSoLuong != TongSoLuong) ;
        }

        public override tDonHangDto ToDto()
        {
            var dto = new tDonHangDto();
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.MaChanh = MaChanh;
            dto.Ngay = Ngay;
            dto.Xong = Xong;
            dto.MaKhoHang = MaKhoHang;
            dto.TongSoLuong = TongSoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tDonHangDto dto)
        {
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            MaChanh = dto.MaChanh;
            Ngay = dto.Ngay;
            Xong = dto.Xong;
            MaKhoHang = dto.MaKhoHang;
            TongSoLuong = dto.TongSoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rKhachHangDataModel MaKhachHangNavigation { get; set; }
        public rChanhDataModel MaChanhNavigation { get; set; }
        public rKhoHangDataModel MaKhoHangNavigation { get; set; }

        object _MaKhachHangDataSource;
        object _MaChanhDataSource;
        object _MaKhoHangDataSource;

        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { _MaKhachHangDataSource = value; OnPropertyChanged(); } }
        public object MaChanhDataSource { get { return _MaChanhDataSource; } set { _MaChanhDataSource = value; OnPropertyChanged(); } }
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }
    }
}
