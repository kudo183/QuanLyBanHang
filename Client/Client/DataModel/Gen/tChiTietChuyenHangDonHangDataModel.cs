﻿using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChiTietChuyenHangDonHangDataModel : BaseDataModel<tChiTietChuyenHangDonHangDto>
    {
        partial void ToDtoPartial(ref tChiTietChuyenHangDonHangDto dto);
        partial void FromDtoPartial(tChiTietChuyenHangDonHangDto dto);
		
        public static int DMaChuyenHangDonHang;
        public static int DMaChiTietDonHang;
        public static int DSoLuong;
        public static int DSoLuongTheoDonHang;

        int oMaChuyenHangDonHang;
        int oMaChiTietDonHang;
        int oSoLuong;
        int oSoLuongTheoDonHang;

        int _MaChuyenHangDonHang = DMaChuyenHangDonHang;
        int _MaChiTietDonHang = DMaChiTietDonHang;
        int _SoLuong = DSoLuong;
        int _SoLuongTheoDonHang = DSoLuongTheoDonHang;

        public int MaChuyenHangDonHang { get { return _MaChuyenHangDonHang; } set { _MaChuyenHangDonHang = value; OnPropertyChanged(); } }
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { _MaChiTietDonHang = value; OnPropertyChanged(); } }
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        public int SoLuongTheoDonHang { get { return _SoLuongTheoDonHang; } set { _SoLuongTheoDonHang = value; OnPropertyChanged(); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaChuyenHangDonHang = MaChuyenHangDonHang;
            oMaChiTietDonHang = MaChiTietDonHang;
            oSoLuong = SoLuong;
            oSoLuongTheoDonHang = SoLuongTheoDonHang;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChiTietChuyenHangDonHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaChuyenHangDonHang = dataModel.MaChuyenHangDonHang;
            MaChiTietDonHang = dataModel.MaChiTietDonHang;
            SoLuong = dataModel.SoLuong;
            SoLuongTheoDonHang = dataModel.SoLuongTheoDonHang;
        }

        public override bool HasChange()
        {
            return
            (oMaChuyenHangDonHang != MaChuyenHangDonHang) ||
            (oMaChiTietDonHang != MaChiTietDonHang) ||
            (oSoLuong != SoLuong) ||
            (oSoLuongTheoDonHang != SoLuongTheoDonHang) ;
        }

        public override tChiTietChuyenHangDonHangDto ToDto()
        {
            var dto = new tChiTietChuyenHangDonHangDto();
            dto.ID = ID;
            dto.MaChuyenHangDonHang = MaChuyenHangDonHang;
            dto.MaChiTietDonHang = MaChiTietDonHang;
            dto.SoLuong = SoLuong;
            dto.SoLuongTheoDonHang = SoLuongTheoDonHang;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChiTietChuyenHangDonHangDto dto)
        {
            ID = dto.ID;
            MaChuyenHangDonHang = dto.MaChuyenHangDonHang;
            MaChiTietDonHang = dto.MaChiTietDonHang;
            SoLuong = dto.SoLuong;
            SoLuongTheoDonHang = dto.SoLuongTheoDonHang;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public tChuyenHangDonHangDataModel MaChuyenHangDonHangNavigation { get; set; }
        public tChiTietDonHangDataModel MaChiTietDonHangNavigation { get; set; }


    }
}
