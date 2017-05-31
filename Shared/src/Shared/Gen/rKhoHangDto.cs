using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class rKhoHangDto : IDto, INotifyPropertyChanged
    {
        int oMa;
        string oTenKho;
        bool oTrangThai;
        int oTenantID;
        long oCreateTime;
        long oLastUpdateTime;

        int _Ma;
        string _TenKho;
        bool _TrangThai;
        int _TenantID;
        long _CreateTime;
        long _LastUpdateTime;

        [ProtoBuf.ProtoMember(1)]
        public int Ma { get { return _Ma; } set { _Ma = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(2)]
        public string TenKho { get { return _TenKho; } set { _TenKho = value; OnPropertyChanged(); } }
        [ProtoBuf.ProtoMember(3)]
        public bool TrangThai { get { return _TrangThai; } set { _TrangThai = value; OnPropertyChanged(); } }
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
            oTenKho = TenKho;
            oTrangThai = TrangThai;
            oTenantID = TenantID;
            oCreateTime = CreateTime;
            oLastUpdateTime = LastUpdateTime;
        }

        public void Update(object obj)
        {
            var dto = obj as rKhoHangDto;
            if (dto == null)
            {
                return;
            }

            Ma = dto.Ma;
            TenKho = dto.TenKho;
            TrangThai = dto.TrangThai;
            TenantID = dto.TenantID;
            CreateTime = dto.CreateTime;
            LastUpdateTime = dto.LastUpdateTime;
        }

        public bool HasChange()
        {
            return
            (oMa != Ma)||
            (oTenKho != TenKho)||
            (oTrangThai != TrangThai)||
            (oTenantID != TenantID)||
            (oCreateTime != CreateTime)||
            (oLastUpdateTime != LastUpdateTime);
        }




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
