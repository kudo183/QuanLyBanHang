using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rNuocDataModel : BaseDataModel<rNuocDto>
    {
        partial void ToDtoPartial(ref rNuocDto dto);
        partial void FromDtoPartial(rNuocDto dto);
		
        public static string DTenNuoc;

        string oTenNuoc;

        string _TenNuoc = DTenNuoc;

        public string TenNuoc { get { return _TenNuoc; } set { _TenNuoc = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenNuoc = TenNuoc;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNuocDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenNuoc = dataModel.TenNuoc;
        }

        public override bool HasChange()
        {
            return
            (oTenNuoc != TenNuoc) ;
        }

        public override rNuocDto ToDto()
        {
            var dto = new rNuocDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenNuoc = TenNuoc;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNuocDto dto)
        {
            ID = dto.ID;
            TenNuoc = dto.TenNuoc;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
