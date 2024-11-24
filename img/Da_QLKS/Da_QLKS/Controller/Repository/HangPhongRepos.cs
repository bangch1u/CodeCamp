using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class HangPhongRepos
    {
        private DBContext _context;
        public HangPhongRepos()
        {
            _context = new DBContext();
        }
        public List<HangPhong> GetHangPhong(string search)
        {
            if (search == null)
            {
                List<HangPhong> data = _context.HangPhongs.ToList();
                return data;
            }
            return _context.HangPhongs.Where(nn => nn.MaHangPhong.StartsWith(search) || nn.TenHangPhong.StartsWith(search)).ToList();
        }
        public bool AddHangPhong(HangPhong hangPhong)
        {
            if (hangPhong == null)
            {
                return false;
            }
            else
            {
                _context.Add(hangPhong);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteHangPhong(HangPhong hangPhong)
        {
            if (hangPhong == null)
            {
                return false;
            }
            else
            {
                _context.Remove(hangPhong);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateHangPhong(HangPhong hangPhong)
        {
            if (hangPhong == null)
            {
                return false;
            }

            _context.Update(hangPhong);
            _context.SaveChanges();
            return true;

        }
        
    }
}
