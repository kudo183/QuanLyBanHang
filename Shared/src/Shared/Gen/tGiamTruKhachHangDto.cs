using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tGiamTruKhachHangDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaKhachHang;
        public static System.DateTime DNgay;
        public static int DSoTien;
        public static string DGhiChu;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaKhachHang;
        System.DateTime oNgay;
        int oSoTien;
        string oGhiChu;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaKhachHang = DMaKhachHang;
        System.DateTime _Ngay = DNgay;
        int _SoTien = DSoTien;
        string _GhiChu = DGhiChu;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }
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
            oMaKhachHang = MaKhachHang;
            oNgay = Ngay;
            oSoTien = SoTien;
            oGhiChu = GhiChu;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tGiamTruKhachHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaKhachHang = dto.MaKhachHang;
            Ngay = dto.Ngay;
            SoTien = dto.SoTien;
            GhiChu = dto.GhiChu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaKhachHang != MaKhachHang) ||
            (oNgay != Ngay) ||
            (oSoTien != SoTien) ||
            (oGhiChu != GhiChu) ||
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
