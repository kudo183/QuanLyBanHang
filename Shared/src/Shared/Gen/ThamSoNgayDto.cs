using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class ThamSoNgayDto : IDto, INotifyPropertyChanged
    {
        public static int DMa;
        public static string DTen;
        public static System.DateTime DGiaTri;
        public static int DTenantID;
        public static long DCreateTime;
        public static long DLastUpdateTime;

        int oMa;
        string oTen;
        System.DateTime oGiaTri;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma = DMa;
        string _Ten = DTen;
        System.DateTime _GiaTri = DGiaTri;
        int _TenantID = DTenantID;
        long _CreateTime = DCreateTime;
        long _LastUpdateTime = DLastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string Ten { get { return _Ten; } set { _Ten = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime GiaTri { get { return _GiaTri; } set { _GiaTri = value; OnPropertyChanged(); } }
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
            oTen = Ten;
            oGiaTri = GiaTri;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as ThamSoNgayDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            Ten = dto.Ten;
            GiaTri = dto.GiaTri;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma) ||
            (oTen != Ten) ||
            (oGiaTri != GiaTri) ||
            (oTenantID != TenantID) ||
            (oCreateTime != CreateTime) ||
            (oLastUpdateTime != LastUpdateTime) ;
        }




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
