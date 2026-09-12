using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

            string query = "SELECT j.id_jadwal, s.nama_siswa, g.nama_guru, DATE_FORMAT(j.tanggal, '%Y-%m-%d') AS tanggal, TIME_FORMAT(j.jam, '%H:%i:%s') AS jam, j.keperluan, j.status FROM jadwal_konseling j INNER JOIN siswa s ON j.id_siswa = s.id_siswa INNER JOIN guru g ON j.id_guru = g.id_guru ORDER BY j.id_jadwal DESC";

            db.crud(query);

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                dataGridView1.Rows.Add(
                    baris["id_jadwal"].ToString(),
                    baris["nama_siswa"].ToString(),
                    baris["nama_guru"].ToString(),
                    baris["tanggal"].ToString(),
                    baris["jam"].ToString(),
                    baris["keperluan"].ToString(),
                    baris["status"].ToString()
                );
            }
        }

        public void Bersih()
        {
            if (cmbSiswa.Items.Count > 0)
                cmbSiswa.SelectedIndex = 0;

            if (cmbGuru.Items.Count > 0)
                cmbGuru.SelectedIndex = 0;

            dtpTanggal.Value = DateTime.Now;
            txtJam.Text = "";
            txtKeperluan.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = "yyyy-MM-dd";

            TampilSiswa();
            TampilGuru();
            TampilkanData();
        }

        private void dataGridView1_CellContentClick_1(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow baris = dataGridView1.Rows[e.RowIndex];

            if (baris.Cells[1].Value == null ||
                baris.Cells[2].Value == null)
                return;

            string namaSiswa = baris.Cells[1].Value.ToString();
            string namaGuru = baris.Cells[2].Value.ToString();

            for (int i = 0; i < cmbSiswa.Items.Count; i++)
            {
                DataRowView siswa = cmbSiswa.Items[i] as DataRowView;

                if (siswa != null &&
                    siswa["nama_siswa"].ToString() == namaSiswa)
                {
                    cmbSiswa.SelectedValue = siswa["id_siswa"];
                    break;
                }
            }

            for (int i = 0; i < cmbGuru.Items.Count; i++)
            {
                DataRowView guru = cmbGuru.Items[i] as DataRowView;

                if (guru != null &&
                    guru["nama_guru"].ToString() == namaGuru)
                {
                    cmbGuru.SelectedValue = guru["id_guru"];
                    break;
                }
            }

            if (baris.Cells[3].Value != null)
            {
                DateTime tanggal;

                if (DateTime.TryParse(
                    baris.Cells[3].Value.ToString(),
                    out tanggal))
                {
                    dtpTanggal.Value = tanggal;
                }
            }

            txtJam.Text = baris.Cells[4].Value?.ToString() ?? "";
            txtKeperluan.Text = baris.Cells[5].Value?.ToString() ?? "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (cmbSiswa.SelectedValue == null ||
                cmbGuru.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtJam.Text) ||
                string.IsNullOrWhiteSpace(txtKeperluan.Text))
            {
                MessageBox.Show(
                    "Lengkapi semua data terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TimeSpan jam;

            if (!TimeSpan.TryParse(txtJam.Text, out jam))
            {
                MessageBox.Show(
                    "Format jam tidak valid!\nContoh: 09:00:00",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_siswa = cmbSiswa.SelectedValue.ToString();
            string id_guru = cmbGuru.SelectedValue.ToString();
            string keperluan = txtKeperluan.Text.Replace("'", "''");

            string query = $"INSERT INTO jadwal_konseling (id_siswa, id_guru, tanggal, jam, keperluan, status) VALUES ('{id_siswa}', '{id_guru}', '{dtpTanggal.Value:yyyy-MM-dd}', '{jam:hh\\:mm\\:ss}', '{keperluan}', 'Menunggu')";

            db.crud(query);

            MessageBox.Show(
                "Data jadwal berhasil ditambahkan!",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
                MessageBox.Show(
                    "Pilih data yang ingin diubah terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbSiswa.SelectedValue == null ||
                cmbGuru.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtJam.Text) ||
                string.IsNullOrWhiteSpace(txtKeperluan.Text))
            {
                MessageBox.Show(
                    "Lengkapi semua data terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            TimeSpan jam;

            if (!TimeSpan.TryParse(txtJam.Text, out jam))
            {
                MessageBox.Show(
                    "Format jam tidak valid!\nContoh: 09:00:00",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_jadwal =
                dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string id_siswa =
                cmbSiswa.SelectedValue.ToString();

            string id_guru =
                cmbGuru.SelectedValue.ToString();

            string keperluan =
                txtKeperluan.Text.Replace("'", "''");

            string query = $"UPDATE jadwal_konseling SET id_siswa='{id_siswa}', id_guru='{id_guru}', tanggal='{dtpTanggal.Value:yyyy-MM-dd}', jam='{jam:hh\\:mm\\:ss}', keperluan='{keperluan}' WHERE id_jadwal='{id_jadwal}'";

            db.crud(query);

            MessageBox.Show(
                "Data jadwal berhasil diupdate!",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Bersih();
            TampilkanData();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Pilih data yang ingin dihapus terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_jadwal =
                dataGridView1.CurrentRow.Cells[0].Value.ToString();

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus jadwal ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                string query =
                    $"DELETE FROM jadwal_konseling WHERE id_jadwal='{id_jadwal}'";

                db.crud(query);

                MessageBox.Show(
                    "Data jadwal berhasil dihapus!",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Bersih();
                TampilkanData();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Pilih jadwal terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_jadwal =
                dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string status =
                dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (status == "Selesai")
            {
                MessageBox.Show(
                    "Jadwal yang sudah selesai tidak dapat disetujui lagi!");

                return;
            }

            string query =
                $"UPDATE jadwal_konseling SET status='Disetujui', alasan_penolakan=NULL WHERE id_jadwal='{id_jadwal}'";

            db.crud(query);

            MessageBox.Show(
                "Jadwal berhasil disetujui!",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            TampilkanData();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Pilih jadwal terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_jadwal =
                dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string status =
                dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (status == "Selesai")
            {
                MessageBox.Show(
                    "Jadwal yang sudah selesai tidak dapat ditolak lagi!");

                return;
            }

            Form formAlasan = new Form();

            formAlasan.Text = "Alasan Penolakan";
            formAlasan.Width = 450;
            formAlasan.Height = 250;
            formAlasan.StartPosition =
                FormStartPosition.CenterParent;

            Label label = new Label();

            label.Text = "Masukkan alasan penolakan:";
            label.Left = 20;
            label.Top = 20;
            label.Width = 350;

            TextBox txtAlasan = new TextBox();

            txtAlasan.Left = 20;
            txtAlasan.Top = 50;
            txtAlasan.Width = 390;
            txtAlasan.Height = 80;
            txtAlasan.Multiline = true;

            Button btnOK = new Button();

            btnOK.Text = "Tolak";
            btnOK.Left = 230;
            btnOK.Top = 150;
            btnOK.Width = 80;
            btnOK.DialogResult = DialogResult.OK;

            Button btnBatal = new Button();

            btnBatal.Text = "Batal";
            btnBatal.Left = 320;
            btnBatal.Top = 150;
            btnBatal.Width = 80;
            btnBatal.DialogResult = DialogResult.Cancel;

            formAlasan.Controls.Add(label);
            formAlasan.Controls.Add(txtAlasan);
            formAlasan.Controls.Add(btnOK);
            formAlasan.Controls.Add(btnBatal);

            formAlasan.AcceptButton = btnOK;
            formAlasan.CancelButton = btnBatal;

            DialogResult hasil = formAlasan.ShowDialog();

            if (hasil != DialogResult.OK)
                return;

            string alasan = txtAlasan.Text.Trim();

            if (string.IsNullOrWhiteSpace(alasan))
            {
                MessageBox.Show(
                    "Alasan penolakan wajib diisi!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string alasanSQL =
                alasan.Replace("'", "''");

            string query =
                $"UPDATE jadwal_konseling SET status='Ditolak', alasan_penolakan='{alasanSQL}' WHERE id_jadwal='{id_jadwal}'";

            db.crud(query);

            MessageBox.Show(
                "Jadwal berhasil ditolak!",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            TampilkanData();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show(
                    "Pilih jadwal terlebih dahulu!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string id_jadwal =
                dataGridView1.CurrentRow.Cells[0].Value.ToString();

            string status =
                dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (status != "Disetujui")
            {
                MessageBox.Show(
                    "Jadwal hanya bisa diselesaikan jika sudah Disetujui!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Apakah konseling ini sudah selesai?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                string query =
                    $"UPDATE jadwal_konseling SET status='Selesai' WHERE id_jadwal='{id_jadwal}'";

                db.crud(query);

                MessageBox.Show(
                    "Jadwal berhasil ditandai sebagai Selesai!",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TampilkanData();
            }
        }
    }
}

