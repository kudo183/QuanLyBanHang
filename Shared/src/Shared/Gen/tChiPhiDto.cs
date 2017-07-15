using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tChiPhiDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaNhanVienGiaoHang;
        public static int DMaLoaiChiPhi;
        public static int DSoTien;
        public static System.DateTime DNgay;
        public static string DGhiChu;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaNhanVienGiaoHang;
        int oMaLoaiChiPhi;
        int oSoTien;
        System.DateTime oNgay;
        string oGhiChu;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaNhanVienGiaoHang = DMaNhanVienGiaoHang;
        int _MaLoaiChiPhi = DMaLoaiChiPhi;
        int _SoTien = DSoTien;
        System.DateTime _Ngay = DNgay;
        string _GhiChu = DGhiChu;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVienGiaoHang { get { return _MaNhanVienGiaoHang; } set { _MaNhanVienGiaoHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaLoaiChiPhi { get { return _MaLoaiChiPhi; } set { _MaLoaiChiPhi = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int SoTien { get { return _SoTien; } set { _SoTien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public string GhiChu { get { return _GhiChu; } set { _GhiChu = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(7)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(8)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(9)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaNhanVienGiaoHang = MaNhanVienGiaoHang;
            oMaLoaiChiPhi = MaLoaiChiPhi;
            oSoTien = SoTien;
            oNgay = Ngay;
            oGhiChu = GhiChu;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChiPhiDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaNhanVienGiaoHang = dto.MaNhanVienGiaoHang;
            MaLoaiChiPhi = dto.MaLoaiChiPhi;
            SoTien = dto.SoTien;
            Ngay = dto.Ngay;
            GhiChu = dto.GhiChu;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaNhanVienGiaoHang != MaNhanVienGiaoHang)||
            (oMaLoaiChiPhi != MaLoaiChiPhi)||
            (oSoTien != SoTien)||
            (oNgay != Ngay)||
            (oGhiChu != GhiChu)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rNhanVienDto MaNhanVienGiaoHangNavigation { get; set; }
        public rLoaiChiPhiDto MaLoaiChiPhiNavigation { get; set; }

        object _MaNhanVienGiaoHangDataSource;
        object _MaLoaiChiPhiDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienGiaoHangDataSource { get { return _MaNhanVienGiaoHangDataSource; } set { _MaNhanVienGiaoHangDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaLoaiChiPhiDataSource { get { return _MaLoaiChiPhiDataSource; } set { _MaLoaiChiPhiDataSource = value; OnPropertyChanged(); } }

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
