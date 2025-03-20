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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLiSinhVienNhom4
{
    public partial class fdanhsachgiangvien: Form
    {
        public fdanhsachgiangvien()
        {
            InitializeComponent();
        }
        string chuoilienket = "Data Source= DESKTOP-N04KL08\\SQLEXPRESS01;" +
            "Initial Catalog=quanlysinhvien;" +
            "Integrated Security=True;";
        SqlConnection conn = null;

        DataTable Load_SQL(string sql)
        {
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        

        private void fdanhsachgiangvien_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Giangvien " +
                "left JOIN Khoa ON Giangvien.makhoa = Khoa.makhoa;";
            dgv_giangvien.DataSource = Load_SQL(sql);
        }




        void Xoagiangvien(string magiangvien)
        {
            string query = "delete from giangvien where magiangvien=@magiangvien";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@magiangvien", magiangvien);

            cmd.ExecuteNonQuery();
        }


        private void bt_them_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (rd_nam.Checked)
                gt = "Nam";
            if (rd_nu.Checked)
                gt = "Nữ";
            string sql = "insert giangvien values (@magiangvien,@tengiangvien,@sodienthoai,@diachi,@makhoa,@gioitinh);";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@magiangvien", tb_magiangvien.Text);
            cmd.Parameters.AddWithValue("@tengiangvien", tb_hoten.Text);
            cmd.Parameters.AddWithValue("@sodienthoai", tb_sdt.Text);
            cmd.Parameters.AddWithValue("@diachi", tb_diachi.Text);
            cmd.Parameters.AddWithValue("@makhoa", cb_makhoa.Text);
            cmd.Parameters.AddWithValue("@gioitinh", gt);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Mã Giảng viên " + tb_magiangvien.Text + " đã được sử dụng");
            }

            fdanhsachgiangvien_Load(sender, e);

        }

        private void dgv_giangvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_magiangvien.Text = dgv_giangvien.CurrentRow.Cells[0].Value.ToString().Trim();
            tb_hoten.Text = dgv_giangvien.CurrentRow.Cells[1].Value.ToString().Trim();
            cb_makhoa.Text = dgv_giangvien.CurrentRow.Cells[2].Value.ToString().Trim();
            date_ngaysinh.Text = dgv_giangvien.CurrentRow.Cells[5].Value.ToString().Trim();
            tb_sdt.Text = dgv_giangvien.CurrentRow.Cells[6].Value.ToString().Trim();
            tb_diachi.Text = dgv_giangvien.CurrentRow.Cells[7].Value.ToString().Trim();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {

        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_giangvien.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgv_giangvien.SelectedRows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string magiangvien = row.Cells[0].Value.ToString(); // Giả sử cột đầu tiên là MaKhoa

                            // Xóa dữ liệu trong SQL
                            Xoagiangvien(magiangvien);


                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fdanhsachgiangvien_Load(sender, e);
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT Giangvien.magiangvien, Giangvien.tengiangvien, Khoa.makhoa, Khoa.tenkhoa 
                   FROM Giangvien 
                   LEFT JOIN Khoa ON Giangvien.makhoa = Khoa.makhoa 
                   WHERE Giangvien.magiangvien LIKE @magiangvien 
                   OR Giangvien.tengiangvien LIKE @tengiangvien 
                   OR Khoa.tenkhoa LIKE @tenkhoa";

            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@magiangvien", "%" + tb_magiangvien.Text.Trim() + "%");
            da.SelectCommand.Parameters.AddWithValue("@tengiangvien", "%" + tb_hoten.Text.Trim() + "%");
            da.SelectCommand.Parameters.AddWithValue("@tenkhoa", "%" + cb_makhoa.Text.Trim() + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_giangvien.DataSource = dt; // Hiển thị dữ liệu trên DataGridView giảng viên
        }

        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            tb_magiangvien.Clear();
            tb_hoten.Clear();
            tb_sdt.Clear();
            tb_diachi.Clear();
            cb_makhoa.SelectedIndex = -1;
            rd_nam.Checked = false;
            rd_nu.Checked = false;
            fdanhsachgiangvien_Load(sender, e); // Load lại danh sách
        }

        private void tlp_button_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
