using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class tChuyenKhoDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        int oMaNhanVien;
        int oMaKhoHangXuat;
        int oMaKhoHangNhap;
        System.DateTime oNgay;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        int _MaNhanVien;
        int _MaKhoHangXuat;
        int _MaKhoHangNhap;
        System.DateTime _Ngay;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVien { get { return _MaNhanVien; } set { _MaNhanVien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhoHangXuat { get { return _MaKhoHangXuat; } set { _MaKhoHangXuat = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int MaKhoHangNhap { get { return _MaKhoHangNhap; } set { _MaKhoHangNhap = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public System.DateTime Ngay { get { return _Ngay; } set { _Ngay = value; OnPropertyChanged(); } }
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
            oMaNhanVien = MaNhanVien;
            oMaKhoHangXuat = MaKhoHangXuat;
            oMaKhoHangNhap = MaKhoHangNhap;
            oNgay = Ngay;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as tChuyenKhoDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaNhanVien = dto.MaNhanVien;
            MaKhoHangXuat = dto.MaKhoHangXuat;
            MaKhoHangNhap = dto.MaKhoHangNhap;
            Ngay = dto.Ngay;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oMaNhanVien != MaNhanVien)||
            (oMaKhoHangXuat != MaKhoHangXuat)||
            (oMaKhoHangNhap != MaKhoHangNhap)||
            (oNgay != Ngay)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }

        public rNhanVienDto MaNhanVienrNhanVienDto { get; set; }
        public rKhoHangDto MaKhoHangXuatrKhoHangDto { get; set; }
        public rKhoHangDto MaKhoHangNhaprKhoHangDto { get; set; }

        object _MaNhanVienDataSource;
        object _MaKhoHangXuatDataSource;
        object _MaKhoHangNhapDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaNhanVienDataSource { get { return _MaNhanVienDataSource; } set { _MaNhanVienDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangXuatDataSource { get { return _MaKhoHangXuatDataSource; } set { _MaKhoHangXuatDataSource = value; OnPropertyChanged(); } }
        [Newtonsoft.Json.JsonIgnore]
        public object MaKhoHangNhapDataSource { get { return _MaKhoHangNhapDataSource; } set { _MaKhoHangNhapDataSource = value; OnPropertyChanged(); } }

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
