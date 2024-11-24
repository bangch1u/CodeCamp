using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Da_QLKS.DomainClass;

[Table("hoaDon")]
public partial class HoaDon
{
    [Key]
    [Column("maHoaDon")]
    [StringLength(10)]
    [Unicode(false)]
    public string MaHoaDon { get; set; } = null!;

    [Column("maKhachHang")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaKhachHang { get; set; }

    [Column("maNhanVien")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaNhanVien { get; set; }

    [Column("maThanhToan")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaThanhToan { get; set; }

    [Column("tongTien", TypeName = "money")]
    public decimal? TongTien { get; set; }

    [Column("trangThai")]
    public int? TrangThai { get; set; }

    [InverseProperty("MaHoaDonNavigation")]
    public virtual ICollection<DichVuChiTiet> DichVuChiTiets { get; set; } = new List<DichVuChiTiet>();

    [ForeignKey("MaKhachHang")]
    [InverseProperty("HoaDons")]
    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    [ForeignKey("MaNhanVien")]
    [InverseProperty("HoaDons")]
    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    [ForeignKey("MaThanhToan")]
    [InverseProperty("HoaDons")]
    public virtual ThanhToan? MaThanhToanNavigation { get; set; }

    [InverseProperty("MaHoaDonNavigation")]
    public virtual ICollection<PhieuDatPhongChiTiet> PhieuDatPhongChiTiets { get; set; } = new List<PhieuDatPhongChiTiet>();
}
