using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rLoaiChiPhi : IEntity
    {
        public rLoaiChiPhi()
        {
            tChiPhiMaLoaiChiPhiNavigation = new HashSet<tChiPhi>();
        }

        public int Ma { get; set; }
        public string TenLoaiChiPhi { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<tChiPhi> tChiPhiMaLoaiChiPhiNavigation { get; set; }
    }
}
