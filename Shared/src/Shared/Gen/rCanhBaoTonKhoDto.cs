﻿using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rCanhBaoTonKhoDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaMatHang;
        int oMaKhoHang;
        int oTonCaoNhat;
        int oTonThapNhat;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        int _MaMatHang;
        int _MaKhoHang;
        int _TonCaoNhat;
        int _TonThapNhat;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaMatHang { get { return _MaMatHang; } set { _MaMatHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TonCaoNhat { get { return _TonCaoNhat; } set { _TonCaoNhat = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TonThapNhat { get { return _TonThapNhat; } set { _TonThapNhat = value; OnPropertyChanged(); } }
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
            oMaMatHang = MaMatHang;
            oMaKhoHang = MaKhoHang;
            oTonCaoNhat = TonCaoNhat;
            oTonThapNhat = TonThapNhat;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rCanhBaoTonKhoDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaMatHang = dto.MaMatHang;
            MaKhoHang = dto.MaKhoHang;
            TonCaoNhat = dto.TonCaoNhat;
            TonThapNhat = dto.TonThapNhat;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaMatHang != MaMatHang)||
            (oMaKhoHang != MaKhoHang)||
            (oTonCaoNhat != TonCaoNhat)||
            (oTonThapNhat != TonThapNhat)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public tMatHangDto MaMatHangtMatHangDto { get; set; }
        public rKhoHangDto MaKhoHangrKhoHangDto { get; set; }

        object _MaMatHangDataSource;
        object _MaKhoHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonIgnore]
        public int ID { get { return Ma; } set { Ma = value;} }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}
