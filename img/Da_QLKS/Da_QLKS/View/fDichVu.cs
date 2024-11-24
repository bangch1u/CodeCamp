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
    public partial class fDichVu : Form
    {
        DichVuService _service = new DichVuService();
        public fDichVu()
        {
            InitializeComponent();
            dtgDichVu.CellClick += dtgDichVu_CellContentClick;
           
        }
        public void LoadGid(string input)
        {
            int stt = 1;
            Type type = typeof(DichVu);
            int slThuocTinh = type.GetProperties().Length;
            dtgDichVu.ColumnCount = slThuocTinh + 1;
            dtgDichVu.Columns[0].Name = "STT";
            dtgDichVu.Columns[1].Name = "MaDV";
            dtgDichVu.Columns[2].Name = "TenDV";
            dtgDichVu.Columns[3].Name = "DonGia";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgDichVu.Rows.Clear();
            foreach (var item in _service.GetDichVus(input))
            {
                dtgDichVu.Rows.Add(stt++, item.MaDichVu, item.TenDichVu, item.DonGia);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            DichVu checkValid = _service.GetDichVus(null).FirstOrDefault(nv => nv.MaDichVu == txtMaDV.Text);
            if (checkValid != null)
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại!");
                return;
            }
            DichVu obj = new DichVu();
            obj.MaDichVu = txtMaDV.Text;
            obj.TenDichVu = txtTenDV.Text;
            obj.DonGia = Convert.ToDecimal(txtDonGia.Text);
            _service.AddDichVu(obj);
            LoadGid(null);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            DichVu obj = _service.GetDichVus(null).FirstOrDefault(nv => nv.MaDichVu == txtMaDV.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã dịch vụ không tồn tại!");
                return;
            }
            obj.TenDichVu = txtTenDV.Text;
            obj.DonGia = Convert.ToDecimal(txtDonGia.Text);
            _service.UpdateDichVu(obj);
            LoadGid(null);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DichVu obj = _service.GetDichVus(null).FirstOrDefault(nv => nv.MaDichVu == txtMaDV.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã dịch vụ không tồn tại!");
                return;
            }
            _service.DeleteDichVu(obj);
        }

        private void dtgDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDV.Text = dtgDichVu.CurrentRow.Cells[1].Value.ToString();
            txtTenDV.Text = dtgDichVu.CurrentRow.Cells[2].Value.ToString();
            txtDonGia.Text = dtgDichVu.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadGid(null);
        }
    }
}
