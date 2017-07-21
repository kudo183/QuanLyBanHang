using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tChiTietNhapHang : IEntity
    {
        public tChiTietNhapHang()
        {
        }

        public int Ma { get; set; }
        public int MaNhapHang { get; set; }
        public int MaMatHang { get; set; }
        public int SoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public tNhapHang MaNhapHangNavigation { get; set; }
        public tMatHang MaMatHangNavigation { get; set; }
		
    }
}
