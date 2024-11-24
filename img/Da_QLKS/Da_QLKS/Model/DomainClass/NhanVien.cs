using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("nhanVien")]
public partial class NhanVien
{
    [Key]
    [Column("maNhanVien")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaNhanVien { get; set; } = null!;

    [Column("hoTen")]
    [StringLength(30)]
    public string? HoTen { get; set; }

    [Column("sdt")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Sdt { get; set; }

    [Column("diaChi")]
    [StringLength(30)]
    public string? DiaChi { get; set; }

    [Column("ngaySinh", TypeName = "datetime")]
    public DateTime? NgaySinh { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaNhanVienNavigation")]
    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
