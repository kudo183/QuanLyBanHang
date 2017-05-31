using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tChiTietToaHang : IEntity
    {
        public tChiTietToaHang()
        {
        }

        public int Ma { get; set; }
        public int MaToaHang { get; set; }
        public int MaChiTietDonHang { get; set; }
        public int GiaTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tToaHang MaToaHangNavigation { get; set; }
        public tChiTietDonHang MaChiTietDonHangNavigation { get; set; }
		
    }
}
