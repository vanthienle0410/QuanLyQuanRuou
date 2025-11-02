namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(16)]
        public string MaKH { get; set; }

        [Required]
        [StringLength(128)]
        public string TenKH { get; set; }

        [StringLength(20)]
        public string SoDienThoai { get; set; }

        [StringLength(128)]
        public string DiaChi { get; set; }
        public virtual ICollection<KyGui_Ruou> KyGui_Ruous { get; set; } = new HashSet<KyGui_Ruou>();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
