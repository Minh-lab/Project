namespace QuanLiSinhVienNhom4
{
    partial class FormTkeDiem
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMon2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLop1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTkeD = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTkeD)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.57692F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.42308F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(899, 241);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMon2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbLop1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbMon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbLop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 235);
            this.panel1.TabIndex = 0;
            // 
            // cbMon2
            // 
            this.cbMon2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMon2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMon2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMon2.FormattingEnabled = true;
            this.cbMon2.Location = new System.Drawing.Point(324, 155);
            this.cbMon2.Name = "cbMon2";
            this.cbMon2.Size = new System.Drawing.Size(301, 24);
            this.cbMon2.TabIndex = 7;
            this.cbMon2.SelectionChangeCommitted += new System.EventHandler(this.cbMon2_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(3, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 44);
            this.label4.TabIndex = 6;
            this.label4.Text = "Điểm trung bình các lớp môn";
            // 
            // cbLop1
            // 
            this.cbLop1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLop1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLop1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLop1.FormattingEnabled = true;
            this.cbLop1.Location = new System.Drawing.Point(324, 85);
            this.cbLop1.Name = "cbLop1";
            this.cbLop1.Size = new System.Drawing.Size(301, 24);
            this.cbLop1.TabIndex = 5;
            this.cbLop1.SelectionChangeCommitted += new System.EventHandler(this.cbLop1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trung bình các môn học trong lớp";
            // 
            // cbMon
            // 
            this.cbMon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbMon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(324, 38);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(301, 24);
            this.cbMon.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(7, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "môn";
            // 
            // cbLop
            // 
            this.cbLop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(324, 5);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(301, 24);
            this.cbLop.TabIndex = 1;
            this.cbLop.SelectedIndexChanged += new System.EventHandler(this.cbLop_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số SV đỗ, đạt của lớp ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.button3, 0, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(637, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.90476F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.238095F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.95238F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.42857F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.90476F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(259, 210);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(3, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thống kê";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(253, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Thống kê";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(253, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "Thống kê";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTkeD, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 250);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 262);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // dgvTkeD
            // 
            this.dgvTkeD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTkeD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTkeD.Location = new System.Drawing.Point(3, 3);
            this.dgvTkeD.Name = "dgvTkeD";
            this.dgvTkeD.ReadOnly = true;
            this.dgvTkeD.RowHeadersWidth = 51;
            this.dgvTkeD.RowTemplate.Height = 24;
            this.dgvTkeD.Size = new System.Drawing.Size(893, 256);
            this.dgvTkeD.TabIndex = 0;
            // 
            // FormTkeDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 513);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormTkeDiem";
            this.Text = "FormTkeDiem";
            this.Load += new System.EventHandler(this.FormTkeDiem_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTkeD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbMon2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLop1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvTkeD;
    }
}