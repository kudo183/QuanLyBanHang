using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rLoaiNguyenLieuDataModel : BaseDataModel<rLoaiNguyenLieuDto>
    {
        partial void ToDtoPartial(ref rLoaiNguyenLieuDto dto);
        partial void FromDtoPartial(rLoaiNguyenLieuDto dto);

        public static string DTenLoai;

        string oTenLoai;

        string _TenLoai = DTenLoai;

        public string TenLoai { get { return _TenLoai; } set { SetField(ref _TenLoai, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oTenLoai = TenLoai;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rLoaiNguyenLieuDataModel;
            if (dataModel == null)
            {
                return;
            }

            TenLoai = dataModel.TenLoai;
        }

        public override bool HasChange()
        {
            return
            (oTenLoai != TenLoai);
        }

        public override rLoaiNguyenLieuDto ToDto()
        {
            var dto = new rLoaiNguyenLieuDto();
            dto.State = State;
            dto.ID = ID;
            dto.TenLoai = TenLoai;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rLoaiNguyenLieuDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            TenLoai = dto.TenLoai;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }



    }
}
