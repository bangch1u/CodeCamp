using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class DichVuRepos
    {
        private DBContext _context;
        public DichVuRepos()
        {
            _context = new DBContext();
        }
        public List<DichVu> GetDichVus(string search)
        {
            if (search == null)
            {
                List<DichVu> data = _context.DichVus.ToList();
                return data;
            }
            return _context.DichVus.Where(nn => nn.MaDichVu.StartsWith(search) || nn.TenDichVu.StartsWith(search)).ToList();
        }
        public bool AddDichVu(DichVu dichVu)
        {
            if (dichVu == null)
            {
                return false;
            }
            else
            {
                _context.Add(dichVu);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteDichVu(DichVu dichVu)
        {
            if (dichVu == null)
            {
                return false;
            }
            else
            {
                _context.Remove(dichVu);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateDichVu(DichVu dichVu)
        {
            if (dichVu == null)
            {
                return false;
            }

            _context.Update(dichVu);
            _context.SaveChanges();
            return true;

        }
    }
}
