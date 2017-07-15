using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rChanhDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static int DMaBaiXe;
        public static string DTenChanh;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        int oMaBaiXe;
        string oTenChanh;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        int _MaBaiXe = DMaBaiXe;
        string _TenChanh = DTenChanh;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public int MaBaiXe { get { return _MaBaiXe; } set { _MaBaiXe = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public string TenChanh { get { return _TenChanh; } set { _TenChanh = value; OnPropertyChanged(); } }
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
            oMaBaiXe = MaBaiXe;
            oTenChanh = TenChanh;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rChanhDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            MaBaiXe = dto.MaBaiXe;
            TenChanh = dto.TenChanh;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oMaBaiXe != MaBaiXe) ||
            (oTenChanh != TenChanh) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }

        public rBaiXeDto MaBaiXeNavigation { get; set; }

        object _MaBaiXeDataSource;

        [Newtonsoft.Json.JsonIgnore]
        public object MaBaiXeDataSource { get { return _MaBaiXeDataSource; } set { _MaBaiXeDataSource = value; OnPropertyChanged(); } }

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
