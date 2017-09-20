﻿using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tTonKhoDataModel : BaseDataModel<tTonKhoDto>
    {
        partial void ToDtoPartial(ref tTonKhoDto dto);
        partial void FromDtoPartial(tTonKhoDto dto);
		
        public static int DMaKhoHang;
        public static int DMaMatHang;
        public static System.DateTime DNgay;
        public static int DSoLuong;
        public static int DSoLuongCu;

        int oMaKhoHang;
        int oMaMatHang;
        System.DateTime oNgay;
        int oSoLuong;
        int oSoLuongCu;

        int _MaKhoHang = DMaKhoHang;
        int _MaMatHang = DMaMatHang;
        System.DateTime _Ngay = DNgay;
        int _SoLuong = DSoLuong;
        int _SoLuongCu = DSoLuongCu;

        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        public int SoLuongCu { get { return _SoLuongCu; } set { _SoLuongCu = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaKhoHang = MaKhoHang;
            oMaMatHang = MaMatHang;
            oNgay = Ngay;
            oSoLuong = SoLuong;
            oSoLuongCu = SoLuongCu;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tTonKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaKhoHang = dataModel.MaKhoHang;
            MaMatHang = dataModel.MaMatHang;
            Ngay = dataModel.Ngay;
            SoLuong = dataModel.SoLuong;
            SoLuongCu = dataModel.SoLuongCu;
        }

        public override bool HasChange()
        {
            return
            (oMaKhoHang != MaKhoHang) ||
            (oMaMatHang != MaMatHang) ||
            (oNgay != Ngay) ||
            (oSoLuong != SoLuong) ||
            (oSoLuongCu != SoLuongCu) ;
        }

        public override tTonKhoDto ToDto()
        {
            var dto = new tTonKhoDto();
            dto.ID = ID;
            dto.MaKhoHang = MaKhoHang;
            dto.MaMatHang = MaMatHang;
            dto.Ngay = Ngay;
            dto.SoLuong = SoLuong;
            dto.SoLuongCu = SoLuongCu;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tTonKhoDto dto)
        {
            ID = dto.ID;
            MaKhoHang = dto.MaKhoHang;
            MaMatHang = dto.MaMatHang;
            Ngay = dto.Ngay;
            SoLuong = dto.SoLuong;
            SoLuongCu = dto.SoLuongCu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rKhoHangDataModel MaKhoHangNavigation { get; set; }
        public tMatHangDataModel MaMatHangNavigation { get; set; }

        object _MaKhoHangDataSource;
        object _MaMatHangDataSource;

        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }
        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
    }
}
