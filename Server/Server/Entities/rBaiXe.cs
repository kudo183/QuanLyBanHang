using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rBaiXe : IEntity
    {
        public rBaiXe()
        {
            rChanhMaBaiXeNavigation = new HashSet<rChanh>();
        }

        public int Ma { get; set; }
        public string DiaDiemBaiXe { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<rChanh> rChanhMaBaiXeNavigation { get; set; }
    }
}
