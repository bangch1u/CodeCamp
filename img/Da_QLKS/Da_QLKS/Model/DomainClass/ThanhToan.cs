using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("thanhToan")]
public partial class ThanhToan
{
    [Key]
    [Column("maThanhToan")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaThanhToan { get; set; } = null!;

    [Column("hinhThucThanhToan")]
    public int? HinhThucThanhToan { get; set; }

    [Column("ngayThanhToan", TypeName = "datetime")]
    public DateTime? NgayThanhToan { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaThanhToanNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
