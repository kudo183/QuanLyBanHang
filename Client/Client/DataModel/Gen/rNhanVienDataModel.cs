using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class rNhanVienDataModel : BaseDataModel<rNhanVienDto>
    {
        partial void ToDtoPartial(ref rNhanVienDto dto);
        partial void FromDtoPartial(rNhanVienDto dto);
		
        public static int DMaPhuongTien;
        public static string DTenNhanVien;

        int oMaPhuongTien;
        string oTenNhanVien;

        int _MaPhuongTien = DMaPhuongTien;
        string _TenNhanVien = DTenNhanVien;

        public int MaPhuongTien { get { return _MaPhuongTien; } set { _MaPhuongTien = value; OnPropertyChanged(); } }
        public string TenNhanVien { get { return _TenNhanVien; } set { _TenNhanVien = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaPhuongTien = MaPhuongTien;
            oTenNhanVien = TenNhanVien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as rNhanVienDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaPhuongTien = dataModel.MaPhuongTien;
            TenNhanVien = dataModel.TenNhanVien;
        }

        public override bool HasChange()
        {
            return
            (oMaPhuongTien != MaPhuongTien) ||
            (oTenNhanVien != TenNhanVien) ;
        }

        public override rNhanVienDto ToDto()
        {
            var dto = new rNhanVienDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaPhuongTien = MaPhuongTien;
            dto.TenNhanVien = TenNhanVien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(rNhanVienDto dto)
        {
            ID = dto.ID;
            MaPhuongTien = dto.MaPhuongTien;
            TenNhanVien = dto.TenNhanVien;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rPhuongTienDataModel MaPhuongTienNavigation { get; set; }

        object _MaPhuongTienDataSource;

        public object MaPhuongTienDataSource { get { return _MaPhuongTienDataSource; } set { _MaPhuongTienDataSource = value; OnPropertyChanged(); } }
    }
}
