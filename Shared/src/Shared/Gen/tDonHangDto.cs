using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tDonHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaKhachHang;
        public static int? DMaChanh;
        public static System.DateTime DNgay;
        public static bool DXong;
        public static int DMaKhoHang;
        public static int DTongSoLuong;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaKhachHang;
        int? oMaChanh;
        System.DateTime oNgay;
        bool oXong;
        int oMaKhoHang;
        int oTongSoLuong;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaKhachHang = DMaKhachHang;
        int? _MaChanh = DMaChanh;
        System.DateTime _Ngay = DNgay;
        bool _Xong = DXong;
        int _MaKhoHang = DMaKhoHang;
        int _TongSoLuong = DTongSoLuong;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int? MaChanh { get { return _MaChanh; } set { _MaChanh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public bool Xong { get { return _Xong; } set { _Xong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int MaKhoHang { get { return _MaKhoHang; } set { _MaKhoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public int TongSoLuong { get { return _TongSoLuong; } set { _TongSoLuong = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(9)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(10)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaKhachHang = MaKhachHang;
            oMaChanh = MaChanh;
            oNgay = Ngay;
            oXong = Xong;
            oMaKhoHang = MaKhoHang;
            oTongSoLuong = TongSoLuong;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tDonHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaKhachHang = dto.MaKhachHang;
            MaChanh = dto.MaChanh;
            Ngay = dto.Ngay;
            Xong = dto.Xong;
            MaKhoHang = dto.MaKhoHang;
            TongSoLuong = dto.TongSoLuong;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaKhachHang != MaKhachHang)||
            (oMaChanh != MaChanh)||
            (oNgay != Ngay)||
            (oXong != Xong)||
            (oMaKhoHang != MaKhoHang)||
            (oTongSoLuong != TongSoLuong)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rKhachHangDto MaKhachHangNavigation { get; set; }
        public rChanhDto MaChanhNavigation { get; set; }
        public rKhoHangDto MaKhoHangNavigation { get; set; }

        object _MaKhachHangDataSource;
        object _MaChanhDataSource;
        object _MaKhoHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaKhachHangDataSource { get { return _MaKhachHangDataSource; } set { _MaKhachHangDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaChanhDataSource { get { return _MaChanhDataSource; } set { _MaChanhDataSource = value; OnPropertyChanged(); } }
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
