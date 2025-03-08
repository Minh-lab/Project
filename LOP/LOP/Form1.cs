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

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                string query = "insert into lop values(@malop,@tenlop, @makhoa ,@magiangvien, @siso)";
                if (txtmalop.Text == "")
                    errorProvider1.SetError(txtmalop, "Không được để trống!");
                else
                    errorProvider1.SetError(txtmalop, "");
                if (txtmagv.Text == "")
                    errorProvider1.SetError(txtmagv, "Không được để trống!");
                else
                    errorProvider1.SetError(txtmagv, "");
                if (txtmakhoa.Text == "")
                    errorProvider1.SetError(txtmakhoa, "Không được để trống!");
                else
                    errorProvider1.SetError(txtmakhoa, "");
                if (txtsiso.Text == "")
                    errorProvider1.SetError(txtsiso, "Không được để trống!");
                else
                    errorProvider1.SetError(txtsiso, "");
                if (txttenlop.Text == "")
                    errorProvider1.SetError(txttenlop, "Không được để trống!");
                else
                    errorProvider1.SetError(txttenlop, "");
                using (conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@malop", txtmalop.Text);
                    cmd.Parameters.AddWithValue("@tenlop", txttenlop.Text);
                    cmd.Parameters.AddWithValue("@makhoa", txtmakhoa.Text);
                    cmd.Parameters.AddWithValue("@magiangvien", txtmagv.Text);
                    cmd.Parameters.AddWithValue("@siso", txtsiso.Text);
                    cmd.ExecuteNonQuery();
                }
                dslop.DataSource = getDSLop();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            dslop.DataSource = getDSLop();
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
                txtmagv.Text = getmaGVCN(dslop.Rows[e.RowIndex].Cells["malop"].Value.ToString());
                txtmakhoa.Text = getmaKhoa(dslop.Rows[e.RowIndex].Cells["malop"].Value.ToString());
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
                    cmd.Parameters.AddWithValue("@makhoa", txtmakhoa.Text);
                    cmd.Parameters.AddWithValue("@magiangvien", txtmagv.Text);
                    cmd.Parameters.AddWithValue("@siso", txtsiso.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            dslop.DataSource = getDSLop();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string query = "delete lop where malop = @malop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@malop", txtmalop.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            txtmagv.Text = "";
            txtmakhoa.Text = "";
            txtmalop.Text = "";
            txtsiso.Text = "";
            txttenlop.Text = "";

            dslop.DataSource = getDSLop();
            errorProvider1.Clear();
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            string query = "delete lop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            dslop.DataSource= getDSLop();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            timkiem form2 = new timkiem();
            form2.ShowDialog();
            dslop.DataSource = getDSLop(form2.lop);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thongke form3 = new thongke();
            form3.ShowDialog();

        }
    }
}
