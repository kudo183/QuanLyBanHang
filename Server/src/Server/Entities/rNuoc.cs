using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rNuoc : IEntity
    {
        public rNuoc()
        {
            rDiaDiemMaNuocNavigation = new HashSet<rDiaDiem>();
        }

        public int Ma { get; set; }
        public string TenNuoc { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<rDiaDiem> rDiaDiemMaNuocNavigation { get; set; }
    }
}
