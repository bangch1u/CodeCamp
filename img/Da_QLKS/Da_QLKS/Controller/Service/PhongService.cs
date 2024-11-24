using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class PhongService
    {
        private PhongRepos phongRepos;
        public PhongService()
        {
            phongRepos = new PhongRepos();
        }
        public void AddPhong(Phong obj)
        {
            if (phongRepos.AddPhong(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdatePhong(Phong obj)
        {
            if (phongRepos.UpdatePhong(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeletePhong(Phong obj)
        {
            if (phongRepos.DeletePhong(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<Phong> GetPhongs(string input)
        {
            return phongRepos.GetPhongs(input);
        }
        public string GetTenHPByID(string id)
        {
            return phongRepos.GetTenHangPhongs(id); 
        }
        public decimal GetGiaPhongByID(string id)
        {
            return phongRepos.GetGiaPhongByID(id);
        }

    }
}
