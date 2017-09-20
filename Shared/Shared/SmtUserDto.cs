using huypq.SmtShared;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class SmtUserDto : IUserDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime CreateDate { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string Email { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string PasswordHash { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public string UserName { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public int TenantID { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public long TokenValidTime { get; set; }
        [ProtoBuf.ProtoMember(8)]
        public long LastUpdateTime { get; set; }
        [ProtoBuf.ProtoMember(9)]
        public bool IsConfirmed { get; set; }
        [ProtoBuf.ProtoMember(10)]
        public bool IsLocked { get; set; }
        [ProtoBuf.ProtoMember(11)]
        public long CreateTime { get; set; }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
