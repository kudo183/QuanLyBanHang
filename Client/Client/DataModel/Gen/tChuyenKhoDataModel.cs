﻿using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tChuyenKhoDataModel : BaseDataModel<tChuyenKhoDto>
    {
        partial void ToDtoPartial(ref tChuyenKhoDto dto);
        partial void FromDtoPartial(tChuyenKhoDto dto);

        public static int DMaNhanVien;
        public static int DMaKhoHangXuat;
        public static int DMaKhoHangNhap;
        public static System.DateTime DNgay;

        int oMaNhanVien;
        int oMaKhoHangXuat;
        int oMaKhoHangNhap;
        System.DateTime oNgay;

        int _MaNhanVien = DMaNhanVien;
        int _MaKhoHangXuat = DMaKhoHangXuat;
        int _MaKhoHangNhap = DMaKhoHangNhap;
        System.DateTime _Ngay = DNgay;

        public int MaNhanVien { get { return _MaNhanVien; } set { SetField(ref _MaNhanVien, value); } }
        public int MaKhoHangXuat { get { return _MaKhoHangXuat; } set { SetField(ref _MaKhoHangXuat, value); } }
        public int MaKhoHangNhap { get { return _MaKhoHangNhap; } set { SetField(ref _MaKhoHangNhap, value); } }
        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oMaNhanVien = MaNhanVien;
            oMaKhoHangXuat = MaKhoHangXuat;
            oMaKhoHangNhap = MaKhoHangNhap;
            oNgay = Ngay;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tChuyenKhoDataModel;
            if (dataModel == null)
            {
                return;
            }

            MaNhanVien = dataModel.MaNhanVien;
            MaKhoHangXuat = dataModel.MaKhoHangXuat;
            MaKhoHangNhap = dataModel.MaKhoHangNhap;
            Ngay = dataModel.Ngay;
        }

        public override bool HasChange()
        {
            return
            (oMaNhanVien != MaNhanVien) ||
            (oMaKhoHangXuat != MaKhoHangXuat) ||
            (oMaKhoHangNhap != MaKhoHangNhap) ||
            (oNgay != Ngay);
        }

        public override tChuyenKhoDto ToDto()
        {
            var dto = new tChuyenKhoDto();
            dto.State = State;
            dto.ID = ID;
            dto.MaNhanVien = MaNhanVien;
            dto.MaKhoHangXuat = MaKhoHangXuat;
            dto.MaKhoHangNhap = MaKhoHangNhap;
            dto.Ngay = Ngay;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tChuyenKhoDto dto)
        {
            State = dto.State;
            ID = dto.ID;
            MaNhanVien = dto.MaNhanVien;
            MaKhoHangXuat = dto.MaKhoHangXuat;
            MaKhoHangNhap = dto.MaKhoHangNhap;
            Ngay = dto.Ngay;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rNhanVienDataModel MaNhanVienNavigation { get; set; }
        public rKhoHangDataModel MaKhoHangXuatNavigation { get; set; }
        public rKhoHangDataModel MaKhoHangNhapNavigation { get; set; }

        object _MaNhanVienDataSource;
        object _MaKhoHangXuatDataSource;
        object _MaKhoHangNhapDataSource;

        public object MaNhanVienDataSource { get { return _MaNhanVienDataSource; } set { SetField(ref _MaNhanVienDataSource, value); } }
        public object MaKhoHangXuatDataSource { get { return _MaKhoHangXuatDataSource; } set { SetField(ref _MaKhoHangXuatDataSource, value); } }
        public object MaKhoHangNhapDataSource { get { return _MaKhoHangNhapDataSource; } set { SetField(ref _MaKhoHangNhapDataSource, value); } }
    }
}
