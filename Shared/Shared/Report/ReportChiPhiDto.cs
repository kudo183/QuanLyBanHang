using System;

namespace Shared.Report
{
    [ProtoBuf.ProtoContract]
    public class ReportChiPhiDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int MaLoaiChiPhi { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenLoaiChiPhi { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaNhanVien { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string TenNhanVien { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public DateTime Ngay { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public int SoTien { get; set; }
        [ProtoBuf.ProtoMember(7)]
        public string GhiChu { get; set; }
    }
}
