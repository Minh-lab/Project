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
    public partial class fdanhsachgiangvien1: Form
    {
        public fdanhsachgiangvien1()
        {
            InitializeComponent();
        }
        


        class SQL
        {
            public static string table1 = "giangvien";
            public static string column11 = "magiangvien";
            public static string column12 = "tengiangvien";
            public static string column13 = "makhoa";
            public static string column14 = "diachi";
            public static string column15 = "sodienthoai";
            public static string column16 = "Ngaysinh";
            public static string column17 = "gioitinh";

            public static string table2 = "khoa";
            public static string column21 = "makhoa";
            public static string column22 = "tenkhoa";

            public static string select()
            {
                return $"select {column21},{column22} from {table2}";
            }
            public static string select_from()
            {
                return $"SELECT {table1}.{column11}, {table1}.{column12}, {table1}.{column13}, {table2}.{column22}," +
                       $"{table1}.{column14},{table1}.{column15},{table1}.{column16},{table1}.{column17}  " +
                       $"FROM {table1} " +
                       $"LEFT JOIN {table2} ON {table1}.{column13} = {table2}.{column21};";
            }

            public static string them()
            {
                return $"INSERT INTO {table1} VALUES (@magiangvien,@tengiangvien,@sodienthoai,@diachi,@makhoa,@ngaysinh,@gioitinh);";
            }

            public static string sua()
            {
                return $"UPDATE {table1} SET " +
                       $"{column12} = @tengiangvien, " +
                       $"{column13} = @makhoa, " +
                       $"{column14} = @diachi, " +
                       $"{column15} = @sodienthoai, " +
                       $"{column16} = @ngaysinh, " +
                       $"{column17} = @gioitinh " +
                       $"WHERE {column11} = @magiangvien;";
            }

            public static string xoa()
            {
                return $"DELETE FROM {table1} WHERE {column11}=@magiangvien;";
            }

            public static string timkiem()
            {
                return $"SELECT {table1}.{column11}, {table1}.{column12}, {table1}.{column13}, {table2}.{column22}, " +
                       $"{table1}.{column14}, {table1}.{column15}, {table1}.{column16}, {table1}.{column17} " +
                       $"FROM {table1} " +
                       $"LEFT JOIN {table2} ON {table1}.{column13} = {table2}.{column21} " +
                       $"WHERE " +
                       $"LOWER({table1}.{column11}) LIKE '%' + LOWER(@magiangvien) + '%' OR " +
                       $"LOWER({table1}.{column12}) LIKE '%' + LOWER(@tengiangvien) + '%' OR " +
                       $"LOWER({table1}.{column13}) LIKE '%' + LOWER(@makhoa) + '%' OR " +
                       $"{table1}.{column14} LIKE '%' + @sodienthoai + '%' OR " +
                       $"LOWER({table1}.{column15}) LIKE '%' + LOWER(@diachi) + '%' ; ";
                       

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


            dgv_giangvien.Columns["column1"].DataPropertyName = SQL.column11;
            dgv_giangvien.Columns["column2"].DataPropertyName = SQL.column12;
            dgv_giangvien.Columns["column3"].DataPropertyName = SQL.column13;

            dgv_giangvien.Columns["column4"].DataPropertyName = SQL.column22;
            dgv_giangvien.Columns["column5"].DataPropertyName = SQL.column14;
            dgv_giangvien.Columns["column6"].DataPropertyName = SQL.column15;
            dgv_giangvien.Columns["column7"].DataPropertyName = SQL.column16;
            dgv_giangvien.Columns["column8"].DataPropertyName = SQL.column17;
            dgv_giangvien.DataSource = Load_SQL_dt(sql);
            cb_makhoa.SelectedIndex = -1;
        }

        void Load_cb()
        {
            string sql = SQL.select();


            cb_makhoa.DataSource = Load_SQL_dt(sql);

            cb_makhoa.DisplayMember = SQL.column21;
            cb_makhoa.ValueMember = SQL.column22; 

            tb_khoa.Text = cb_makhoa.SelectedValue?.ToString();
        }

        

        private void fdanhsachgiangvien_Load(object sender, EventArgs e)
        {
            //dgv_giangvien.AutoGenerateColumns = false;
            Load_dgv();
            Load_cb();
        }




        void Xoa(string x)
        {
            string sql = SQL.xoa();
            
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@magiangvien", x);

            cmd.ExecuteNonQuery();
        }


        private void bt_them_Click(object sender, EventArgs e)
        {
            if (tb_magiangvien.Text.Trim() == "" || 
                tb_hoten.Text.Trim() == ""||
                tb_diachi.Text.Trim() == "" ||
                tb_sdt.Text.Trim() == "" ||
                cb_makhoa.Text.Trim() == "" 
                )
            {
                MessageBox.Show("Điền đầy đủ thông tin");
                return;
            }

            string gt = "";
            if (rd_nam.Checked)
                gt = "Nam";
            if (rd_nu.Checked)
                gt = "Nữ";

            string sql = SQL.them();
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@magiangvien", tb_magiangvien.Text);
            cmd.Parameters.AddWithValue("@tengiangvien", tb_hoten.Text);
            cmd.Parameters.AddWithValue("@makhoa", cb_makhoa.Text);
            cmd.Parameters.AddWithValue("@diachi", tb_diachi.Text);
            cmd.Parameters.AddWithValue("@sodienthoai", tb_sdt.Text);
            cmd.Parameters.AddWithValue("@ngaysinh", date_ngaysinh.Value);
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
            if (dgv_giangvien.CurrentRow != null)
            {
                tb_magiangvien.Text = dgv_giangvien.CurrentRow.Cells[0].Value?.ToString().Trim();
                tb_hoten.Text = dgv_giangvien.CurrentRow.Cells[1].Value?.ToString().Trim();
                cb_makhoa.Text = dgv_giangvien.CurrentRow.Cells[2].Value?.ToString().Trim();
                //tb_magiangvien.Text = dgv_giangvien.CurrentRow.Cells[3].Value?.ToString().Trim();
                tb_diachi.Text = dgv_giangvien.CurrentRow.Cells[4].Value?.ToString().Trim();
                tb_sdt.Text = dgv_giangvien.CurrentRow.Cells[5].Value?.ToString().Trim();

                object cellValue = dgv_giangvien.CurrentRow.Cells[6].Value;

                if (cellValue != DBNull.Value && DateTime.TryParse(cellValue.ToString(), out DateTime ngaysinh))
                {
                    date_ngaysinh.Value = ngaysinh;
                }
                else
                {
                    date_ngaysinh.Value = DateTime.Today; // Giá trị mặc định nếu NULL
                }

            }

        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            string gt = "";
            if (rd_nam.Checked)
                gt = "Nam";
            if (rd_nu.Checked)
                gt = "Nữ";


            string sql = SQL.sua();
            conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@magiangvien", tb_magiangvien.Text);
            cmd.Parameters.AddWithValue("@tengiangvien", tb_hoten.Text);
            cmd.Parameters.AddWithValue("@makhoa", cb_makhoa.Text);
            cmd.Parameters.AddWithValue("@diachi", tb_diachi.Text);
            cmd.Parameters.AddWithValue("@sodienthoai", tb_sdt.Text);
            cmd.Parameters.AddWithValue("@ngaysinh", date_ngaysinh.Value);
            cmd.Parameters.AddWithValue("@gioitinh", gt);

            cmd.ExecuteNonQuery();
            fdanhsachgiangvien_Load(sender, e);
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
                            
                            Xoa(row.Cells[0].Value.ToString());


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
            

            string sql = SQL.timkiem();

            SqlConnection conn = new SqlConnection(chuoilienket);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);

            // Xử lý nếu textbox rỗng thì truyền "%" (không lọc dữ liệu)
            da.SelectCommand.Parameters.AddWithValue("@magiangvien", string.IsNullOrEmpty(tb_magiangvien.Text) ? "" : "%" + tb_magiangvien.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@tengiangvien", string.IsNullOrEmpty(tb_hoten.Text) ? "" : "%" + tb_hoten.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@makhoa", string.IsNullOrEmpty(cb_makhoa.Text) ? "" : "%" + cb_makhoa.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@diachi", string.IsNullOrEmpty(tb_diachi.Text) ? "" : "%" + tb_diachi.Text + "%");
            da.SelectCommand.Parameters.AddWithValue("@sodienthoai", string.IsNullOrEmpty(tb_sdt.Text) ? "" : "%" + tb_sdt.Text + "%");

            
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_giangvien.DataSource = dt; // Hiển thị dữ liệu trên DataGridView

            
        }
        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            dgv_giangvien.DataSource = Load_SQL_dt(SQL.select_from());
        }

        private void cb_makhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_makhoa_TextChanged(object sender, EventArgs e)
        {
            if (cb_makhoa.SelectedValue != null)
            {
                tb_khoa.Text = cb_makhoa.SelectedValue.ToString();
            }
            else
            {
                tb_khoa.Text = ""; // Nếu không có giá trị, để trống
            }
        }
    }
}
