using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rCanhBaoTonKhoDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaMatHang;
        public static int DMaKhoHang;
        public static int DTonCaoNhat;
        public static int DTonThapNhat;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaMatHang;
        int oMaKhoHang;
        int oTonCaoNhat;
        int oTonThapNhat;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaMatHang = DMaMatHang;
        int _MaKhoHang = DMaKhoHang;
        int _TonCaoNhat = DTonCaoNhat;
        int _TonThapNhat = DTonThapNhat;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

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

        public tMatHangDto MaMatHangNavigation { get; set; }
        public rKhoHangDto MaKhoHangNavigation { get; set; }

        object _MaMatHangDataSource;
        object _MaKhoHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaMatHangDataSource { get { return _MaMatHangDataSource; } set { _MaMatHangDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangDataSource { get { return _MaKhoHangDataSource; } set { _MaKhoHangDataSource = value; OnPropertyChanged(); } }

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
