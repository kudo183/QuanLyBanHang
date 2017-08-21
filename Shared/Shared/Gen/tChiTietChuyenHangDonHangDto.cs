﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tChiTietChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        public static int DID;
        public static int DMaChuyenHangDonHang;
        public static int DMaChiTietDonHang;
        public static int DSoLuong;
        public static int DSoLuongTheoDonHang;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oID;
        int oMaChuyenHangDonHang;
        int oMaChiTietDonHang;
        int oSoLuong;
        int oSoLuongTheoDonHang;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _ID = DID;
        int _MaChuyenHangDonHang = DMaChuyenHangDonHang;
        int _MaChiTietDonHang = DMaChiTietDonHang;
        int _SoLuong = DSoLuong;
        int _SoLuongTheoDonHang = DSoLuongTheoDonHang;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public int MaChuyenHangDonHang { get { return _MaChuyenHangDonHang; } set { _MaChuyenHangDonHang = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public int MaChiTietDonHang { get { return _MaChiTietDonHang; } set { _MaChiTietDonHang = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public int SoLuongTheoDonHang { get { return _SoLuongTheoDonHang; } set { _SoLuongTheoDonHang = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(7)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(8)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oID = ID;
            oMaChuyenHangDonHang = MaChuyenHangDonHang;
            oMaChiTietDonHang = MaChiTietDonHang;
            oSoLuong = SoLuong;
            oSoLuongTheoDonHang = SoLuongTheoDonHang;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChiTietChuyenHangDonHangDto;
            if (dto == null)
            {
                return;
            }

            ID = dto.ID;
            MaChuyenHangDonHang = dto.MaChuyenHangDonHang;
            MaChiTietDonHang = dto.MaChiTietDonHang;
            SoLuong = dto.SoLuong;
            SoLuongTheoDonHang = dto.SoLuongTheoDonHang;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oID != ID) ||
            (oMaChuyenHangDonHang != MaChuyenHangDonHang) ||
            (oMaChiTietDonHang != MaChiTietDonHang) ||
            (oSoLuong != SoLuong) ||
            (oSoLuongTheoDonHang != SoLuongTheoDonHang) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public tChuyenHangDonHangDto MaChuyenHangDonHangNavigation { get; set; }
        public tChiTietDonHangDto MaChiTietDonHangNavigation { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}
