using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tChuyenHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaNhanVienGiaoHang;
        System.DateTime oNgay;
        System.TimeSpan? oGio;
        int oTongDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        int _MaNhanVienGiaoHang;
        System.DateTime _Ngay;
        System.TimeSpan? _Gio;
        int _TongDonHang;
        int _TongSoLuongTheoDonHang;
        int _TongSoLuongThucTe;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public System.TimeSpan? Gio { get { return _Gio; } set { _Gio = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TongDonHang { get { return _TongDonHang; } set { _TongDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }
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
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oNgay = Ngay;
            oGio = Gio;
            oTongDonHang = TongDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChuyenHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            Ngay = dto.Ngay;
            Gio = dto.Gio;
            TongDonHang = dto.TongDonHang;
            TongSoLuongTheoDonHang = dto.TongSoLuongTheoDonHang;
            TongSoLuongThucTe = dto.TongSoLuongThucTe;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang)||
            (oNgay != Ngay)||
            (oGio != Gio)||
            (oTongDonHang != TongDonHang)||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang)||
            (oTongSoLuongThucTe != TongSoLuongThucTe)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rNhanVienDto MaNhanVienGiaoHangrNhanVienDto { get; set; }

        object _MaNhanVienGiaoHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { _MaNhanVienGiaoHangDataSource = value; OnPropertyChanged(); } }

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
