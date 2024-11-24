using Da_QLKS.Controller.Service;
using Da_QLKS.DomainClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Da_QLKS.View
{
    public partial class fKhachHang : Form
    {
        KhachHangService _service = new KhachHangService();
        HoaDonService _hoaDonService = new HoaDonService(); 
        public fKhachHang()
        {
            InitializeComponent();
            dtgKhachHang.CellClick += dtgKhachHang_CellContentClick;
            LoadGid(null);
        }
        //Method load dữ liệu lên dataGridView
        public void LoadGid(string input)
        {
            int stt = 1;
            Type type = typeof(KhachHang);
            int slThuocTinh = type.GetProperties().Length;
            dtgKhachHang.ColumnCount = slThuocTinh + 1;
            dtgKhachHang.Columns[0].Name = "STT";
            dtgKhachHang.Columns[1].Name = "MaKH";
            dtgKhachHang.Columns[2].Name = "TenKH";
            dtgKhachHang.Columns[3].Name = "SDT";
            dtgKhachHang.Columns[4].Name = "CCCD";
            dtgKhachHang.Columns[5].Name = "NgaySinh";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgKhachHang.Rows.Clear();
            foreach (var item in _service.GetKhachHangs(input))
            {
                if (item.TrangThai == 0)
                {
                    continue;
                }
                dtgKhachHang.Rows.Add(stt++, item.MaKhachHang, item.HoTen, item.Sdt, item.Cccd, item.NgaySinh);
            }
        }
        static string GenerateMaHD()
        {
            Random random = new Random();
            int maxNumberLength = 8; // Độ dài tối đa của phần số
            int minNumber = (int)Math.Pow(10, maxNumberLength - 1);
            int maxNumber = (int)Math.Pow(10, maxNumberLength) - 1;

            int randomNumber = random.Next(minNumber, maxNumber); // Số ngẫu nhiên từ 10000000 đến 99999999

            string maHoaDon = "HD" + randomNumber.ToString();
            return maHoaDon;
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHang checkValid = _service.GetKhachHangs(null).FirstOrDefault(kh => kh.MaKhachHang == txtMaKH.Text);
            if (checkValid != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại!");
                return;
            }
            KhachHang obj = new KhachHang();
            obj.MaKhachHang = txtMaKH.Text;
            obj.HoTen = txtTenKH.Text;
            obj.Cccd = txtCCCD.Text;
            obj.Sdt = txtSDT.Text;
            obj.NgaySinh = Convert.ToDateTime(dateNgaySinh.Text);
            obj.TrangThai = 1;
            HoaDon hd = new HoaDon();
            hd.MaHoaDon = GenerateMaHD();
            hd.MaKhachHang = txtMaKH.Text;
            _service.AddKhachHang(obj);
            _hoaDonService.AddHoaDon(hd);
            LoadGid(null);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            KhachHang obj = _service.GetKhachHangs(null).FirstOrDefault(kh => kh.MaKhachHang == txtMaKH.Text);
            if (obj == null)
            {
                MessageBox.Show("Khách Hàng cần sửa không tồn tại!");
                return;
            }
            obj.HoTen = txtTenKH.Text;
            obj.Cccd = txtCCCD.Text;
            obj.Sdt = txtSDT.Text;
            obj.NgaySinh = Convert.ToDateTime(dateNgaySinh.Text);
            obj.TrangThai = 1;
            _service.UpdateKhachHang(obj);
            LoadGid(null);
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            KhachHang obj = _service.GetKhachHangs(null).FirstOrDefault(kh => kh.MaKhachHang == txtMaKH.Text);
            if (obj == null)
            {
                MessageBox.Show("Khách Hàng cần xóa không tồn tại!");
                return;
            }
            obj.TrangThai = 0;
            _service.UpdateKhachHang(obj);
            LoadGid(null);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadGid(null);
        }

        private void dtgKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dtgKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtTenKH.Text = dtgKhachHang.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dtgKhachHang.CurrentRow.Cells[3].Value.ToString();
            txtCCCD.Text = dtgKhachHang.CurrentRow.Cells[4].Value.ToString();
            dateNgaySinh.Value = Convert.ToDateTime(dtgKhachHang.CurrentRow.Cells[5].Value.ToString());
        }
    }
}
