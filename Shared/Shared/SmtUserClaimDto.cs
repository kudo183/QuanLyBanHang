using huypq.SmtShared;

namespace Shared
{
    [ProtoBuf.ProtoContract]
    public partial class SmtUserClaimDto : IUserClaimDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int UserID { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string Claim { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public long LastUpdateTime { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public long CreateTime { get; set; }

        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
