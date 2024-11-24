using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class NhanVienRepos
    {
        private DBContext _context;
        public NhanVienRepos()
        {
            _context = new DBContext();
        }
        public List<NhanVien> GetNhanViens(string search)
        {
            if (search == null)
            {
                List<NhanVien> data = _context.NhanViens.ToList();
                return data;
            }
            return _context.NhanViens.Where(nn => nn.MaNhanVien.StartsWith(search) || nn.HoTen.StartsWith(search)).ToList();
        }
        public bool AddNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                return false;
            }
            else
            {
                _context.Add(nhanVien);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeleteNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                return false;
            }
            else
            {
                _context.Remove(nhanVien);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null)
            {
                return false;
            }

            _context.Update(nhanVien);
            _context.SaveChanges();
            return true;

        }
    }
}
