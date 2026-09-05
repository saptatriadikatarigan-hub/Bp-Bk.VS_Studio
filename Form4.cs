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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void TampilkanDashboard()
        {
            db.crud("SELECT COUNT(*) AS total " +"FROM jadwal_konseling " +"WHERE id_siswa='5'");
            lbTotalJadwal.Text =db.ds.Tables[0].Rows[0]["total"].ToString();

            db.crud("SELECT COUNT(*) AS total " +"FROM jadwal_konseling " +"WHERE id_siswa='5' " +"AND status='Menunggu'");
            lbMenunggu.Text =db.ds.Tables[0].Rows[0]["total"].ToString();

            db.crud("SELECT COUNT(*) AS total " +"FROM jadwal_konseling " +"WHERE id_siswa='5' " +"AND status='Disetujui'");
            lbDisetujui.Text = db.ds.Tables[0].Rows[0]["total"].ToString();

            db.crud("SELECT COUNT(*) AS total " +"FROM jadwal_konseling " +"WHERE id_siswa='5' " +"AND status='Ditolak'");
            lbDitolak.Text =db.ds.Tables[0].Rows[0]["total"].ToString();
        }


        public void TampilkanJadwal()
        {
            dataGridView1.Rows.Clear();

            db.crud( "SELECT " +"g.nama_guru, " +"DATE_FORMAT(j.tanggal, '%Y-%m-%d') AS tanggal, " +"TIME_FORMAT(j.jam, '%H:%i') AS jam " +"FROM jadwal_konseling j " +"INNER JOIN guru g ON j.id_guru = g.id_guru " +"WHERE j.id_siswa='5' " +"ORDER BY j.tanggal DESC");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string nama_guru = "" + baris["nama_guru"];
                string tanggal = "" + baris["tanggal"];
                string jam = "" + baris["jam"];

                dataGridView1.Rows.Add(nama_guru,tanggal,jam);
            }
        }
        private void Form4_Load_1(object sender, EventArgs e)
        {
            TampilkanDashboard();
            TampilkanJadwal();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbDisetujui_Click(object sender, EventArgs e)
        {

        }
    }
}