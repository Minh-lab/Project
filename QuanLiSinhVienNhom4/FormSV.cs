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
        string chuoiketnoi = "Data Source=DESKTOP-6EVU3R0\\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True;";
        SqlConnection ketnoi = null;


        public FormSV()
        {
            InitializeComponent();
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            Load();
           // LoadMaSinhVien();
           // LoadMaLop();
        }

        private new void Load()
        {
            try
            {
                string sql = "SELECT SinhVien.MaSinhVien, SinhVien.HoTen, SinhVien.GioiTinh, SinhVien.NgaySinh, " +
                    "Lop.TenLop, SinhVien.MaLop, " +
                    "SinhVien.DiaChi, SinhVien.QueQuan, SinhVien.SoDienThoai " +  // Chỉ lấy MaLop từ SinhVien
                     "FROM SinhVien " +
                     "INNER JOIN Lop ON SinhVien.MaLop = Lop.MaLop;";
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

        private void btTHEM_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(tbMSV.Text) || string.IsNullOrEmpty(tbMALOP.Text))
                {
                    MessageBox.Show("Mã sinh viên và mã lớp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = "INSERT INTO SinhVien (MaSinhVien,HoTen, GioiTinh, NgaySinh, Malop, DiaChi, QueQuan, SoDienThoai)" +
                    "VALUES (@MaSinhVien, @HoTen, @GioiTinh, @NgaySinh, @Malop, @DiaChi, @QueQuan, @SoDienThoai)";
                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    cmd.Parameters.AddWithValue("@MaSinhVien", tbMSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", tbHOTEN.Text);
                    string gioitinh = rbNAM.Checked ? "Nam" : rbNU.Checked ? "Nữ" : "Khác";
                    cmd.Parameters.AddWithValue("@GioiTinh", gioitinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateNS.Value);
                    cmd.Parameters.AddWithValue("@MaLop", tbMALOP.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", tbDIACHI.Text);
                    cmd.Parameters.AddWithValue("@QueQuan", tbQUEQUAN.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", tbSODIENTHOAI.Text);
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

                string sql = "UPDATE SinhVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, " +
                             "MaLop = @MaLop, DiaChi = @DiaChi, QueQuan = @QueQuan, SoDienThoai = @SoDienThoai " +
                             "WHERE MaSinhVien = @MaSinhVien";

                using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                {
                    cmd.Parameters.AddWithValue("@MaSinhVien", tbMSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", tbHOTEN.Text);
                    string gioiTinh = rbNAM.Checked ? "Nam" : rbNU.Checked ? "Nữ" : "Khác";
                    cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", dateNS.Value);
                    cmd.Parameters.AddWithValue("@MaLop", tbMALOP.Text);
                    cmd.Parameters.AddWithValue("@DiaChi", tbDIACHI.Text);
                    cmd.Parameters.AddWithValue("@QueQuan", tbQUEQUAN.Text);
                    cmd.Parameters.AddWithValue("@SoDienThoai", tbSODIENTHOAI.Text);

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
                    string sql = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien";
                    using (SqlCommand cmd = new SqlCommand(sql, ketnoi))
                    {
                        cmd.Parameters.AddWithValue("@MaSinhVien", tbMSV.Text);
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
                string sql = "Select MaSinhVien,HoTen, GioiTinh, NgaySinh, Malop,Lop.TenLop, DiaChi, QueQuan, SoDienThoai from SinhVien"+
                    "Inner join Lop on SinhVien.MaLop = Lop.MaLop" + "Where SinhVien.MaSinhVien like @keyword or Lop.MaLop like @keyword";
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
            tbMALOP.Clear();
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
                tbMALOP.Text = row.Cells["Column5"].Value?.ToString() ?? "";
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
    }
}
