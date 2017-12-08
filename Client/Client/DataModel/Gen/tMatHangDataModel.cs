using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tMatHangDataModel : BaseDataModel<tMatHangDto>
    {
        partial void ToDtoPartial(ref tMatHangDto dto);
        partial void FromDtoPartial(tMatHangDto dto);

        public static int DMaLoai;
        public static string DTenMatHang;
        public static int DSoKy;
        public static int DSoMet;
        public static string DTenMatHangDayDu;
        public static string DTenMatHangIn;
        public static int DMaHinhAnh;

        int oMaLoai;
        string oTenMatHang;
        int oSoKy;
        int oSoMet;
        string oTenMatHangDayDu;
        string oTenMatHangIn;
        int oMaHinhAnh;

        int _MaLoai = DMaLoai;
        string _TenMatHang = DTenMatHang;
        int _SoKy = DSoKy;
        int _SoMet = DSoMet;
        string _TenMatHangDayDu = DTenMatHangDayDu;
        string _TenMatHangIn = DTenMatHangIn;
        int _MaHinhAnh = DMaHinhAnh;

        public int MaLoai { get { return _MaLoai; } set { SetField(ref _MaLoai, value); } }
        public string TenMatHang { get { return _TenMatHang; } set { SetField(ref _TenMatHang, value); } }
        public int SoKy { get { return _SoKy; } set { SetField(ref _SoKy, value); } }
        public int SoMet { get { return _SoMet; } set { SetField(ref _SoMet, value); } }
        public string TenMatHangDayDu { get { return _TenMatHangDayDu; } set { SetField(ref _TenMatHangDayDu, value); } }
        public string TenMatHangIn { get { return _TenMatHangIn; } set { SetField(ref _TenMatHangIn, value); } }
        public int MaHinhAnh { get { return _MaHinhAnh; } set { SetField(ref _MaHinhAnh, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaLoai = MaLoai;
            oTenMatHang = TenMatHang;
            oSoKy = SoKy;
            oSoMet = SoMet;
            oTenMatHangDayDu = TenMatHangDayDu;
            oTenMatHangIn = TenMatHangIn;
            oMaHinhAnh = MaHinhAnh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tMatHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaLoai = dataModel.MaLoai;
            TenMatHang = dataModel.TenMatHang;
            SoKy = dataModel.SoKy;
            SoMet = dataModel.SoMet;
            TenMatHangDayDu = dataModel.TenMatHangDayDu;
            TenMatHangIn = dataModel.TenMatHangIn;
            MaHinhAnh = dataModel.MaHinhAnh;
        }

        public override bool HasChange()
        {
            return
            (oMaLoai != MaLoai) ||
            (oTenMatHang != TenMatHang) ||
            (oSoKy != SoKy) ||
            (oSoMet != SoMet) ||
            (oTenMatHangDayDu != TenMatHangDayDu) ||
            (oTenMatHangIn != TenMatHangIn) ||
            (oMaHinhAnh != MaHinhAnh);
        }

        public override tMatHangDto ToDto()
        {
            var dto = new tMatHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaLoai = MaLoai;
            dto.TenMatHang = TenMatHang;
            dto.SoKy = SoKy;
            dto.SoMet = SoMet;
            dto.TenMatHangDayDu = TenMatHangDayDu;
            dto.TenMatHangIn = TenMatHangIn;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;
            dto.MaHinhAnh = MaHinhAnh;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tMatHangDto dto)
        {
            ID = dto.ID;
            MaLoai = dto.MaLoai;
            TenMatHang = dto.TenMatHang;
            SoKy = dto.SoKy;
            SoMet = dto.SoMet;
            TenMatHangDayDu = dto.TenMatHangDayDu;
            TenMatHangIn = dto.TenMatHangIn;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
            MaHinhAnh = dto.MaHinhAnh;

            FromDtoPartial(dto);
        }

        public rLoaiHangDataModel MaLoaiNavigation { get; set; }

        object _MaLoaiDataSource;

        public object MaLoaiDataSource { get { return _MaLoaiDataSource; } set { SetField(ref _MaLoaiDataSource, value); } }
    }
}
