using System;
using System.Collections.Generic;

namespace Shared.Report
{
    [ProtoBuf.ProtoContract]
    public class KhachHangDto
    {
        [ProtoBuf.ProtoMember(1)]
        public DateTime Ngay { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public int MaKho { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public string TenKho { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public List<ChiTietKhachHangDto> ChiTiet { get; set; }
    }

    [ProtoBuf.ProtoContract]
    public class ChiTietKhachHangDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int MaMatHang { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenMatHang { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int SoLuong { get; set; }
    }
}
