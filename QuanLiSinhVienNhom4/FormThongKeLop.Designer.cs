namespace QuanLiSinhVienNhom4
{
    partial class FormThongKeLop
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbluachon = new System.Windows.Forms.ComboBox();
            this.lblluachon = new System.Windows.Forms.Label();
            this.cmbtieuchi = new System.Windows.Forms.ComboBox();
            this.lbltimkiem = new System.Windows.Forms.Label();
            this.chartthongke = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.thongke = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartthongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.thongke);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1146, 455);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.cmbluachon);
            this.splitContainer2.Panel1.Controls.Add(this.lblluachon);
            this.splitContainer2.Panel1.Controls.Add(this.cmbtieuchi);
            this.splitContainer2.Panel1.Controls.Add(this.lbltimkiem);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chartthongke);
            this.splitContainer2.Size = new System.Drawing.Size(1146, 200);
            this.splitContainer2.SplitterDistance = 615;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 61);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thống Kê";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbluachon
            // 
            this.cmbluachon.FormattingEnabled = true;
            this.cmbluachon.Location = new System.Drawing.Point(140, 89);
            this.cmbluachon.Name = "cmbluachon";
            this.cmbluachon.Size = new System.Drawing.Size(343, 33);
            this.cmbluachon.TabIndex = 3;
            this.cmbluachon.Visible = false;
            // 
            // lblluachon
            // 
            this.lblluachon.Location = new System.Drawing.Point(13, 79);
            this.lblluachon.Name = "lblluachon";
            this.lblluachon.Size = new System.Drawing.Size(111, 43);
            this.lblluachon.TabIndex = 2;
            this.lblluachon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbtieuchi
            // 
            this.cmbtieuchi.FormattingEnabled = true;
            this.cmbtieuchi.Items.AddRange(new object[] {
            "Thống kê số học sinh nam, nữ trong 1 lớp",
            "Thống kê số học sinh trong từng khoa",
            "Thống kê số học sinh trong từng lớp theo khoa"});
            this.cmbtieuchi.Location = new System.Drawing.Point(140, 13);
            this.cmbtieuchi.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtieuchi.Name = "cmbtieuchi";
            this.cmbtieuchi.Size = new System.Drawing.Size(343, 33);
            this.cmbtieuchi.TabIndex = 1;
            this.cmbtieuchi.SelectedIndexChanged += new System.EventHandler(this.cmbtieuchi_SelectedIndexChanged);
            // 
            // lbltimkiem
            // 
            this.lbltimkiem.Location = new System.Drawing.Point(13, 9);
            this.lbltimkiem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltimkiem.Name = "lbltimkiem";
            this.lbltimkiem.Size = new System.Drawing.Size(84, 41);
            this.lbltimkiem.TabIndex = 0;
            this.lbltimkiem.Text = "Tiêu chí ";
            this.lbltimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartthongke
            // 
            chartArea1.Name = "ChartArea1";
            this.chartthongke.ChartAreas.Add(chartArea1);
            this.chartthongke.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartthongke.Legends.Add(legend1);
            this.chartthongke.Location = new System.Drawing.Point(0, 0);
            this.chartthongke.Margin = new System.Windows.Forms.Padding(4);
            this.chartthongke.Name = "chartthongke";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartthongke.Series.Add(series1);
            this.chartthongke.Size = new System.Drawing.Size(526, 200);
            this.chartthongke.TabIndex = 0;
            this.chartthongke.Text = "chart1";
            // 
            // thongke
            // 
            this.thongke.AllowUserToAddRows = false;
            this.thongke.AllowUserToDeleteRows = false;
            this.thongke.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.thongke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.thongke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongke.Location = new System.Drawing.Point(0, 0);
            this.thongke.Name = "thongke";
            this.thongke.RowHeadersWidth = 62;
            this.thongke.RowTemplate.Height = 28;
            this.thongke.Size = new System.Drawing.Size(1146, 250);
            this.thongke.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1146, 250);
            this.dataGridView1.TabIndex = 0;
            // 
            // FormThongKeLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 455);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormThongKeLop";
            this.Text = "Thống kê";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartthongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartthongke;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbtieuchi;
        private System.Windows.Forms.Label lbltimkiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbluachon;
        private System.Windows.Forms.Label lblluachon;
        private System.Windows.Forms.DataGridView thongke;
    }
}