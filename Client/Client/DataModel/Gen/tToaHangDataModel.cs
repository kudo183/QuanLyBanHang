﻿using huypq.SmtWpfClient.Abstraction;
using Shared;

namespace Client.DataModel
{
    public partial class tToaHangDataModel : BaseDataModel<tToaHangDto>
    {
        partial void ToDtoPartial(ref tToaHangDto dto);
        partial void FromDtoPartial(tToaHangDto dto);

        public static System.DateTime DNgay;
        public static int DMaKhachHang;

        System.DateTime oNgay;
        int oMaKhachHang;

        System.DateTime _Ngay = DNgay;
        int _MaKhachHang = DMaKhachHang;

        public System.DateTime Ngay { get { return _Ngay; } set { SetField(ref _Ngay, value); } }
        public int MaKhachHang { get { return _MaKhachHang; } set { SetField(ref _MaKhachHang, value); } }

        public override void SetCurrentValueAsOriginalValue()
        {
            oNgay = Ngay;
            oMaKhachHang = MaKhachHang;
        }

        public override void Update(object obj)
        {
            var dataModel = obj as tToaHangDataModel;
            if (dataModel == null)
            {
                return;
            }

            Ngay = dataModel.Ngay;
            MaKhachHang = dataModel.MaKhachHang;
        }

        public override bool HasChange()
        {
            return
            (oNgay != Ngay) ||
            (oMaKhachHang != MaKhachHang);
        }

        public override tToaHangDto ToDto()
        {
            var dto = new tToaHangDto();
            dto.State = State;
            dto.ID = ID;
            dto.Ngay = Ngay;
            dto.MaKhachHang = MaKhachHang;
            dto.TenantID = TenantID;
            dto.CreateTime = CreateTime;
            dto.LastUpdateTime = LastUpdateTime;

            ToDtoPartial(ref dto);

            return dto;
        }

        public override void FromDto(tToaHangDto dto)
        {
            ID = dto.ID;
            Ngay = dto.Ngay;
            MaKhachHang = dto.MaKhachHang;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;

            FromDtoPartial(dto);
        }

        public rKhachHangDataModel MaKhachHangNavigation { get; set; }

        object _MaKhachHangDataSource;

        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { SetField(ref _MaKhachHangDataSource, value); } }
    }
}
