using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rChanhDataModel : BaseDataModel<rChanhDto>
    {
        partial void ToDtoPartial(ref rChanhDto dto);
        partial void FromDtoPartial(rChanhDto dto);
		
        public static int DMaBaiXe;
        public static string DTenChanh;

        int oMaBaiXe;
        string oTenChanh;

        int _MaBaiXe = DMaBaiXe;
        string _TenChanh = DTenChanh;

        public int MaBaiXe { get { return _MaBaiXe; } set { _MaBaiXe = value; OnPropertyChanged(); } }
        public string TenChanh { get { return _TenChanh; } set { _TenChanh = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaBaiXe = MaBaiXe;
            oTenChanh = TenChanh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rChanhDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaBaiXe = dataModel.MaBaiXe;
            TenChanh = dataModel.TenChanh;
        }

        public override bool HasChange()
        {
            return
            (oMaBaiXe != MaBaiXe) ||
            (oTenChanh != TenChanh) ;
        }

        public override rChanhDto ToDto()
        {
            var dto = new rChanhDto();
            dto.ID = ID;
            dto.MaBaiXe = MaBaiXe;
            dto.TenChanh = TenChanh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rChanhDto dto)
        {
            ID = dto.ID;
            MaBaiXe = dto.MaBaiXe;
            TenChanh = dto.TenChanh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rBaiXeDataModel MaBaiXeNavigation { get; set; }

        object _MaBaiXeDataSource;

        public object MaBaiXeDataSource { get { return _MaBaiXeDataSource; } set { _MaBaiXeDataSource = value; OnPropertyChanged(); } }
    }
}
