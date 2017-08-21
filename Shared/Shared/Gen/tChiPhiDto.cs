﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tChiPhiDto : IDto, INotifyPropertyChanged
    {
        public static int DID;
        public static int DMaNhanVienGiaoHang;
        public static int DMaLoaiChiPhi;
        public static int DSoTien;
        public static System.DateTime DNgay;
        public static string DGhiChu;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oID;
        int oMaNhanVienGiaoHang;
        int oMaLoaiChiPhi;
        int oSoTien;
        System.DateTime oNgay;
        string oGhiChu;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _ID = DID;
        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        int _MaLoaiChiPhi = DMaLoaiChiPhi;
        int _SoTien = DSoTien;
        System.DateTime _Ngay = DNgay;
        string _GhiChu = DGhiChu;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public int MaLoaiChiPhi { get { return _MaLoaiChiPhi; } set { _MaLoaiChiPhi = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(7)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(8)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(9)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oID = ID;
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oMaLoaiChiPhi = MaLoaiChiPhi;
            oSoTien = SoTien;
            oNgay = Ngay;
            oGhiChu = GhiChu;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChiPhiDto;
            if (dto == null)
            {
                return;
            }

            ID = dto.ID;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dto.MaLoaiChiPhi;
            SoTien = dto.SoTien;
            Ngay = dto.Ngay;
            GhiChu = dto.GhiChu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oID != ID) ||
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang) ||
            (oMaLoaiChiPhi != MaLoaiChiPhi) ||
            (oSoTien != SoTien) ||
            (oNgay != Ngay) ||
            (oGhiChu != GhiChu) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rNhanVienDto MaNhanVienGiaoHangNavigation { get; set; }
        public rLoaiChiPhiDto MaLoaiChiPhiNavigation { get; set; }

        object _MaNhanVienGiaoHangDataSource;
        object _MaLoaiChiPhiDataSource;

        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { _MaNhanVienGiaoHangDataSource = value; OnPropertyChanged(); } }
        public object MaLoaiChiPhiDataSource { get { return _MaLoaiChiPhiDataSource; } set { _MaLoaiChiPhiDataSource = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}
