using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rKhachHangDataModel : BaseDataModel<rKhachHangDto>
    {
        partial void ToDtoPartial(ref rKhachHangDto dto);
        partial void FromDtoPartial(rKhachHangDto dto);

        public static int DMaDiaDiem;
        public static string DTenKhachHang;
        public static bool DKhachRieng;

        int oMaDiaDiem;
        string oTenKhachHang;
        bool oKhachRieng;

        int _MaDiaDiem = DMaDiaDiem;
        string _TenKhachHang = DTenKhachHang;
        bool _KhachRieng = DKhachRieng;

        public int MaDiaDiem { get { return _MaDiaDiem; } set { SetField(ref _MaDiaDiem, value); } }
        public string TenKhachHang { get { return _TenKhachHang; } set { SetField(ref _TenKhachHang, value); } }
        public bool KhachRieng { get { return _KhachRieng; } set { SetField(ref _KhachRieng, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaDiaDiem = MaDiaDiem;
            oTenKhachHang = TenKhachHang;
            oKhachRieng = KhachRieng;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rKhachHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaDiaDiem = dataModel.MaDiaDiem;
            TenKhachHang = dataModel.TenKhachHang;
            KhachRieng = dataModel.KhachRieng;
        }

        public override bool HasChange()
        {
            return
            (oMaDiaDiem != MaDiaDiem) ||
            (oTenKhachHang != TenKhachHang) ||
            (oKhachRieng != KhachRieng);
        }

        public override rKhachHangDto ToDto()
        {
            var dto = new rKhachHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaDiaDiem = MaDiaDiem;
            dto.TenKhachHang = TenKhachHang;
            dto.KhachRieng = KhachRieng;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rKhachHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaDiaDiem = dto.MaDiaDiem;
            TenKhachHang = dto.TenKhachHang;
            KhachRieng = dto.KhachRieng;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rDiaDiemDataModel MaDiaDiemNavigation { get; set; }

        object _MaDiaDiemDataSource;

        public object MaDiaDiemDataSource { get { return _MaDiaDiemDataSource; } set { SetField(ref _MaDiaDiemDataSource, value); } }
    }
}
