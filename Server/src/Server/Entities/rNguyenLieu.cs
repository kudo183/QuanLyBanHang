using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rNguyenLieu : IEntity
    {
        public rNguyenLieu()
        {
            rMatHangNguyenLieuMaNguyenLieuNavigation = new HashSet<rMatHangNguyenLieu>();
            tNhapNguyenLieuMaNguyenLieuNavigation = new HashSet<tNhapNguyenLieu>();
        }

        public int Ma { get; set; }
        public int MaLoaiNguyenLieu { get; set; }
        public int DuongKinh { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rLoaiNguyenLieu MaLoaiNguyenLieuNavigation { get; set; }
		
		public ICollection<rMatHangNguyenLieu> rMatHangNguyenLieuMaNguyenLieuNavigation { get; set; }
		public ICollection<tNhapNguyenLieu> tNhapNguyenLieuMaNguyenLieuNavigation { get; set; }
    }
}
