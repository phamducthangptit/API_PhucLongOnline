using System;
using System.Collections.Generic;
using API_PhucLongOnline.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_PhucLongOnline.Data
{
    public partial class PhucLongOnlineContext : DbContext
    {
        public PhucLongOnlineContext()
        {
        }

        public PhucLongOnlineContext(DbContextOptions<PhucLongOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BangGium> BangGia { get; set; } = null!;
        public virtual DbSet<CongThuc> CongThucs { get; set; } = null!;
        public virtual DbSet<CtBangGium> CtBangGia { get; set; } = null!;
        public virtual DbSet<CtDonDatHang> CtDonDatHangs { get; set; } = null!;
        public virtual DbSet<CtDonHang> CtDonHangs { get; set; } = null!;
        public virtual DbSet<CtNguyenLieu> CtNguyenLieus { get; set; } = null!;
        public virtual DbSet<CtPhieuNhapHang> CtPhieuNhapHangs { get; set; } = null!;
        public virtual DbSet<CtSanPhamSize> CtSanPhamSizes { get; set; } = null!;
        public virtual DbSet<DonDatNguyenLieu> DonDatNguyenLieus { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<GioHang> GioHangs { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; } = null!;
        public virtual DbSet<NguyenLieu> NguyenLieus { get; set; } = null!;
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; } = null!;
        public virtual DbSet<Quyen> Quyens { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=PhucLongOnline;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangGium>(entity =>
            {
                entity.HasKey(e => e.IdBangGia);

                entity.Property(e => e.NgayApDung).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.TenLoaiGia).HasMaxLength(100);
            });

            modelBuilder.Entity<CongThuc>(entity =>
            {
                entity.HasKey(e => e.IdCongThuc);

                entity.ToTable("CongThuc");

                entity.HasIndex(e => new { e.IdSanPhamSize, e.IdNguyenLieu }, "UK_CongThuc")
                    .IsUnique();

                entity.Property(e => e.DonVi).HasMaxLength(10);

                entity.HasOne(d => d.IdNguyenLieuNavigation)
                    .WithMany(p => p.CongThucs)
                    .HasForeignKey(d => d.IdNguyenLieu)
                    .HasConstraintName("FK_CongThuc_NguyenLieu");

                entity.HasOne(d => d.IdSanPhamSizeNavigation)
                    .WithMany(p => p.CongThucs)
                    .HasForeignKey(d => d.IdSanPhamSize)
                    .HasConstraintName("FK_CongThuc_CT_SanPham_Size");
            });

            modelBuilder.Entity<CtBangGium>(entity =>
            {
                entity.HasKey(e => e.IdCtbangGia);

                entity.ToTable("CT_BangGia");

                entity.HasIndex(e => new { e.IdSanPhamSize, e.IdBangGia }, "UK_CT_BangGia")
                    .IsUnique();

                entity.Property(e => e.IdCtbangGia).HasColumnName("IdCTBangGia");

                entity.HasOne(d => d.IdBangGiaNavigation)
                    .WithMany(p => p.CtBangGia)
                    .HasForeignKey(d => d.IdBangGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BangGia_BangGia");

                entity.HasOne(d => d.IdSanPhamSizeNavigation)
                    .WithMany(p => p.CtBangGia)
                    .HasForeignKey(d => d.IdSanPhamSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_BangGia_CT_SanPham_Size");
            });

            modelBuilder.Entity<CtDonDatHang>(entity =>
            {
                entity.HasKey(e => e.IdCtdonDatHang);

                entity.ToTable("CT_DonDatHang");

                entity.HasIndex(e => new { e.IdDonDatNguyenLieu, e.IdNguyenLieu, e.MaNhaCungCap }, "UK_CTDonDatHang")
                    .IsUnique();

                entity.Property(e => e.IdCtdonDatHang)
                    .ValueGeneratedNever()
                    .HasColumnName("IdCTDonDatHang");

                entity.Property(e => e.MaNhaCungCap).HasMaxLength(10);

                entity.HasOne(d => d.IdDonDatNguyenLieuNavigation)
                    .WithMany(p => p.CtDonDatHangs)
                    .HasForeignKey(d => d.IdDonDatNguyenLieu)
                    .HasConstraintName("FK_CT_DonDatHang_DonDatNguyenLieu");

                entity.HasOne(d => d.IdNguyenLieuNavigation)
                    .WithMany(p => p.CtDonDatHangs)
                    .HasForeignKey(d => d.IdNguyenLieu)
                    .HasConstraintName("FK_CT_DonDatHang_NguyenLieu");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.CtDonDatHangs)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("FK_CT_DonDatHang_NhaCungCap");
            });

            modelBuilder.Entity<CtDonHang>(entity =>
            {
                entity.HasKey(e => e.IdCtdonHang)
                    .HasName("PK_CT_DonHang_1");

                entity.ToTable("CT_DonHang");

                entity.HasIndex(e => new { e.IdDonHang, e.IdSanPhamSize }, "UK_CT_DonHang")
                    .IsUnique();

                entity.Property(e => e.IdCtdonHang).HasColumnName("IdCTDonHang");

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.CtDonHangs)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DonHang_DonHang");

                entity.HasOne(d => d.IdSanPhamSizeNavigation)
                    .WithMany(p => p.CtDonHangs)
                    .HasForeignKey(d => d.IdSanPhamSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_DonHang_CT_SanPham_Size");
            });

            modelBuilder.Entity<CtNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.IdCtnguyenLieu);

                entity.ToTable("CT_NguyenLieu");

                entity.HasIndex(e => new { e.IdNguyenLieu, e.MaNhaCungCap }, "UK_NguyenLieu")
                    .IsUnique();

                entity.Property(e => e.IdCtnguyenLieu)
                    .ValueGeneratedNever()
                    .HasColumnName("IdCTNguyenLieu");

                entity.Property(e => e.MaNhaCungCap).HasMaxLength(10);

                entity.HasOne(d => d.IdNguyenLieuNavigation)
                    .WithMany(p => p.CtNguyenLieus)
                    .HasForeignKey(d => d.IdNguyenLieu)
                    .HasConstraintName("FK_CT_NguyenLieu_NguyenLieu");

                entity.HasOne(d => d.MaNhaCungCapNavigation)
                    .WithMany(p => p.CtNguyenLieus)
                    .HasForeignKey(d => d.MaNhaCungCap)
                    .HasConstraintName("FK_CT_NguyenLieu_NhaCungCap");
            });

            modelBuilder.Entity<CtPhieuNhapHang>(entity =>
            {
                entity.HasKey(e => e.IdCtphieuNhapHang);

                entity.ToTable("CT_PhieuNhapHang");

                entity.HasIndex(e => new { e.IdCtdonDatHang, e.IdPhieuNhapHang, e.LanNhap }, "UK_CTPhieuNhapHang")
                    .IsUnique();

                entity.Property(e => e.IdCtphieuNhapHang).HasColumnName("IdCTPhieuNhapHang");

                entity.Property(e => e.IdCtdonDatHang).HasColumnName("IdCTDonDatHang");

                entity.HasOne(d => d.IdCtdonDatHangNavigation)
                    .WithMany(p => p.CtPhieuNhapHangs)
                    .HasForeignKey(d => d.IdCtdonDatHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_PhieuNhapHang_CT_DonDatHang");

                entity.HasOne(d => d.IdPhieuNhapHangNavigation)
                    .WithMany(p => p.CtPhieuNhapHangs)
                    .HasForeignKey(d => d.IdPhieuNhapHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_PhieuNhapHang_PhieuNhapHang");
            });

            modelBuilder.Entity<CtSanPhamSize>(entity =>
            {
                entity.HasKey(e => e.IdSanPhamSize);

                entity.ToTable("CT_SanPham_Size");

                entity.HasIndex(e => new { e.IdSize, e.IdSanPham }, "UK_CT_SanPham_Size")
                    .IsUnique();

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.CtSanPhamSizes)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_SanPham_Size_SanPham");

                entity.HasOne(d => d.IdSizeNavigation)
                    .WithMany(p => p.CtSanPhamSizes)
                    .HasForeignKey(d => d.IdSize)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CT_SanPham_Size_Size");
            });

            modelBuilder.Entity<DonDatNguyenLieu>(entity =>
            {
                entity.HasKey(e => e.IdDonDatNguyenLieu);

                entity.ToTable("DonDatNguyenLieu");

                entity.Property(e => e.MaNhanVien).HasMaxLength(10);

                entity.Property(e => e.NgayDat).HasColumnType("date");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.DonDatNguyenLieus)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_DonDatNguyenLieu_NhanVien");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.IdDonHang);

                entity.ToTable("DonHang");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.Property(e => e.TenDangNhap).HasMaxLength(10);

                entity.Property(e => e.TrangThaiDonHang).HasMaxLength(20);

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.IdHoaDon)
                    .HasConstraintName("FK_DonHang_HoaDon");
            });

            modelBuilder.Entity<GioHang>(entity =>
            {
                entity.HasKey(e => e.IdGioHang);

                entity.ToTable("GioHang");

                entity.HasIndex(e => new { e.IdSanPhamSize, e.TenDangNhap }, "UK_GioHang")
                    .IsUnique();

                entity.Property(e => e.TenDangNhap).HasMaxLength(10);

                entity.HasOne(d => d.IdSanPhamSizeNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.IdSanPhamSize)
                    .HasConstraintName("FK_GioHang_CT_SanPham_Size");

                entity.HasOne(d => d.TenDangNhapNavigation)
                    .WithMany(p => p.GioHangs)
                    .HasForeignKey(d => d.TenDangNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GioHang_TaiKhoan");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.NgayLap).HasColumnType("date");

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_DonHang");

                entity.HasOne(d => d.IdVoucherNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdVoucher)
                    .HasConstraintName("FK_HoaDon_Voucher");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap);

                entity.ToTable("KhachHang");

                entity.Property(e => e.TenDangNhap).HasMaxLength(10);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.HinhAnh).HasMaxLength(100);

                entity.Property(e => e.Ho).HasMaxLength(10);

                entity.Property(e => e.Mst)
                    .HasMaxLength(15)
                    .HasColumnName("MST");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.TenDangNhapNavigation)
                    .WithOne(p => p.KhachHang)
                    .HasForeignKey<KhachHang>(d => d.TenDangNhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_TaiKhoan");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.IdLoaiSanPham);

                entity.ToTable("LoaiSanPham");

                entity.HasIndex(e => e.TenLoai, "UK_LoaiSanPham")
                    .IsUnique();

                entity.Property(e => e.IdLoaiSanPham).ValueGeneratedNever();

                entity.Property(e => e.TenLoai).HasMaxLength(50);
            });

            modelBuilder.Entity<NguyenLieu>(entity =>
            {
                entity.HasKey(e => e.IdNguyenLieu);

                entity.ToTable("NguyenLieu");

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.TenNguyenLieu).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNhaCungCap);

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNhaCungCap).HasMaxLength(10);

                entity.Property(e => e.TenNhaCungCap).HasMaxLength(50);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.ToTable("NhanVien");

                entity.Property(e => e.MaNhanVien).HasMaxLength(10);

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.GioiTinh).HasMaxLength(5);

                entity.Property(e => e.HinhAnh).HasMaxLength(100);

                entity.Property(e => e.Ho).HasMaxLength(10);

                entity.Property(e => e.HopDong).HasColumnType("date");

                entity.Property(e => e.Mst)
                    .HasMaxLength(15)
                    .HasColumnName("MST");

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .HasColumnName("SDT");

                entity.Property(e => e.SoBhxh)
                    .HasMaxLength(15)
                    .HasColumnName("SoBHXH");

                entity.Property(e => e.Ten).HasMaxLength(50);

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithOne(p => p.NhanVien)
                    .HasForeignKey<NhanVien>(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NhanVien_TaiKhoan");
            });

            modelBuilder.Entity<PhieuNhapHang>(entity =>
            {
                entity.HasKey(e => e.IdPhieuNhapHang);

                entity.ToTable("PhieuNhapHang");

                entity.Property(e => e.MaNhanVien).HasMaxLength(10);

                entity.Property(e => e.NgayLapPhieuNhap).HasColumnType("date");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.PhieuNhapHangs)
                    .HasForeignKey(d => d.MaNhanVien)
                    .HasConstraintName("FK_PhieuNhapHang_NhanVien1");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.HasKey(e => e.IdQuyen);

                entity.ToTable("Quyen");

                entity.Property(e => e.IdQuyen).ValueGeneratedNever();

                entity.Property(e => e.CapDo).HasMaxLength(20);

                entity.Property(e => e.ChucVu).HasMaxLength(20);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.IdSanPham);

                entity.ToTable("SanPham");

                entity.HasIndex(e => e.TenSanPham, "UK_SanPham")
                    .IsUnique();

                entity.Property(e => e.CachPhaChe).HasMaxLength(200);

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.IdLoaiSanPhamNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.IdLoaiSanPham)
                    .HasConstraintName("FK_SanPham_LoaiSanPham");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.IdSize);

                entity.ToTable("Size");

                entity.Property(e => e.TenSize).HasMaxLength(5);
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap);

                entity.ToTable("TaiKhoan");

                entity.Property(e => e.TenDangNhap).HasMaxLength(10);

                entity.Property(e => e.MatKhau).HasMaxLength(50);

                entity.HasOne(d => d.IdQuyenNavigation)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.IdQuyen)
                    .HasConstraintName("FK_TaiKhoan_Quyen");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.IdVoucher);

                entity.ToTable("Voucher");

                entity.Property(e => e.NgayApDung).HasColumnType("date");

                entity.Property(e => e.NgayHetHan).HasColumnType("date");

                entity.Property(e => e.NoiDung).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
