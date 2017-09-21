using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rCanhBaoTonKhoDataModel : BaseDataModel<rCanhBaoTonKhoDto>
    {
        partial void ToDtoPartial(ref rCanhBaoTonKhoDto dto);
        partial void FromDtoPartial(rCanhBaoTonKhoDto dto);
		
        public static int DMaMatHang;
        public static int DMaKhoHang;
        public static int DTonCaoNhat;
        public static int DTonThapNhat;

        int oMaMatHang;
        int oMaKhoHang;
        int oTonCaoNhat;
        int oTonThapNhat;

        int _MaMatHang = DMaMatHang;
        int _MaKhoHang = DMaKhoHang;
        int _TonCaoNhat = DTonCaoNhat;
        int _TonThapNhat = DTonThapNhat;

        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        public int TonCaoNhat { get { return _TonCaoNhat; } set { _TonCaoNhat = value; OnPropertyChanged(); } }
        public int TonThapNhat { get { return _TonThapNhat; } set { _TonThapNhat = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaMatHang = MaMatHang;
            oMaKhoHang = MaKhoHang;
            oTonCaoNhat = TonCaoNhat;
            oTonThapNhat = TonThapNhat;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rCanhBaoTonKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaMatHang = dataModel.MaMatHang;
            MaKhoHang = dataModel.MaKhoHang;
            TonCaoNhat = dataModel.TonCaoNhat;
            TonThapNhat = dataModel.TonThapNhat;
        }

        public override bool HasChange()
        {
            return
            (oMaMatHang != MaMatHang) ||
            (oMaKhoHang != MaKhoHang) ||
            (oTonCaoNhat != TonCaoNhat) ||
            (oTonThapNhat != TonThapNhat) ;
        }

        public override rCanhBaoTonKhoDto ToDto()
        {
            var dto = new rCanhBaoTonKhoDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaMatHang = MaMatHang;
            dto.MaKhoHang = MaKhoHang;
            dto.TonCaoNhat = TonCaoNhat;
            dto.TonThapNhat = TonThapNhat;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rCanhBaoTonKhoDto dto)
        {
            ID = dto.ID;
            MaMatHang = dto.MaMatHang;
            MaKhoHang = dto.MaKhoHang;
            TonCaoNhat = dto.TonCaoNhat;
            TonThapNhat = dto.TonThapNhat;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tMatHangDataModel MaMatHangNavigation { get; set; }
        public rKhoHangDataModel MaKhoHangNavigation { get; set; }

        object _MaMatHangDataSource;
        object _MaKhoHangDataSource;

        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }
    }
}
