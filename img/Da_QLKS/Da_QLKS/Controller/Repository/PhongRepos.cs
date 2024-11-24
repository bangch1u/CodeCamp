using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class PhongRepos
    {
        private DBContext _context;
        public PhongRepos()
        {
            _context = new DBContext();
        }
        public List<Phong> GetPhongs(string search)
        {
            if (search == null)
            {
                List<Phong> data = _context.Phongs.ToList();
                return data;
            }
            return _context.Phongs.Where(nn => nn.MaPhong.StartsWith(search) || nn.TenPhong.StartsWith(search)).ToList();
        }
        public bool AddPhong(Phong phong)
        {
            if (phong == null)
            {
                return false;
            }
            else
            {
                _context.Add(phong);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeletePhong(Phong phong)
        {
            if (phong == null)
            {
                return false;
            }
            else
            {
                _context.Remove(phong);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdatePhong(Phong phong)
        {
            if (phong == null)
            {
                return false;
            }

            _context.Update(phong);
            _context.SaveChanges();
            return true;

        }
        public string GetTenHangPhongs(string id)
        {
             string tenHangPhong = (from P in _context.Phongs
                                         join HP in _context.HangPhongs on P.MaHangPhong equals HP.MaHangPhong
                                         where P.MaHangPhong == id
                                         select HP.TenHangPhong).FirstOrDefault();

            return tenHangPhong;
        }
        public decimal GetGiaPhongByID(string id)
        {
            // Truy vấn để lấy giá phòng dựa trên MaPhong
            var giaPhong = (from P in _context.Phongs
                            join HP in _context.HangPhongs on P.MaHangPhong equals HP.MaHangPhong
                            where P.MaHangPhong == id
                            select HP.GiaPhong).FirstOrDefault(); // Lấy giá phòng đầu tiên hoặc null nếu không tìm thấy

            // Kiểm tra nếu giá phòng là null, trả về 0 hoặc giá trị mặc định khác tuỳ theo yêu cầu của bạn
            if (giaPhong == null)
            {
                return 0; // hoặc trả về một giá trị mặc định khác
            }

            // Trả về giá phòng, chuyển đổi từ decimal? thành decimal
            return giaPhong.Value;
        }




    }
}
