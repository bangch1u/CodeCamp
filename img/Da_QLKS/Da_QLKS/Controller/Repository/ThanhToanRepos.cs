using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class ThanhToanRepos
    {
        private DBContext _context;
        public ThanhToanRepos()
        {
            _context = new DBContext();
        }
        public List<ThanhToan> GetThanhToans(string search)
        {
            if (search == null)
            {
                List<ThanhToan> data = _context.ThanhToans.ToList();
                return data;
            }
            return _context.ThanhToans.Where(nn => nn.MaThanhToan.StartsWith(search)).ToList();
        }
        public bool AddThanhToan(ThanhToan thanhToan)
        {
            if (thanhToan == null)
            {
                return false;
            }
            else
            {
                _context.Add(thanhToan);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteThanhToan(ThanhToan thanhToan)
        {
            if (thanhToan == null)
            {
                return false;
            }
            else
            {
                _context.Remove(thanhToan);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateThanhToan(ThanhToan thanhToan)
        {
            if (thanhToan == null)
            {
                return false;
            }

            _context.Update(thanhToan);
            _context.SaveChanges();
            return true;

        }
    }
}
