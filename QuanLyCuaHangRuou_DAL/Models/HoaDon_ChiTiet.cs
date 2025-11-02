namespace QuanLyCuaHangRuou_DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_ChiTiet
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string MaDo_Uong { get; set; }

        public decimal DonGia { get; set; }

        public decimal SoLuong { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ThanhTien { get; set; }

        public virtual DoUong DoUong { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
