using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasisData01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtpetugas_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            db.crud($"SELECT * FROM login WHERE user = '{txtuser.Text}' and password = '{txtpass.Text}'");
            int cekbaris = db.ds.Tables[0].Rows.Count;
            if (cekbaris == 1)
            {
                DataRow baris = db.ds.Tables[0].Rows[0];
                dashboard F2 = new dashboard();
                F2.Visible = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username atau Password anda Salah lorem ipsum");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
