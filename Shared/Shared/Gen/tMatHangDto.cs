using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tMatHangDto : IDto, INotifyPropertyChanged
    {
        public static int DID;
        public static int DMaLoai;
        public static string DTenMatHang;
        public static int DSoKy;
        public static int DSoMet;
        public static string DTenMatHangDayDu;
        public static string DTenMatHangIn;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oID;
        int oMaLoai;
        string oTenMatHang;
        int oSoKy;
        int oSoMet;
        string oTenMatHangDayDu;
        string oTenMatHangIn;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _ID = DID;
        int _MaLoai = DMaLoai;
        string _TenMatHang = DTenMatHang;
        int _SoKy = DSoKy;
        int _SoMet = DSoMet;
        string _TenMatHangDayDu = DTenMatHangDayDu;
        string _TenMatHangIn = DTenMatHangIn;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public int MaLoai { get { return _MaLoai; } set { _MaLoai = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public string TenMatHang { get { return _TenMatHang; } set { _TenMatHang = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int SoKy { get { return _SoKy; } set { _SoKy = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public int SoMet { get { return _SoMet; } set { _SoMet = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public string TenMatHangDayDu { get { return _TenMatHangDayDu; } set { _TenMatHangDayDu = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(7)]
        public string TenMatHangIn { get { return _TenMatHangIn; } set { _TenMatHangIn = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(8)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(9)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(10)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oID = ID;
            oMaLoai = MaLoai;
            oTenMatHang = TenMatHang;
            oSoKy = SoKy;
            oSoMet = SoMet;
            oTenMatHangDayDu = TenMatHangDayDu;
            oTenMatHangIn = TenMatHangIn;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tMatHangDto;
            if (dto == null)
            {
                return;
            }

            ID = dto.ID;
            MaLoai = dto.MaLoai;
            TenMatHang = dto.TenMatHang;
            SoKy = dto.SoKy;
            SoMet = dto.SoMet;
            TenMatHangDayDu = dto.TenMatHangDayDu;
            TenMatHangIn = dto.TenMatHangIn;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oID != ID) ||
            (oMaLoai != MaLoai) ||
            (oTenMatHang != TenMatHang) ||
            (oSoKy != SoKy) ||
            (oSoMet != SoMet) ||
            (oTenMatHangDayDu != TenMatHangDayDu) ||
            (oTenMatHangIn != TenMatHangIn) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rLoaiHangDto MaLoaiNavigation { get; set; }

        object _MaLoaiDataSource;

        public object MaLoaiDataSource { get { return _MaLoaiDataSource; } set { _MaLoaiDataSource = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            RaiseDependentPropertyChanged(name);
        }

        partial void RaiseDependentPropertyChanged(string basePropertyName);
    }
}
