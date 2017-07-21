using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rKhachHangChanh : IEntity
    {
        public rKhachHangChanh()
        {
        }

        public int Ma { get; set; }
        public int MaChanh { get; set; }
        public int MaKhachHang { get; set; }
        public bool LaMacDinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rChanh MaChanhNavigation { get; set; }
        public rKhachHang MaKhachHangNavigation { get; set; }
		
    }
}
