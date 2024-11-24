using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Da_QLKS.Controller.Service
{
    internal class HangPhongService
    {
        private HangPhongRepos hangPhongRepos;
        public HangPhongService()
        {
            hangPhongRepos = new HangPhongRepos();
        }
        public void AddHangPhong(HangPhong obj)
        {
            if (hangPhongRepos.AddHangPhong(obj) == true)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        public void UpdateHangPhong(HangPhong obj)
        {
            if (hangPhongRepos.UpdateHangPhong(obj) == true)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
        public void DeleteHangPhong(HangPhong obj)
        {
            if (hangPhongRepos.DeleteHangPhong(obj) == true)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        public List<HangPhong> GetHangPhongs(string input)
        {
            return hangPhongRepos.GetHangPhong(input);
        }
    }
}
