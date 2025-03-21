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
        public string chuoiketnoi = "Data Source = LAPTOP-UPFI3FMF\\ASADAS; " +
            "Initial Catalog = QLSV; " +
            "User ID = sa; Password = khacsy0; ";

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
                lblluachon.Text = "";
                cmbluachon.Visible = false;
            }
            if (cmbtieuchi.SelectedIndex == 2)
            {
                lopform lopform = new lopform();
                cmbluachon.DataSource = lopform.getDanhSachKhoa();
                cmbluachon.DisplayMember = "tenkhoa";
                cmbluachon.ValueMember = "tenkhoa";
                lblluachon.Text = "Chọn khoa";
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

                    Series seriesNam = new Series("Số Nam");
                    seriesNam.ChartType = SeriesChartType.Column; // Biểu đồ cột
                    seriesNam.Color = Color.Blue;
                    seriesNam.IsValueShownAsLabel = true; // Hiển thị số trên cột
                    chartthongke.Series.Add(seriesNam);


                    Series seriesNu = new Series("Số Nữ");
                    seriesNu.ChartType = SeriesChartType.Column;
                    seriesNu.Color = Color.Pink;
                    seriesNu.IsValueShownAsLabel = true;
                    chartthongke.Series.Add(seriesNu);


                    chartthongke.ChartAreas[0].AxisX.Title = "Lớp học";
                    chartthongke.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
                    chartthongke.ChartAreas[0].AxisY.Minimum = 0; // Bắt đầu từ 0
                    chartthongke.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả lớp

                    foreach (DataRow row in dt.Rows)
                    {
                        string tenLop = row["Tên lớp"].ToString();
                        int soNam = Convert.ToInt32(row["Số nam"]);
                        int soNu = Convert.ToInt32(row["Số nữ"]);

                        chartthongke.Series["Số Nam"].Points.AddXY(tenLop, soNam);
                        chartthongke.Series["Số Nữ"].Points.AddXY(tenLop, soNu);
                    }

                    int maxValue = dt.AsEnumerable()
                                     .Max(row => Math.Max(Convert.ToInt32(row["Số nam"]), Convert.ToInt32(row["Số nữ"])));

                    chartthongke.ChartAreas[0].AxisY.Minimum = 0;
                    chartthongke.ChartAreas[0].AxisY.Maximum = maxValue + 10; // Thêm khoảng trống để dễ nhìn
                    chartthongke.ChartAreas[0].AxisY.Interval = Math.Max(1, maxValue / 2); // Chia khoảng cho dễ đọc

                    chartthongke.Update();
                }
                else if (cmbtieuchi.SelectedIndex == 1)
                {
                    string query = "SELECT khoa.tenkhoa as [Tên khoa], COUNT(sinhvien.masinhvien) AS [Số sinh viên] FROM khoa JOIN lop ON khoa.makhoa = lop.makhoa JOIN sinhvien ON lop.malop = sinhvien.malop GROUP BY khoa.tenkhoa";
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                    sqlDataAdapter.Fill(dataTable);
                    thongke.DataSource = dataTable;
                    chartthongke.Series.Clear();

                    Series series = new Series("Số Sinh Viên");
                    series.ChartType = SeriesChartType.Column; // Dạng biểu đồ cột
                    series.Color = Color.Blue;
                    series.IsValueShownAsLabel = true; // Hiển thị số lượng trên cột
                    chartthongke.Series.Add(series);

                    // 3️⃣ Thêm dữ liệu từ DataTable vào Chart
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string tenKhoa = row["Tên khoa"].ToString();
                        int soSinhVien = Convert.ToInt32(row["Số sinh viên"]);

                        // Thêm điểm dữ liệu vào biểu đồ
                        chartthongke.Series["Số Sinh Viên"].Points.AddXY(tenKhoa, soSinhVien);
                    }

                    // 4️⃣ Cấu hình trục X, Y cho biểu đồ
                    chartthongke.ChartAreas[0].AxisX.Title = "Khoa";
                    chartthongke.ChartAreas[0].AxisY.Title = "Số lượng sinh viên";
                    chartthongke.ChartAreas[0].AxisY.Minimum = 0;
                    chartthongke.ChartAreas[0].AxisX.Interval = 1; // Hiển thị tất cả khoa

                    // 5️⃣ Cập nhật lại biểu đồ
                    chartthongke.Update();
                }
                else if (cmbtieuchi.SelectedIndex == 2)
                {
                    string query = @"
                    SELECT 
                        khoa.tenkhoa AS [Tên Khoa], 
                        lop.tenlop AS [Tên Lớp], 
                        COUNT(sinhvien.masinhvien) AS [Số Sinh Viên] 
                    FROM khoa
                    JOIN lop ON khoa.makhoa = lop.makhoa
                    JOIN sinhvien ON lop.malop = sinhvien.malop
                    WHERE khoa.tenkhoa = @tenkhoa
                    GROUP BY khoa.tenkhoa, lop.tenlop;
                ";

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Tạo SqlCommand và thêm Parameter
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenkhoa", cmbluachon.Text);
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dataTable);
                    }

                    // Hiển thị dữ liệu lên DataGridView
                    thongke.DataSource = dataTable;

                    // Xóa dữ liệu cũ trong Chart
                    chartthongke.Series.Clear();

                    // Tạo Series mới cho biểu đồ (Dạng cột)
                    Series series = new Series("Số Sinh Viên")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.Blue,
                        IsValueShownAsLabel = true // Hiển thị số trên cột
                    };

                    int maxValue = 0; // Biến lưu giá trị lớn nhất để đặt trục Y

                    // Thêm dữ liệu từ DataTable vào Chart
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string tenLop = row["Tên Lớp"].ToString();
                        int soSV = Convert.ToInt32(row["Số Sinh Viên"]);

                        series.Points.AddXY(tenLop, soSV);

                        // Cập nhật giá trị lớn nhất
                        if (soSV > maxValue)
                            maxValue = soSV;
                    }

                    // Thêm Series vào Chart
                    chartthongke.Series.Add(series);
                    // Cập nhật biểu đồ
                    chartthongke.Invalidate();
                }
            



            
        }
            }
        }
    }

