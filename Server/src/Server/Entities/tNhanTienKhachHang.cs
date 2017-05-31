using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tNhanTienKhachHang : IEntity
    {
        public tNhanTienKhachHang()
        {
        }

        public int Ma { get; set; }
        public int MaKhachHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoTien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rKhachHang MaKhachHangNavigation { get; set; }
		
    }
}
