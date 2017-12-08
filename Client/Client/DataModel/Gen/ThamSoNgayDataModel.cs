using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class ThamSoNgayDataModel : BaseDataModel<ThamSoNgayDto>
    {
        partial void ToDtoPartial(ref ThamSoNgayDto dto);
        partial void FromDtoPartial(ThamSoNgayDto dto);

        public static string DTen;
        public static System.DateTime DGiaTri;

        string oTen;
        System.DateTime oGiaTri;

        string _Ten = DTen;
        System.DateTime _GiaTri = DGiaTri;

        public string Ten { get { return _Ten; } set { SetField(ref _Ten, value); } }
        public System.DateTime GiaTri { get { return _GiaTri; } set { SetField(ref _GiaTri, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTen = Ten;
            oGiaTri = GiaTri;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as ThamSoNgayDataModel;
            if (dataModel == null)
            {
                return;
            }

            Ten = dataModel.Ten;
            GiaTri = dataModel.GiaTri;
        }

        public override bool HasChange()
        {
            return
            (oTen != Ten) ||
            (oGiaTri != GiaTri);
        }

        public override ThamSoNgayDto ToDto()
        {
            var dto = new ThamSoNgayDto();
            dto.State = State;
            dto.ID = ID;
            dto.Ten = Ten;
            dto.GiaTri = GiaTri;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(ThamSoNgayDto dto)
        {
            ID = dto.ID;
            Ten = dto.Ten;
            GiaTri = dto.GiaTri;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
