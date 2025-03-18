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
    }
}
