using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class tNhapNguyenLieu : IEntity
    {
        public tNhapNguyenLieu()
        {
        }

        public int Ma { get; set; }
        public System.DateTime Ngay { get; set; }
        public int MaNguyenLieu { get; set; }
        public int MaNhaCungCap { get; set; }
        public int SoLuong { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rNguyenLieu MaNguyenLieuNavigation { get; set; }
        public rNhaCungCap MaNhaCungCapNavigation { get; set; }
		
    }
}
