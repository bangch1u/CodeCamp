using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class PhieuDatPhongCTService
    {
        private PhieuDatPhongCTRepos phieuDatPhongCTRepos;
        public PhieuDatPhongCTService()
        {
            phieuDatPhongCTRepos = new PhieuDatPhongCTRepos();
        }
        public void AddPhieuDatPhongCT(PhieuDatPhongChiTiet obj)
        {
            if (phieuDatPhongCTRepos.AddPhieuDatPhongCT(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdatePhieuDatPhongCT(PhieuDatPhongChiTiet obj)
        {
            if (phieuDatPhongCTRepos.UpdatePhieuDatPhongCT(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeletePhieuDatPhongCT(PhieuDatPhongChiTiet obj)
        {
            if (phieuDatPhongCTRepos.DeletePhieuDatPhongCT(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<PhieuDatPhongChiTiet> GetPhieuDatPhongChiTiets(string input)
        {
            return phieuDatPhongCTRepos.GetPhieuDatPhongChiTiets(input);
        }
    }
}
