﻿using huypq.SmtShared;

namespace Shared
{
    [Newtonsoft.Json.JsonObject(Newtonsoft.Json.MemberSerialization.OptIn)]
    [ProtoBuf.ProtoContract]
    public partial class tChuyenHangDto : IDto
    {
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(1)]
        public int ID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(2)]
        public int MaNhanVienGiaoHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(3)]
        public System.DateTime Ngay { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(4)]
        public System.TimeSpan? Gio { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(5)]
        public int TongDonHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(6)]
        public int TongSoLuongTheoDonHang { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(7)]
        public int TongSoLuongThucTe { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(8)]
        public int TenantID { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(9)]
        public long CreateTime { get; set;}
        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(10)]
        public long LastUpdateTime { get; set;}

        [Newtonsoft.Json.JsonProperty]
        [ProtoBuf.ProtoMember(100)]
        public int State { get; set; }
    }
}
