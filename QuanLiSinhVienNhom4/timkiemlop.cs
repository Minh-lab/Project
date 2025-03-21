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

namespace QuanLiSinhVienNhom4
{
    public partial class timkiemlop : Form
    {
        public timkiemlop()
        {
            InitializeComponent();
        }
        public string chuoiketnoi = "Data Source = DESKTOP-6EVU3R0\\SQLEXPRESS;" + "Initial Catalog=quanlisinhvien;" + "Integrated Security=True";
        public SqlConnection conn = null;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtimkiem.Text != "")
            {
                lbltimkiem.Text = "Nhập " + cmbtimkiem.Text;
                txttimkiem.Visible = true;
                errorProvider1.SetError(cmbtimkiem, "");
            }
            else
            {
                errorProvider1.SetError(cmbtimkiem, "Không được để trống");
            }
        }

        private void cmbtimkiem_TextChanged(object sender, EventArgs e)
        {
            if(cmbtimkiem.Text == "")
            {
                lbltimkiem.Text = "";
                txttimkiem.Visible = false;
            }
        }

        public DataTable TimKiemLopTheoMaLop()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where lop.malop = @malop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@malop", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }
        public DataTable TimKiemLopTheoMaKhoa()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where lop.makhoa = @makhoa";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makhoa", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }
        public DataTable TimKiemLopTheoMaGVCN()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where lop.magiangvien = @magiangvien";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@magiangvien", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }
        public DataTable TimKiemLopTheoTenLop()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where lop.tenlop = @tenlop";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenlop", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }
        public DataTable TimKiemLopTheoTenKhoa()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where khoa.tenkhoa = @tenkhoa";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenkhoa", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }
        public DataTable TimKiemLopTheoTenGVCN()
        {
            DataTable timkiem = new DataTable();
            string query = "select malop,tenlop, khoa.makhoa ,tenkhoa,giangvien.magiangvien,tengiangvien,siso from lop join khoa on lop.makhoa = khoa.makhoa join giangvien on giangvien.magiangvien = lop.magiangvien where giangvien.tengiangvien = @tengiangvien";
            using (conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tengiangvien", txttimkiem.Text.Trim());
                SqlDataReader reader = cmd.ExecuteReader();
                timkiem.Load(reader);
            }
            return timkiem;
        }

        public string getYeuCauTimKiem()
        {
            return cmbtimkiem.Text;
        }
        public void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txttimkiem.Text == "" || cmbtimkiem.Text == "")
            {
                if (txttimkiem.Text == "")
                    errorProvider1.SetError(txttimkiem, "Không được để trống");
                if (cmbtimkiem.Text == "")
                    errorProvider1.SetError(cmbtimkiem, "Không được để trống");
            }
            else if(txttimkiem.Text != "" && cmbtimkiem.Text != "")
            {
                if (txttimkiem.Text != "")
                    errorProvider1.SetError(txttimkiem, "");
                if (cmbtimkiem.Text != "")
                    errorProvider1.SetError(cmbtimkiem, "");
                this.Close();
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txttimkiem.Text == "")
                errorProvider1.SetError(txttimkiem, "Không được để trống");
            else
            {
                errorProvider1.SetError(txttimkiem, "");
            }
        }
    }
}
