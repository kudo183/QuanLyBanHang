using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tTonKho : IEntity
    {
        public tTonKho()
        {
        }

        public int Ma { get; set; }
        public int MaKhoHang { get; set; }
        public int MaMatHang { get; set; }
        public System.DateTime Ngay { get; set; }
        public int SoLuong { get; set; }
        public int SoLuongCu { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rKhoHang MaKhoHangNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
    }
}
