using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("phong")]
public partial class Phong
{
    [Key]
    [Column("maPhong")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaPhong { get; set; } = null!;

    [Column("tenPhong")]
    [StringLength(50)]
    public string? TenPhong { get; set; }

    [Column("dienTich")]
    public double? DienTich { get; set; }

    [Column("soLuongKhach")]
    public int? SoLuongKhach { get; set; }

    [Column("soGiuong")]
    public int? SoGiuong { get; set; }

    [Column("maHangPhong")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaHangPhong { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [ForeignKey("MaHangPhong")]
    [InverseProperty("Phongs")]
    public virtual HangPhong? MaHangPhongNavigation { get; set; }

    [InverseProperty("MaPhongNavigation")]
    public virtual ICollection<PhieuDatPhongChiTiet> PhieuDatPhongChiTiets { get; set; } = new List<PhieuDatPhongChiTiet>();
}
