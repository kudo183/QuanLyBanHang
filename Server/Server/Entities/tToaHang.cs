using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tToaHang : IEntity
    {
        public tToaHang()
        {
            tChiTietToaHangMaToaHangNavigation = new HashSet<tChiTietToaHang>();
        }

        public int Ma { get; set; }
        public System.DateTime Ngay { get; set; }
        public int MaKhachHang { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rKhachHang MaKhachHangNavigation { get; set; }
		
		public ICollection<tChiTietToaHang> tChiTietToaHangMaToaHangNavigation { get; set; }
    }
}
