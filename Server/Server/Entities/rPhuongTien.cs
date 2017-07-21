using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rPhuongTien : IEntity
    {
        public rPhuongTien()
        {
            rNhanVienMaPhuongTienNavigation = new HashSet<rNhanVien>();
        }

        public int Ma { get; set; }
        public string TenPhuongTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<rNhanVien> rNhanVienMaPhuongTienNavigation { get; set; }
    }
}
