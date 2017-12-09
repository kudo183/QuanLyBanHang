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

        public int MaToaHang { get { return _MaToaHang; } set { SetField(ref _MaToaHang, value); } }
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { SetField(ref _MaChiTietDonHang, value); } }
        public int GiaTien { get { return _GiaTien; } set { SetField(ref _GiaTien, value); } }

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
            (oGiaTien != GiaTien);
        }

        public override tChiTietToaHangDto ToDto()
        {
            var dto = new tChiTietToaHangDto();
            dto.State = State;
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
            State = dto.State;
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
