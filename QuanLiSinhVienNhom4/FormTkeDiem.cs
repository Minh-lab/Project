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
    public partial class FormTkeDiem : Form
    {
        public event Action DataUpdated;
        public FormTkeDiem()
        {
            InitializeComponent();
            DataUpdated?.Invoke();
        }
        string chuoiketnoi = "Data Source=LAPTOP-UPFI3FMF\\ASADAS;Initial Catalog=quanlisinhvien;User ID = sa; Password = khacsy0;";
        SqlConnection conn = null;
        private void FormTkeDiem_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoiketnoi);
            conn.Open();
            LoadMaLop();
            cbMon.DataSource = null;
            cbMon.Items.Clear();
            LoadMaMonHoc1();
        }

        private void LoadMaMonHoc()
        {
            string sql = "select * FROM monhoc where MaK = @MaK";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaK", maKhoa);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            cbMon.DataSource = dt;
            cbMon.DisplayMember = "TenMH";
            cbMon.ValueMember = "mamonhoc";
            cbMon.SelectedIndex = -1;
        }
        private void LoadMaMonHoc1()
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
            cbMon2.DataSource = dt;
            cbMon2.DisplayMember = "TenMH";
            cbMon2.ValueMember = "mamonhoc";
            cbMon2.SelectedIndex = -1;
        }

        private void LoadMaLop()
        {
            string sql = "select * FROM lop";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            DataTable data = new DataTable();
            da.Fill(dt);
            da.Fill(data);
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
            cbLop.DataSource = dt;
            cbLop.DisplayMember = "malop";
            cbLop.ValueMember = "malop";
            cbLop.SelectedIndex = -1;
            cbLop1.DataSource = data;
            cbLop1.DisplayMember = "malop";
            cbLop1.ValueMember = "malop";
            cbLop1.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbLop.SelectedIndex == -1 || cbMon.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học trước khi thống kê!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy mã lớp và mã môn học được chọn
            string maLop = cbLop.SelectedValue.ToString().Trim();
            string maMon = cbMon.SelectedValue.ToString().Trim();
            string tenMon = cbMon.Text.Trim();

            // Chuẩn bị DataGridView
            dgvTkeD.Columns.Clear();
            DataGridViewTextBoxColumn colMaL = new DataGridViewTextBoxColumn();
            colMaL.Name = "MaL";
            colMaL.HeaderText = "Mã Lớp";
            dgvTkeD.Columns.Add(colMaL);

            DataGridViewTextBoxColumn colTenMH = new DataGridViewTextBoxColumn();
            colTenMH.Name = "TenMH";
            colTenMH.HeaderText = "Tên Môn Học";
            dgvTkeD.Columns.Add(colTenMH);

            DataGridViewTextBoxColumn colDo = new DataGridViewTextBoxColumn();
            colDo.Name = "Do";
            colDo.HeaderText = "Số SV Đạt";
            dgvTkeD.Columns.Add(colDo);

            DataGridViewTextBoxColumn colTruot = new DataGridViewTextBoxColumn();
            colTruot.Name = "Truot";
            colTruot.HeaderText = "Số SV Trượt";
            dgvTkeD.Columns.Add(colTruot);

            DataGridViewTextBoxColumn colTongSV = new DataGridViewTextBoxColumn();
            colTongSV.Name = "TongSV";
            colTongSV.HeaderText = "Tổng Số SV";
            dgvTkeD.Columns.Add(colTongSV);

            DataGridViewTextBoxColumn colTyLeDat = new DataGridViewTextBoxColumn();
            colTyLeDat.Name = "TyLeDat";
            colTyLeDat.HeaderText = "Tỷ Lệ Đạt (%)";
            dgvTkeD.Columns.Add(colTyLeDat);

            dgvTkeD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                // Truy vấn SQL để đếm số sinh viên đạt và trượt
                string sql = @"
            SELECT 
                COUNT(CASE WHEN DanhGia = 'Dat' THEN 1 END) AS SoSVDat,
                COUNT(CASE WHEN DanhGia = 'Truot' THEN 1 END) AS SoSVTruot,
                COUNT(*) AS TongSoSV
            FROM DIEM
            WHERE MaL = @MaL AND MaMH = @MaMH";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaL", maLop);
                cmd.Parameters.AddWithValue("@MaMH", maMon);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int soSVDat = Convert.ToInt32(reader["SoSVDat"]);
                    int soSVTruot = Convert.ToInt32(reader["SoSVTruot"]);
                    int tongSoSV = Convert.ToInt32(reader["TongSoSV"]);
                    double tyLeDat = tongSoSV > 0 ? (soSVDat * 100.0 / tongSoSV) : 0;

                    // Thêm dữ liệu vào DataGridView
                    dgvTkeD.Rows.Add(maLop, tenMon, soSVDat, soSVTruot, tongSoSV, Math.Round(tyLeDat, 2) + "%");

                    // Hiển thị tổng kết
                    string thongKe = $"Thống kê môn {tenMon} của lớp {maLop}:\n" +
                                     $"- Số sinh viên đạt: {soSVDat}\n" +
                                     $"- Số sinh viên trượt: {soSVTruot}\n" +
                                     $"- Tổng số sinh viên: {tongSoSV}\n" +
                                     $"- Tỷ lệ đạt: {Math.Round(tyLeDat, 2)}%";

                    MessageBox.Show(thongKe, "Kết quả thống kê", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu điểm cho lớp và môn học này!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê điểm: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string maKhoa = "";
        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop.SelectedIndex != -1 && cbLop.SelectedItem != null)
            {
                try
                {
                    DataRowView selectedRow = (DataRowView)cbLop.SelectedItem;
                    maKhoa = selectedRow["MaK"].ToString().Trim();
                    LoadMaMonHoc();

                }
                catch
                {

                }
            }

        }
        private void cbLop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLop1.SelectedIndex != -1 && cbLop1.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)cbLop1.SelectedItem;
                maKhoa = selectedRow["MaK"].ToString().Trim();

            }
        }
        private void cbMon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMon2.SelectedIndex != -1 && cbMon2.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)cbMon2.SelectedItem;
                maKhoa = selectedRow["MaK"].ToString().Trim();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cbLop1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn lớp trước khi thống kê!",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = cbLop1.SelectedValue.ToString().Trim();

            // Chuẩn bị DataGridView
            dgvTkeD.Columns.Clear();

            DataGridViewTextBoxColumn colTenMH = new DataGridViewTextBoxColumn();
            colTenMH.Name = "TenMH";
            colTenMH.HeaderText = "Tên Môn Học";
            dgvTkeD.Columns.Add(colTenMH);

            DataGridViewTextBoxColumn colTongSV = new DataGridViewTextBoxColumn();
            colTongSV.Name = "TongSV";
            colTongSV.HeaderText = "Số SV Học Môn";
            dgvTkeD.Columns.Add(colTongSV);

            DataGridViewTextBoxColumn colDo = new DataGridViewTextBoxColumn();
            colDo.Name = "Do";
            colDo.HeaderText = "Số SV Đạt";
            dgvTkeD.Columns.Add(colDo);

            DataGridViewTextBoxColumn colTruot = new DataGridViewTextBoxColumn();
            colTruot.Name = "Truot";
            colTruot.HeaderText = "Số SV Trượt";
            dgvTkeD.Columns.Add(colTruot);

            DataGridViewTextBoxColumn colTyLeDat = new DataGridViewTextBoxColumn();
            colTyLeDat.Name = "TyLeDat";
            colTyLeDat.HeaderText = "Tỷ Lệ Đạt (%)";
            dgvTkeD.Columns.Add(colTyLeDat);

            dgvTkeD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                string sql = @"
            SELECT MH.TenMH, 
                COUNT(D.MaSV) AS TongSoSV,
                COUNT(CASE WHEN D.DanhGia = 'Dat' THEN 1 END) AS SoSVDat,
                COUNT(CASE WHEN D.DanhGia = 'Truot' THEN 1 END) AS SoSVChuaDat
            FROM MONHOC MH
            LEFT JOIN DIEM D ON MH.MaMH = D.MaMH AND D.MaL = @MaL
            WHERE MH.MaK = @MaK
            GROUP BY MH.TenMH";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaL", maLop);
                cmd.Parameters.AddWithValue("@MaK", maKhoa);

                SqlDataReader reader = cmd.ExecuteReader();

                int totalRows = 0;
                while (reader.Read())
                {
                    string tenMon = reader["TenMH"].ToString().Trim();
                    int tongSoSV = Convert.ToInt32(reader["TongSoSV"]);
                    int soSVDat = Convert.ToInt32(reader["SoSVDat"]);
                    int soSVChuaDat = Convert.ToInt32(reader["SoSVChuaDat"]);

                    double tyLeDat = tongSoSV > 0 ? (soSVDat * 100.0 / tongSoSV) : 0;

                    dgvTkeD.Rows.Add(tenMon, tongSoSV, soSVDat, soSVChuaDat, Math.Round(tyLeDat, 2) + "%");
                    totalRows++;
                }

                reader.Close();

                if (totalRows == 0)
                {
                    MessageBox.Show("Không có dữ liệu môn học cho lớp này!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Đã thống kê được {totalRows} môn học của lớp {maLop}",
                                   "Thống kê thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê điểm: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cbMon2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn môn học trước khi thống kê!",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string maMon = cbMon2.SelectedValue.ToString().Trim();
            string tenMon = cbMon2.Text.Trim();

            // Chuẩn bị DataGridView
            dgvTkeD.Columns.Clear();

            // Thêm các cột mới phù hợp với chức năng thống kê điểm trung bình
            DataGridViewTextBoxColumn colMaL = new DataGridViewTextBoxColumn();
            colMaL.Name = "MaL";
            colMaL.HeaderText = "Mã Lớp";
            dgvTkeD.Columns.Add(colMaL);


            DataGridViewTextBoxColumn colTenMH = new DataGridViewTextBoxColumn();
            colTenMH.Name = "TenMH";
            colTenMH.HeaderText = "Tên Môn Học";
            dgvTkeD.Columns.Add(colTenMH);

            DataGridViewTextBoxColumn colDiemTB = new DataGridViewTextBoxColumn();
            colDiemTB.Name = "DiemTB";
            colDiemTB.HeaderText = "Điểm Trung Bình";
            dgvTkeD.Columns.Add(colDiemTB);

            DataGridViewTextBoxColumn colDiemCao = new DataGridViewTextBoxColumn();
            colDiemCao.Name = "DiemCaoNhat";
            colDiemCao.HeaderText = "Điểm Cao Nhất";
            dgvTkeD.Columns.Add(colDiemCao);

            DataGridViewTextBoxColumn colDiemThap = new DataGridViewTextBoxColumn();
            colDiemThap.Name = "DiemThapNhat";
            colDiemThap.HeaderText = "Điểm Thấp Nhất";
            dgvTkeD.Columns.Add(colDiemThap);

            DataGridViewTextBoxColumn colTongSV = new DataGridViewTextBoxColumn();
            colTongSV.Name = "TongSV";
            colTongSV.HeaderText = "Số SV Học Môn";
            dgvTkeD.Columns.Add(colTongSV);

            dgvTkeD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {
                string sql = @"
            SELECT 
                L.MaL,
                AVG(CAST(D.DiemTK AS FLOAT)) AS DiemTrungBinh,
                MAX(D.DiemTK) AS DiemCaoNhat,
                MIN(D.DiemTK) AS DiemThapNhat,
                COUNT(D.MaSV) AS SoSinhVien
            FROM LOP L
            LEFT JOIN DIEM D ON L.MaL = D.MaL AND D.MaMH = @MaMH
            WHERE L.MaK = @MaK
            GROUP BY L.MaL";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaMH", maMon);
                cmd.Parameters.AddWithValue("@MaK", maKhoa);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string maLop = reader["MaL"].ToString().Trim();

                    // Xử lý giá trị NULL có thể có từ LEFT JOIN
                    double diemTB = reader["DiemTrungBinh"] != DBNull.Value
                        ? Math.Round(Convert.ToDouble(reader["DiemTrungBinh"]), 2)
                        : 0;

                    string diemCaoNhat = reader["DiemCaoNhat"] != DBNull.Value
                        ? reader["DiemCaoNhat"].ToString()
                        : "N/A";

                    string diemThapNhat = reader["DiemThapNhat"] != DBNull.Value
                        ? reader["DiemThapNhat"].ToString()
                        : "N/A";

                    int soSinhVien = reader["SoSinhVien"] != DBNull.Value
                        ? Convert.ToInt32(reader["SoSinhVien"])
                        : 0;

                    // Thêm dữ liệu vào DataGridView
                    dgvTkeD.Rows.Add(maLop, tenMon, diemTB, diemCaoNhat, diemThapNhat, soSinhVien);
                }
                reader.Close();

                // Thông báo khi hoàn tất
                if (dgvTkeD.Rows.Count > 0)
                {
                    //lblTongKet.Text = $"Thống kê điểm trung bình môn {tenMon} cho {dgvTkeD.Rows.Count} lớp của khoa";
                }
                else
                {
                    //lblTongKet.Text = "Không có dữ liệu thống kê";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê điểm trung bình: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
