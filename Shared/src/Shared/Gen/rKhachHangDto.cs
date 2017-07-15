using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rKhachHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaDiaDiem;
        public static string DTenKhachHang;
        public static bool DKhachRieng;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaDiaDiem;
        string oTenKhachHang;
        bool oKhachRieng;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaDiaDiem = DMaDiaDiem;
        string _TenKhachHang = DTenKhachHang;
        bool _KhachRieng = DKhachRieng;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaDiaDiem { get { return _MaDiaDiem; } set { _MaDiaDiem = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenKhachHang { get { return _TenKhachHang; } set { _TenKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public bool KhachRieng { get { return _KhachRieng; } set { _KhachRieng = value; OnPropertyChanged(); } }
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
            oMaDiaDiem = MaDiaDiem;
            oTenKhachHang = TenKhachHang;
            oKhachRieng = KhachRieng;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rKhachHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaDiaDiem = dto.MaDiaDiem;
            TenKhachHang = dto.TenKhachHang;
            KhachRieng = dto.KhachRieng;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaDiaDiem != MaDiaDiem) ||
            (oTenKhachHang != TenKhachHang) ||
            (oKhachRieng != KhachRieng) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rDiaDiemDto MaDiaDiemNavigation { get; set; }

        object _MaDiaDiemDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaDiaDiemDataSource { get { return _MaDiaDiemDataSource; } set { _MaDiaDiemDataSource = value; OnPropertyChanged(); } }

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
