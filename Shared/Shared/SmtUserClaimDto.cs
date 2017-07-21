using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class SmtUserClaimDto : IUserClaimDto, INotifyPropertyChanged
    {
        int oID;
        int oUserID;
        string oClaim;
        int oTenantID;
        long oLastUpdateTime;
        long oCreateTime;

        int _ID;
        int _UserID;
        string _Claim;
        int _TenantID;
        long _LastUpdateTime;
        long _CreateTime;

		[ProtoBuf.ProtoMember(1)]
		public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(2)]
		public int UserID { get { return _UserID; } set { _UserID = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(3)]
		public string Claim { get { return _Claim; } set { _Claim = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(4)]
		public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(5)]
		public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(6)]
		public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }

		[ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
        
		public void SetCurrentValueAsOriginalValue()
        {
			oID = ID;
			oUserID = UserID;
			oClaim = Claim;
			oTenantID = TenantID;
			oLastUpdateTime = LastUpdateTime;
			oCreateTime = CreateTime;
		}

		public void Update(object obj)
        {
			var dto = obj as SmtUserClaimDto;
            if (dto == null)
            {
                return;
            }
			
			ID = dto.ID;
			UserID = dto.UserID;
			Claim = dto.Claim;
			TenantID = dto.TenantID;
			LastUpdateTime = dto.LastUpdateTime;
			CreateTime = dto.CreateTime;
		}

		public bool HasChange()
        {
			return
			(oID != ID)||
			(oUserID != UserID)||
			(oClaim != Claim)||
			(oTenantID != TenantID)||
			(oLastUpdateTime != LastUpdateTime)||
			(oCreateTime != CreateTime);
        }
		
		object _UserIDDataSource;
		object _TenantIDDataSource;

		[Newtonsoft.Json.JsonIgnore]
		public object UserIDDataSource { get { return _UserIDDataSource; } set { _UserIDDataSource = value; OnPropertyChanged(); } }
		[Newtonsoft.Json.JsonIgnore]
		public object TenantIDDataSource { get { return _TenantIDDataSource; } set { _TenantIDDataSource = value; OnPropertyChanged(); } }
		
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
