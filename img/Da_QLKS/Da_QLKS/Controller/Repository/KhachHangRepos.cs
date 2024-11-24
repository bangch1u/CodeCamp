

using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class KhachHangRepos
    {
        private DBContext _context;
        public KhachHangRepos()
        {
            _context = new DBContext();
        }
        public List<KhachHang> GetKhachHangs(string search)
        {
            if (search == null)
            {
                List<KhachHang> data = _context.KhachHangs.ToList();
                return data;
            }
            return _context.KhachHangs.Where(nn => nn.MaKhachHang.StartsWith(search) || nn.HoTen.StartsWith(search)).ToList();
        }
        public bool AddKHachHang(KhachHang khachHang)
        {
            if (khachHang == null)
            {
                return false;
            }
            else
            {
                _context.Add(khachHang);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteKhachHang(KhachHang khachHang)
        {
            if (khachHang == null)
            {
                return false;
            }
            else
            {
                _context.Remove(khachHang);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateKhachHang(KhachHang khachHang)
        {
            if (khachHang == null)
            {
                return false;
            }

            _context.Update(khachHang);
            _context.SaveChanges();
            return true;

        }
        public string GetMaHoaDonByIDKH(string id)
        {
            List<String> maHD = (from KH in _context.KhachHangs
                                         join HD in _context.HoaDons on KH.MaKhachHang equals HD.MaKhachHang
                                         where KH.MaKhachHang == id
                                         select HD.MaHoaDon).ToList();

            return String.Join(", ", maHD);
        }
        


    }
}
