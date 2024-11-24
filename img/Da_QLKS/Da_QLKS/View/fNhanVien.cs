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
    public partial class fNhanVien : Form
    {
        NhanVienService _service = new NhanVienService();
        public fNhanVien()
        {
            InitializeComponent();
            //LoadGid(null);
            dtgNhanVien.CellClick += dtgNhanVien_CellContentClick;
        }
        public void LoadGid(string input)
        {
            int stt = 1;
            Type type = typeof(NhanVien);
            int slThuocTinh = type.GetProperties().Length;
            dtgNhanVien.ColumnCount = slThuocTinh + 1;
            dtgNhanVien.Columns[0].Name = "STT";
            dtgNhanVien.Columns[1].Name = "MaNV";
            dtgNhanVien.Columns[2].Name = "TenNV";
            dtgNhanVien.Columns[3].Name = "SDT";
            dtgNhanVien.Columns[4].Name = "DiaChi";
            dtgNhanVien.Columns[5].Name = "NgaySinh";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgNhanVien.Rows.Clear();
            foreach (var item in _service.GetNhanViens(input))
            {
                dtgNhanVien.Rows.Add(stt++, item.MaNhanVien, item.HoTen, item.Sdt, item.DiaChi, item.NgaySinh);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            NhanVien checkValid = _service.GetNhanViens(null).FirstOrDefault(nv => nv.MaNhanVien == txtMaNV.Text);
            if (checkValid != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }
            NhanVien obj = new NhanVien();
            obj.MaNhanVien = txtMaNV.Text;
            obj.HoTen = txtTenNV.Text;
            obj.DiaChi = txtDiaChi.Text;
            obj.Sdt = txtSDT.Text;
            obj.NgaySinh = Convert.ToDateTime(dateNgaySinh.Text);
            _service.AddNhanVien(obj);
            LoadGid(null);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            NhanVien obj = _service.GetNhanViens(null).FirstOrDefault(nv => nv.MaNhanVien == txtMaNV.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            obj.HoTen = txtTenNV.Text;
            obj.DiaChi = txtDiaChi.Text;
            obj.Sdt = txtSDT.Text;
            obj.NgaySinh = Convert.ToDateTime(dateNgaySinh.Text);
            _service.UpdateNhanVien(obj);
            LoadGid(null);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            NhanVien obj = _service.GetNhanViens(null).FirstOrDefault(nv => nv.MaNhanVien == txtMaNV.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            _service.DeleteNhanVien(obj);
            LoadGid(null);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadGid(null);
        }

        private void dtgNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtTenNV.Text = dtgNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dtgNhanVien.CurrentRow.Cells[3].Value.ToString();
            txtDiaChi.Text = dtgNhanVien.CurrentRow.Cells[4].Value.ToString();
            dateNgaySinh.Value = Convert.ToDateTime(dtgNhanVien.CurrentRow.Cells[5].Value.ToString());
        }
    }
}
