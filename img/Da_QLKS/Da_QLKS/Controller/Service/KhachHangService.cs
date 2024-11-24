using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class KhachHangService
    {
        private KhachHangRepos khachRepos;
        public KhachHangService()
        {
            khachRepos = new KhachHangRepos();
        }
        public void  AddKhachHang(KhachHang obj)
        {
            if (khachRepos.AddKHachHang(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateKhachHang(KhachHang obj)
        {
            if (khachRepos.UpdateKhachHang(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteKhachHang(KhachHang obj)
        {
            if (khachRepos.DeleteKhachHang(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<KhachHang> GetKhachHangs(string input)
        {
            return khachRepos.GetKhachHangs(input);
        }
        public string GetMaHDByIDKH(string id)
        {
            return khachRepos.GetMaHoaDonByIDKH(id);
        }

        internal IEnumerable<object> GetPhongs(string input)
        {
            throw new NotImplementedException();
        }
    }
}
