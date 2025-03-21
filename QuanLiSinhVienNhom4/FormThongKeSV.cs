using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLiSinhVienNhom4
{
    public partial class FormThongKeSV: Form
    {
        string chuoiketnoi = "Data Source = DESKTOP-DOFGP4J;" +
            " Initial Catalog = quanlisinhvien; Integrated Security = true";
        
        public FormThongKeSV()
        {
            InitializeComponent();
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            string tieuchi = comboBoxTieuChi.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tieuchi))
            {
                MessageBox.Show("Vui lòng chọn tiêu chí thống kê!");
                return;
            }

            string query = "";
            if (tieuchi == "Theo giới tính")
            {
                query = "Select gioitinh, count(*) as soluong from sinhvien group by gioitinh";
            }
            else if (tieuchi == "Theo quê quán")
            {
                query = "Select quequan, count(*) as soluong from sinhvien group by quequan";
            }
            else if (tieuchi == "Theo lớp")
            {
                query = "Select lop.tenlop, count(*) as soluong from sinhvien " +
                        "join lop on sinhvien.malop = lop.malop group by lop.tenlop";
            }

            ThongKe(query, tieuchi); // 🔥 Gọi phương thức với tiêu chí đã chọn
        }


        private void ThongKe(string query, string tieuchi)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // ✅ Cập nhật DataGridView
                dataGridViewThongKe.DataSource = dt;

                // ✅ Thiết lập lại tiêu đề cột theo tiêu chí
                if (tieuchi == "Theo giới tính")
                {
                    dataGridViewThongKe.Columns[0].HeaderText = "Giới tính";
                    dataGridViewThongKe.Columns[1].HeaderText = "Số lượng";
                }
                else if (tieuchi == "Theo quê quán")
                {
                    dataGridViewThongKe.Columns[0].HeaderText = "Quê quán";
                    dataGridViewThongKe.Columns[1].HeaderText = "Số lượng";
                }
                else if (tieuchi == "Theo lớp")
                {
                    dataGridViewThongKe.Columns[0].HeaderText = "Tên lớp";
                    dataGridViewThongKe.Columns[1].HeaderText = "Số lượng";
                }

                // ✅ Cập nhật Chart
                chartThongKe.Series.Clear();
                Series series = new Series("Số lượng");
                series.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    string label = row[0].ToString();
                    int value = Convert.ToInt32(row[1]);
                    series.Points.AddXY(label, value);
                }

                chartThongKe.Series.Add(series);
                chartThongKe.ChartAreas[0].AxisX.Title = "Nhóm";
                chartThongKe.ChartAreas[0].AxisY.Title = "Số lượng";
                chartThongKe.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartThongKe.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
                chartThongKe.ChartAreas[0].AxisX.Interval = 1;
                chartThongKe.ChartAreas[0].AxisX.IsLabelAutoFit = true;

                // ✅ Bật scroll nếu số lượng nhóm quá nhiều
                chartThongKe.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chartThongKe.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                chartThongKe.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            }
        }

    }
}
