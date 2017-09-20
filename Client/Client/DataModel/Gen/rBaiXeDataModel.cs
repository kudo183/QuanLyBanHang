using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rBaiXeDataModel : BaseDataModel<rBaiXeDto>
    {
        partial void ToDtoPartial(ref rBaiXeDto dto);
        partial void FromDtoPartial(rBaiXeDto dto);
		
        public static string DDiaDiemBaiXe;

        string oDiaDiemBaiXe;

        string _DiaDiemBaiXe = DDiaDiemBaiXe;

        public string DiaDiemBaiXe { get { return _DiaDiemBaiXe; } set { _DiaDiemBaiXe = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oDiaDiemBaiXe = DiaDiemBaiXe;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rBaiXeDataModel;
            if (dataModel == null)
            {
                return;
            }

            DiaDiemBaiXe = dataModel.DiaDiemBaiXe;
        }

        public override bool HasChange()
        {
            return
            (oDiaDiemBaiXe != DiaDiemBaiXe) ;
        }

        public override rBaiXeDto ToDto()
        {
            var dto = new rBaiXeDto();
            dto.ID = ID;
            dto.DiaDiemBaiXe = DiaDiemBaiXe;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rBaiXeDto dto)
        {
            ID = dto.ID;
            DiaDiemBaiXe = dto.DiaDiemBaiXe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
