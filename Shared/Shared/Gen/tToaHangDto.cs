﻿using huypq.SmtShared;

namespace Shared
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tToaHangDto : IDto
    {
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public System.DateTime Ngay { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public int TenantID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public long CreateTime { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public long LastUpdateTime { get; set;}

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
