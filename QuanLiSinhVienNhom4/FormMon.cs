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
using QuanLiSinhVienNhom4;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp6
{
    public partial class FromMon : Form
    {
        public FromMon()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source =DESKTOP-6EVU3R0\\SQLEXPRESS; " +
            "Initial Catalog = quanlisinhvien; " +
            "User ID = sa; Password = khacsy0; ";
        SqlConnection conn = null;
        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            LoadMonHoc();
            LoadMaGiangVien();
            LoadKhoa();
        }


        private DataTable originalDataTable;
        private void LoadMonHoc()
        {
            LoadDataMonHoc();
            LoadTRIM();
            originalDataTable = ((DataTable)dgvMH.DataSource).Copy();
        }

        private void LoadTRIM()
        {
            string sql = "select * FROM monhoc";

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
        }
        private void LoadDataMonHoc()
        {
            try
            {
                string sql = "SELECT * FROM monhoc";
                SqlDataAdapter daSV = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                daSV.Fill(dt);
                dgvMH.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void LoadKhoa()
        {
            string sql = "select * from khoa";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
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
            cbK.SelectedIndex = -1;
        }
        public event Action DataUpdated;
        private void btnX_Click(object sender, EventArgs e)
        {
            if (dgvMH.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            string checkSql = "SELECT COUNT(*) FROM diemthi WHERE mamonhoc = @MaMH";
            using (SqlCommand cmd = new SqlCommand(checkSql, conn))
            {
                cmd.Parameters.AddWithValue("@MaMH", txbMMH.Text);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa! Môn học này đang được sử dụng trong bảng Điểm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgvMH.SelectedRows)
                {
                    if (row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))

                    {
                        MessageBox.Show("Dữ liệu trong hàng chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string maMH = row.Cells[0].Value.ToString();
                    string sql = "DELETE FROM monhoc WHERE mamonhoc = @MaMH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@MaMH", maMH);
                        cmd.ExecuteNonQuery();
                    }

                    dgvMH.Rows.Remove(row); // Xóa khỏi DataGridView
                    DataUpdated?.Invoke();
                }
            }

            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbGV.Text = "";
            txbMMH.Clear();
            txbSTC.Clear();
            txbTenMH.Clear();
            txbHSDQT.Clear();
            txbHSDT.Clear();
            cbK.Text = "";
            originalDataTable = ((DataTable)dgvMH.DataSource).Copy();
        }


        private void LoadMaGiangVien()
        {
            string sql = "select * from giangvien";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
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
            cbGV.DataSource = dt;
            cbGV.DisplayMember = "tengiangvien";
            cbGV.SelectedIndex = -1;
        }
        private void btnT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbHSDQT.Text) || string.IsNullOrEmpty(txbHSDQT.Text) || string.IsNullOrEmpty(txbHSDQT.Text) || string.IsNullOrEmpty(txbHSDQT.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sqlcheck = "select count(*) from monhoc where mamonhoc = @MaMH or TenMH = @TenMH";
            using (SqlCommand cmdd = new SqlCommand(sqlcheck, conn))
            {

                cmdd.Parameters.AddWithValue("@MaMH", txbMMH.Text);
                cmdd.Parameters.AddWithValue("@TenMH", txbTenMH.Text);
                int count = (int)cmdd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Dữ liệu đã có trong bảng!Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            double HSDiemQT = 0f, HSDiemT = 0f;
            if (!double.TryParse(txbHSDQT.Text, out HSDiemQT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(txbHSDT.Text, out HSDiemT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "insert into MONHOC (mamonhoc,TenMH,MaK,SoTinChi,TenGV,HSDiemQT,HSDiemT)" +
                " values (@mamonhoc,@TenMH,@MaK,@SoTinChi,@TenGV,@HSDiemQT,@HSDiemT)";


            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {

                cmd.Parameters.AddWithValue("@mamonhoc", txbMMH.Text);
                cmd.Parameters.AddWithValue("@TenMH", txbTenMH.Text);
                cmd.Parameters.AddWithValue("@MaK", cbK.Text);
                cmd.Parameters.AddWithValue("@SoTinChi", txbSTC.Text);
                cmd.Parameters.AddWithValue("@TenGV", cbGV.Text);
                cmd.Parameters.AddWithValue("@HSDiemQT", Math.Round(HSDiemQT, 1));
                cmd.Parameters.AddWithValue("@HSDiemT", Math.Round(HSDiemT, 1));
                int sodong = cmd.ExecuteNonQuery();
                if (sodong > 0)
                {
                    LoadDataMonHoc();

                }

                DataUpdated?.Invoke();
            }
            cbGV.Text = "";
            txbMMH.Clear();
            txbSTC.Clear();
            cbK.Text = "";
            txbTenMH.Clear();
            txbHSDQT.Clear();
            txbHSDT.Clear();
            originalDataTable = ((DataTable)dgvMH.DataSource).Copy();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            double HSDiemQT = 0f, HSDiemT = 0f;
            if (!double.TryParse(txbHSDQT.Text, out HSDiemQT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(txbHSDT.Text, out HSDiemT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sql = "update MONHOC set TenMH = @TenMH,MaK = @MaK,SoTinChi = @SoTinChi, TenGV = @TenGV , HSDiemQT = @HSDiemQT, HSDiemT = @HSDiemT where MaMH = @MaMH;" +
                 " UPDATE DIEM SET TenMH = @TenMH WHERE mamonhoc = @MaMH;";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaMH", txbMMH.Text);
                cmd.Parameters.AddWithValue("@TenMH", txbTenMH.Text);
                cmd.Parameters.AddWithValue("@MaK", cbK.Text);
                cmd.Parameters.AddWithValue("@SoTinChi", txbSTC.Text);
                cmd.Parameters.AddWithValue("@TenGV", cbGV.Text);
                cmd.Parameters.AddWithValue("@HSDiemQT", Math.Round(HSDiemQT, 1));
                cmd.Parameters.AddWithValue("@HSDiemT", Math.Round(HSDiemT, 1));
                int sodong = cmd.ExecuteNonQuery();
                if (sodong > 0)
                {
                    LoadDataMonHoc();

                }
                DataUpdated?.Invoke();
            }
            originalDataTable = ((DataTable)dgvMH.DataSource).Copy();
        }

        private void dgvMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMMH.Text = dgvMH.CurrentRow.Cells[0].Value.ToString().Trim();
            txbTenMH.Text = dgvMH.CurrentRow.Cells[1].Value.ToString().Trim();
            txbSTC.Text = dgvMH.CurrentRow.Cells[3].Value.ToString();
            cbGV.Text = dgvMH.CurrentRow.Cells[4].Value.ToString();
            cbK.Text = dgvMH.CurrentRow.Cells[2].Value.ToString();
            txbHSDQT.Text = dgvMH.CurrentRow.Cells[5].Value.ToString();
            txbHSDT.Text = dgvMH.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnLM_Click(object sender, EventArgs e)
        {
            cbGV.Text = "";
            txbMMH.Clear();
            txbSTC.Clear();
            cbK.Text = "";
            txbTenMH.Clear();
            txbHSDQT.Clear();
            txbHSDT.Clear();

            LoadDataMonHoc();
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void PerformSearch()
        {
            string searchText = textBox7.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Không tìm thầy thông tin cần tìm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable filteredData = new DataTable();

            // Sao chép cấu trúc của bảng gốc
            if (originalDataTable != null)
            {
                filteredData = originalDataTable.Clone();


                foreach (DataRow row in originalDataTable.Rows)
                {
                    bool rowMatches = false;


                    foreach (DataColumn col in originalDataTable.Columns)
                    {

                        if (row[col] != null && row[col].ToString().ToLower().Contains(searchText))
                        {
                            rowMatches = true;
                            break;
                        }
                    }
                    if (rowMatches)
                    {
                        filteredData.ImportRow(row);
                    }
                }


                dgvMH.DataSource = filteredData;
            }
        }



        private void cbGV_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnTke_Click(object sender, EventArgs e)
        {
           FormTkeMon formTkeMon = new FormTkeMon();    
           formTkeMon.ShowDialog();
        }
    }
}
