using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rDiaDiemDataModel : BaseDataModel<rDiaDiemDto>
    {
        partial void ToDtoPartial(ref rDiaDiemDto dto);
        partial void FromDtoPartial(rDiaDiemDto dto);

        public static int DMaNuoc;
        public static string DTinh;

        int oMaNuoc;
        string oTinh;

        int _MaNuoc = DMaNuoc;
        string _Tinh = DTinh;

        public int MaNuoc { get { return _MaNuoc; } set { SetField(ref _MaNuoc, value); } }
        public string Tinh { get { return _Tinh; } set { SetField(ref _Tinh, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNuoc = MaNuoc;
            oTinh = Tinh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rDiaDiemDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNuoc = dataModel.MaNuoc;
            Tinh = dataModel.Tinh;
        }

        public override bool HasChange()
        {
            return
            (oMaNuoc != MaNuoc) ||
            (oTinh != Tinh);
        }

        public override rDiaDiemDto ToDto()
        {
            var dto = new rDiaDiemDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNuoc = MaNuoc;
            dto.Tinh = Tinh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rDiaDiemDto dto)
        {
            ID = dto.ID;
            MaNuoc = dto.MaNuoc;
            Tinh = dto.Tinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rNuocDataModel MaNuocNavigation { get; set; }

        object _MaNuocDataSource;

        public object MaNuocDataSource { get { return _MaNuocDataSource; } set { SetField(ref _MaNuocDataSource, value); } }
    }
}
