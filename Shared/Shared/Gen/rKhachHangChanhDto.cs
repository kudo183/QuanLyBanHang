using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rKhachHangChanhDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaChanh;
        public static int DMaKhachHang;
        public static bool DLaMacDinh;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaChanh;
        int oMaKhachHang;
        bool oLaMacDinh;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaChanh = DMaChanh;
        int _MaKhachHang = DMaKhachHang;
        bool _LaMacDinh = DLaMacDinh;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaChanh { get { return _MaChanh; } set { _MaChanh = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang { get { return _MaKhachHang; } set { _MaKhachHang = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public bool LaMacDinh { get { return _LaMacDinh; } set { _LaMacDinh = value; OnPropertyChanged(); } }
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
            oMaChanh = MaChanh;
            oMaKhachHang = MaKhachHang;
            oLaMacDinh = LaMacDinh;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rKhachHangChanhDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaChanh = dto.MaChanh;
            MaKhachHang = dto.MaKhachHang;
            LaMacDinh = dto.LaMacDinh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaChanh != MaChanh) ||
            (oMaKhachHang != MaKhachHang) ||
            (oLaMacDinh != LaMacDinh) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rChanhDto MaChanhNavigation { get; set; }
        public rKhachHangDto MaKhachHangNavigation { get; set; }

        object _MaChanhDataSource;
        object _MaKhachHangDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaChanhDataSource { get { return _MaChanhDataSource; } set { _MaChanhDataSource = value; OnPropertyChanged(); } }
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
