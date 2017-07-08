namespace Shared.Report
{
    [ProtoBuf.ProtoContract]
    public class DailyDto
    {
        [ProtoBuf.ProtoMember(1)]
        public string TenKho { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenKhachHang { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string TenMatHang { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public int SoLuong { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public int SoKg { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string SoLuongString
        {
            get
            {
                if (TenMatHang != null) return SoLuong.ToString();
                return string.Empty;
            }
        }
    }
}
