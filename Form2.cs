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
using System.Data;


namespace BasisData01
{

    public partial class Form2 : Form
    {
        DataTable table = new DataTable("table");
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection koneksi = new MySqlConnection(
        "server=localhost;database=db_bp_bk;uid=root;pwd=;");

        public void TampilkanData()
        {
            dataGridView1.Rows.Clear();
            db.crud("select * from siswa");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string nisn = "" + baris["nisn"];
                string nama_siswa = "" + baris["nama_siswa"];
                string kelas = "" + baris["kelas"];
                string point_pelanggaran = "" + baris["point_pelanggaran"];
                dataGridView1.Rows.Add(nisn, nama_siswa, kelas, point_pelanggaran);
            }
        }
        public void bersih()
        {
            txtnisn.Text = "";
            txtnmsiswa.Text = "";
            txtkls.Text = "";
            txtpp.Text = "";
        }

        private void Form2_Load(object sender, EventArgs e)
            {
            TampilkanData();
            }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txtnisn.Text == "" || txtnmsiswa.Text == "" || txtkls.Text == "" || txtpp.Text == "")
            {
                MessageBox.Show("lengkapi data");
            }
            else
            {
                string nisn = txtnisn.Text;
                string nama_siswa = txtnmsiswa.Text;
                string kelas = txtkls.Text;
                string point_pelanggaran = txtpp.Text;
                db.crud($"INSERT INTO siswa VALUES( null, '{nisn}', '{nama_siswa}', '{kelas}', '{point_pelanggaran}')");
                bersih();
                TampilkanData();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (txtnisn.Text == "" || txtnmsiswa.Text == "" || txtkls.Text == "" || txtpp.Text == "")
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }

            string nisn = txtnisn.Text;
            string nama_siswa = txtnmsiswa.Text;
            string kelas = txtkls.Text;
            string point_pelanggaran = txtpp.Text;

            string query = $"UPDATE siswa SET nama_siswa='{nama_siswa}', kelas='{kelas}', point_pelanggaran='{point_pelanggaran}' WHERE nisn='{nisn}'";

            db.crud(query);

            MessageBox.Show("Data berhasil diupdate");

            bersih();
            TampilkanData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            {
                TampilkanData();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow baris = dataGridView1.Rows[e.RowIndex];

                txtnisn.Text = baris.Cells[0].Value.ToString();
                txtnmsiswa.Text = baris.Cells[1].Value.ToString();
                txtkls.Text = baris.Cells[2].Value.ToString();
                txtpp.Text = baris.Cells[3].Value.ToString();
            }
        }
    }
}
