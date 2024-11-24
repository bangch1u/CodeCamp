using System;
using System.Collections.Generic;
using Da_QLKS.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.Context;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DichVuChiTiet> DichVuChiTiets { get; set; }

    public virtual DbSet<HangPhong> HangPhongs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuDatPhongChiTiet> PhieuDatPhongChiTiets { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BANGCHIU105\\SQLEXPRESS01;Initial Catalog=QLKS2;Integrated Security=True ;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__dichVu__80F48B091100E7C7");
        });

        modelBuilder.Entity<DichVuChiTiet>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaDichVu }).HasName("PK__dichVuCh__8A64052A2FBECD9D");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.DichVuChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dichVuChi__maDic__3A81B327");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.DichVuChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dichVuChi__maHoa__398D8EEE");
        });

        modelBuilder.Entity<HangPhong>(entity =>
        {
            entity.HasKey(e => e.MaHangPhong).HasName("PK__hangPhon__E092382A4032D92E");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__hoaDon__026B4D9A4932A816");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK__hoaDon__maKhachH__2A4B4B5E");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK__hoaDon__maNhanVi__2B3F6F97");

            entity.HasOne(d => d.MaThanhToanNavigation).WithMany(p => p.HoaDons).HasConstraintName("FK__hoaDon__maThanhT__2C3393D0");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__khachHan__0CCB3D4935D151CE");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__nhanVien__BDDEF20D4DB37F00");
        });

        modelBuilder.Entity<PhieuDatPhongChiTiet>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaPhong }).HasName("PK__phieuDat__16A6187B67D9206F");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.PhieuDatPhongChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__phieuDatP__maHoa__35BCFE0A");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.PhieuDatPhongChiTiets)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__phieuDatP__maPho__36B12243");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__phong__4CD55E10E9254A6B");

            entity.HasOne(d => d.MaHangPhongNavigation).WithMany(p => p.Phongs).HasConstraintName("FK__phong__maHangPho__30F848ED");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__thanhToa__7675FE60DE4E363C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
