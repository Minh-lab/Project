using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOP
{
    public partial class Form1 : Form
    {
            public string chuoiketnoi = "Data Source = DESKTOP-DOFGP4J;" +
                                            " Initial Catalog =  quanlisinhvien;" +
                                                "Integrated Security = true;  ";
            public SqlConnection conn = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into lop values(@malop,@tenlop, @makhoa ,@magiangvien, @siso)";
                if (txtmalop.Text != "" && txtsiso.Text != "" && txtsiso.Text != "")
                {
                    using (conn = new SqlConnection(chuoiketnoi))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@malop", txtmalop.Text);
                        cmd.Parameters.AddWithValue("@tenlop", txttenlop.Text);
                        cmd.Parameters.AddWithValue("@makhoa", cmbkhoa.Text);
                        cmd.Parameters.AddWithValue("@magiangvien", cmbgvcn.Text);
                        cmd.Parameters.AddWithValue("@siso", txtsiso.Text);
                        cmd.ExecuteNonQuery();
                    }
                    dslop.DataSource = getDSLop();
                }
                else
                {
                    errorProvider1.Clear();
                    if (txtmalop.Text == "")
                        errorProvider1.SetError(txtmalop, "Không được để trống!");
                    else
                        errorProvider1.SetError(txtmalop, "");
                    if (cmbkhoa.Text == "")
                        errorProvider1.SetError(cmbgvcn, "Không được để trống!");
                    else
                        errorProvider1.SetError(cmbgvcn, "");
                    if (cmbkhoa.Text == "")
                        errorProvider1.SetError(cmbkhoa, "Không được để trống!");
                    else
                        errorProvider1.SetError(cmbkhoa, "");
                    if (txtsiso.Text == "")
                        errorProvider1.SetError(txtsiso, "Không được để trống!");
                    else
                        errorProvider1.SetError(txtsiso, "");
                    if (txttenlop.Text == "")
                        errorProvider1.SetError(txttenlop, "Không được để trống!");
                    else
                        errorProvider1.SetError(txttenlop, "");
                }
            }
            catch (SqlException) {
                if (txttenlop.Text != "") 
                 MessageBox.Show("Error", "Lớp đã có trong danh sách!");
                }
            }

        private void txttenlop_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
                errorProvider1.SetError(textBox, "Không được để trống!");
            else
                errorProvider1.SetError(textBox, "");
        }

        private DataTable  getDsGiangVien()
        {
            DataTable dt = new DataTable();
            string query = "select magiangvien from giangvien"; 
            using(conn = new SqlConnection(chuoiketnoi))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dslop.DataSource = getDSLop();
            cmbkhoa.DataSource = getMaKhoa();
            cmbkhoa.DisplayMember = "makhoa"; // Cột hiển thị
            cmbkhoa.ValueMember = "makhoa";   // Giá trị thực tế
            cmbgvcn.DataSource = getMaGiangVien(cmbkhoa.Text);
            cmbgvcn.DisplayMember = "magiangvien"; // Cột hiển thị
            cmbgvcn.ValueMember = "magiangvien";   // Giá trị thực tế

        }


        DataTable getDSLop()
        {
            DataTable dt = new DataTable();
            string query = "select malop,tenlop,tenkhoa,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }
        DataTable getDSLop(string malop)
        {
            DataTable dt = new DataTable();
            string query = "select malop,tenlop,tenkhoa,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where malop = '"+malop+"'";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
            return dt;
        }

        string getmaGVCN(string malop)
        {
            string query = "select magiangvien from lop where malop = @malop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", malop);
                    object result = cmd.ExecuteScalar();
                    return result.ToString();
                }
            }
        }
        string getmaKhoa(string malop)
        {
            string query = "select makhoa from lop where malop = @malop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", malop);
                    object result = cmd.ExecuteScalar();
                    return result.ToString();
                }
            }
        }

        private void dslop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtmalop.Text = dslop.Rows[e.RowIndex].Cells["malop"].Value.ToString();
                cmbgvcn.Text = getmaGVCN(dslop.Rows[e.RowIndex].Cells["malop"].Value.ToString());
                cmbkhoa.Text = getmaKhoa(dslop.Rows[e.RowIndex].Cells["malop"].Value.ToString());
                txtsiso.Text = dslop.Rows[e.RowIndex].Cells["siso"].Value.ToString();
                txttenlop.Text = dslop.Rows[e.RowIndex].Cells["tenlop"].Value.ToString();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            string query = "update lop set malop = @malop,tenlop = @tenlop, magiangvien = @magiangvien, makhoa = @makhoa, siso = @siso where malop = @malop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", txtmalop.Text);
                    cmd.Parameters.AddWithValue("@tenlop", txttenlop.Text);
                    cmd.Parameters.AddWithValue("@makhoa", cmbkhoa.Text);
                    cmd.Parameters.AddWithValue("@magiangvien", cmbgvcn.Text);
                    cmd.Parameters.AddWithValue("@siso", txtsiso.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            dslop.DataSource = getDSLop();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            dslop.DataSource = getDSLop();
        }




        

        Color oldColor;
        private void btnxoa_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            oldColor = btn.BackColor;
            btn.BackColor = Color.LightCoral;

        }

        private void btnxoa_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = SystemColors.Control;
        }

        private void cmbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbkhoa.Text != "") { 
                cmbgvcn.Enabled = true;
                lbltenkhoa.Text = getTenKhoa(cmbkhoa.Text);
                cmbgvcn.DataSource = getMaGiangVien(cmbkhoa.Text);
            }
        }

        //lay danh sach ma giang vien
        private DataTable getMaGiangVien(string makhoa)
        {
            DataTable dt = new DataTable();
            string query = "select giangvien.magiangvien from giangvien  where makhoa = @makhoa";
            using (conn = new SqlConnection(chuoiketnoi)) {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhoa", makhoa);
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            return dt; 
        }
        //lay ten giang vien tu magiangvien
        private string getTenGiangVien(string magiangvien)
        {
            string kq = "";
            string query = "select tengiangvien from giangvien where magiangvien = @magv";
            using(conn =  new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@magv", magiangvien);
                object res = cmd.ExecuteScalar();
                if(res != null)
                 kq = res.ToString();
            }
            return kq;
        }

        // lấy danh sách mã khoa
        private DataTable getMaKhoa()
        {
            DataTable dt = new DataTable();
            string query = "select makhoa from khoa";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(dt);
            }
             return dt;
        }
        //lấy tên khoa từ mã khoa
        private string getTenKhoa(string makhoa)
        {
            string kq;
            string query = "select tenkhoa from khoa where makhoa = @makhoa";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhoa", makhoa);
                object res = cmd.ExecuteScalar();
                if(res != null)
                    kq = res.ToString();
                else
                {
                    kq = "";
                }
            }
            return kq;
        }
        private void cmbkhoa_MouseLeave(object sender, EventArgs e)
        {
            if (cmbkhoa.Text != "")
            {
                cmbgvcn.Enabled = true;
            }
            else
                cmbgvcn.Enabled = false;
        }

        private void cmbgvcn_TextChanged(object sender, EventArgs e)
        {
            lbltengiangvien.Text  = getTenGiangVien(cmbgvcn.Text);
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            string query = "update sinhvien\r\nset malop = NULL where malop = @malop;\r\ndelete lop where malop = @malop";
            if (txtmalop.Text != "" && txtsiso.Text != "" && txtsiso.Text != "")
            {
                using (conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@malop", txtmalop.Text);
                    cmd.ExecuteNonQuery();
                }
                dslop.DataSource = getDSLop();
            }
            else
            {
                errorProvider1.Clear();
                if (txtmalop.Text == "")
                    errorProvider1.SetError(txtmalop, "Không được để trống!");
                else
                    errorProvider1.SetError(txtmalop, "");
                if (cmbkhoa.Text == "")
                    errorProvider1.SetError(cmbgvcn, "Không được để trống!");
                else
                    errorProvider1.SetError(cmbgvcn, "");
                if (cmbkhoa.Text == "")
                    errorProvider1.SetError(cmbkhoa, "Không được để trống!");
                else
                    errorProvider1.SetError(cmbkhoa, "");
                if (txtsiso.Text == "")
                    errorProvider1.SetError(txtsiso, "Không được để trống!");
                else
                    errorProvider1.SetError(txtsiso, "");
                if (txttenlop.Text == "")
                    errorProvider1.SetError(txttenlop, "Không được để trống!");
                else
                    errorProvider1.SetError(txttenlop, "");
            }
        }
    }
}
