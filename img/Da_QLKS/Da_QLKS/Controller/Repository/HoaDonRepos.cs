using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class HoaDonRepos
    {
        private DBContext _context;
        public HoaDonRepos()
        {
            _context = new DBContext();
        }
        public List<HoaDon> GetHoaDons(string search)
        {
            if (search == null)
            {
                List<HoaDon> data = _context.HoaDons.ToList();
                return data;
            }
            return _context.HoaDons.Where(nn => nn.MaHoaDon.StartsWith(search) || nn.MaNhanVien.StartsWith(search)).ToList();
        }
        public bool AddHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null)
            {
                return false;
            }
            else
            {
                _context.Add(hoaDon);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null)
            {
                return false;
            }
            else
            {
                _context.Remove(hoaDon);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null)
            {
                return false;
            }

            _context.Update(hoaDon);
            _context.SaveChanges();
            return true;

        }
    }
}
