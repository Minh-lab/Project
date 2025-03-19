using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVienNhom4
{
    public partial class FormThongKeLop : Form
    {
        public FormThongKeLop()
        {
            InitializeComponent();
        }

        private void cmbtieuchi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbtieuchi.SelectedIndex == 0)
            {
                lopform lopform = new lopform();
                cmbluachon.DataSource = lopform.getDanhSachLop();
                cmbluachon.DisplayMember = "tenlop";
                cmbluachon.ValueMember = "tenlop";
                lblluachon.Text = "Chọn Lớp";
                cmbluachon.Visible = true;

            }
            if(cmbtieuchi.SelectedIndex == 1)
            {
                lopform lopform = new lopform();
                cmbluachon.DataSource = lopform.getDanhSachKhoa();
                cmbluachon.DisplayMember = "tenkhoa";
                cmbluachon.ValueMember = "tenkhoa";
                lblluachon.Text = "Chọn Khoa";
                cmbluachon.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
