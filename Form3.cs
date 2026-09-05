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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void TampilSiswa()
        {
            db.crud("SELECT id_siswa, nama_siswa FROM siswa");
            cmbSiswa.DataSource = null;
            cmbSiswa.DataSource = db.ds.Tables[0];
            cmbSiswa.DisplayMember = "nama_siswa";
            cmbSiswa.ValueMember = "id_siswa";
        }
        public void TampilGuru()
        {
            db.crud("SELECT id_guru, nama_guru FROM guru");
            cmbGuru.DataSource = null;
            cmbGuru.DataSource = db.ds.Tables[0];
            cmbGuru.DisplayMember = "nama_guru";
            cmbGuru.ValueMember = "id_guru";
        }
        public void TampilkanData()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT " + "j.id_jadwal, " +"s.nama_siswa, " +"g.nama_guru, " +"DATE_FORMAT(j.tanggal, '%Y-%m-%d') AS tanggal, " +"TIME_FORMAT(j.jam, '%H:%i:%s') AS jam, " + "j.keperluan, " +"j.status " +"FROM jadwal_konseling j " +"INNER JOIN siswa s ON j.id_siswa = s.id_siswa " +"INNER JOIN guru g ON j.id_guru = g.id_guru");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id_jadwal = "" + baris["id_jadwal"];
                string nama_siswa = "" + baris["nama_siswa"];
                string nama_guru = "" + baris["nama_guru"];
                string tanggal = "" + baris["tanggal"];
                string jam = "" + baris["jam"];
                string keperluan = "" + baris["keperluan"];
                string status = "" + baris["status"];
                dataGridView1.Rows.Add(id_jadwal,nama_siswa,nama_guru,tanggal,jam,keperluan,status);
            }
        }
        public void Bersih()
        {
            if (cmbSiswa.Items.Count > 0)
                cmbSiswa.SelectedIndex = 0;

            if (cmbGuru.Items.Count > 0)
                cmbGuru.SelectedIndex = 0;

            txtTanggal.Text = "";
            txtJam.Text = "";
            txtKeperluan.Text = "";
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            TampilSiswa();
            TampilGuru();
            TampilkanData();
        }
        private void dataGridView1_CellContentClick_1(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow baris =dataGridView1.Rows[e.RowIndex];
                string namaSiswa =baris.Cells[1].Value.ToString();
                string namaGuru =baris.Cells[2].Value.ToString();
                for (int i = 0; i < cmbSiswa.Items.Count; i++)
                {
                    DataRowView siswa =
                        (DataRowView)cmbSiswa.Items[i];
                    if (siswa["nama_siswa"].ToString() == namaSiswa)
                    {
                        cmbSiswa.SelectedValue =
                            siswa["id_siswa"];
                        break;
                    }
                }
                for (int i = 0; i < cmbGuru.Items.Count; i++)
                {
                    DataRowView guru = (DataRowView)cmbGuru.Items[i];

                    if (guru["nama_guru"].ToString() == namaGuru)
                    {
                        cmbGuru.SelectedValue =
                            guru["id_guru"];
                        break;
                    }
                }

                txtTanggal.Text = baris.Cells[3].Value.ToString();
                txtJam.Text =baris.Cells[4].Value.ToString();
                txtKeperluan.Text =baris.Cells[5].Value.ToString();

            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cmbSiswa.SelectedValue == null ||
                cmbGuru.SelectedValue == null ||
                txtTanggal.Text == "" ||
                txtJam.Text == "" ||
                txtKeperluan.Text == "")
            {
                MessageBox.Show("Lengkapi data");
                return;
            }
            string id_siswa =cmbSiswa.SelectedValue.ToString();
            string id_guru =cmbGuru.SelectedValue.ToString();
            string tanggal =txtTanggal.Text;
            string jam =txtJam.Text;
            string keperluan = txtKeperluan.Text;
            db.crud($"INSERT INTO jadwal_konseling " +$"(id_siswa, id_guru, tanggal, jam, keperluan, status) " +$"VALUES " +$"('{id_siswa}', '{id_guru}', '{tanggal}', '{jam}', '{keperluan}', 'Menunggu')");
            MessageBox.Show("Data berhasil ditambahkan");

            Bersih();
            TampilkanData();
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }
            if (cmbSiswa.SelectedValue == null ||
                cmbGuru.SelectedValue == null ||
                txtTanggal.Text == "" ||
                txtJam.Text == "" ||
                txtKeperluan.Text == "" )
            {
                MessageBox.Show("Lengkapi data");
                return;
            }
            string id_jadwal =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string id_siswa =cmbSiswa.SelectedValue.ToString();
            string id_guru =cmbGuru.SelectedValue.ToString();
            string tanggal = txtTanggal.Text;
            string jam =txtJam.Text;
            string keperluan =txtKeperluan.Text;
            string query =$"UPDATE jadwal_konseling SET " +$"id_siswa='{id_siswa}', " + $"id_guru='{id_guru}', " +$"tanggal='{tanggal}', " +$"jam='{jam}', " +$"keperluan='{keperluan}', " +$"WHERE id_jadwal='{id_jadwal}'";
            db.crud(query);
            MessageBox.Show("Data berhasil diupdate");
            Bersih();
            TampilkanData();
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih data terlebih dahulu");
                return;
            }
            string id_jadwal =dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult hasil = MessageBox.Show( "Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            
            if (hasil == DialogResult.Yes)
            {
                db.crud($"DELETE FROM jadwal_konseling " +$"WHERE id_jadwal='{id_jadwal}'");
                MessageBox.Show("Data berhasil dihapus");
                Bersih();
                TampilkanData();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu");
                return;
            }

            string id_jadwal =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            db.crud($"UPDATE jadwal_konseling " +$"SET status='Disetujui' " +$"WHERE id_jadwal='{id_jadwal}'");

            MessageBox.Show("Jadwal berhasil disetujui");
            TampilkanData();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Pilih jadwal terlebih dahulu");
                return;
            }

            string id_jadwal =dataGridView1.CurrentRow.Cells[0].Value.ToString();
            db.crud($"UPDATE jadwal_konseling " +$"SET status='Ditolak' " +$"WHERE id_jadwal='{id_jadwal}'");

            MessageBox.Show("Jadwal ditolak");
            TampilkanData();

        }
    }
}