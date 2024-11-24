namespace Da_QLKS.View
{
    partial class fThanhToan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.btnXoaNV = new System.Windows.Forms.Button();
            this.btnSuaNV = new System.Windows.Forms.Button();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labe = new System.Windows.Forms.Label();
            this.txtHinhThucTT = new System.Windows.Forms.TextBox();
            this.txtMaTT = new System.Windows.Forms.TextBox();
            this.dtgThanhToan = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhThucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(645, 264);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 85;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(414, 264);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(225, 23);
            this.txtTimKiem.TabIndex = 84;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 15);
            this.label6.TabIndex = 83;
            this.label6.Text = "Bảng dữ liệu khách hàng";
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(486, 186);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(75, 41);
            this.btnHienThi.TabIndex = 82;
            this.btnHienThi.Text = "Hiển Thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            // 
            // btnXoaNV
            // 
            this.btnXoaNV.Location = new System.Drawing.Point(355, 186);
            this.btnXoaNV.Name = "btnXoaNV";
            this.btnXoaNV.Size = new System.Drawing.Size(75, 41);
            this.btnXoaNV.TabIndex = 81;
            this.btnXoaNV.Text = "Xóa";
            this.btnXoaNV.UseVisualStyleBackColor = true;
            // 
            // btnSuaNV
            // 
            this.btnSuaNV.Location = new System.Drawing.Point(219, 186);
            this.btnSuaNV.Name = "btnSuaNV";
            this.btnSuaNV.Size = new System.Drawing.Size(75, 41);
            this.btnSuaNV.TabIndex = 80;
            this.btnSuaNV.Text = "Sửa";
            this.btnSuaNV.UseVisualStyleBackColor = true;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Location = new System.Drawing.Point(81, 186);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(75, 41);
            this.btnThemNV.TabIndex = 79;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 78;
            this.label3.Text = "Hình Thức Thanh Toán";
            // 
            // labe
            // 
            this.labe.AutoSize = true;
            this.labe.Location = new System.Drawing.Point(84, 10);
            this.labe.Name = "labe";
            this.labe.Size = new System.Drawing.Size(88, 15);
            this.labe.TabIndex = 76;
            this.labe.Text = "Mã Thanh Toán";
            // 
            // txtHinhThucTT
            // 
            this.txtHinhThucTT.Location = new System.Drawing.Point(289, 28);
            this.txtHinhThucTT.Name = "txtHinhThucTT";
            this.txtHinhThucTT.Size = new System.Drawing.Size(172, 23);
            this.txtHinhThucTT.TabIndex = 75;
            // 
            // txtMaTT
            // 
            this.txtMaTT.Location = new System.Drawing.Point(84, 28);
            this.txtMaTT.Name = "txtMaTT";
            this.txtMaTT.Size = new System.Drawing.Size(172, 23);
            this.txtMaTT.TabIndex = 73;
            // 
            // dtgThanhToan
            // 
            this.dtgThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgThanhToan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.MaTT,
            this.HinhThucTT});
            this.dtgThanhToan.Location = new System.Drawing.Point(84, 291);
            this.dtgThanhToan.Name = "dtgThanhToan";
            this.dtgThanhToan.RowTemplate.Height = 25;
            this.dtgThanhToan.Size = new System.Drawing.Size(636, 150);
            this.dtgThanhToan.TabIndex = 72;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            // 
            // MaTT
            // 
            this.MaTT.HeaderText = "Mã Thanh Toán";
            this.MaTT.Name = "MaTT";
            // 
            // HinhThucTT
            // 
            this.HinhThucTT.HeaderText = "Hình Thức Thanh Toán";
            this.HinhThucTT.Name = "HinhThucTT";
            // 
            // fThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnXoaNV);
            this.Controls.Add(this.btnSuaNV);
            this.Controls.Add(this.btnThemNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labe);
            this.Controls.Add(this.txtHinhThucTT);
            this.Controls.Add(this.txtMaTT);
            this.Controls.Add(this.dtgThanhToan);
            this.Name = "fThanhToan";
            this.Text = "fThanhToan";
            ((System.ComponentModel.ISupportInitialize)(this.dtgThanhToan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnTimKiem;
        private TextBox txtTimKiem;
        private Label label6;
        private Button btnHienThi;
        private Button btnXoaNV;
        private Button btnSuaNV;
        private Button btnThemNV;
        private Label label3;
        private Label labe;
        private TextBox txtHinhThucTT;
        private TextBox txtMaTT;
        private DataGridView dtgThanhToan;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn MaTT;
        private DataGridViewTextBoxColumn HinhThucTT;
    }
}