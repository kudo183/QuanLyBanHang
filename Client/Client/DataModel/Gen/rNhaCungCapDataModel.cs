using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rNhaCungCapDataModel : BaseDataModel<rNhaCungCapDto>
    {
        partial void ToDtoPartial(ref rNhaCungCapDto dto);
        partial void FromDtoPartial(rNhaCungCapDto dto);

        public static string DTenNhaCungCap;

        string oTenNhaCungCap;

        string _TenNhaCungCap = DTenNhaCungCap;

        public string TenNhaCungCap { get { return _TenNhaCungCap; } set { SetField(ref _TenNhaCungCap, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenNhaCungCap = TenNhaCungCap;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNhaCungCapDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenNhaCungCap = dataModel.TenNhaCungCap;
        }

        public override bool HasChange()
        {
            return
            (oTenNhaCungCap != TenNhaCungCap);
        }

        public override rNhaCungCapDto ToDto()
        {
            var dto = new rNhaCungCapDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenNhaCungCap = TenNhaCungCap;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNhaCungCapDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenNhaCungCap = dto.TenNhaCungCap;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
