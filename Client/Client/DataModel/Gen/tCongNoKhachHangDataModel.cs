using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tCongNoKhachHangDataModel : BaseDataModel<tCongNoKhachHangDto>
    {
        partial void ToDtoPartial(ref tCongNoKhachHangDto dto);
        partial void FromDtoPartial(tCongNoKhachHangDto dto);
		
        public static int DMaKhachHang;
        public static System.DateTime DNgay;
        public static int DSoTien;

        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;

        int _MaKhachHang = DMaKhachHang;
        System.DateTime _Ngay = DNgay;
        int _SoTien = DSoTien;

        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tCongNoKhachHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhachHang = dataModel.MaKhachHang;
            Ngay = dataModel.Ngay;
            SoTien = dataModel.SoTien;
        }

        public override bool HasChange()
        {
            return
            (oMaKhachHang != MaKhachHang) ||
            (oNgay != Ngay) ||
            (oSoTien != SoTien) ;
        }

        public override tCongNoKhachHangDto ToDto()
        {
            var dto = new tCongNoKhachHangDto();
            dto.ID = ID;
            dto.MaKhachHang = MaKhachHang;
            dto.Ngay = Ngay;
            dto.SoTien = SoTien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tCongNoKhachHangDto dto)
        {
            ID = dto.ID;
            MaKhachHang = dto.MaKhachHang;
            Ngay = dto.Ngay;
            SoTien = dto.SoTien;
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
