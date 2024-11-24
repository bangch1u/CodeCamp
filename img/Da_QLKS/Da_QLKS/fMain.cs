using Da_QLKS.View;

namespace Da_QLKS
{
    public partial class fMain : Form
    {
        private Form currentFormChild;
        public fMain()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelMuonTra.Visible = false;
            panelSach.Visible = false;
            panelKhachHang.Visible = false;
            panelNhanVien.Visible = false;
   
        }
        private void hideSubMenu()
        {
            if (panelMuonTra.Visible == true)
            {
                panelMuonTra.Visible = false;
            }
            if (panelSach.Visible == true)
            {
                panelSach.Visible = false;
            }
            if (panelKhachHang.Visible == true)
            {
                panelKhachHang.Visible = false;
            }
            if (panelNhanVien.Visible == true)
            {
                panelNhanVien.Visible = false;
            }
       
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // if form open is close
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;  // close form firt
            childForm.FormBorderStyle = FormBorderStyle.None; // of window controls
            childForm.Dock = DockStyle.Fill;
            panelOpenForm.Controls.Add(childForm);
            panelOpenForm.BringToFront();
            childForm.Show();
        }
        private void ChangeBackGroundButton(Button buttonAction)
        {
            btnKH.BackColor = Color.FromArgb(51, 51, 76);
            btnP.BackColor = Color.FromArgb(51, 51, 76);
            btnDichVu.BackColor = Color.FromArgb(51, 51, 76);
            btnNhanVien.BackColor = Color.FromArgb(51, 51, 76);
       


            buttonAction.BackColor = Color.MediumSeaGreen;
        }


        private void lbTenChucNang_Click(object sender, EventArgs e)
        {

        }


        private void btnKH_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMuonTra);
            ChangeBackGroundButton(btnKH);
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // if form open is close
                //panelOpenForm
            }
            lbTenChucNang.Text = "Khách Hàng";
        }
        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            //hideSubMenu();
            OpenChildForm(new fKhachHang());
            lbTenChucNang.Text = "Thông Tin Khách Hàng";
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSach);
            ChangeBackGroundButton(btnP);
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // if form open is close
                //panelOpenForm
            }
            lbTenChucNang.Text = "Quản Lý Phòng";
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fPhong());
            lbTenChucNang.Text = "Phòng";
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDatPhong());
            lbTenChucNang.Text = "Đặt Phòng";
        }

        private void btnHangPhong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fHangPhong());
            lbTenChucNang.Text = "Hạng Phòng";
        }

        private void btnQlyNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fNhanVien());
            lbTenChucNang.Text = "Nhân Viên";
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            showSubMenu(panelNhanVien);
            ChangeBackGroundButton(btnNhanVien);
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // if form open is close
                //panelOpenForm
            }
            lbTenChucNang.Text = "Quản Lý Nhân Viên";
        }

        private void btnThongTinDV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fDichVu());
            lbTenChucNang.Text = "Dịch Vụ";
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKhachHang);
            ChangeBackGroundButton(btnDichVu);
            if (currentFormChild != null)
            {
                currentFormChild.Close(); // if form open is close
                //panelOpenForm
            }
            lbTenChucNang.Text = "Quản Lý Nhân Viên";
        }

        private void btnDatDV_Click(object sender, EventArgs e)
        {
            
            lbTenChucNang.Text = "Đặt Dịch Vụ";
        }
    }
}