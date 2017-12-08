using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiTietNhapHangDataModel : BaseDataModel<tChiTietNhapHangDto>
    {
        partial void ToDtoPartial(ref tChiTietNhapHangDto dto);
        partial void FromDtoPartial(tChiTietNhapHangDto dto);

        public static int DMaNhapHang;
        public static int DMaMatHang;
        public static int DSoLuong;

        int oMaNhapHang;
        int oMaMatHang;
        int oSoLuong;

        int _MaNhapHang = DMaNhapHang;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;

        public int MaNhapHang { get { return _MaNhapHang; } set { SetField(ref _MaNhapHang, value); } }
        public int MaMatHang { get { return _MaMatHang; } set { SetField(ref _MaMatHang, value); } }
        public int SoLuong { get { return _SoLuong; } set { SetField(ref _SoLuong, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhapHang = MaNhapHang;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietNhapHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhapHang = dataModel.MaNhapHang;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
        }

        public override bool HasChange()
        {
            return
            (oMaNhapHang != MaNhapHang) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong);
        }

        public override tChiTietNhapHangDto ToDto()
        {
            var dto = new tChiTietNhapHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhapHang = MaNhapHang;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietNhapHangDto dto)
        {
            ID = dto.ID;
            MaNhapHang = dto.MaNhapHang;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tNhapHangDataModel MaNhapHangNavigation { get; set; }
        public tMatHangDataModel MaMatHangNavigation { get; set; }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { SetField(ref _MaMatHangDataSource, value); } }
    }
}
