using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiTietChuyenKhoDataModel : BaseDataModel<tChiTietChuyenKhoDto>
    {
        partial void ToDtoPartial(ref tChiTietChuyenKhoDto dto);
        partial void FromDtoPartial(tChiTietChuyenKhoDto dto);
		
        public static int DMaChuyenKho;
        public static int DMaMatHang;
        public static int DSoLuong;

        int oMaChuyenKho;
        int oMaMatHang;
        int oSoLuong;

        int _MaChuyenKho = DMaChuyenKho;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;

        public int MaChuyenKho { get { return _MaChuyenKho; } set { _MaChuyenKho = value; OnPropertyChanged(); } }
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenKho = MaChuyenKho;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietChuyenKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenKho = dataModel.MaChuyenKho;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenKho != MaChuyenKho) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong) ;
        }

        public override tChiTietChuyenKhoDto ToDto()
        {
            var dto = new tChiTietChuyenKhoDto();
            dto.ID = ID;
            dto.MaChuyenKho = MaChuyenKho;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietChuyenKhoDto dto)
        {
            ID = dto.ID;
            MaChuyenKho = dto.MaChuyenKho;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tChuyenKhoDataModel MaChuyenKhoNavigation { get; set; }
        public tMatHangDataModel MaMatHangNavigation { get; set; }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
    }
}
