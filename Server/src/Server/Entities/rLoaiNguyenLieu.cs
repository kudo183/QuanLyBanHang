using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rLoaiNguyenLieu : IEntity
    {
        public rLoaiNguyenLieu()
        {
            rNguyenLieuMaLoaiNguyenLieuNavigation = new HashSet<rNguyenLieu>();
        }

        public int Ma { get; set; }
        public string TenLoai { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<rNguyenLieu> rNguyenLieuMaLoaiNguyenLieuNavigation { get; set; }
    }
}
