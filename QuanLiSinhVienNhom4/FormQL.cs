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
using WindowsFormsApp6;

namespace QuanLiSinhVienNhom4
{
    public partial class FormQL: Form
    {
        public FormQL()
        {
            InitializeComponent();
        }

        private void FormQL_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("D:\\Ảnh\\quanlysinhvien.jpg");

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


        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fdanhsachgiangvien1 frmgiangvien = new fdanhsachgiangvien1();
            frmgiangvien.Show();
        }

        private void khoaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fdanhsachkhoa1 frmdanhsachkhoa = new fdanhsachkhoa1();
            frmdanhsachkhoa.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDiem formDiem = new FormDiem();
            formDiem.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromMon formMon = new FromMon();
            formMon.Show();
        }

        private void mônHọcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FromMon formMon = new FromMon();
            formMon.Show();
        }
    }
}
