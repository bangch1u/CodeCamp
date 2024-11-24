using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[PrimaryKey("MaHoaDon", "MaDichVu")]
[Table("dichVuChiTiet")]
public partial class DichVuChiTiet
{
    [Key]
    [Column("maHoaDon")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHoaDon { get; set; } = null!;

    [Key]
    [Column("maDichVu")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaDichVu { get; set; } = null!;

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [ForeignKey("MaDichVu")]
    [InverseProperty("DichVuChiTiets")]
    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    [ForeignKey("MaHoaDon")]
    [InverseProperty("DichVuChiTiets")]
    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;
}
