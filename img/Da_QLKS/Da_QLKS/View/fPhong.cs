using Da_QLKS.DomainClass;
using Da_QLKS.Controller.Service;
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
    public partial class fPhong : Form
    {
        PhongService _service = new PhongService();
        HangPhongService _serHP = new HangPhongService();
        public fPhong()
        {
            InitializeComponent();
            LoadDataCmb();
            LoadGid(null);
            dtgPhong.CellClick += dtgPhong_CellContentClick;
        }
        public void LoadGid(string input)
        {

            int stt = 1;
            Type type = typeof(Phong);
            int slThuocTinh = type.GetProperties().Length;
            dtgPhong.ColumnCount = slThuocTinh + 2;
            dtgPhong.Columns[0].Name = "STT";
            dtgPhong.Columns[1].Name = "MaPhong";
            dtgPhong.Columns[2].Name = "TenPhong";
            dtgPhong.Columns[3].Name = "DienTich";
            dtgPhong.Columns[4].Name = "SoLuongKhach";
            dtgPhong.Columns[5].Name = "SoGiuong";
            //dtgPhong.Columns[6].Name = ""; -- note taks: hiện thị hạng phòng.

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgPhong.Rows.Clear();
            foreach (var item in _service.GetPhongs(input))
            {
                dtgPhong.Rows.Add(stt++, item.MaPhong, item.TenPhong, item.DienTich, item.SoLuongKhach, item.SoGiuong,_service.GetTenHPByID(item.MaHangPhong),item.MaHangPhong);
            }
        }
        public void LoadDataCmb() //hiện thị dữ liệu của hạng phòng sang combobox để lựa chọn khi thêm phòng
        {
            var lstHangPhong = _serHP.GetHangPhongs(null);
            List<HangPhong> lstHP = new List<HangPhong>();
            foreach (var item in lstHangPhong)
            {
                lstHP.Add(item);
            }
            cmbHangPhong.DataSource = lstHP;
            cmbHangPhong.DisplayMember = "tenHangPhong";
            cmbHangPhong.ValueMember = "maHangPhong";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Phong checkValid = _service.GetPhongs(null).FirstOrDefault(nv => nv.MaPhong == txtMaPhong.Text);
            if (checkValid != null)
            {
                MessageBox.Show("Mã phòng đã tồn tại!");
                return;
            }
            Phong obj = new Phong();
            obj.MaPhong = txtMaPhong.Text;
            obj.TenPhong = txtTenPhong.Text;
            obj.DienTich = Convert.ToDouble(txtDienTich.Text);
            obj.SoGiuong = Convert.ToInt32(txtSoGiuong.Text);
            obj.SoLuongKhach = Convert.ToInt32(txtSoLuongKhach.Text);
            obj.MaHangPhong = cmbHangPhong.SelectedValue.ToString();
            _service.AddPhong(obj);
            LoadGid(null);
            var test = cmbHangPhong.SelectedValue.ToString();
            MessageBox.Show(test);
        }

        private void dtgPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dtgPhong.CurrentRow.Cells[1].Value.ToString();
            txtTenPhong.Text = dtgPhong.CurrentRow.Cells[2].Value.ToString();
            txtDienTich.Text = dtgPhong.CurrentRow.Cells[3].Value.ToString();
            txtSoLuongKhach.Text = dtgPhong.CurrentRow.Cells[4].Value.ToString();
            txtSoGiuong.Text = dtgPhong.CurrentRow.Cells[5].Value.ToString();
            // Lấy giá trị maHangPhong từ DataGridView và gán cho ComboBox
            string maHangPhong = dtgPhong.CurrentRow.Cells[7].Value.ToString();
            cmbHangPhong.SelectedValue = maHangPhong;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Phong obj = _service.GetPhongs(null).FirstOrDefault(nv => nv.MaPhong == txtMaPhong.Text);
            if (obj == null)
            {
                MessageBox.Show("Mã phòng không tồn tại!");
                return;
            }
            obj.TenPhong = txtTenPhong.Text;
            obj.DienTich = Convert.ToDouble(txtDienTich.Text);
            obj.SoGiuong = Convert.ToInt32(txtSoGiuong.Text);
            obj.SoLuongKhach = Convert.ToInt32(txtSoLuongKhach.Text);
            obj.MaHangPhong = cmbHangPhong.SelectedValue.ToString();
            _service.UpdatePhong(obj);
            LoadGid(null);
            var test = cmbHangPhong.SelectedValue.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }
    }
}
