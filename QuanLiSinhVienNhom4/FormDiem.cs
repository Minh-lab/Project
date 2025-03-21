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
using Microsoft.VisualBasic.ApplicationServices;

namespace QuanLiSinhVienNhom4
{
    public partial class FormDiem : Form
    {
        public FormDiem()
        {
            InitializeComponent();
        }
        private DataTable originalDataTable;
        public float HSDQT = 0, HSDT = 0;

        string chuoiketnoi = "Data Source=DESKTOP-6EVU3R0\\SQLEXPRESS; " +
            "Initial Catalog = quanlisinhvien; " +
            "Integrated Security = true; ";



        SqlConnection conn = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            LoadDiemSV();

        }

        private void LoadDiemSV()
        {
            LoadDataDiem();
            LoadMaSinhVien();
            LoadMaMonHoc();

            originalDataTable = ((DataTable)dgvDSV.DataSource).Copy();
        }

        public void LoadDataDiem()
        {
            try
            {
                string sql = "SELECT * FROM diemthi";
                SqlDataAdapter daSV = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                daSV.Fill(dt);
                dgvDSV.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadMaSinhVien()
        {
            try
            {
                string sql = "SELECT * FROM sinhvien";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Debug kiểm tra bảng có dữ liệu không
 

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
                cbMSV.DataSource = dt;
                cbMSV.DisplayMember = "masinhvien";
                cbMSV.ValueMember = "masinhvien";
                cbMSV.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải mã sinh viên: " + ex.Message);
            }
        }

        string lop = "";
        private void cbMSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMSV.SelectedIndex != -1 && cbMSV.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)cbMSV.SelectedItem;
                    txbHT.Text = selectedRow["hoten"].ToString();
                    lop = selectedRow["malop"].ToString().Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    txbHT.Text = "";
                }
            }
            else
            {
                txbHT.Text = "";
            }
        }


        private void LoadMaMonHoc()
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
            cbMMH.DataSource = dt;
            cbMMH.DisplayMember = "mamonhoc";
            cbMMH.SelectedIndex = -1;
        }

        private void cbMMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMMH.SelectedIndex != -1 && cbMMH.SelectedItem != null)
            {
                try
                {
                    DataRowView data = (DataRowView)cbMMH.SelectedItem;
                    txbMH.Text = data["TenMH"].ToString().Trim();
                    HSDQT = data["HSDiemQT"] != DBNull.Value ?
                    Convert.ToSingle(data["HSDiemQT"]) : 0f;

                    HSDT = data["HSDiemT"] != DBNull.Value ?
                        Convert.ToSingle(data["HSDiemT"]) : 0f;
                }
                catch
                {
                    txbMH.Text = "";
                }
            }
            else
            {
                txbMH.Text = "";
            }
        }
        public double tong = 0;
        private void btnT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbMSV.Text) || string.IsNullOrEmpty(cbMMH.Text))
            {
                MessageBox.Show("Vui long nhap day du thong tin", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sqlcheck = "select count(*) from diemthi where masinhvien = @masinhvien and mamonhoc = @mamonhoc";
            using (SqlCommand cmdd = new SqlCommand(sqlcheck, conn))
            {
                cmdd.Parameters.AddWithValue("@masinhvien", cbMSV.Text);
                cmdd.Parameters.AddWithValue("@mamonhoc", cbMMH.Text);
                int count = (int)cmdd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Dữ liệu đã có trong bảng!Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            double DiemQT = 0f, DiemT = 0f;
            if (!double.TryParse(txbDQT.Text, out DiemQT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(txbDT.Text, out DiemT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double DiemTK = ((DiemQT * HSDQT + DiemT * HSDT));
            tong += DiemTK;
            string DiemChu = "", DanhGia = "";
            if (DiemTK < 4)
            {
                DiemChu = "F";
                DanhGia = "Truot";
            }
            else if (DiemTK >= 4 && DiemTK < 5.5)
            {
                DiemChu = "D";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 5.5 && DiemTK < 7)
            {
                DiemChu = "C";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 7 && DiemTK < 8.5)
            {
                DiemChu = "B";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 8.5 && DiemTK <= 10)
            {
                DiemChu = "A";
                DanhGia = "Dat";
            }

            string sql = "insert into diemthi (masinhvien,HoTen,MaL,mamonhoc,TenMH,DiemQT,DiemT,DiemTK,DiemC,DanhGia)" +
                " values (@masinhvien,@HoTen,@MaL,@mamonhoc,@TenMH,@DiemQT,@DiemT,@DiemTK,@DiemC,@DanhGia)";


            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@masinhvien", cbMSV.Text);
                cmd.Parameters.AddWithValue("@HoTen", txbHT.Text);
                cmd.Parameters.AddWithValue("@MaL", lop);
                cmd.Parameters.AddWithValue("@mamonhoc", cbMMH.Text);
                cmd.Parameters.AddWithValue("@TenMH", txbMH.Text);
                cmd.Parameters.AddWithValue("@DiemQT", Math.Round(DiemQT, 1));
                cmd.Parameters.AddWithValue("@DiemT", Math.Round(DiemT, 1));
                cmd.Parameters.AddWithValue("@DiemTK", Math.Round(DiemTK, 1));
                cmd.Parameters.AddWithValue("@DiemC", DiemChu);
                cmd.Parameters.AddWithValue("@DanhGia", DanhGia);
                int sodong = cmd.ExecuteNonQuery();
                if (sodong > 0)
                {
                    LoadDataDiem();
                }
            }
            originalDataTable = ((DataTable)dgvDSV.DataSource).Copy();
            txbDQT.Clear();
            txbDT.Clear();
            cbMSV.Text = "";
            cbMMH.Text = "";
            txbHT.Clear();
            txbMH.Clear();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (dgvDSV.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgvDSV.SelectedRows)
                {
                    if (row.Cells[0].Value == null || row.Cells[3].Value == null ||
                string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()) ||
                string.IsNullOrWhiteSpace(row.Cells[3].Value.ToString()))
                    {
                        MessageBox.Show("Dữ liệu trong hàng chọn không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string maSV = row.Cells[0].Value.ToString();
                    string maMH = row.Cells[3].Value.ToString();
                    string sql = "DELETE FROM diemthi WHERE masinhvien = @masinhvien AND mamonhoc = @mamonhoc";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@masinhvien", maSV);
                        cmd.Parameters.AddWithValue("@mamonhoc", maMH);
                        cmd.ExecuteNonQuery();
                    }

                    dgvDSV.Rows.Remove(row); // Xóa khỏi DataGridView
                }

            }
            originalDataTable = ((DataTable)dgvDSV.DataSource).Copy();
            txbDQT.Clear();
            txbDT.Clear();
            cbMSV.Text = "";
            cbMMH.Text = "";
            txbHT.Clear();
            txbMH.Clear();
            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dgvDSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMSV.Text = dgvDSV.CurrentRow.Cells[0].Value.ToString();
            txbHT.Text = dgvDSV.CurrentRow.Cells[1].Value.ToString();
            cbMMH.Text = dgvDSV.CurrentRow.Cells[3].Value.ToString();
            txbMH.Text = dgvDSV.CurrentRow.Cells[4].Value.ToString();
            txbDQT.Text = dgvDSV.CurrentRow.Cells[5].Value.ToString();
            txbDT.Text = dgvDSV.CurrentRow.Cells[6].Value.ToString();


        }

        private void btnS_Click(object sender, EventArgs e)
        {
            double DiemQT = 0f, DiemT = 0f;
            if (!double.TryParse(txbDQT.Text, out DiemQT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!double.TryParse(txbDT.Text, out DiemT))
            {
                MessageBox.Show("Vui long nhap so hop le cho diem", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double DiemTK = ((DiemQT * HSDQT + DiemT * HSDT));
            string DiemChu = "", DanhGia = "";
            if (DiemTK < 4)
            {
                DiemChu = "F";
                DanhGia = "Truot";
            }
            else if (DiemTK >= 4 && DiemTK < 5.5)
            {
                DiemChu = "D";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 5.5 && DiemTK < 7)
            {
                DiemChu = "C";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 7 && DiemTK < 8.5)
            {
                DiemChu = "B";
                DanhGia = "Dat";
            }
            else if (DiemTK >= 8.5 && DiemTK <= 10)
            {
                DiemChu = "A";
                DanhGia = "Dat";
            }

            string sql = "UPDATE diemthi set DiemQT = @DiemQT, DiemT = @DiemT,DiemTK =  @DiemTK, DiemC = @DiemC,DanhGia = @DanhGia FROM diemthi where masinhvien = @masinhvien and mamonhoc = @mamonhoc";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@masinhvien", cbMSV.Text);
                cmd.Parameters.AddWithValue("@mamonhoc", cbMMH.Text);
                cmd.Parameters.AddWithValue("@DiemQT", Math.Round(DiemQT, 1));
                cmd.Parameters.AddWithValue("@DiemT", Math.Round(DiemT, 1));
                cmd.Parameters.AddWithValue("@DiemTK", Math.Round(DiemTK, 1));
                cmd.Parameters.AddWithValue("@DiemC", DiemChu);
                cmd.Parameters.AddWithValue("@DanhGia", DanhGia);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    LoadDataDiem();
                }
            }
            originalDataTable = ((DataTable)dgvDSV.DataSource).Copy();
        }
        private void btnLM_Click(object sender, EventArgs e)
        {
            txbDQT.Clear();
            txbDT.Clear();
            cbMSV.Text = "";
            cbMMH.Text = "";
            txbHT.Clear();
            txbMH.Clear();
            LoadDataDiem();
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }
        private void PerformSearch()
        {
            string searchText = textBox1.Text.Trim().ToLower();
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
                dgvDSV.DataSource = filteredData;
            }
        }

        private void btnTKe_Click(object sender, EventArgs e)
        {
            FormTkeDiem formTkeDiem = new FormTkeDiem();
            formTkeDiem.DataUpdated += LoadDiemSV;
            formTkeDiem.ShowDialog();
        }


        private void cbMSV_Validating(object sender, CancelEventArgs e)
        {

            string input = cbMSV.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                return; // Không cần validate nếu trống
            }
            bool exists = false;

            // Duyệt qua danh sách item trong ComboBox
            foreach (var item in cbMSV.Items)
            {
                DataRowView row = item as DataRowView;
                if (row != null && row["masinhvien"].ToString() == input)
                {
                    exists = true;
                    break;
                }
            }


            if (!exists)
            {
                MessageBox.Show("Mã sinh viên không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void cbMMH_Validating(object sender, CancelEventArgs e)
        {

            string input = cbMMH.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            bool exists = false;


            foreach (var item in cbMMH.Items)
            {
                DataRowView row = item as DataRowView;
                if (row != null && row["mamonhoc"].ToString() == input)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                MessageBox.Show("Mã môn học không hợp lệ! Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }








    }
}
