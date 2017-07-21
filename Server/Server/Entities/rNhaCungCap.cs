using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rNhaCungCap : IEntity
    {
        public rNhaCungCap()
        {
            tNhapHangMaNhaCungCapNavigation = new HashSet<tNhapHang>();
            tNhapNguyenLieuMaNhaCungCapNavigation = new HashSet<tNhapNguyenLieu>();
        }

        public int Ma { get; set; }
        public string TenNhaCungCap { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

		
		public ICollection<tNhapHang> tNhapHangMaNhaCungCapNavigation { get; set; }
		public ICollection<tNhapNguyenLieu> tNhapNguyenLieuMaNhaCungCapNavigation { get; set; }
    }
}
