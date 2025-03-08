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

namespace LOP
{
    public partial class timkiem : Form
    {
        public string chuoiketnoi = "Data Source = DESKTOP-DOFGP4J;" +
                                " Initial Catalog =  quanlisinhvien;" +
                                    "Integrated Security = true;  ";
        public SqlConnection conn = null;
        public string lop { get; set; }
        public timkiem()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtmalop.Text == "")
                errorProvider1.SetError(txtmalop, "Không được để trống!");
            else
            {
                errorProvider1.SetError(txtmalop, "");
                lop = txtmalop.Text;
                this.Close();
            }
                
        }

        private void txtmalop_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtmalop.Text == "")
                errorProvider1.SetError(txtmalop, "Không được để trống!");
            else
                errorProvider1.SetError(txtmalop, "");
        }



        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){ 
                btnsearch.Focus();
                btnsearch_Click(sender, e);
            }  
        }

        private void txtmalop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsearch.Focus();
                btnsearch_Click(sender, e);
            }
        }
    }
}
