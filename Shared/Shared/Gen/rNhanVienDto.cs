using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rNhanVienDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaPhuongTien;
        public static string DTenNhanVien;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaPhuongTien;
        string oTenNhanVien;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaPhuongTien = DMaPhuongTien;
        string _TenNhanVien = DTenNhanVien;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaPhuongTien { get { return _MaPhuongTien; } set { _MaPhuongTien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenNhanVien { get { return _TenNhanVien; } set { _TenNhanVien = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(5)]
        public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(6)]
        public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }

        public void SetCurrentValueAsOriginalValue()
        {
            oMa = Ma;
            oMaPhuongTien = MaPhuongTien;
            oTenNhanVien = TenNhanVien;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rNhanVienDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaPhuongTien = dto.MaPhuongTien;
            TenNhanVien = dto.TenNhanVien;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaPhuongTien != MaPhuongTien) ||
            (oTenNhanVien != TenNhanVien) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rPhuongTienDto MaPhuongTienNavigation { get; set; }

        object _MaPhuongTienDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaPhuongTienDataSource { get { return _MaPhuongTienDataSource; } set { _MaPhuongTienDataSource = value; OnPropertyChanged(); } }

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
