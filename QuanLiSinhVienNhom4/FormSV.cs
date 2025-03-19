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
using Microsoft.VisualBasic;

namespace QuanLiSinhVienNhom4
{
    public partial class FormSV: Form
    {
        string chuoiketnoi = "Data Source=DESKTOP-6EVU3R0\\SQLEXPRESS;Initial Catalog=quanlisinhvien;Integrated Security=True;";
        SqlConnection ketnoi = null;

        
        public FormSV()
        {
            InitializeComponent();
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            Load();
           // LoadMaSinhVien();
           LoadMaLop();
        }

        private new void Load()
        {
            try
            {
                string sql = "SELECT sinhvien.masinhvien, sinhvien.hoten, sinhvien.gioitinh, sinhvien.ngaysinh, " +
                    "lop.tenlop, lop.malop, " +
                    "sinhvien.diachi, sinhvien.quequan, sinhvien.sodienthoai " +  // Chỉ lấy MaLop từ SinhVien
                     "FROM sinhvien " +
                     "INNER JOIN lop ON sinhvien.malop = lop.malop;";
                SqlDataAdapter daSV = new SqlDataAdapter(sql, ketnoi);
                DataTable dt = new DataTable();
                daSV.Fill(dt);

                dgv1.AutoGenerateColumns = true;
                dgv1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadMaLop()
        {
            try
            {
                string sql = "SELECT malop, tenlop FROM lop"; // Lấy danh sách lớp từ bảng Lop
                SqlDataAdapter da = new SqlDataAdapter(sql, ketnoi);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Đổ dữ liệu vào ComboBox
                cbbMALOP.DataSource = dt;
                cbbMALOP.DisplayMember = "malop";  // Hiển thị Mã Lớp
                cbbMALOP.ValueMember = "malop";   // Giá trị ẩn là Tên Lớp
                cbbMALOP.SelectedIndex = -1;       // Không chọn gì mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
            }
        }


        private void btTHEM_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tbMSV.Text) || cbbMALOP.SelectedValue == null)
                {
                    MessageBox.Show("Mã sinh viên và mã lớp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = "INSERT INTO sinhvien (masinhvien, hoten, gioitinh, ngaysinh, malop, diachi, quequan, sodienthoai)" +
                    "VALUES (@masinhvien, @oten, @gioitinh, @ngaysinh, @malop, @diachi, @quequan, @sodienthoai)";
                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    cmd.Parameters.AddWithValue("@masinhvien", tbMSV.Text);
                    cmd.Parameters.AddWithValue("@hoten", tbHOTEN.Text);
                    string gioitinh = rbNAM.Checked ? "Nam" : rbNU.Checked ? "Nữ" : "Khác";
                    cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cmd.Parameters.AddWithValue("@ngaysinh", dateNS.Value);
                    cmd.Parameters.AddWithValue("@malop", cbbMALOP.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@diachi", tbDIACHI.Text);
                    cmd.Parameters.AddWithValue("@quequan", tbQUEQUAN.Text);
                    cmd.Parameters.AddWithValue("@sodienthoai", tbSODIENTHOAI.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Thêm sinh viên thành công!");
                Load();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sinh viên!" + ex.Message);
            }
        }

        private void btSUA_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMSV.Text))
                {
                    MessageBox.Show("Vui lòng nhập Mã Sinh Viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sql = "UPDATE sinhvien SET hoten = @hoten, gioitinh = @gioitinh, ngaysinh = @ngaysinh, " +
                             "malop = @malop, diachi = @diachi, quequan = @quequan, sodienthoai = @sodienthoai " +
                             "WHERE masinhvien = @masinhvien";

                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    cmd.Parameters.AddWithValue("@masinhvien", tbMSV.Text);
                    cmd.Parameters.AddWithValue("@hoten", tbHOTEN.Text);
                    string gioitinh = rbNAM.Checked ? "Nam" : rbNU.Checked ? "Nữ" : "Khác";
                    cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
                    cmd.Parameters.AddWithValue("@ngaysinh", dateNS.Value);
                    cmd.Parameters.AddWithValue("@malop", cbbMALOP.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@diachi", tbDIACHI.Text);
                    cmd.Parameters.AddWithValue("@quequan", tbQUEQUAN.Text);
                    cmd.Parameters.AddWithValue("@sodienthoai", tbSODIENTHOAI.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXOA_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tbMSV.Text))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM sinhvien WHERE masinhvien = @masinhvien";
                    using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                    {
                        cmd.Parameters.AddWithValue("@masinhvien", tbMSV.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Load();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btTIMKIEM_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = Microsoft.VisualBasic.Interaction.InputBox("Nhập từ khóa tìm kiếm (Mã sinh viên hoặc họ tên):", "Tìm kiếm", "");
                if (string.IsNullOrEmpty(keyword))
                {
                    Load(); ;
                    return;
                }
                string sql = "Select masinhvien, hoten, gioitinh, ngaysinh, malop, diachi, quequan, sodienthoai from sinhvien" +
                    "Inner join lop on sinhvien.malop = lop.malop" + "Where sinhvien.masinhvien like @keyword or lop.malop like @keyword";
                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    cmd.Parameters.AddWithValue ("@keyword","%" + keyword + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);   
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btLAMMOI_Click(object sender, EventArgs e)
        {
            tbMSV.Clear();
            tbHOTEN.Clear();
            cbbMALOP.SelectedIndex = -1;
            tbDIACHI.Clear();
            tbQUEQUAN.Clear();
            tbSODIENTHOAI.Clear();
            rbNAM.Checked = false;
            rbNU.Checked = false;
            rbKHAC.Checked = false;
            dateNS.Value = DateTime.Now;

            Load();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
            {
                DataGridViewRow row = dgv1.Rows[e.RowIndex];

                // Kiểm tra giá trị có null không trước khi gán vào textbox
                tbMSV.Text = row.Cells["Column1"].Value?.ToString() ?? "";
                
                tbHOTEN.Text = row.Cells["Column2"].Value?.ToString() ?? "";
                cbbMALOP.SelectedValue = row.Cells["Column5"].Value?.ToString().Trim();
                tbDIACHI.Text = row.Cells["Column8"].Value?.ToString() ?? "";
                tbLOP.Text = row.Cells["Column6"].Value?.ToString() ?? "";

                tbQUEQUAN.Text = row.Cells["Column9"].Value?.ToString() ?? "";
                tbSODIENTHOAI.Text = row.Cells["Column7"].Value?.ToString() ?? "";

                // Xử lý radio button cho Giới tính
                string gioitinh = row.Cells["Column3"].Value?.ToString();
                if (gioitinh == "Nam") rbNAM.Checked = true;
                else if (gioitinh == "Nữ") rbNU.Checked = true;
                else rbKHAC.Checked = true;

                // Chuyển đổi ngày tháng
                if (row.Cells["Column4"].Value != null)
                {
                    dateNS.Value = Convert.ToDateTime(row.Cells["Column4"].Value);
                }
                else
                {
                    dateNS.Value = DateTime.Now;
                }
            }
        }

        private void cbbMALOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMALOP.SelectedIndex != -1) // Chỉ cập nhật khi có lựa chọn
            {
                DataRowView drv = cbbMALOP.SelectedItem as DataRowView;
                if (drv != null)
                {
                    tbLOP.Text = drv["tenlop"].ToString(); // Lấy tên lớp tương ứng
                }
            }
            else
            {
                tbLOP.Text = ""; // Nếu không chọn gì, để trống
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
          
        }
        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            FormThongKeSV a = new FormThongKeSV();
            a.Show();
        }
    }
}
