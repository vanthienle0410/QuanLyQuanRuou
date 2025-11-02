namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoUong")]
    public partial class DoUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoUong()
        {
            HoaDon_ChiTiet = new HashSet<HoaDon_ChiTiet>();
        }

        [Key]
        [StringLength(16)]
        public string MaDo_Uong { get; set; }

        [Required]
        [StringLength(128)]
        public string TenDo_Uong { get; set; }

        public decimal DonGia { get; set; }

        public decimal? SoLuongTon { get; set; }

        [StringLength(256)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
    }
}
