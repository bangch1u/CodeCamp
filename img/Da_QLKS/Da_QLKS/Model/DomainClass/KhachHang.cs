using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("khachHang")]
public partial class KhachHang
{
    [Key]
    [Column("maKhachHang")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaKhachHang { get; set; } = null!;

    [Column("hoTen")]
    [StringLength(30)]
    public string? HoTen { get; set; }

    [Column("sdt")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [Column("cccd")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Cccd { get; set; }

    [Column("ngaySinh", TypeName = "datetime")]
    public DateTime? NgaySinh { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaKhachHangNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
