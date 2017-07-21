using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using huypq.SmtMiddleware;
using huypq.SmtMiddleware.Entities;
using Server.Entities;

namespace Server.Entities
{
    public partial class SqlDbContext : DbContext, IDbContext<SmtTenant, SmtUser, SmtUserClaim>
    {
	    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<SmtTable>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_SmtTable");
            });
            modelBuilder.Entity<SmtDeletedItem>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_SmtDeletedItem");
            });
            modelBuilder.Entity<SmtTenant>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_SmtTenant");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);
                entity.Property(e => e.TenantName)
                    .IsRequired()
                    .HasMaxLength(256);

            });
            modelBuilder.Entity<SmtUser>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_SmtUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(128);
                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.TenantIDNavigation)
                    .WithMany(p => p.SmtUserTenantIDNavigation)
                    .HasForeignKey(d => d.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SmtUser_SmtTenant");

            });
            modelBuilder.Entity<SmtUserClaim>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK_SmtUserClaim");

                entity.Property(e => e.Claim)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.TenantIDNavigation)
                    .WithMany(p => p.SmtUserClaimTenantIDNavigation)
                    .HasForeignKey(d => d.TenantID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SmtUserClaim_SmtTenant");

                entity.HasOne(d => d.UserIDNavigation)
                    .WithMany(p => p.SmtUserClaimUserIDNavigation)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_SmtUserClaim_SmtUserClaim");

            });
            modelBuilder.Entity<rBaiXe>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rBaiXe");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.DiaDiemBaiXe)
                    .IsRequired()
                    .HasMaxLength(300);

            });
            modelBuilder.Entity<rCanhBaoTonKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rCanhBaoTonKho");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.rCanhBaoTonKhoMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rCanhBaoTonKho_rKhoHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.rCanhBaoTonKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rCanhBaoTonKho_tMatHang");

            });
            modelBuilder.Entity<rChanh>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rChanh");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenChanh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaBaiXeNavigation)
                    .WithMany(p => p.rChanhMaBaiXeNavigation)
                    .HasForeignKey(d => d.MaBaiXe)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rChanh_rBaiXe");

            });
            modelBuilder.Entity<rDiaDiem>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rDiaDiem");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Tinh)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaNuocNavigation)
                    .WithMany(p => p.rDiaDiemMaNuocNavigation)
                    .HasForeignKey(d => d.MaNuoc)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rDiaDiem_rNuoc");

            });
            modelBuilder.Entity<rKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhachHang");

                entity.HasIndex(e => e.TenKhachHang)
                    .HasName("idx_KhachHang_TenKhachHang")
                    .IsUnique();

                entity.Property(e => e.KhachRieng).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaDiaDiemNavigation)
                    .WithMany(p => p.rKhachHangMaDiaDiemNavigation)
                    .HasForeignKey(d => d.MaDiaDiem)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHang_rDiaDiem");

            });
            modelBuilder.Entity<rKhachHangChanh>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhachHangChanh");

                entity.Property(e => e.LaMacDinh).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.rKhachHangChanhMaChanhNavigation)
                    .HasForeignKey(d => d.MaChanh)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.rKhachHangChanhMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rKhachHangChanh_rKhachHang");

            });
            modelBuilder.Entity<rKhoHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rKhoHang");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("(1)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenKho)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<rLoaiChiPhi>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rLoaiChiPhi");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenLoaiChiPhi)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<rLoaiHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rProductType");

                entity.Property(e => e.HangNhaLam).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<rLoaiNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rLoaiNguyenLieu");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<rMatHangNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rMatHangNguyenLieu");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.rMatHangNguyenLieuMaNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rMatHangNguyenLieu_rNguyenLieu");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.rMatHangNguyenLieuMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rMatHangNguyenLieu_tMatHang");

            });
            modelBuilder.Entity<rNuoc>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rNuoc");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenNuoc)
                    .IsRequired()
                    .HasMaxLength(100);

            });
            modelBuilder.Entity<rNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_rNguyenLieu");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaLoaiNguyenLieuNavigation)
                    .WithMany(p => p.rNguyenLieuMaLoaiNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaLoaiNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rNguyenLieu_rLoaiNguyenLieu");

            });
            modelBuilder.Entity<rNhaCungCap>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhaCungCap");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenNhaCungCap)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<rNhanVien>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhanVienGiaoHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenNhanVien)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaPhuongTienNavigation)
                    .WithMany(p => p.rNhanVienMaPhuongTienNavigation)
                    .HasForeignKey(d => d.MaPhuongTien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_rNhanVienGiaoHang_rPhuongTien");

            });
            modelBuilder.Entity<rPhuongTien>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_LoaiPhuongTien");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenPhuongTien)
                    .IsRequired()
                    .HasMaxLength(200);

            });
            modelBuilder.Entity<tCongNoKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tCongNoKhachHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tCongNoKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tCongNoKhachHang_rKhachHang");

            });
            modelBuilder.Entity<tChiPhi>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ChiPhiNhanVienGiaoHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaLoaiChiPhiNavigation)
                    .WithMany(p => p.tChiPhiMaLoaiChiPhiNavigation)
                    .HasForeignKey(d => d.MaLoaiChiPhi)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rLoaiChiPhi");

                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.tChiPhiMaNhanVienGiaoHangNavigation)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiPhiNhanVienGiaoHang_rNhanVienGiaoHang");

            });
            modelBuilder.Entity<tChiTietChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietChuyenHangDonHang");

                entity.Property(e => e.SoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.tChiTietChuyenHangDonHangMaChiTietDonHangNavigation)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenHangDonHang_tChiTietDonHang");

                entity.HasOne(d => d.MaChuyenHangDonHangNavigation)
                    .WithMany(p => p.tChiTietChuyenHangDonHangMaChuyenHangDonHangNavigation)
                    .HasForeignKey(d => d.MaChuyenHangDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenHangDonHang_tChuyenHangDonHang");

            });
            modelBuilder.Entity<tChiTietChuyenKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietChuyenKho");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaChuyenKhoNavigation)
                    .WithMany(p => p.tChiTietChuyenKhoMaChuyenKhoNavigation)
                    .HasForeignKey(d => d.MaChuyenKho)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenKho_tChuyenKho");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.tChiTietChuyenKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietChuyenKho_tMatHang");

            });
            modelBuilder.Entity<tChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietDonHang");

                entity.Property(e => e.Xong).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.tChiTietDonHangMaDonHangNavigation)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietDonHang_tDonHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.tChiTietDonHangMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietDonHang_tMatHang");

            });
            modelBuilder.Entity<tChiTietNhapHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhapMatHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaNhapHangNavigation)
                    .WithMany(p => p.tChiTietNhapHangMaNhapHangNavigation)
                    .HasForeignKey(d => d.MaNhapHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietNhapHang_tNhapHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.tChiTietNhapHangMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapMatHang_tMatHang");

            });
            modelBuilder.Entity<tChiTietToaHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChiTietToaHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaChiTietDonHangNavigation)
                    .WithMany(p => p.tChiTietToaHangMaChiTietDonHangNavigation)
                    .HasForeignKey(d => d.MaChiTietDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietToaHang_tChiTietDonHang");

                entity.HasOne(d => d.MaToaHangNavigation)
                    .WithMany(p => p.tChiTietToaHangMaToaHangNavigation)
                    .HasForeignKey(d => d.MaToaHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChiTietToaHang_tToaHang");

            });
            modelBuilder.Entity<tChuyenHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ChuyenHang");

                entity.Property(e => e.Gio).HasDefaultValueSql("getdate()");

                entity.Property(e => e.TongDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaNhanVienGiaoHangNavigation)
                    .WithMany(p => p.tChuyenHangMaNhanVienGiaoHangNavigation)
                    .HasForeignKey(d => d.MaNhanVienGiaoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHang_rNhanVienGiaoHang");

            });
            modelBuilder.Entity<tChuyenHangDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChuyenHangDonHang");

                entity.Property(e => e.TongSoLuongTheoDonHang).HasDefaultValueSql("(0)");

                entity.Property(e => e.TongSoLuongThucTe).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");


                entity.HasOne(d => d.MaChuyenHangNavigation)
                    .WithMany(p => p.tChuyenHangDonHangMaChuyenHangNavigation)
                    .HasForeignKey(d => d.MaChuyenHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHangDonHang_tChuyenHang");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.tChuyenHangDonHangMaDonHangNavigation)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenHangDonHang_tDonHang");

            });
            modelBuilder.Entity<tChuyenKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tChuyenKho");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhoHangNhapNavigation)
                    .WithMany(p => p.tChuyenKhoMaKhoHangNhapNavigation)
                    .HasForeignKey(d => d.MaKhoHangNhap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rKhoHangNhap");

                entity.HasOne(d => d.MaKhoHangXuatNavigation)
                    .WithMany(p => p.tChuyenKhoMaKhoHangXuatNavigation)
                    .HasForeignKey(d => d.MaKhoHangXuat)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rKhoHangXuat");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.tChuyenKhoMaNhanVienNavigation)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tChuyenKho_rNhanVien");

            });
            modelBuilder.Entity<tDonHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_DonHang");

                entity.Property(e => e.Xong).HasDefaultValueSql("(0)");

                entity.Property(e => e.MaKhoHang).HasDefaultValueSql("(1)");

                entity.Property(e => e.TongSoLuong).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaChanhNavigation)
                    .WithMany(p => p.tDonHangMaChanhNavigation)
                    .HasForeignKey(d => d.MaChanh)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rChanh");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tDonHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhachHang");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.tDonHangMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tDonHang_rKhoHang");

            });
            modelBuilder.Entity<tGiamTruKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tGiamTruKhachHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");
                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tGiamTruKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tGiamTruKhachHang_rKhachHang");

            });
            modelBuilder.Entity<tMatHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_Product");

                entity.Property(e => e.SoKy).HasDefaultValueSql("(0)");

                entity.Property(e => e.SoMet).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenMatHangDayDu).HasDefaultValueSql("''");

                entity.Property(e => e.TenMatHangIn).HasDefaultValueSql("''");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.TenMatHang)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.TenMatHangDayDu)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.TenMatHangIn)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.tMatHangMaLoaiNavigation)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tMatHang_rLoaiHang");

            });
            modelBuilder.Entity<tNhanTienKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tNhanTienKhachHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tNhanTienKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhanTienKhachHang_rKhachHang");

            });
            modelBuilder.Entity<tNhapHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tNhapHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.tNhapHangMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rKhoHang");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.tNhapHangMaNhaCungCapNavigation)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhaCungCap");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.tNhapHangMaNhanVienNavigation)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapHang_rNhanVien");

            });
            modelBuilder.Entity<tNhapNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_NhapNguyenLieu");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaNguyenLieuNavigation)
                    .WithMany(p => p.tNhapNguyenLieuMaNguyenLieuNavigation)
                    .HasForeignKey(d => d.MaNguyenLieu)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNguyenLieu");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.tNhapNguyenLieuMaNhaCungCapNavigation)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tNhapNguyenLieu_rNhaCungCap");

            });
            modelBuilder.Entity<tPhuThuKhachHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tPhuThuKhachHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");
                entity.Property(e => e.GhiChu)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tPhuThuKhachHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tPhuThuKhachHang_rKhachHang");

            });
            modelBuilder.Entity<tToaHang>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tToaHang");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.tToaHangMaKhachHangNavigation)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tToaHang_rKhachHang");

            });
            modelBuilder.Entity<tTonKho>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_tTonKho");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.Ngay).HasColumnType("date(0)");

                entity.HasOne(d => d.MaKhoHangNavigation)
                    .WithMany(p => p.tTonKhoMaKhoHangNavigation)
                    .HasForeignKey(d => d.MaKhoHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_rKhoHang");

                entity.HasOne(d => d.MaMatHangNavigation)
                    .WithMany(p => p.tTonKhoMaMatHangNavigation)
                    .HasForeignKey(d => d.MaMatHang)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_tTonKho_tMatHang");

            });
            modelBuilder.Entity<ThamSoNgay>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK_ThamSoNgay");

                entity.Property(e => e.TenantID).HasDefaultValueSql("(1)");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.LastUpdateTime).HasDefaultValueSql("(0)");

                entity.Property(e => e.GiaTri).HasColumnType("date(0)");
                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

            });
        }
		
		public DbSet<SmtTable> SmtTable { get; set; }
        public DbSet<SmtDeletedItem> SmtDeletedItem { get; set; }
		public DbSet<SmtTenant> SmtTenant { get; set; }
        public DbSet<SmtUser> SmtUser { get; set; }
        public DbSet<SmtUserClaim> SmtUserClaim { get; set; }
        public DbSet<rBaiXe> rBaiXe { get; set; }
        public DbSet<rCanhBaoTonKho> rCanhBaoTonKho { get; set; }
        public DbSet<rChanh> rChanh { get; set; }
        public DbSet<rDiaDiem> rDiaDiem { get; set; }
        public DbSet<rKhachHang> rKhachHang { get; set; }
        public DbSet<rKhachHangChanh> rKhachHangChanh { get; set; }
        public DbSet<rKhoHang> rKhoHang { get; set; }
        public DbSet<rLoaiChiPhi> rLoaiChiPhi { get; set; }
        public DbSet<rLoaiHang> rLoaiHang { get; set; }
        public DbSet<rLoaiNguyenLieu> rLoaiNguyenLieu { get; set; }
        public DbSet<rMatHangNguyenLieu> rMatHangNguyenLieu { get; set; }
        public DbSet<rNuoc> rNuoc { get; set; }
        public DbSet<rNguyenLieu> rNguyenLieu { get; set; }
        public DbSet<rNhaCungCap> rNhaCungCap { get; set; }
        public DbSet<rNhanVien> rNhanVien { get; set; }
        public DbSet<rPhuongTien> rPhuongTien { get; set; }
        public DbSet<tCongNoKhachHang> tCongNoKhachHang { get; set; }
        public DbSet<tChiPhi> tChiPhi { get; set; }
        public DbSet<tChiTietChuyenHangDonHang> tChiTietChuyenHangDonHang { get; set; }
        public DbSet<tChiTietChuyenKho> tChiTietChuyenKho { get; set; }
        public DbSet<tChiTietDonHang> tChiTietDonHang { get; set; }
        public DbSet<tChiTietNhapHang> tChiTietNhapHang { get; set; }
        public DbSet<tChiTietToaHang> tChiTietToaHang { get; set; }
        public DbSet<tChuyenHang> tChuyenHang { get; set; }
        public DbSet<tChuyenHangDonHang> tChuyenHangDonHang { get; set; }
        public DbSet<tChuyenKho> tChuyenKho { get; set; }
        public DbSet<tDonHang> tDonHang { get; set; }
        public DbSet<tGiamTruKhachHang> tGiamTruKhachHang { get; set; }
        public DbSet<tMatHang> tMatHang { get; set; }
        public DbSet<tNhanTienKhachHang> tNhanTienKhachHang { get; set; }
        public DbSet<tNhapHang> tNhapHang { get; set; }
        public DbSet<tNhapNguyenLieu> tNhapNguyenLieu { get; set; }
        public DbSet<tPhuThuKhachHang> tPhuThuKhachHang { get; set; }
        public DbSet<tToaHang> tToaHang { get; set; }
        public DbSet<tTonKho> tTonKho { get; set; }
        public DbSet<ThamSoNgay> ThamSoNgay { get; set; }
    }
}
