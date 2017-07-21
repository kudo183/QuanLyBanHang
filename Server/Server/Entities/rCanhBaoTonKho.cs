using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rCanhBaoTonKho : IEntity
    {
        public rCanhBaoTonKho()
        {
        }

        public int Ma { get; set; }
        public int MaMatHang { get; set; }
        public int MaKhoHang { get; set; }
        public int TonCaoNhat { get; set; }
        public int TonThapNhat { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tMatHang MaMatHangNavigation { get; set; }
        public rKhoHang MaKhoHangNavigation { get; set; }
		
    }
}
