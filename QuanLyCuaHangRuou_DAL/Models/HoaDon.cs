namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            HoaDon_ChiTiet = new HashSet<HoaDon_ChiTiet>();
        }

        [Key]
        [StringLength(16)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(16)]

        public string MaKH { get; set; }

        [Required]
        [StringLength(16)]
        public string MaTK_NV { get; set; }

        public DateTime? NgayHoaDon { get; set; }

        public decimal? TongTien { get; set; }

        [StringLength(100)]
        public string TrangThai { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual TaiKhoan_NhanVien TaiKhoan_NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
    }
}