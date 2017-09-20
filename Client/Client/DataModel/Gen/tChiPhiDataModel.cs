using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiPhiDataModel : BaseDataModel<tChiPhiDto>
    {
        partial void ToDtoPartial(ref tChiPhiDto dto);
        partial void FromDtoPartial(tChiPhiDto dto);
		
        public static int DMaNhanVienGiaoHang;
        public static int DMaLoaiChiPhi;
        public static int DSoTien;
        public static System.DateTime DNgay;
        public static string DGhiChu;

        int oMaNhanVienGiaoHang;
        int oMaLoaiChiPhi;
        int oSoTien;
        System.DateTime oNgay;
        string oGhiChu;

        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        int _MaLoaiChiPhi = DMaLoaiChiPhi;
        int _SoTien = DSoTien;
        System.DateTime _Ngay = DNgay;
        string _GhiChu = DGhiChu;

        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        public int MaLoaiChiPhi { get { return _MaLoaiChiPhi; } set { _MaLoaiChiPhi = value; OnPropertyChanged(); } }
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oMaLoaiChiPhi = MaLoaiChiPhi;
            oSoTien = SoTien;
            oNgay = Ngay;
            oGhiChu = GhiChu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiPhiDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVienGiaoHang = dataModel.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dataModel.MaLoaiChiPhi;
            SoTien = dataModel.SoTien;
            Ngay = dataModel.Ngay;
            GhiChu = dataModel.GhiChu;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang) ||
            (oMaLoaiChiPhi != MaLoaiChiPhi) ||
            (oSoTien != SoTien) ||
            (oNgay != Ngay) ||
            (oGhiChu != GhiChu) ;
        }

        public override tChiPhiDto ToDto()
        {
            var dto = new tChiPhiDto();
            dto.ID = ID;
            dto.MaNhanVienGiaoHang = MaNhanVienGiaoHang;
            dto.MaLoaiChiPhi = MaLoaiChiPhi;
            dto.SoTien = SoTien;
            dto.Ngay = Ngay;
            dto.GhiChu = GhiChu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiPhiDto dto)
        {
            ID = dto.ID;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dto.MaLoaiChiPhi;
            SoTien = dto.SoTien;
            Ngay = dto.Ngay;
            GhiChu = dto.GhiChu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rNhanVienDataModel MaNhanVienGiaoHangNavigation { get; set; }
        public rLoaiChiPhiDataModel MaLoaiChiPhiNavigation { get; set; }

        object _MaNhanVienGiaoHangDataSource;
        object _MaLoaiChiPhiDataSource;

        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { _MaNhanVienGiaoHangDataSource = value; OnPropertyChanged(); } }
        public object MaLoaiChiPhiDataSource { get { return _MaLoaiChiPhiDataSource; } set { _MaLoaiChiPhiDataSource = value; OnPropertyChanged(); } }
    }
}
