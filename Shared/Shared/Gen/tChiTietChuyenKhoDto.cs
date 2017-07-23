﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tChiTietChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaChuyenKho;
        public static int DMaMatHang;
        public static int DSoLuong;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaChuyenKho;
        int oMaMatHang;
        int oSoLuong;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaChuyenKho = DMaChuyenKho;
        int _MaMatHang = DMaMatHang;
        int _SoLuong = DSoLuong;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaChuyenKho { get { return _MaChuyenKho; } set { _MaChuyenKho = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaChuyenKho = MaChuyenKho;
            oMaMatHang = MaMatHang;
            oSoLuong = SoLuong;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChiTietChuyenKhoDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaChuyenKho = dto.MaChuyenKho;
            MaMatHang = dto.MaMatHang;
            SoLuong = dto.SoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaChuyenKho != MaChuyenKho) ||
            (oMaMatHang != MaMatHang) ||
            (oSoLuong != SoLuong) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public tChuyenKhoDto MaChuyenKhoNavigation { get; set; }
        public tMatHangDto MaMatHangNavigation { get; set; }

        object _MaMatHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}