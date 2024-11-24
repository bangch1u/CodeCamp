using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class NhanVienService
    {
        private NhanVienRepos nhanVienRepos;
        public NhanVienService()
        {
            nhanVienRepos = new NhanVienRepos();
        }
        public void AddNhanVien(NhanVien obj)
        {
            if (nhanVienRepos.AddNhanVien(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateNhanVien(NhanVien obj)
        {
            if (nhanVienRepos.UpdateNhanVien(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteNhanVien(NhanVien obj)
        {
            if (nhanVienRepos.DeleteNhanVien(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<NhanVien> GetNhanViens(string input)
        {
            return nhanVienRepos.GetNhanViens(input);
        }
    }
}
