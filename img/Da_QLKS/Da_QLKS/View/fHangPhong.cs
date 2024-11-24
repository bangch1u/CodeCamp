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
    public partial class fHangPhong : Form
    {
        HangPhongService _service = new HangPhongService();
        public fHangPhong()
        {
            InitializeComponent();
            LoadGid(null);
            dtgHangPhong.CellClick += dtgHangPhong_CellContentClick;
        }
        public void LoadGid(string input)
        {
            int stt = 1;
            Type type = typeof(HangPhong);
            //int slThuocTinh = type.GetProperties().Length;
            dtgHangPhong.ColumnCount = 4;
            dtgHangPhong.Columns[0].Name = "STT";
            dtgHangPhong.Columns[1].Name = "MaDV";
            dtgHangPhong.Columns[2].Name = "TenDV";
            dtgHangPhong.Columns[3].Name = "DonGia";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgHangPhong.Rows.Clear();
            foreach (var item in _service.GetHangPhongs(input))
            {
                dtgHangPhong.Rows.Add(stt++, item.MaHangPhong, item.TenHangPhong, item.GiaPhong);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            HangPhong checkValid = _service.GetHangPhongs(null).FirstOrDefault(nv => nv.MaHangPhong == txtMaHP.Text);
            if (checkValid != null)
            {
                MessageBox.Show("Mã hạng phòng đã tồn tại!");
                return;
            }
            HangPhong obj = new HangPhong();
            obj.MaHangPhong = txtMaHP.Text;
            obj.TenHangPhong = txtTenHP.Text;
            obj.GiaPhong = Convert.ToDecimal(txtGiaPhong.Text);
            _service.AddHangPhong(obj);
            LoadGid(null);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            HangPhong obj = _service.GetHangPhongs(null).FirstOrDefault(nv => nv.MaHangPhong == txtMaHP.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã hạng phòng chưa tồn tại!");
                return;
            }
            obj.TenHangPhong = txtTenHP.Text;
            obj.GiaPhong = Convert.ToDecimal(txtGiaPhong.Text);
            _service.UpdateHangPhong(obj);
            LoadGid(null);
        }

        private void dtgHangPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHP.Text = dtgHangPhong.CurrentRow.Cells[1].Value.ToString();
            txtTenHP.Text = dtgHangPhong.CurrentRow.Cells[2].Value.ToString();
            txtGiaPhong.Text = dtgHangPhong.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
