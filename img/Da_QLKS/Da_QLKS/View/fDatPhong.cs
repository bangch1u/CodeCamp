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
    public partial class fDatPhong : Form
    {
        KhachHangService _service = new KhachHangService();
        PhongService _serPhong = new PhongService();
        HangPhongService _serHP = new HangPhongService();
        PhieuDatPhongCTService _serPDPCT = new PhieuDatPhongCTService();
        HoaDonService _serHD = new HoaDonService();
        NhanVienService _serNV = new NhanVienService();
        DichVuService _serDV = new DichVuService();
        DichVuCTService _serDVCT = new DichVuCTService();
        public fDatPhong()
        {
            InitializeComponent();
            LoadGidKH(null);
            dtgShowKH.CellClick += dtgShowKH_CellContentClick;
            dtgShowPhong.CellClick += dtgShowPhong_CellContentClick;
            dtgShowDV.CellClick += dtgShowDV_CellContentClick;
            LoadDataCmb();
            LoadGidPhong(null);
            LoadGidDV(null);
        }
        public void LoadDataCmb() //hiện thị dữ liệu của hạng phòng sang combobox để lựa chọn khi thêm phòng
        {
            var lstNhanVien = _serNV.GetNhanViens(null);
            List<NhanVien> lstNV = new List<NhanVien>();
            foreach (var item in lstNhanVien)
            {
                lstNV.Add(item);
            }
            cmbNhanVien.DataSource = lstNV;
            cmbNhanVien.DisplayMember = "hoTen";
            cmbNhanVien.ValueMember = "maNhanVien";
        }
        public void LoadGidKH(string input)
        {
            int stt = 1;
            Type type = typeof(KhachHang);
            int slThuocTinh = type.GetProperties().Length;
            dtgShowKH.ColumnCount = slThuocTinh + 2;
            dtgShowKH.Columns[0].Name = "STT";
            dtgShowKH.Columns[1].Name = "MaKH";
            dtgShowKH.Columns[2].Name = "TenKH";
            dtgShowKH.Columns[3].Name = "MaHD";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgShowKH.Rows.Clear();
            foreach (var item in _service.GetKhachHangs(input))
            {
                if (item.TrangThai == 0)
                {
                    continue;
                }
                dtgShowKH.Rows.Add(stt++, item.MaKhachHang, item.HoTen, _service.GetMaHDByIDKH(item.MaKhachHang));
            }
        }

        private void dtgShowKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH2.Text = dtgShowKH.CurrentRow.Cells[1].Value.ToString();
            txtMaHD.Text = dtgShowKH.CurrentRow.Cells[3].Value.ToString();
            

        }
        public void LoadGidPhong(string input)
        {
            int stt = 1;
            Type type = typeof(Phong);
            int slThuocTinh = type.GetProperties().Length;
            dtgShowPhong.ColumnCount = slThuocTinh + 3;
            dtgShowPhong.Columns[0].Name = "STT";
            dtgShowPhong.Columns[1].Name = "MaPhong";
            dtgShowPhong.Columns[2].Name = "TenPhong";
            dtgShowPhong.Columns[3].Name = "DienTich";
            dtgShowPhong.Columns[4].Name = "SoLuongKhach";
            dtgShowPhong.Columns[5].Name = "SoGiuong";
            //dtgPhong.Columns[6].Name = ""; -- note taks: hiện thị hạng phòng.

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgShowPhong.Rows.Clear();
            foreach (var item in _serPhong.GetPhongs(input))
            {
                dtgShowPhong.Rows.Add(stt++, item.MaPhong, item.TenPhong, item.DienTich, item.SoLuongKhach, item.SoGiuong, _serPhong.GetTenHPByID(item.MaHangPhong),item.MaHangPhong, _serPhong.GetGiaPhongByID(item.MaHangPhong));
            }
        }

        private void dtgShowPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhong.Text = dtgShowPhong.CurrentRow.Cells[1].Value.ToString();
            txtDonGiaP.Text = dtgShowPhong.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            PhieuDatPhongChiTiet obj = new PhieuDatPhongChiTiet();
            obj.MaPhong = txtMaPhong.Text;
            obj.MaHoaDon = txtMaHD.Text;
            obj.NgayNhan = Convert.ToDateTime(dtpNgayNhan.Text);
            obj.NgayTra = Convert.ToDateTime(dtpNgayTra.Text);
            obj.SoNgayThue = Convert.ToInt32(txtSoNgayThue.Text);
            var soNgay = Convert.ToDecimal(obj.SoNgayThue);
            decimal a = Convert.ToDecimal(txtDonGiaP.Text);
            obj.DonGia = a;
            _serPDPCT.AddPhieuDatPhongCT(obj);
            HoaDon hd = _serHD.GetHoaDons(null).FirstOrDefault(nv => nv.MaHoaDon == txtMaHD.Text);
            decimal tongTienThue = a * soNgay;
            if (hd.TongTien == null)
            {
                hd.TongTien = 0;
            }
             hd.TongTien = hd.TongTien + tongTienThue;
            _serHD.UpdateHoaDon(hd);
            lbTongTienP.Text = tongTienThue.ToString();
            lbTongTien.Text = hd.TongTien.ToString();

        }

        private void fDatPhong_Load(object sender, EventArgs e)
        {

        }
        public void LoadGidDV(string input)
        {
            int stt = 1;
            Type type = typeof(DichVu);
            int slThuocTinh = type.GetProperties().Length;
            dtgShowDV.ColumnCount = slThuocTinh + 2;
            dtgShowDV.Columns[0].Name = "STT";
            dtgShowDV.Columns[1].Name = "MaDV";
            dtgShowDV.Columns[2].Name = "TenDV";
            dtgShowDV.Columns[3].Name = "DonGia";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgShowDV.Rows.Clear();
            foreach (var item in _serDV.GetDichVus(input))
            {
                dtgShowDV.Rows.Add(stt++, item.MaDichVu, item.TenDichVu, item.DonGia);
            }
        }

        private void dtgShowDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDV.Text = dtgShowDV.CurrentRow.Cells[1].Value.ToString();
            txtTenDV.Text = dtgShowDV.CurrentRow.Cells[2].Value.ToString();
            txtDonGia.Text = dtgShowDV.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDatDV_Click(object sender, EventArgs e)
        {
            DichVuChiTiet obj = new DichVuChiTiet();
            obj.MaDichVu = txtMaDV.Text;
            obj.MaHoaDon = txtMaHD.Text;
            obj.TrangThai = Convert.ToInt32(txtSLDV.Text);
            decimal soLuongDV = Convert.ToDecimal(obj.TrangThai); // thay thế cho số lượng dịch vụ do thiếu :))
            _serDVCT.AddDichVuCT(obj);
          
            decimal tienDV = _serDVCT.GetGiaDVByID(obj.MaDichVu);
            var tongTienDV = tienDV * soLuongDV;
            HoaDon hd = _serHD.GetHoaDons(null).FirstOrDefault(nv => nv.MaHoaDon == txtMaHD.Text);
            if (hd.TongTien == null)
            {
                hd.TongTien = 0;
            }
            hd.TongTien = hd.TongTien + tongTienDV;
            _serHD.UpdateHoaDon(hd);
            lbTienDV.Text = tongTienDV.ToString();
            lbTongTien.Text = hd.TongTien.ToString();
        }
    }
}
