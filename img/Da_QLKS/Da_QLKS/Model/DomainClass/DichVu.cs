using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("dichVu")]
public partial class DichVu
{
    [Key]
    [Column("maDichVu")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaDichVu { get; set; } = null!;

    [Column("tenDichVu")]
    [StringLength(20)]
    public string? TenDichVu { get; set; }

    [Column("donGia", TypeName = "money")]
    public decimal? DonGia { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaDichVuNavigation")]
    public virtual ICollection<DichVuChiTiet> DichVuChiTiets { get; set; } = new List<DichVuChiTiet>();
}
