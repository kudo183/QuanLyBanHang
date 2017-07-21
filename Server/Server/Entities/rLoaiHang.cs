using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rLoaiHang : IEntity
    {
        public rLoaiHang()
        {
            tMatHangMaLoaiNavigation = new HashSet<tMatHang>();
        }

        public int Ma { get; set; }
        public string TenLoai { get; set; }
        public bool HangNhaLam { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<tMatHang> tMatHangMaLoaiNavigation { get; set; }
    }
}
