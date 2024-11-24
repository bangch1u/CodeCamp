using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class HoaDonService
    {
        private HoaDonRepos hoaDonRepos;
        public HoaDonService()
        {
            hoaDonRepos = new HoaDonRepos();
        }
        public void AddHoaDon(HoaDon obj)
        {
            if (hoaDonRepos.AddHoaDon(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateHoaDon(HoaDon obj)
        {
            if (hoaDonRepos.UpdateHoaDon(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteHoaDon(HoaDon obj)
        {
            if (hoaDonRepos.DeleteHoaDon(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<HoaDon> GetHoaDons(string input)
        {
            return hoaDonRepos.GetHoaDons(input);
        }
    }
}
