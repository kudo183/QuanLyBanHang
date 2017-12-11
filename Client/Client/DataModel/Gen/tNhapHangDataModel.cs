using huypq.SmtWpfClient.Abstraction;
using Shared;
using System.Collections.Generic;

namespace Client.DataModel
{
    public partial class tNhapHangDataModel : BaseDataModel<tNhapHangDto>
    {
        partial void ToDtoPartial(ref tNhapHangDto dto);
        partial void FromDtoPartial(tNhapHangDto dto);
        partial void SetPropertiesDependencyPartial();
        partial void DisplayTextPartial();

        public static int DMaNhanVien;
        public static int DMaKhoHang;
        public static int DMaNhaCungCap;
        public static System.DateTime DNgay;

        int oMaNhanVien;
        int oMaKhoHang;
        int oMaNhaCungCap;
        System.DateTime oNgay;

        int _MaNhanVien = DMaNhanVien;
        int _MaKhoHang = DMaKhoHang;
        int _MaNhaCungCap = DMaNhaCungCap;
        System.DateTime _Ngay = DNgay;

        public int MaNhanVien { get { return _MaNhanVien; } set { SetField(ref _MaNhanVien, value); } }
        public int MaKhoHang { get { return _MaKhoHang; } set { SetField(ref _MaKhoHang, value); } }
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { SetField(ref _MaNhaCungCap, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVien = MaNhanVien;
            oMaKhoHang = MaKhoHang;
            oMaNhaCungCap = MaNhaCungCap;
            oNgay = Ngay;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tNhapHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVien = dataModel.MaNhanVien;
            MaKhoHang = dataModel.MaKhoHang;
            MaNhaCungCap = dataModel.MaNhaCungCap;
            Ngay = dataModel.Ngay;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVien != MaNhanVien) ||
            (oMaKhoHang != MaKhoHang) ||
            (oMaNhaCungCap != MaNhaCungCap) ||
            (oNgay != Ngay);
        }

        public override tNhapHangDto ToDto()
        {
            var dto = new tNhapHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhanVien = MaNhanVien;
            dto.MaKhoHang = MaKhoHang;
            dto.MaNhaCungCap = MaNhaCungCap;
            dto.Ngay = Ngay;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tNhapHangDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaNhanVien = dto.MaNhanVien;
            MaKhoHang = dto.MaKhoHang;
            MaNhaCungCap = dto.MaNhaCungCap;
            Ngay = dto.Ngay;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        protected override void SetPropertiesDependency()
        {
            SetPropertiesDependencyPartial();
        }

        private string _displayText;
        public override string DisplayText
        {
            get
            {
                _displayText = base.DisplayText;
                DisplayTextPartial();
                return _displayText;
            }
        }

        public rNhanVienDataModel MaNhanVienNavigation { get; set; }
        public rKhoHangDataModel MaKhoHangNavigation { get; set; }
        public rNhaCungCapDataModel MaNhaCungCapNavigation { get; set; }

        object _MaNhanVienDataSource;
        object _MaKhoHangDataSource;
        object _MaNhaCungCapDataSource;

        public object MaNhanVienDataSource { get { return _MaNhanVienDataSource; } set { SetField(ref _MaNhanVienDataSource, value); } }
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { SetField(ref _MaKhoHangDataSource, value); } }
        public object MaNhaCungCapDataSource { get { return _MaNhaCungCapDataSource; } set { SetField(ref _MaNhaCungCapDataSource, value); } }
    }
}
