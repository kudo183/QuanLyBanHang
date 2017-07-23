﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tToaHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static System.DateTime DNgay;
        public static int DMaKhachHang;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        System.DateTime oNgay;
        int oMaKhachHang;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        System.DateTime _Ngay = DNgay;
        int _MaKhachHang = DMaKhachHang;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oNgay = Ngay;
            oMaKhachHang = MaKhachHang;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tToaHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            Ngay = dto.Ngay;
            MaKhachHang = dto.MaKhachHang;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oNgay != Ngay) ||
            (oMaKhachHang != MaKhachHang) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rKhachHangDto MaKhachHangNavigation { get; set; }

        object _MaKhachHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { _MaKhachHangDataSource = value; OnPropertyChanged(); } }

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