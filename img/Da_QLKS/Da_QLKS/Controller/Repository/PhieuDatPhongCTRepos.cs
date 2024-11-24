
using Da_QLKS.Context;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Repository
{
    internal class PhieuDatPhongCTRepos
    {
        private DBContext _context;
        public PhieuDatPhongCTRepos()
        {
            _context = new DBContext();
        }
        public List<PhieuDatPhongChiTiet> GetPhieuDatPhongChiTiets(string search)
        {
            if (search == null)
            {
                List<PhieuDatPhongChiTiet> data = _context.PhieuDatPhongChiTiets.ToList();
                return data;
            }
            return _context.PhieuDatPhongChiTiets.Where(nn => nn.MaPhong.StartsWith(search) || nn.MaHoaDon.StartsWith(search)).ToList();
        }
        public bool AddPhieuDatPhongCT(PhieuDatPhongChiTiet phieuDatPhongChiTiet)
        {
            if (phieuDatPhongChiTiet == null)
            {
                return false;
            }
            else
            {
                _context.Add(phieuDatPhongChiTiet);
                _context.SaveChanges();
                return true;
            }
        }
        public bool DeletePhieuDatPhongCT(PhieuDatPhongChiTiet phieuDatPhongChiTiet)
        {
            if (phieuDatPhongChiTiet == null)
            {
                return false;
            }
            else
            {
                _context.Remove(phieuDatPhongChiTiet);
                _context.SaveChanges();
                return true;
            }
        }
        public bool UpdatePhieuDatPhongCT(PhieuDatPhongChiTiet phieuDatPhongChiTiet)
        {
            if (phieuDatPhongChiTiet == null)
            {
                return false;
            }

            _context.Update(phieuDatPhongChiTiet);
            _context.SaveChanges();
            return true;

        }
    }
}
