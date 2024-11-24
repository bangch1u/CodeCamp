using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("hangPhong")]
public partial class HangPhong
{
    [Key]
    [Column("maHangPhong")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHangPhong { get; set; } = null!;

    [Column("tenHangPhong")]
    [StringLength(20)]
    public string? TenHangPhong { get; set; }

    [Column("giaPhong", TypeName = "money")]
    public decimal? GiaPhong { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaHangPhongNavigation")]
    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
