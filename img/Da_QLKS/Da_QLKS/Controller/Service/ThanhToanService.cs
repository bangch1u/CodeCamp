using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class ThanhToanService
    {
        private ThanhToanRepos thanhToanRepos;
        public ThanhToanService()
        {
            thanhToanRepos = new ThanhToanRepos();
        }
        public void AddThanhToan(ThanhToan obj)
        {
            if (thanhToanRepos.AddThanhToan(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateThanhToan(ThanhToan obj)
        {
            if (thanhToanRepos.UpdateThanhToan(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteThanhToan(ThanhToan obj)
        {
            if (thanhToanRepos.DeleteThanhToan(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<ThanhToan> GetThanhToans(string input)
        {
            return thanhToanRepos.GetThanhToans(input);
        }
    }
}
