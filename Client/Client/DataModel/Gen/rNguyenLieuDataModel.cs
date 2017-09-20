using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rNguyenLieuDataModel : BaseDataModel<rNguyenLieuDto>
    {
        partial void ToDtoPartial(ref rNguyenLieuDto dto);
        partial void FromDtoPartial(rNguyenLieuDto dto);
		
        public static int DMaLoaiNguyenLieu;
        public static int DDuongKinh;

        int oMaLoaiNguyenLieu;
        int oDuongKinh;

        int _MaLoaiNguyenLieu = DMaLoaiNguyenLieu;
        int _DuongKinh = DDuongKinh;

        public int MaLoaiNguyenLieu { get { return _MaLoaiNguyenLieu; } set { _MaLoaiNguyenLieu = value; OnPropertyChanged(); } }
        public int DuongKinh { get { return _DuongKinh; } set { _DuongKinh = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaLoaiNguyenLieu = MaLoaiNguyenLieu;
            oDuongKinh = DuongKinh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNguyenLieuDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaLoaiNguyenLieu = dataModel.MaLoaiNguyenLieu;
            DuongKinh = dataModel.DuongKinh;
        }

        public override bool HasChange()
        {
            return
            (oMaLoaiNguyenLieu != MaLoaiNguyenLieu) ||
            (oDuongKinh != DuongKinh) ;
        }

        public override rNguyenLieuDto ToDto()
        {
            var dto = new rNguyenLieuDto();
            dto.ID = ID;
            dto.MaLoaiNguyenLieu = MaLoaiNguyenLieu;
            dto.DuongKinh = DuongKinh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNguyenLieuDto dto)
        {
            ID = dto.ID;
            MaLoaiNguyenLieu = dto.MaLoaiNguyenLieu;
            DuongKinh = dto.DuongKinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rLoaiNguyenLieuDataModel MaLoaiNguyenLieuNavigation { get; set; }

        object _MaLoaiNguyenLieuDataSource;

        public object MaLoaiNguyenLieuDataSource { get { return _MaLoaiNguyenLieuDataSource; } set { _MaLoaiNguyenLieuDataSource = value; OnPropertyChanged(); } }
    }
}
