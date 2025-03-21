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
    public partial class fdanhsachkhoa1 : Form
    {
        public fdanhsachkhoa1()
        {
            InitializeComponent();
            //fdanhsachgiangvien frm = new fdanhsachgiangvien();
            //frm.Show();
        }
        // nơi chứa lệnh sql
        class SQL
        {
            public static string table1 = "khoa";
            public static string column11 = "makhoa";
            public static string column12 = "tenkhoa";
            public static string column13 = "magiangvien";

            public static string table2 = "giangvien";
            public static string column21 = "magiangvien";
            public static string column22 = "tengiangvien";

            public static string select()
            {
                return $"select {column21},{column22} from {table2}";
            }
            public static string select_from()
            {
                return $"SELECT {table1}.{column11}, {table1}.{column12}, {table1}.{column13}, {table2}.{column22} " +
                       $"FROM {table1} " +
                       $"LEFT JOIN {table2} ON {table1}.{column13} = {table2}.{column21};";
            }

            public static string them()
            {
                return $"INSERT INTO {table1} VALUES (@Makhoa, @Tenkhoa, @Matruongkhoa);";
            }

            public static string sua()
            {
                return $"UPDATE {table1} SET  {column12}=@Tenkhoa,{column13}=@Matruongkhoa WHERE {column11}=@Makhoa;";
            }

            public static string xoa()
            {
                return $"DELETE FROM {table1} WHERE {column11}=@Makhoa;";
            }

            public static string timkiem()
            {
                return $"SELECT {table1}.{column11}, {table1}.{column12}, {table1}.{column13}, {table2}.{column22} " +
                       $"FROM {table1} " +
                       $"LEFT JOIN {table2} ON {table1}.{column13} = {table2}.{column21} " +
                       $"WHERE LOWER({table1}.{column11}) LIKE LOWER(@Makhoa) OR " +
                       $"LOWER({table1}.{column12}) LIKE LOWER(@Tenkhoa) OR " +
                       $"LOWER({table1}.{column13}) LIKE LOWER(@Matruongkhoa);";
            }
        }


        




        public static string chuoilienket = "Data Source=DESKTOP-N04KL08\\SQLEXPRESS01;" +
            "Initial Catalog=quanlisinhvien;" +
            "Integrated Security=True;";
        SqlConnection conn = null;

        public DataTable Load_SQL_dt(string sql)
        {
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        void Load_dgv()
        {
            string sql = SQL.select_from();

            
            dgv_khoa.Columns["column1"].DataPropertyName = SQL.column11;
            dgv_khoa.Columns["column2"].DataPropertyName = SQL.column12;
            dgv_khoa.Columns["column3"].DataPropertyName = SQL.column13;
            dgv_khoa.Columns["column4"].DataPropertyName = SQL.column22;
            dgv_khoa.DataSource = Load_SQL_dt(sql);
            cb_matruongkhoa.SelectedIndex = -1;
        }

        void Load_cb()
        {
            string sql = SQL.select();
            

            cb_matruongkhoa.DataSource = Load_SQL_dt(sql);

            cb_matruongkhoa.DisplayMember = SQL.column21; 
            cb_matruongkhoa.ValueMember = SQL.column22;  

            tb_tentruongkhoa.Text = cb_matruongkhoa.SelectedValue?.ToString();
        }

        private void fdanhsachkhoa_Load(object sender, EventArgs e)
        {
            Load_dgv();

            Load_cb();

        }

        private void cb_matruongkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void cb_matruongkhoa_TextChanged(object sender, EventArgs e)
        {

            if (cb_matruongkhoa.SelectedValue != null)
            {
                tb_tentruongkhoa.Text = cb_matruongkhoa.SelectedValue.ToString();
            }
            else
            {
                tb_tentruongkhoa.Text = ""; // Nếu không có giá trị, để trống
            }
        }

        private void dgv_khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_khoa.CurrentRow != null)
            {
                tb_makhoa.Text = dgv_khoa.CurrentRow.Cells[0].Value?.ToString().Trim();
                tb_tenkhoa.Text = dgv_khoa.CurrentRow.Cells[1].Value?.ToString().Trim();
                cb_matruongkhoa.Text = dgv_khoa.CurrentRow.Cells[2].Value?.ToString().Trim();
            }

        }

        void Xoa(string x)
        {
            string sql = SQL.xoa();
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Makhoa", x);

            cmd.ExecuteNonQuery();
        }






        //Thêm
        private void bt_them_Click(object sender, EventArgs e)
        {
            if (tb_makhoa.Text.Trim() == "" || tb_tenkhoa.Text.Trim() == "")
            {
                MessageBox.Show("Điền đầy đủ thông tin");
                return;
            }

            string sql = SQL.them();
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Makhoa", tb_makhoa.Text);
            cmd.Parameters.AddWithValue("@Tenkhoa", tb_tenkhoa.Text);
            cmd.Parameters.AddWithValue("@Matruongkhoa", cb_matruongkhoa.Text);
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
            string sql = SQL.sua();
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@Makhoa", tb_makhoa.Text);
            cmd.Parameters.AddWithValue("@Tenkhoa", tb_tenkhoa.Text);
            cmd.Parameters.AddWithValue("@Matruongkhoa", cb_matruongkhoa.Text);

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
                            
                            Xoa(row.Cells[0].Value.ToString());


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
            //Application.Restart();
            //this.Close(); // Đóng form hiện tại
            //fdanhsachkhoa newForm = new fdanhsachkhoa(); // Tạo instance mới
            //newForm.Show(); // Mở lại form

            fdanhsachkhoa_Load(sender,e);
        }
        //Tìm kiếm
        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            string sql = SQL.timkiem();

            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            da.SelectCommand.Parameters.AddWithValue("@Makhoa", string.IsNullOrEmpty(tb_makhoa.Text) ? "" : "%" + tb_makhoa.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@Tenkhoa", string.IsNullOrEmpty(tb_tenkhoa.Text) ? "" : "%" + tb_tenkhoa.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@Matruongkhoa", string.IsNullOrEmpty(cb_matruongkhoa.Text) ? "" : "%" + cb_matruongkhoa.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_khoa.DataSource = dt;
        }

        private void tb_makhoa_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void tb_tenkhoa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
