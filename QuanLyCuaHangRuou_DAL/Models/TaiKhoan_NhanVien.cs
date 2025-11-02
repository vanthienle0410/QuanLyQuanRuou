namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaiKhoan_NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan_NhanVien()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(16)]
        public string MaTK_NV { get; set; }

        [Required]
        [StringLength(64)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(64)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(128)]
        public string TenNV { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(128)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(16)]
        public string MaQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
