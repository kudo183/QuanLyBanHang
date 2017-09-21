using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rLoaiHangDataModel : BaseDataModel<rLoaiHangDto>
    {
        partial void ToDtoPartial(ref rLoaiHangDto dto);
        partial void FromDtoPartial(rLoaiHangDto dto);
		
        public static string DTenLoai;
        public static bool DHangNhaLam;

        string oTenLoai;
        bool oHangNhaLam;

        string _TenLoai = DTenLoai;
        bool _HangNhaLam = DHangNhaLam;

        public string TenLoai { get { return _TenLoai; } set { _TenLoai = value; OnPropertyChanged(); } }
        public bool HangNhaLam { get { return _HangNhaLam; } set { _HangNhaLam = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenLoai = TenLoai;
            oHangNhaLam = HangNhaLam;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rLoaiHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenLoai = dataModel.TenLoai;
            HangNhaLam = dataModel.HangNhaLam;
        }

        public override bool HasChange()
        {
            return
            (oTenLoai != TenLoai) ||
            (oHangNhaLam != HangNhaLam) ;
        }

        public override rLoaiHangDto ToDto()
        {
            var dto = new rLoaiHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenLoai = TenLoai;
            dto.HangNhaLam = HangNhaLam;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rLoaiHangDto dto)
        {
            ID = dto.ID;
            TenLoai = dto.TenLoai;
            HangNhaLam = dto.HangNhaLam;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
