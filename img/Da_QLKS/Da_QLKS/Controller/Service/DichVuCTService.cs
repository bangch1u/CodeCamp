using Da_QLKS.Controller.Repository;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class DichVuCTService
    {
        private DichVuCTRepos dichVuCTRepos;
        public DichVuCTService()
        {
            dichVuCTRepos = new DichVuCTRepos();
        }
        public void AddDichVuCT(DichVuChiTiet obj)
        {
            if (dichVuCTRepos.AddDichVuCT(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateDichVuCT(DichVuChiTiet obj)
        {
            if (dichVuCTRepos.UpdateDichVuCT(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteDichVuCT(DichVuChiTiet obj)
        {
            if (dichVuCTRepos.DeleteDichVuCT(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<DichVuChiTiet> GetDichVuCTs(string input)
        {
            return dichVuCTRepos.GetDichVuChiTiets(input);
        }
        public decimal GetGiaDVByID(string id)
        {
            return dichVuCTRepos.GetGiaDVByID(id);
        }
    }
}
