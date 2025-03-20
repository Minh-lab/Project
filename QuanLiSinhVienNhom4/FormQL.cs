using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiSinhVienNhom4;

namespace QuanLiSinhVienNhom4
{
    public partial class FormQL: Form
    {
        public FormQL()
        {
            InitializeComponent();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSV formsv = new FormSV();
            formsv.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
               lopform quanlilop = new lopform();
                quanlilop.Show();

        }

        private void FormQL_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("D:\\Ảnh\\quanlysinhvien.jpg");

        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdanhsachgiangvien frmgiangvien = new fdanhsachgiangvien();
            frmgiangvien.Show();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdanhsachkhoa frmdanhsachkhoa = new fdanhsachkhoa();
            frmdanhsachkhoa.Show();
        }
    }
}
