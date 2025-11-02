using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Đảm bảo namespace này khớp với Model1.cs
namespace QuanLyCuaHangRuou_DAL.Models
{
    [Table("KyGui_Ruou")]
    public class KyGui_Ruou
    {
        [Key]
        [StringLength(16)]
        public string MaKyGui { get; set; }

        [StringLength(16)]
        [Required]
        public string MaKH { get; set; }

        [StringLength(128)]
        [Required]
        public string TenRuou { get; set; }

        [Required]
        public decimal DungTichConLai { get; set; }

        [StringLength(10)]
        [Required]
        public string DonViTinh { get; set; }

        public DateTime NgayKyGui { get; set; }

        public DateTime? HanKyGui { get; set; }

        [StringLength(64)]
        public string ViTriLuuTru { get; set; }

        [StringLength(30)]
        [Required]
        public string TrangThai { get; set; }

        // Navigation Property
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
    }
}