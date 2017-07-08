using System;
using System.Collections.Generic;

namespace Shared.Report
{
    [ProtoBuf.ProtoContract]
    public class XuatDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int MaKho { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenKho { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaKhachHang { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string TenKhachHang { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public List<ChiTietXuatDto> ChiTietXuat { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public DateTime Ngay { get; set; }
    }

    [ProtoBuf.ProtoContract]
    public class ChiTietXuatDto
    {
        [ProtoBuf.ProtoMember(1)]
        public int MaMatHang { get; set; }
        [ProtoBuf.ProtoMember(2)]
        public string TenMatHang { get; set; }
        [ProtoBuf.ProtoMember(3)]
        public int MaLoaiHang { get; set; }
        [ProtoBuf.ProtoMember(4)]
        public string TenLoaiHang { get; set; }
        [ProtoBuf.ProtoMember(5)]
        public int SoLuong { get; set; }
        [ProtoBuf.ProtoMember(6)]
        public int SoKg { get; set; }
    }
}
