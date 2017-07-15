using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tChuyenHangDonHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaChuyenHang;
        public static int DMaDonHang;
        public static int DTongSoLuongTheoDonHang;
        public static int DTongSoLuongThucTe;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaChuyenHang;
        int oMaDonHang;
        int oTongSoLuongTheoDonHang;
        int oTongSoLuongThucTe;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaChuyenHang = DMaChuyenHang;
        int _MaDonHang = DMaDonHang;
        int _TongSoLuongTheoDonHang = DTongSoLuongTheoDonHang;
        int _TongSoLuongThucTe = DTongSoLuongThucTe;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaChuyenHang { get { return _MaChuyenHang; } set { _MaChuyenHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaDonHang { get { return _MaDonHang; } set { _MaDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TongSoLuongTheoDonHang { get { return _TongSoLuongTheoDonHang; } set { _TongSoLuongTheoDonHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public int TongSoLuongThucTe { get { return _TongSoLuongThucTe; } set { _TongSoLuongThucTe = value; OnPropertyChanged(); } }
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
            oMaChuyenHang = MaChuyenHang;
            oMaDonHang = MaDonHang;
            oTongSoLuongTheoDonHang = TongSoLuongTheoDonHang;
            oTongSoLuongThucTe = TongSoLuongThucTe;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChuyenHangDonHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaChuyenHang = dto.MaChuyenHang;
            MaDonHang = dto.MaDonHang;
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
            (oMaChuyenHang != MaChuyenHang)||
            (oMaDonHang != MaDonHang)||
            (oTongSoLuongTheoDonHang != TongSoLuongTheoDonHang)||
            (oTongSoLuongThucTe != TongSoLuongThucTe)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public tChuyenHangDto MaChuyenHangNavigation { get; set; }
        public tDonHangDto MaDonHangNavigation { get; set; }



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
