using huypq.SmtShared;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class SmtUserDto : IUserDto, INotifyPropertyChanged
    {
        int oID;
        System.DateTime oCreateDate;
        string oEmail;
        string oPasswordHash;
        string oUserName;
        int oTenantID;
        long oTokenValidTime;
        long oLastUpdateTime;
        bool oIsConfirmed;
        bool oIsLocked;
        long oCreateTime;

        int _ID;
        System.DateTime _CreateDate;
        string _Email;
        string _PasswordHash;
        string _UserName;
        int _TenantID;
        long _TokenValidTime;
        long _LastUpdateTime;
        bool _IsConfirmed;
        bool _IsLocked;
        long _CreateTime;

		[ProtoBuf.ProtoMember(1)]
		public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(2)]
		public System.DateTime CreateDate { get { return _CreateDate; } set { _CreateDate = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(3)]
		public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(4)]
		public string PasswordHash { get { return _PasswordHash; } set { _PasswordHash = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(5)]
		public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(6)]
		public int TenantID { get { return _TenantID; } set { _TenantID = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(7)]
		public long TokenValidTime { get { return _TokenValidTime; } set { _TokenValidTime = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(8)]
		public long LastUpdateTime { get { return _LastUpdateTime; } set { _LastUpdateTime = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(9)]
		public bool IsConfirmed { get { return _IsConfirmed; } set { _IsConfirmed = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(10)]
		public bool IsLocked { get { return _IsLocked; } set { _IsLocked = value; OnPropertyChanged(); } }
		[ProtoBuf.ProtoMember(11)]
		public long CreateTime { get { return _CreateTime; } set { _CreateTime = value; OnPropertyChanged(); } }

		[ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
        
		public void SetCurrentValueAsOriginalValue()
        {
			oID = ID;
			oCreateDate = CreateDate;
			oEmail = Email;
			oPasswordHash = PasswordHash;
			oUserName = UserName;
			oTenantID = TenantID;
			oTokenValidTime = TokenValidTime;
			oLastUpdateTime = LastUpdateTime;
			oIsConfirmed = IsConfirmed;
			oIsLocked = IsLocked;
			oCreateTime = CreateTime;
		}

		public void Update(object obj)
        {
			var dto = obj as SmtUserDto;
            if (dto == null)
            {
                return;
            }
			
			ID = dto.ID;
			CreateDate = dto.CreateDate;
			Email = dto.Email;
			PasswordHash = dto.PasswordHash;
			UserName = dto.UserName;
			TenantID = dto.TenantID;
			TokenValidTime = dto.TokenValidTime;
			LastUpdateTime = dto.LastUpdateTime;
			IsConfirmed = dto.IsConfirmed;
			IsLocked = dto.IsLocked;
			CreateTime = dto.CreateTime;
		}

		public bool HasChange()
        {
			return
			(oID != ID)||
			(oCreateDate != CreateDate)||
			(oEmail != Email)||
			(oPasswordHash != PasswordHash)||
			(oUserName != UserName)||
			(oTenantID != TenantID)||
			(oTokenValidTime != TokenValidTime)||
			(oLastUpdateTime != LastUpdateTime)||
			(oIsConfirmed != IsConfirmed)||
			(oIsLocked != IsLocked)||
			(oCreateTime != CreateTime);
        }
		
		object _TenantIDDataSource;

		[Newtonsoft.Json.JsonIgnore]
		public object TenantIDDataSource { get { return _TenantIDDataSource; } set { _TenantIDDataSource = value; OnPropertyChanged(); } }
		
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
