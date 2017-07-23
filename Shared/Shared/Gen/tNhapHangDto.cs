﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tNhapHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaNhanVien;
        public static int DMaKhoHang;
        public static int DMaNhaCungCap;
        public static System.DateTime DNgay;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaNhanVien;
        int oMaKhoHang;
        int oMaNhaCungCap;
        System.DateTime oNgay;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaNhanVien = DMaNhanVien;
        int _MaKhoHang = DMaKhoHang;
        int _MaNhaCungCap = DMaNhaCungCap;
        System.DateTime _Ngay = DNgay;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { _MaNhaCungCap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaNhanVien = MaNhanVien;
            oMaKhoHang = MaKhoHang;
            oMaNhaCungCap = MaNhaCungCap;
            oNgay = Ngay;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tNhapHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaNhanVien = dto.MaNhanVien;
            MaKhoHang = dto.MaKhoHang;
            MaNhaCungCap = dto.MaNhaCungCap;
            Ngay = dto.Ngay;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaNhanVien != MaNhanVien) ||
            (oMaKhoHang != MaKhoHang) ||
            (oMaNhaCungCap != MaNhaCungCap) ||
            (oNgay != Ngay) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rNhanVienDto MaNhanVienNavigation { get; set; }
        public rKhoHangDto MaKhoHangNavigation { get; set; }
        public rNhaCungCapDto MaNhaCungCapNavigation { get; set; }

        object _MaNhanVienDataSource;
        object _MaKhoHangDataSource;
        object _MaNhaCungCapDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienDataSource { get { return _MaNhanVienDataSource; } set { _MaNhanVienDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaNhaCungCapDataSource { get { return _MaNhaCungCapDataSource; } set { _MaNhaCungCapDataSource = value; OnPropertyChanged(); } }

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