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
    public partial class fdanhsachkhoa: Form
    {
        public fdanhsachkhoa()
        {
            InitializeComponent();
            fdanhsachgiangvien frm = new fdanhsachgiangvien();
            //frm.Show();
        }
        string chuoilienket = "Data Source = DESKTOP-6EVU3R0\\SQLEXPRESS;" +
            " Initial Catalog = quanlisinhvien; Integrated Security = true";
        SqlConnection conn = null;

        void Load_dgv(string sql)
        {
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_khoa.DataSource = dt;
        }
        private void fdanhsachkhoa_Load(object sender, EventArgs e)
        {
            string sql = "SELECT magiangvien, tengiangvien FROM giangvien;";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb_matruongkhoa.DataSource = dt;
            cb_matruongkhoa.DisplayMember = "magianvien"; // Hiển thị mã giảng viên
            cb_matruongkhoa.ValueMember = "tengiangvien";  // Giá trị là họ tên
            tb_tentruongkhoa.Text = cb_matruongkhoa.SelectedValue?.ToString();

            sql = "SELECT khoa.makhoa, khoa.tenkhoa, khoa.matruongkhoa, giangvien.tengiangvien FROM khoa " +
                "LEft JOIN giangvien ON khoa.matruongkhoa = giangvien.magiangvien;";
            Load_dgv(sql);

            cb_matruongkhoa.SelectedIndex = -1;
        }

        private void cb_matruongkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        private void cb_matruongkhoa_TextChanged(object sender, EventArgs e)
        {
            
            tb_tentruongkhoa.Text = cb_matruongkhoa.SelectedValue?.ToString();
            if(cb_matruongkhoa.Text=="")
            {
                cb_matruongkhoa.SelectedIndex = -1;
            }
        }

        private void dgv_khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            tb_makhoa.Text = dgv_khoa.CurrentRow.Cells[0].Value.ToString().Trim();
            tb_tenkhoa.Text = dgv_khoa.CurrentRow.Cells[1].Value.ToString().Trim();
            cb_matruongkhoa.Text = dgv_khoa.CurrentRow.Cells[2].Value.ToString().Trim();
            
        }

        void Xoakhoa(string Makhoa)
        {
            string query = "delete from khoa where makhoa=@makhoa";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@makhoa", Makhoa);

            cmd.ExecuteNonQuery();
        }










        //Thêm
        private void bt_them_Click(object sender, EventArgs e)
        {
            if(tb_makhoa.Text.Trim()=="" || tb_tenkhoa.Text.Trim()=="")
            {
                MessageBox.Show("Không hợp lệ");
                return;
            }    

            string sql = "insert khoa values (@makhoa,@tenkhoa,@matruongkhoa);";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@makhoa", tb_makhoa.Text);
            cmd.Parameters.AddWithValue("@tenkhoa", tb_tenkhoa.Text);
            cmd.Parameters.AddWithValue("@matruongkhoa", cb_matruongkhoa.Text);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Mã khoa " + tb_makhoa.Text + " đã được sử dụng");
            }
            fdanhsachkhoa_Load(sender, e);
        }
        //Sửa
        private void bt_sua_Click(object sender, EventArgs e)
        {
            string sql = "update khoa set tenkhoa=@tenkhoa,matruongkhoa=@matruongkhoa where makhoa=@makhoa;";
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@makhoa", tb_makhoa.Text);
            cmd.Parameters.AddWithValue("@tenkhoa", tb_tenkhoa.Text);
            cmd.Parameters.AddWithValue("@matruongkhoa", tb_tentruongkhoa.Text);

            cmd.ExecuteNonQuery();
            fdanhsachkhoa_Load(sender, e);
        }
        //Xóa
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            
            if (dgv_khoa.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgv_khoa.SelectedRows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            string Makhoa = row.Cells[0].Value.ToString(); // Giả sử cột đầu tiên là MaKhoa

                            // Xóa dữ liệu trong SQL
                            Xoakhoa(Makhoa);

                            
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fdanhsachkhoa_Load(sender, e);
        }
        //Làm mới
        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            Application.Restart();
            //this.Close(); // Đóng form hiện tại
            //fdanhsachkhoa newForm = new fdanhsachkhoa(); // Tạo instance mới
            //newForm.Show(); // Mở lại form
        }
        //Tìm kiếm
        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string sql = "SELECT khoa.makhoa, khoa.tenkhoa, khoa.matruongkhoa, giangvien.tengiangvien FROM khoa " +
                "LEft JOIN giangvien ON khoa.matruongkhoa = giangvien.magianvien " +
                "WHERE khoa.makhoa LIKE @makhoa OR " +
                "khoa.tenkhoa LIKE @tenkhoa OR " +
                "khoa.matruongkhoa LIKE @matruongkhoa";

            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@makhoa", string.IsNullOrEmpty(tb_makhoa.Text) ? "" : "%" + tb_makhoa.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@tenkhoa", string.IsNullOrEmpty(tb_tenkhoa.Text) ? "" : "%" + tb_tenkhoa.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@matruongkhoa", string.IsNullOrEmpty(cb_matruongkhoa.Text) ? "" : "%" + cb_matruongkhoa.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_khoa.DataSource = dt;
        }

        private void tb_makhoa_TextChanged(object sender, EventArgs e)
        {
            // Giới hạn độ dài mã khoa (tối đa 10 ký tự)
            if (tb_makhoa.Text.Length > 10)
            {
                tb_makhoa.Text = tb_makhoa.Text.Substring(0, 10);
                tb_makhoa.SelectionStart = tb_makhoa.Text.Length; // Giữ con trỏ cuối dòng
            }

        }

        private void tb_tenkhoa_TextChanged(object sender, EventArgs e)
        {

            // Giới hạn độ dài tên khoa (tối đa 50 ký tự)
            if (tb_tenkhoa.Text.Length > 50)
            {
                tb_tenkhoa.Text = tb_tenkhoa.Text.Substring(0, 50);
                tb_tenkhoa.SelectionStart = tb_tenkhoa.Text.Length; // Giữ con trỏ cuối dòng
            }
        }
    }
}
