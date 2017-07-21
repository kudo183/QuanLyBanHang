using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tChuyenHangDonHang : IEntity
    {
        public tChuyenHangDonHang()
        {
            tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation = new HashSet<tChiTietChuyenHangDonHang>();
        }

        public int Ma { get; set; }
        public int MaChuyenHang { get; set; }
        public int MaDonHang { get; set; }
        public int TongSoLuongTheoDonHang { get; set; }
        public int TongSoLuongThucTe { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tChuyenHang MaChuyenHangNavigation { get; set; }
        public tDonHang MaDonHangNavigation { get; set; }
		
		public ICollection<tChiTietChuyenHangDonHang> tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation { get; set; }
    }
}
