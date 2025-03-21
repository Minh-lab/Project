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

namespace QuanLiSinhVienNhom4
{
    public partial class FormTkeMon : Form
    {
        public event Action DataUpdated;
        public FormTkeMon()
        {
            InitializeComponent();
            DataUpdated?.Invoke();
        }
        string chuoiketnoi = "Data Source=DESKTOP-6EVU3R0\\SQLEXPRESS;Initial Catalog=quanlisinhvien;User ID = sa; Password = khacsy0;";
        SqlConnection conn = null;
        private void FormTkeDiem_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            LoadMaK();
        }

       
        private void LoadMaK()
        {
          
                string sql = "select * FROM khoa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (row[col] is string)
                        {
                            row[col] = row[col].ToString().Trim();
                        }
                    }
                }
                cbK.DataSource = dt;
                cbK.DisplayMember = "makhoa";
                cbK.ValueMember = "makhoa";
                cbK.SelectedIndex = -1;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbK.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa trước khi thống kê!",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string makhoa = cbK.SelectedValue.ToString().Trim();

            

            // Thêm các cột phù hợp cho thống kê số môn học trong khoa
            DataGridViewTextBoxColumn colMaK = new DataGridViewTextBoxColumn();
            colMaK.Name = "MaK";
            colMaK.HeaderText = "Mã Khoa";
            dgvTkeMon.Columns.Add(colMaK);

            DataGridViewTextBoxColumn colTenK = new DataGridViewTextBoxColumn();
            colTenK.Name = "TenK";
            colTenK.HeaderText = "Tên Khoa";
            dgvTkeMon.Columns.Add(colTenK);

            DataGridViewTextBoxColumn colSoMH = new DataGridViewTextBoxColumn();
            colSoMH.Name = "SoMH";
            colSoMH.HeaderText = "Số Môn Học";
            dgvTkeMon.Columns.Add(colSoMH);

            dgvTkeMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                // Lấy tên khoa
                string tenKhoa = "";
                string sqlTenKhoa = "SELECT tenkhoa FROM khoa WHERE makhoa = @maK";
                SqlCommand cmdTenKhoa = new SqlCommand(sqlTenKhoa, conn);
                cmdTenKhoa.Parameters.AddWithValue("@maK", makhoa);
                object result = cmdTenKhoa.ExecuteScalar();
                if (result != null)
                {
                    tenKhoa = result.ToString().Trim();
                }

                // Lấy số lượng môn học trong khoa
                // Vì môn học chỉ có mã khoa, không có mã lớp
                string sql = @"
        SELECT COUNT(*) AS SoMonHoc
        FROM monhoc
        WHERE makhoa = @MaK";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaK", makhoa);

                int soMonHoc = Convert.ToInt32(cmd.ExecuteScalar());

                // Thêm dữ liệu vào DataGridView
                dgvTkeMon.Rows.Add(makhoa, tenKhoa, soMonHoc);

                // Thông báo khi hoàn tất
                if (soMonHoc > 0)
                {
                    MessageBox.Show($"Khoa {tenKhoa} có {soMonHoc} môn học.",
                        "Thống kê thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Khoa {tenKhoa} chưa có môn học nào.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê số môn học: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
