namespace QuanLiSinhVienNhom4
{
    partial class fdanhsachgiangvien
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
            this.p_dgv = new System.Windows.Forms.Panel();
            this.dgv_giangvien = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_hoten = new System.Windows.Forms.Label();
            this.tb_magiangvien = new System.Windows.Forms.TextBox();
            this.lb_diachi = new System.Windows.Forms.Label();
            this.tb_diachi = new System.Windows.Forms.TextBox();
            this.lb_sodienthoai = new System.Windows.Forms.Label();
            this.tb_sdt = new System.Windows.Forms.TextBox();
            this.lb_magiangvien = new System.Windows.Forms.Label();
            this.tb_hoten = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp_button = new System.Windows.Forms.TableLayoutPanel();
            this.bt_timkiem = new System.Windows.Forms.Button();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_lammoi = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_ngaysinh = new System.Windows.Forms.Label();
            this.date_ngaysinh = new System.Windows.Forms.DateTimePicker();
            this.lb_giotinh = new System.Windows.Forms.Label();
            this.lb_khoa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_makhoa = new System.Windows.Forms.ComboBox();
            this.tb_khoa = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rd_nu = new System.Windows.Forms.RadioButton();
            this.rd_nam = new System.Windows.Forms.RadioButton();
            this.p_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giangvien)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlp_button.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_dgv
            // 
            this.p_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_dgv.Controls.Add(this.dgv_giangvien);
            this.p_dgv.Location = new System.Drawing.Point(1, 205);
            this.p_dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p_dgv.Name = "p_dgv";
            this.p_dgv.Size = new System.Drawing.Size(1120, 349);
            this.p_dgv.TabIndex = 0;
            // 
            // dgv_giangvien
            // 
            this.dgv_giangvien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_giangvien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column4});
            this.dgv_giangvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_giangvien.Location = new System.Drawing.Point(0, 0);
            this.dgv_giangvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_giangvien.Name = "dgv_giangvien";
            this.dgv_giangvien.RowHeadersWidth = 62;
            this.dgv_giangvien.RowTemplate.Height = 28;
            this.dgv_giangvien.Size = new System.Drawing.Size(1120, 349);
            this.dgv_giangvien.TabIndex = 1;
            this.dgv_giangvien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_giangvien_CellClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "magiangvien";
            this.Column1.HeaderText = "Mã giảng viên";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "tengiangvien";
            this.Column2.HeaderText = "Họ tên";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "makhoa";
            this.Column8.HeaderText = "Mã khoa";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.Width = 150;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "tenkhoa";
            this.Column3.HeaderText = "Khoa";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "gioitinh";
            this.Column5.HeaderText = "Giới tính";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "ngaysinh";
            this.Column6.HeaderText = "Ngày sinh";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "sodienthoai";
            this.Column7.HeaderText = "Số điện thoại";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "diachi";
            this.Column4.HeaderText = "Địa chỉ";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1121, 200);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.66666F));
            this.tableLayoutPanel2.Controls.Add(this.lb_hoten, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tb_magiangvien, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lb_diachi, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_diachi, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lb_sodienthoai, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_sdt, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lb_magiangvien, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tb_hoten, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(554, 196);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lb_hoten
            // 
            this.lb_hoten.AutoSize = true;
            this.lb_hoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_hoten.Location = new System.Drawing.Point(3, 47);
            this.lb_hoten.Name = "lb_hoten";
            this.lb_hoten.Size = new System.Drawing.Size(101, 47);
            this.lb_hoten.TabIndex = 1;
            this.lb_hoten.Text = "Họ tên";
            // 
            // tb_magiangvien
            // 
            this.tb_magiangvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_magiangvien.Location = new System.Drawing.Point(110, 2);
            this.tb_magiangvien.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_magiangvien.Name = "tb_magiangvien";
            this.tb_magiangvien.Size = new System.Drawing.Size(441, 22);
            this.tb_magiangvien.TabIndex = 6;
            // 
            // lb_diachi
            // 
            this.lb_diachi.AutoSize = true;
            this.lb_diachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_diachi.Location = new System.Drawing.Point(3, 141);
            this.lb_diachi.Name = "lb_diachi";
            this.lb_diachi.Size = new System.Drawing.Size(101, 55);
            this.lb_diachi.TabIndex = 2;
            this.lb_diachi.Text = "Địa chỉ";
            // 
            // tb_diachi
            // 
            this.tb_diachi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_diachi.Location = new System.Drawing.Point(110, 143);
            this.tb_diachi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_diachi.Name = "tb_diachi";
            this.tb_diachi.Size = new System.Drawing.Size(441, 22);
            this.tb_diachi.TabIndex = 9;
            // 
            // lb_sodienthoai
            // 
            this.lb_sodienthoai.AutoSize = true;
            this.lb_sodienthoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_sodienthoai.Location = new System.Drawing.Point(3, 94);
            this.lb_sodienthoai.Name = "lb_sodienthoai";
            this.lb_sodienthoai.Size = new System.Drawing.Size(101, 47);
            this.lb_sodienthoai.TabIndex = 3;
            this.lb_sodienthoai.Text = "Số điện thoại";
            // 
            // tb_sdt
            // 
            this.tb_sdt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_sdt.Location = new System.Drawing.Point(110, 96);
            this.tb_sdt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_sdt.Name = "tb_sdt";
            this.tb_sdt.Size = new System.Drawing.Size(441, 22);
            this.tb_sdt.TabIndex = 8;
            // 
            // lb_magiangvien
            // 
            this.lb_magiangvien.AutoSize = true;
            this.lb_magiangvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_magiangvien.Location = new System.Drawing.Point(3, 0);
            this.lb_magiangvien.Name = "lb_magiangvien";
            this.lb_magiangvien.Size = new System.Drawing.Size(101, 47);
            this.lb_magiangvien.TabIndex = 4;
            this.lb_magiangvien.Text = "Mã Giảng viên";
            // 
            // tb_hoten
            // 
            this.tb_hoten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_hoten.Location = new System.Drawing.Point(110, 49);
            this.tb_hoten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_hoten.Name = "tb_hoten";
            this.tb_hoten.Size = new System.Drawing.Size(441, 22);
            this.tb_hoten.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlp_button);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(563, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 196);
            this.panel1.TabIndex = 2;
            // 
            // tlp_button
            // 
            this.tlp_button.ColumnCount = 5;
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.Controls.Add(this.bt_timkiem, 3, 0);
            this.tlp_button.Controls.Add(this.bt_them, 0, 0);
            this.tlp_button.Controls.Add(this.bt_xoa, 2, 0);
            this.tlp_button.Controls.Add(this.bt_sua, 1, 0);
            this.tlp_button.Controls.Add(this.bt_lammoi, 4, 0);
            this.tlp_button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlp_button.Location = new System.Drawing.Point(0, 162);
            this.tlp_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tlp_button.Name = "tlp_button";
            this.tlp_button.RowCount = 1;
            this.tlp_button.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_button.Size = new System.Drawing.Size(555, 34);
            this.tlp_button.TabIndex = 3;
            this.tlp_button.Paint += new System.Windows.Forms.PaintEventHandler(this.tlp_button_Paint);
            // 
            // bt_timkiem
            // 
            this.bt_timkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_timkiem.Location = new System.Drawing.Point(336, 2);
            this.bt_timkiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_timkiem.Name = "bt_timkiem";
            this.bt_timkiem.Size = new System.Drawing.Size(105, 30);
            this.bt_timkiem.TabIndex = 3;
            this.bt_timkiem.Text = "Tìm kiếm";
            this.bt_timkiem.UseVisualStyleBackColor = true;
            this.bt_timkiem.Click += new System.EventHandler(this.bt_timkiem_Click);
            // 
            // bt_them
            // 
            this.bt_them.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_them.Location = new System.Drawing.Point(3, 2);
            this.bt_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(105, 30);
            this.bt_them.TabIndex = 0;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_xoa.Location = new System.Drawing.Point(225, 2);
            this.bt_xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(105, 30);
            this.bt_xoa.TabIndex = 2;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_sua.Location = new System.Drawing.Point(114, 2);
            this.bt_sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(105, 30);
            this.bt_sua.TabIndex = 1;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_lammoi
            // 
            this.bt_lammoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_lammoi.Location = new System.Drawing.Point(447, 2);
            this.bt_lammoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_lammoi.Name = "bt_lammoi";
            this.bt_lammoi.Size = new System.Drawing.Size(105, 30);
            this.bt_lammoi.TabIndex = 4;
            this.bt_lammoi.Text = "Làm mới";
            this.bt_lammoi.UseVisualStyleBackColor = true;
            this.bt_lammoi.Click += new System.EventHandler(this.bt_lammoi_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.37452F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.62548F));
            this.tableLayoutPanel3.Controls.Add(this.lb_ngaysinh, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.date_ngaysinh, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lb_giotinh, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lb_khoa, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cb_makhoa, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.tb_khoa, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(555, 158);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lb_ngaysinh
            // 
            this.lb_ngaysinh.AutoSize = true;
            this.lb_ngaysinh.Location = new System.Drawing.Point(3, 39);
            this.lb_ngaysinh.Name = "lb_ngaysinh";
            this.lb_ngaysinh.Size = new System.Drawing.Size(67, 16);
            this.lb_ngaysinh.TabIndex = 1;
            this.lb_ngaysinh.Text = "Ngày sinh";
            // 
            // date_ngaysinh
            // 
            this.date_ngaysinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.date_ngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date_ngaysinh.Location = new System.Drawing.Point(99, 41);
            this.date_ngaysinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.date_ngaysinh.Name = "date_ngaysinh";
            this.date_ngaysinh.Size = new System.Drawing.Size(453, 22);
            this.date_ngaysinh.TabIndex = 3;
            this.date_ngaysinh.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lb_giotinh
            // 
            this.lb_giotinh.AutoSize = true;
            this.lb_giotinh.Location = new System.Drawing.Point(3, 0);
            this.lb_giotinh.Name = "lb_giotinh";
            this.lb_giotinh.Size = new System.Drawing.Size(54, 16);
            this.lb_giotinh.TabIndex = 0;
            this.lb_giotinh.Text = "Giới tính";
            // 
            // lb_khoa
            // 
            this.lb_khoa.AutoSize = true;
            this.lb_khoa.Location = new System.Drawing.Point(3, 117);
            this.lb_khoa.Name = "lb_khoa";
            this.lb_khoa.Size = new System.Drawing.Size(38, 16);
            this.lb_khoa.TabIndex = 2;
            this.lb_khoa.Text = "Khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã khoa";
            // 
            // cb_makhoa
            // 
            this.cb_makhoa.DisplayMember = "MaKhoa";
            this.cb_makhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_makhoa.FormattingEnabled = true;
            this.cb_makhoa.Location = new System.Drawing.Point(99, 80);
            this.cb_makhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_makhoa.Name = "cb_makhoa";
            this.cb_makhoa.Size = new System.Drawing.Size(453, 24);
            this.cb_makhoa.TabIndex = 6;
            this.cb_makhoa.ValueMember = "MaKhoa";
            // 
            // tb_khoa
            // 
            this.tb_khoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_khoa.Location = new System.Drawing.Point(99, 119);
            this.tb_khoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_khoa.Name = "tb_khoa";
            this.tb_khoa.ReadOnly = true;
            this.tb_khoa.Size = new System.Drawing.Size(453, 22);
            this.tb_khoa.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rd_nu);
            this.panel2.Controls.Add(this.rd_nam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(99, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 35);
            this.panel2.TabIndex = 8;
            // 
            // rd_nu
            // 
            this.rd_nu.AutoSize = true;
            this.rd_nu.Location = new System.Drawing.Point(180, 6);
            this.rd_nu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rd_nu.Name = "rd_nu";
            this.rd_nu.Size = new System.Drawing.Size(45, 20);
            this.rd_nu.TabIndex = 1;
            this.rd_nu.TabStop = true;
            this.rd_nu.Text = "Nữ";
            this.rd_nu.UseVisualStyleBackColor = true;
            // 
            // rd_nam
            // 
            this.rd_nam.AutoSize = true;
            this.rd_nam.Location = new System.Drawing.Point(12, 6);
            this.rd_nam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rd_nam.Name = "rd_nam";
            this.rd_nam.Size = new System.Drawing.Size(57, 20);
            this.rd_nam.TabIndex = 0;
            this.rd_nam.TabStop = true;
            this.rd_nam.Text = "Nam";
            this.rd_nam.UseVisualStyleBackColor = true;
            // 
            // fdanhsachgiangvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.p_dgv);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fdanhsachgiangvien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách giảng viên";
            this.Load += new System.EventHandler(this.fdanhsachgiangvien_Load);
            this.p_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_giangvien)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tlp_button.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel p_dgv;
        private System.Windows.Forms.DataGridView dgv_giangvien;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lb_hoten;
        private System.Windows.Forms.TextBox tb_magiangvien;
        private System.Windows.Forms.Label lb_diachi;
        private System.Windows.Forms.TextBox tb_diachi;
        private System.Windows.Forms.Label lb_sodienthoai;
        private System.Windows.Forms.TextBox tb_sdt;
        private System.Windows.Forms.Label lb_magiangvien;
        private System.Windows.Forms.TextBox tb_hoten;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlp_button;
        private System.Windows.Forms.Button bt_timkiem;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_lammoi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lb_ngaysinh;
        private System.Windows.Forms.DateTimePicker date_ngaysinh;
        private System.Windows.Forms.Label lb_giotinh;
        private System.Windows.Forms.Label lb_khoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_makhoa;
        private System.Windows.Forms.TextBox tb_khoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rd_nu;
        private System.Windows.Forms.RadioButton rd_nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}