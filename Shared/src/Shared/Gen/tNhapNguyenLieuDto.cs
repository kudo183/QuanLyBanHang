using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tNhapNguyenLieuDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static System.DateTime DNgay;
        public static int DMaNguyenLieu;
        public static int DMaNhaCungCap;
        public static int DSoLuong;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        System.DateTime oNgay;
        int oMaNguyenLieu;
        int oMaNhaCungCap;
        int oSoLuong;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        System.DateTime _Ngay = DNgay;
        int _MaNguyenLieu = DMaNguyenLieu;
        int _MaNhaCungCap = DMaNhaCungCap;
        int _SoLuong = DSoLuong;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaNguyenLieu { get { return _MaNguyenLieu; } set { _MaNguyenLieu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaNhaCungCap { get { return _MaNhaCungCap; } set { _MaNhaCungCap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get { return _SoLuong; } set { _SoLuong = value; OnPropertyChanged(); } }
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
            oNgay = Ngay;
            oMaNguyenLieu = MaNguyenLieu;
            oMaNhaCungCap = MaNhaCungCap;
            oSoLuong = SoLuong;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tNhapNguyenLieuDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            Ngay = dto.Ngay;
            MaNguyenLieu = dto.MaNguyenLieu;
            MaNhaCungCap = dto.MaNhaCungCap;
            SoLuong = dto.SoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oNgay != Ngay) ||
            (oMaNguyenLieu != MaNguyenLieu) ||
            (oMaNhaCungCap != MaNhaCungCap) ||
            (oSoLuong != SoLuong) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rNguyenLieuDto MaNguyenLieuNavigation { get; set; }
        public rNhaCungCapDto MaNhaCungCapNavigation { get; set; }

        object _MaNguyenLieuDataSource;
        object _MaNhaCungCapDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNguyenLieuDataSource { get { return _MaNguyenLieuDataSource; } set { _MaNguyenLieuDataSource = value; OnPropertyChanged(); } }
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
