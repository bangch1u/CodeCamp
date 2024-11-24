using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class DichVuCTRepos
    {
        private DBContext _context;
        public DichVuCTRepos()
        {
            _context = new DBContext();
        }
        public List<DichVuChiTiet> GetDichVuChiTiets(string search)
        {
            if (search == null)
            {
                List<DichVuChiTiet> data = _context.DichVuChiTiets.ToList();
                return data;
            }
            return _context.DichVuChiTiets.Where(nn => nn.MaDichVu.StartsWith(search) || nn.MaHoaDon.StartsWith(search)).ToList();
        }
        public bool AddDichVuCT(DichVuChiTiet dichVuChiTiet)
        {
            if (dichVuChiTiet == null)
            {
                return false;
            }
            else
            {
                _context.Add(dichVuChiTiet);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteDichVuCT(DichVuChiTiet dichVuChiTiet)
        {
            if (dichVuChiTiet == null)
            {
                return false;
            }
            else
            {
                _context.Remove(dichVuChiTiet);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateDichVuCT(DichVuChiTiet dichVuChiTiet)
        {
            if (dichVuChiTiet == null)
            {
                return false;
            }

            _context.Update(dichVuChiTiet);
            _context.SaveChanges();
            return true;

        }
        public decimal GetGiaDVByID(string id)
        {
            // Truy vấn để lấy giá phòng dựa trên MaPhong
            var giaDV = (from P in _context.DichVuChiTiets
                            join HP in _context.DichVus on P.MaDichVu equals HP.MaDichVu
                            where P.MaDichVu == id
                            select HP.DonGia).FirstOrDefault(); // Lấy giá phòng đầu tiên hoặc null nếu không tìm thấy

            // Kiểm tra nếu giá phòng là null, trả về 0 hoặc giá trị mặc định khác tuỳ theo yêu cầu của bạn
            if (giaDV == null)
            {
                return 0; // hoặc trả về một giá trị mặc định khác
            }

            // Trả về giá phòng, chuyển đổi từ decimal? thành decimal
            return giaDV.Value;
        }
    }
}
