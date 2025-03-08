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

namespace LOP
{
    public partial class thongke : Form
    {
        public string chuoiketnoi = "Data Source = DESKTOP-DOFGP4J;" +
                                " Initial Catalog =  quanlisinhvien;" +
                                    "Integrated Security = true;  ";
        public SqlConnection conn = null;
        public thongke()
        {
            InitializeComponent();
        }

        private void btnsinhvien_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "select tenlop as TenLop, siso as SoLuongSV from lop";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị trên biểu đồ
                chart1.Series.Clear();
                Series series = new Series("Số Lượng SV");
                series.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["TenLop"].ToString(),row["SoLuongSV"]);
                }

                chart1.Series.Add(series);
                chart1.Visible = true;
            }
        }

        private void thongke_Load(object sender, EventArgs e)
        {
            chart1.Visible = false;
        }

        private void btnsinhvienkhoa_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "select tenkhoa as TenKhoa, count(masinhvien) as soluongsinhvien from khoa join lop on lop.makhoa = khoa.makhoa  join sinhvien on lop.malop = sinhvien.malop group by tenkhoa;\r\n";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị trên biểu đồ
                chart1.Series.Clear();
                Series series = new Series("Số Lượng SV");
                series.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["TenKhoa"].ToString(), row["soluongsinhvien"]);
                }

                chart1.Series.Add(series);
                chart1.Visible = true;
            }

        }

        private void btnnamnu_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "select tenlop as tenlop, count(masinhvien) as soluongsinhvien from sinhvien join lop on sinhvien.malop = lop.malop group by sinhvien.gioitinh";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Hiển thị trên biểu đồ
                chart1.Series.Clear();
                Series series = new Series("Số Lượng SV");
                series.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["TenKhoa"].ToString(), row["soluongsinhvien"]);
                }

                chart1.Series.Add(series);
                chart1.Visible = true;
            }
        }
    }
}
