using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLiSinhVienNhom4
{
    public partial class FormThongKeLop : Form
    {
        public FormThongKeLop()
        {
            InitializeComponent();
        }
        public string chuoiketnoi = "Data Source = DESKTOP-DOFGP4J;" +
                                        " Initial Catalog =  quanlisinhvien;" +
                                            "Integrated Security = true;  ";
        public SqlConnection conn = null;
        private void cmbtieuchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbtieuchi.SelectedIndex == 0)
            {
                lopform lopform = new lopform();
                cmbluachon.DataSource = lopform.getDanhSachLop();
                cmbluachon.DisplayMember = "tenlop";
                cmbluachon.ValueMember = "tenlop";
                lblluachon.Text = "Chọn Lớp";
                cmbluachon.Visible = true;

            }
            if(cmbtieuchi.SelectedIndex == 1)
            {
                lopform lopform = new lopform();
                cmbluachon.DataSource = lopform.getDanhSachKhoa();
                cmbluachon.DisplayMember = "tenkhoa";
                cmbluachon.ValueMember = "tenkhoa";
                lblluachon.Text = "Chọn Khoa";
                cmbluachon.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                if (cmbtieuchi.SelectedIndex == 0)
                {
                    string query = @"
                                    SELECT 
                                        l.tenlop AS [Tên lớp], 
                                        SUM(CASE WHEN sv.gioitinh = N'Nam' THEN 1 ELSE 0 END) AS [Số nam], 
                                        SUM(CASE WHEN sv.gioitinh = N'Nữ' THEN 1 ELSE 0 END) AS [Số nữ]
                                    FROM lop l
                                    LEFT JOIN sinhvien sv ON l.malop = sv.malop 
                                    WHERE l.tenlop = N'" + cmbluachon.Text + @"'
                                    GROUP BY l.tenlop";
                    DataTable dt = new DataTable();
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, conn);
                    sqlData.Fill(dt);
                    thongke.DataSource = dt;
                    chartthongke.Series.Clear();

                    // 2️⃣ Tạo Series cho Số Nam
                    Series seriesNam = new Series("Số Nam");
                    seriesNam.ChartType = SeriesChartType.Column; // Biểu đồ cột
                    seriesNam.Color = Color.Blue;
                    seriesNam.IsValueShownAsLabel = true; // Hiển thị số trên cột
                    chartthongke.Series.Add(seriesNam);

                    // 3️⃣ Tạo Series cho Số Nữ
                    Series seriesNu = new Series("Số Nữ");
                    seriesNu.ChartType = SeriesChartType.Column;
                    seriesNu.Color = Color.Pink;
                    seriesNu.IsValueShownAsLabel = true;
                    chartthongke.Series.Add(seriesNu);

                    // 4️⃣ Cấu hình trục X, Y
                    chartthongke.ChartAreas[0].AxisX.Title = "Lớp học";
                    chartthongke.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
                    chartthongke.ChartAreas[0].AxisY.Minimum = 0; // Bắt đầu từ 0
                    chartthongke.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả lớp

                    // 5️⃣ Thêm dữ liệu vào biểu đồ
                    foreach (DataRow row in dt.Rows)
                    {
                        string tenLop = row["Tên lớp"].ToString();
                        int soNam = Convert.ToInt32(row["Số nam"]);
                        int soNu = Convert.ToInt32(row["Số nữ"]);

                        chartthongke.Series["Số Nam"].Points.AddXY(tenLop, soNam);
                        chartthongke.Series["Số Nữ"].Points.AddXY(tenLop, soNu);
                    }

                    // 6️⃣ Cập nhật lại biểu đồ sau khi thêm dữ liệu
                    // Lấy giá trị lớn nhất của Số Nam và Số Nữ
                    int maxValue = dt.AsEnumerable()
                                     .Max(row => Math.Max(Convert.ToInt32(row["Số nam"]), Convert.ToInt32(row["Số nữ"])));

                    // Đặt trục Y với khoảng phù hợp
                    chartthongke.ChartAreas[0].AxisY.Minimum = 0;
                    chartthongke.ChartAreas[0].AxisY.Maximum = maxValue + 5; // Thêm khoảng trống để dễ nhìn
                    chartthongke.ChartAreas[0].AxisY.Interval = Math.Max(1, maxValue / 5); // Chia khoảng cho dễ đọc

                    // Cập nhật lại biểu đồ
                    chartthongke.Update();
                }
                else if (cmbluachon.SelectedIndex == 1)
                {

                }
              }
            }
        }
    }

