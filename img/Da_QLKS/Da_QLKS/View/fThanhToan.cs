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
    public partial class fThanhToan : Form
    {
        ThanhToanService _service = new ThanhToanService();
        public fThanhToan()
        {
            InitializeComponent();
            LoadGid(null);
        }

        public void LoadGid(string input)
        {
            int stt = 1;
            Type type = typeof(ThanhToan);
            int slThuocTinh = type.GetProperties().Length;
            dtgThanhToan.ColumnCount = slThuocTinh + 1;
            dtgThanhToan.Columns[0].Name = "STT";
            dtgThanhToan.Columns[1].Name = "MaTT";
            dtgThanhToan.Columns[2].Name = "HinhThucTT";

            //clear dữ liệu cũ hiển thị trên dataGridView khi load dữ liệu mới
            dtgThanhToan.Rows.Clear();
            foreach (var item in _service.GetThanhToans(input))
            {
                string hinhThucThanhToan = item.HinhThucThanhToan == 1 ? "Tiền mặt" :
                             item.HinhThucThanhToan == 2 ? "Chuyển khoản" :
                             item.HinhThucThanhToan == 3 ? "Visa" :
                             "Không xác định";

                // Thêm hàng vào DataGridView
                dtgThanhToan.Rows.Add(stt++, item.MaThanhToan, hinhThucThanhToan);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

        }
    }
}
