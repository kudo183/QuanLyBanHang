using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rNhanVien : IEntity
    {
        public rNhanVien()
        {
            tChiPhiMaNhanVienGiaoHangNavigation = new HashSet<tChiPhi>();
            tChuyenHangMaNhanVienGiaoHangNavigation = new HashSet<tChuyenHang>();
            tChuyenKhoMaNhanVienNavigation = new HashSet<tChuyenKho>();
            tNhapHangMaNhanVienNavigation = new HashSet<tNhapHang>();
        }

        public int Ma { get; set; }
        public int MaPhuongTien { get; set; }
        public string TenNhanVien { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rPhuongTien MaPhuongTienNavigation { get; set; }
		
		public ICollection<tChiPhi> tChiPhiMaNhanVienGiaoHangNavigation { get; set; }
		public ICollection<tChuyenHang> tChuyenHangMaNhanVienGiaoHangNavigation { get; set; }
		public ICollection<tChuyenKho> tChuyenKhoMaNhanVienNavigation { get; set; }
		public ICollection<tNhapHang> tNhapHangMaNhanVienNavigation { get; set; }
    }
}
