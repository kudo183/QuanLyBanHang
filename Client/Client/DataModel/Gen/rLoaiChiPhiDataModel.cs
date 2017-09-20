using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rLoaiChiPhiDataModel : BaseDataModel<rLoaiChiPhiDto>
    {
        partial void ToDtoPartial(ref rLoaiChiPhiDto dto);
        partial void FromDtoPartial(rLoaiChiPhiDto dto);
		
        public static string DTenLoaiChiPhi;

        string oTenLoaiChiPhi;

        string _TenLoaiChiPhi = DTenLoaiChiPhi;

        public string TenLoaiChiPhi { get { return _TenLoaiChiPhi; } set { _TenLoaiChiPhi = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenLoaiChiPhi = TenLoaiChiPhi;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rLoaiChiPhiDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenLoaiChiPhi = dataModel.TenLoaiChiPhi;
        }

        public override bool HasChange()
        {
            return
            (oTenLoaiChiPhi != TenLoaiChiPhi) ;
        }

        public override rLoaiChiPhiDto ToDto()
        {
            var dto = new rLoaiChiPhiDto();
            dto.ID = ID;
            dto.TenLoaiChiPhi = TenLoaiChiPhi;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rLoaiChiPhiDto dto)
        {
            ID = dto.ID;
            TenLoaiChiPhi = dto.TenLoaiChiPhi;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
