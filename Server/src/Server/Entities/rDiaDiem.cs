using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rDiaDiem : IEntity
    {
        public rDiaDiem()
        {
            rKhachHangMaDiaDiemNavigation = new HashSet<rKhachHang>();
        }

        public int Ma { get; set; }
        public int MaNuoc { get; set; }
        public string Tinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rNuoc MaNuocNavigation { get; set; }
		
		public ICollection<rKhachHang> rKhachHangMaDiaDiemNavigation { get; set; }
    }
}
