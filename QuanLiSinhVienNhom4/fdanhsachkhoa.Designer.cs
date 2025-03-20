namespace QuanLiSinhVienNhom4
{
    partial class fdanhsachkhoa
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_matruongkhoa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_tentruongkhoa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_tenkhoa = new System.Windows.Forms.TextBox();
            this.tb_makhoa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_khoa = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlp_button = new System.Windows.Forms.TableLayoutPanel();
            this.bt_them = new System.Windows.Forms.Button();
            this.bt_sua = new System.Windows.Forms.Button();
            this.bt_xoa = new System.Windows.Forms.Button();
            this.bt_lammoi = new System.Windows.Forms.Button();
            this.bt_timkiem = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khoa)).BeginInit();
            this.panel1.SuspendLayout();
            this.tlp_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cb_matruongkhoa);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tb_tentruongkhoa);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(559, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(551, 129);
            this.panel3.TabIndex = 1;
            // 
            // cb_matruongkhoa
            // 
            this.cb_matruongkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_matruongkhoa.FormattingEnabled = true;
            this.cb_matruongkhoa.Location = new System.Drawing.Point(160, 32);
            this.cb_matruongkhoa.Name = "cb_matruongkhoa";
            this.cb_matruongkhoa.Size = new System.Drawing.Size(371, 28);
            this.cb_matruongkhoa.TabIndex = 7;
            this.cb_matruongkhoa.SelectedIndexChanged += new System.EventHandler(this.cb_matruongkhoa_SelectedIndexChanged);
            this.cb_matruongkhoa.TextChanged += new System.EventHandler(this.cb_matruongkhoa_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã trưởng khoa";
            // 
            // tb_tentruongkhoa
            // 
            this.tb_tentruongkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_tentruongkhoa.Location = new System.Drawing.Point(160, 89);
            this.tb_tentruongkhoa.Name = "tb_tentruongkhoa";
            this.tb_tentruongkhoa.ReadOnly = true;
            this.tb_tentruongkhoa.Size = new System.Drawing.Size(371, 26);
            this.tb_tentruongkhoa.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên trưởng khoa";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_tenkhoa);
            this.panel2.Controls.Add(this.tb_makhoa);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 129);
            this.panel2.TabIndex = 0;
            // 
            // tb_tenkhoa
            // 
            this.tb_tenkhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_tenkhoa.Location = new System.Drawing.Point(136, 83);
            this.tb_tenkhoa.Name = "tb_tenkhoa";
            this.tb_tenkhoa.Size = new System.Drawing.Size(393, 26);
            this.tb_tenkhoa.TabIndex = 5;
            this.tb_tenkhoa.TextChanged += new System.EventHandler(this.tb_tenkhoa_TextChanged);
            // 
            // tb_makhoa
            // 
            this.tb_makhoa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_makhoa.Location = new System.Drawing.Point(136, 28);
            this.tb_makhoa.Name = "tb_makhoa";
            this.tb_makhoa.Size = new System.Drawing.Size(393, 26);
            this.tb_makhoa.TabIndex = 4;
            this.tb_makhoa.TextChanged += new System.EventHandler(this.tb_makhoa_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khoa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1113, 135);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgv_khoa
            // 
            this.dgv_khoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_khoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_khoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dgv_khoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_khoa.Location = new System.Drawing.Point(0, 0);
            this.dgv_khoa.Name = "dgv_khoa";
            this.dgv_khoa.ReadOnly = true;
            this.dgv_khoa.RowHeadersWidth = 62;
            this.dgv_khoa.RowTemplate.Height = 28;
            this.dgv_khoa.Size = new System.Drawing.Size(1112, 453);
            this.dgv_khoa.TabIndex = 2;
            this.dgv_khoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_khoa_CellClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgv_khoa);
            this.panel1.Location = new System.Drawing.Point(2, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 453);
            this.panel1.TabIndex = 0;
            // 
            // tlp_button
            // 
            this.tlp_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlp_button.ColumnCount = 5;
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlp_button.Controls.Add(this.bt_them, 0, 0);
            this.tlp_button.Controls.Add(this.bt_sua, 1, 0);
            this.tlp_button.Controls.Add(this.bt_xoa, 2, 0);
            this.tlp_button.Controls.Add(this.bt_lammoi, 3, 0);
            this.tlp_button.Controls.Add(this.bt_timkiem, 4, 0);
            this.tlp_button.Location = new System.Drawing.Point(131, 141);
            this.tlp_button.Name = "tlp_button";
            this.tlp_button.RowCount = 1;
            this.tlp_button.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_button.Size = new System.Drawing.Size(845, 59);
            this.tlp_button.TabIndex = 6;
            // 
            // bt_them
            // 
            this.bt_them.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_them.Location = new System.Drawing.Point(3, 3);
            this.bt_them.Name = "bt_them";
            this.bt_them.Size = new System.Drawing.Size(163, 53);
            this.bt_them.TabIndex = 0;
            this.bt_them.Text = "Thêm";
            this.bt_them.UseVisualStyleBackColor = true;
            this.bt_them.Click += new System.EventHandler(this.bt_them_Click);
            // 
            // bt_sua
            // 
            this.bt_sua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_sua.Location = new System.Drawing.Point(172, 3);
            this.bt_sua.Name = "bt_sua";
            this.bt_sua.Size = new System.Drawing.Size(163, 53);
            this.bt_sua.TabIndex = 1;
            this.bt_sua.Text = "Sửa";
            this.bt_sua.UseVisualStyleBackColor = true;
            this.bt_sua.Click += new System.EventHandler(this.bt_sua_Click);
            // 
            // bt_xoa
            // 
            this.bt_xoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_xoa.Location = new System.Drawing.Point(341, 3);
            this.bt_xoa.Name = "bt_xoa";
            this.bt_xoa.Size = new System.Drawing.Size(163, 53);
            this.bt_xoa.TabIndex = 2;
            this.bt_xoa.Text = "Xóa";
            this.bt_xoa.UseVisualStyleBackColor = true;
            this.bt_xoa.Click += new System.EventHandler(this.bt_xoa_Click);
            // 
            // bt_lammoi
            // 
            this.bt_lammoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_lammoi.Location = new System.Drawing.Point(510, 3);
            this.bt_lammoi.Name = "bt_lammoi";
            this.bt_lammoi.Size = new System.Drawing.Size(163, 53);
            this.bt_lammoi.TabIndex = 3;
            this.bt_lammoi.Text = "Làm mới";
            this.bt_lammoi.UseVisualStyleBackColor = true;
            this.bt_lammoi.Click += new System.EventHandler(this.bt_lammoi_Click);
            // 
            // bt_timkiem
            // 
            this.bt_timkiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_timkiem.Location = new System.Drawing.Point(679, 3);
            this.bt_timkiem.Name = "bt_timkiem";
            this.bt_timkiem.Size = new System.Drawing.Size(163, 53);
            this.bt_timkiem.TabIndex = 4;
            this.bt_timkiem.Text = "Tìm kiếm";
            this.bt_timkiem.UseVisualStyleBackColor = true;
            this.bt_timkiem.Click += new System.EventHandler(this.bt_timkiem_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Makhoa";
            this.Column1.HeaderText = "Mã khoa";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Tenkhoa";
            this.Column2.HeaderText = "Tên";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "matruongkhoa";
            this.Column4.HeaderText = "Mã trưởng khoa";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "tengiangvien";
            this.Column3.HeaderText = "Trưởng khoa";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // fdanhsachkhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 666);
            this.Controls.Add(this.tlp_button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "fdanhsachkhoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách khoa";
            this.Load += new System.EventHandler(this.fdanhsachkhoa_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_khoa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tlp_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cb_matruongkhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_tentruongkhoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_tenkhoa;
        private System.Windows.Forms.TextBox tb_makhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgv_khoa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlp_button;
        private System.Windows.Forms.Button bt_them;
        private System.Windows.Forms.Button bt_sua;
        private System.Windows.Forms.Button bt_xoa;
        private System.Windows.Forms.Button bt_lammoi;
        private System.Windows.Forms.Button bt_timkiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

