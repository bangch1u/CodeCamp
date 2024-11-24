using Da_QLKS.Controller.Repository;
using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class DichVuService
    {
        private DichVuRepos dichVuRepos;
        public DichVuService()
        {
            dichVuRepos = new DichVuRepos();
        }
        public void AddDichVu(DichVu obj)
        {
            if (dichVuRepos.AddDichVu(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateDichVu(DichVu obj)
        {
            if (dichVuRepos.UpdateDichVu(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteDichVu(DichVu obj)
        {
            if (dichVuRepos.DeleteDichVu(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<DichVu> GetDichVus(string input)
        {
            return dichVuRepos.GetDichVus(input);
        }
    }
}
