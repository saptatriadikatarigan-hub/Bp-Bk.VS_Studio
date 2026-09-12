using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BasisData01
{
    public partial class dashboard : Form
    {
        //private bool isSidebarExpanded= true;

        private const int ExpandedWidth = 150;
        private const int CollapsedWidth = -200;
        private int idSiswa = 5;
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult setuhju = MessageBox.Show("apakah mau mangkat?","pemberitahuan",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (setuhju == DialogResult.Yes)
            {
                Form f1 = new Form1();
                f1.Visible = true;
                this.Hide();
            }
             
        }
  

        private void dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult setuhju = MessageBox.Show("apakah mau mangkat?", "pemberitahuan",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (setuhju == DialogResult.Yes)
            {
                Form f1 = new Form1();
                f1.Visible = true;
                this.Hide();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form2 Menu = new Form2() { TopMost = true, TopLevel = false };
            KFE.untukformsapta(Menu, pnltengah);
        }

        private void pnltengah_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Form4 Menu = new Form4(idSiswa)
            {TopMost = true,TopLevel = false};
            KFE.untukformsapta(Menu, pnltengah);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Form3 Menu = new Form3() { TopMost = true, TopLevel = false };
            KFE.untukformsapta(Menu, pnltengah);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form1 formLogin = new Form1();
            formLogin.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form5 Menu = new Form5() { TopMost = true, TopLevel = false };
            KFE.untukformsapta(Menu, pnltengah);
        }
    }
}
