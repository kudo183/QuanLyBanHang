using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tPhuThuKhachHangDataModel : BaseDataModel<tPhuThuKhachHangDto>
    {
        partial void ToDtoPartial(ref tPhuThuKhachHangDto dto);
        partial void FromDtoPartial(tPhuThuKhachHangDto dto);
		
        public static int DMaKhachHang;
        public static System.DateTime DNgay;
        public static int DSoTien;
        public static string DGhiChu;

        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;
        string oGhiChu;

        int _MaKhachHang = DMaKhachHang;
        System.DateTime _Ngay = DNgay;
        int _SoTien = DSoTien;
        string _GhiChu = DGhiChu;

        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
            oGhiChu = GhiChu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tPhuThuKhachHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            Ngay = dataModel.Ngay;
            SoTien = dataModel.SoTien;
            GhiChu = dataModel.GhiChu;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oNgay != Ngay) ||
            (oSoTien != SoTien) ||
            (oGhiChu != GhiChu) ;
        }

        public override tPhuThuKhachHangDto ToDto()
        {
            var dto = new tPhuThuKhachHangDto();
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.Ngay = Ngay;
            dto.SoTien = SoTien;
            dto.GhiChu = GhiChu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tPhuThuKhachHangDto dto)
        {
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            Ngay = dto.Ngay;
            SoTien = dto.SoTien;
            GhiChu = dto.GhiChu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rKhachHangDataModel MaKhachHangNavigation { get; set; }

        object _MaKhachHangDataSource;

        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { _MaKhachHangDataSource = value; OnPropertyChanged(); } }
    }
}
