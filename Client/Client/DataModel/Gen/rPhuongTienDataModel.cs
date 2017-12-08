using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rPhuongTienDataModel : BaseDataModel<rPhuongTienDto>
    {
        partial void ToDtoPartial(ref rPhuongTienDto dto);
        partial void FromDtoPartial(rPhuongTienDto dto);

        public static string DTenPhuongTien;

        string oTenPhuongTien;

        string _TenPhuongTien = DTenPhuongTien;

        public string TenPhuongTien { get { return _TenPhuongTien; } set { SetField(ref _TenPhuongTien, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenPhuongTien = TenPhuongTien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rPhuongTienDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenPhuongTien = dataModel.TenPhuongTien;
        }

        public override bool HasChange()
        {
            return
            (oTenPhuongTien != TenPhuongTien);
        }

        public override rPhuongTienDto ToDto()
        {
            var dto = new rPhuongTienDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenPhuongTien = TenPhuongTien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rPhuongTienDto dto)
        {
            ID = dto.ID;
            TenPhuongTien = dto.TenPhuongTien;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
