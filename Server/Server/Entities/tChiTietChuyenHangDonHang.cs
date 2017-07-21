using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tChiTietChuyenHangDonHang : IEntity
    {
        public tChiTietChuyenHangDonHang()
        {
        }

        public int Ma { get; set; }
        public int MaChuyenHangDonHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongTheoDonHang { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tChuyenHangDonHang MaChuyenHangDonHangNavigation { get; set; }
        public tChiTietDonHang MaChiTietDonHangNavigation { get; set; }
		
    }
}
