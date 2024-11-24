using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[PrimaryKey("MaHoaDon", "MaPhong")]
[Table("phieuDatPhongChiTiet")]
public partial class PhieuDatPhongChiTiet
{
    [Key]
    [Column("maHoaDon")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHoaDon { get; set; } = null!;

    [Key]
    [Column("maPhong")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaPhong { get; set; } = null!;

    [Column("ngayNhan", TypeName = "datetime")]
    public DateTime? NgayNhan { get; set; }

    [Column("ngayTra", TypeName = "datetime")]
    public DateTime? NgayTra { get; set; }

    [Column("soNgayThue")]
    public int? SoNgayThue { get; set; }

    [Column("donGia", TypeName = "money")]
    public decimal? DonGia { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [ForeignKey("MaHoaDon")]
    [InverseProperty("PhieuDatPhongChiTiets")]
    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;

    [ForeignKey("MaPhong")]
    [InverseProperty("PhieuDatPhongChiTiets")]
    public virtual Phong MaPhongNavigation { get; set; } = null!;
}
