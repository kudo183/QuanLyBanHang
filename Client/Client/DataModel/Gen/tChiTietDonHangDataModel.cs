using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiTietDonHangDataModel : BaseDataModel<tChiTietDonHangDto>
    {
        partial void ToDtoPartial(ref tChiTietDonHangDto dto);
        partial void FromDtoPartial(tChiTietDonHangDto dto);
		
        public static int DMaDonHang;
        public static int DMaMatHang;
        public static int DSoLuong;
        public static bool DXong;

        int oMaDonHang;
        int oMaMatHang;
        int oSoLuong;
        bool oXong;

        int _MaDonHang = DMaDonHang;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;
        bool _Xong = DXong;

        public int MaDonHang { get { return _MaDonHang; } set { _MaDonHang = value; OnPropertyChanged(); } }
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        public bool Xong { get { return _Xong; } set { _Xong = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaDonHang = MaDonHang;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
            oXong = Xong;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaDonHang = dataModel.MaDonHang;
            MaMatHang = dataModel.MaMatHang;
            SoLuong = dataModel.SoLuong;
            Xong = dataModel.Xong;
        }

        public override bool HasChange()
        {
            return
            (oMaDonHang != MaDonHang) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong) ||
            (oXong != Xong) ;
        }

        public override tChiTietDonHangDto ToDto()
        {
            var dto = new tChiTietDonHangDto();
            dto.ID = ID;
            dto.MaDonHang = MaDonHang;
            dto.MaMatHang = MaMatHang;
            dto.SoLuong = SoLuong;
            dto.Xong = Xong;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietDonHangDto dto)
        {
            ID = dto.ID;
            MaDonHang = dto.MaDonHang;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
            Xong = dto.Xong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tDonHangDataModel MaDonHangNavigation { get; set; }
        public tMatHangDataModel MaMatHangNavigation { get; set; }

        object _MaMatHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
    }
}
