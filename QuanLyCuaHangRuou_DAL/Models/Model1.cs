using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace QuanLyCuaHangRuou_DAL.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<DoUong> DoUongs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan_NhanVien> TaiKhoan_NhanVien { get; set; }

        // BỔ SUNG: DbSet cho Bảng Ký Gửi Rượu
        public virtual DbSet<KyGui_Ruou> KyGui_Ruous { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoUong>()
                .HasMany(e => e.HoaDon_ChiTiet)
                .WithRequired(e => e.DoUong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TrangThai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.HoaDon_ChiTiet)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon_ChiTiet>()
                .Property(e => e.ThanhTien)
                .HasPrecision(37, 4);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            // BỔ SUNG: Thiết lập mối quan hệ KhachHang -> KyGui_Ruou
            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.KyGui_Ruous)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.TaiKhoan_NhanVien)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan_NhanVien>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.TaiKhoan_NhanVien)
                .WillCascadeOnDelete(false);
        }
    }
}