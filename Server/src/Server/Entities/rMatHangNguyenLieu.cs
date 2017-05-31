using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rMatHangNguyenLieu : IEntity
    {
        public rMatHangNguyenLieu()
        {
        }

        public int Ma { get; set; }
        public int MaMatHang { get; set; }
        public int MaNguyenLieu { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tMatHang MaMatHangNavigation { get; set; }
        public rNguyenLieu MaNguyenLieuNavigation { get; set; }
		
    }
}
