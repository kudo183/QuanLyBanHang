using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiTietToaHangDataModel : BaseDataModel<tChiTietToaHangDto>
    {
        partial void ToDtoPartial(ref tChiTietToaHangDto dto);
        partial void FromDtoPartial(tChiTietToaHangDto dto);
		
        public static int DMaToaHang;
        public static int DMaChiTietDonHang;
        public static int DGiaTien;

        int oMaToaHang;
        int oMaChiTietDonHang;
        int oGiaTien;

        int _MaToaHang = DMaToaHang;
        int _MaChiTietDonHang = DMaChiTietDonHang;
        int _GiaTien = DGiaTien;

        public int MaToaHang { get { return _MaToaHang; } set { _MaToaHang = value; OnPropertyChanged(); } }
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { _MaChiTietDonHang = value; OnPropertyChanged(); } }
        public int GiaTien { get { return _GiaTien; } set { _GiaTien = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaToaHang = MaToaHang;
            oMaChiTietDonHang = MaChiTietDonHang;
            oGiaTien = GiaTien;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietToaHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaToaHang = dataModel.MaToaHang;
            MaChiTietDonHang = dataModel.MaChiTietDonHang;
            GiaTien = dataModel.GiaTien;
        }

        public override bool HasChange()
        {
            return
            (oMaToaHang != MaToaHang) ||
            (oMaChiTietDonHang != MaChiTietDonHang) ||
            (oGiaTien != GiaTien) ;
        }

        public override tChiTietToaHangDto ToDto()
        {
            var dto = new tChiTietToaHangDto();
            dto.ID = ID;
            dto.MaToaHang = MaToaHang;
            dto.MaChiTietDonHang = MaChiTietDonHang;
            dto.GiaTien = GiaTien;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietToaHangDto dto)
        {
            ID = dto.ID;
            MaToaHang = dto.MaToaHang;
            MaChiTietDonHang = dto.MaChiTietDonHang;
            GiaTien = dto.GiaTien;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tToaHangDataModel MaToaHangNavigation { get; set; }
        public tChiTietDonHangDataModel MaChiTietDonHangNavigation { get; set; }


    }
}
