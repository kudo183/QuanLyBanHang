﻿using System.Collections.Generic;
using huypq.SmtMiddleware;

namespace Server.Entities
{
    public partial class rKhachHang : IEntity
    {
        public rKhachHang()
        {
            rKhachHangChanhMaKhachHangNavigation = new HashSet<rKhachHangChanh>();
            tCongNoKhachHangMaKhachHangNavigation = new HashSet<tCongNoKhachHang>();
            tDonHangMaKhachHangNavigation = new HashSet<tDonHang>();
            tGiamTruKhachHangMaKhachHangNavigation = new HashSet<tGiamTruKhachHang>();
            tNhanTienKhachHangMaKhachHangNavigation = new HashSet<tNhanTienKhachHang>();
            tPhuThuKhachHangMaKhachHangNavigation = new HashSet<tPhuThuKhachHang>();
            tToaHangMaKhachHangNavigation = new HashSet<tToaHang>();
        }

        public int Ma { get; set; }
        public int MaDiaDiem { get; set; }
        public string TenKhachHang { get; set; }
        public bool KhachRieng { get; set; }
        public int TenantID { get; set; }
        public long CreateTime { get; set; }
        public long LastUpdateTime { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int ID { get { return Ma; } set { Ma = value;} }

        public rDiaDiem MaDiaDiemNavigation { get; set; }
		
		public ICollection<rKhachHangChanh> rKhachHangChanhMaKhachHangNavigation { get; set; }
		public ICollection<tCongNoKhachHang> tCongNoKhachHangMaKhachHangNavigation { get; set; }
		public ICollection<tDonHang> tDonHangMaKhachHangNavigation { get; set; }
		public ICollection<tGiamTruKhachHang> tGiamTruKhachHangMaKhachHangNavigation { get; set; }
		public ICollection<tNhanTienKhachHang> tNhanTienKhachHangMaKhachHangNavigation { get; set; }
		public ICollection<tPhuThuKhachHang> tPhuThuKhachHangMaKhachHangNavigation { get; set; }
		public ICollection<tToaHang> tToaHangMaKhachHangNavigation { get; set; }
    }
}
