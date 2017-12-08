using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rKhachHangChanhDataModel : BaseDataModel<rKhachHangChanhDto>
    {
        partial void ToDtoPartial(ref rKhachHangChanhDto dto);
        partial void FromDtoPartial(rKhachHangChanhDto dto);

        public static int DMaChanh;
        public static int DMaKhachHang;
        public static bool DLaMacDinh;

        int oMaChanh;
        int oMaKhachHang;
        bool oLaMacDinh;

        int _MaChanh = DMaChanh;
        int _MaKhachHang = DMaKhachHang;
        bool _LaMacDinh = DLaMacDinh;

        public int MaChanh { get { return _MaChanh; } set { SetField(ref _MaChanh, value); } }
        public int MaKhachHang { get { return _MaKhachHang; } set { SetField(ref _MaKhachHang, value); } }
        public bool LaMacDinh { get { return _LaMacDinh; } set { SetField(ref _LaMacDinh, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChanh = MaChanh;
            oMaKhachHang = MaKhachHang;
            oLaMacDinh = LaMacDinh;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rKhachHangChanhDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChanh = dataModel.MaChanh;
            MaKhachHang = dataModel.MaKhachHang;
            LaMacDinh = dataModel.LaMacDinh;
        }

        public override bool HasChange()
        {
            return
            (oMaChanh != MaChanh) ||
            (oMaKhachHang != MaKhachHang) ||
            (oLaMacDinh != LaMacDinh);
        }

        public override rKhachHangChanhDto ToDto()
        {
            var dto = new rKhachHangChanhDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaChanh = MaChanh;
            dto.MaKhachHang = MaKhachHang;
            dto.LaMacDinh = LaMacDinh;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rKhachHangChanhDto dto)
        {
            ID = dto.ID;
            MaChanh = dto.MaChanh;
            MaKhachHang = dto.MaKhachHang;
            LaMacDinh = dto.LaMacDinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rChanhDataModel MaChanhNavigation { get; set; }
        public rKhachHangDataModel MaKhachHangNavigation { get; set; }

        object _MaChanhDataSource;
        object _MaKhachHangDataSource;

        public object MaChanhDataSource { get { return _MaChanhDataSource; } set { SetField(ref _MaChanhDataSource, value); } }
        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { SetField(ref _MaKhachHangDataSource, value); } }
    }
}
