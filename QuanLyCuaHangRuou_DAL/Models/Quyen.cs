namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quyen")]
    public partial class Quyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quyen()
        {
            TaiKhoan_NhanVien = new HashSet<TaiKhoan_NhanVien>();
        }

        [Key]
        [StringLength(16)]
        public string MaQuyen { get; set; }

        [Required]
        [StringLength(64)]
        public string TenQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan_NhanVien> TaiKhoan_NhanVien { get; set; }
    }
}
