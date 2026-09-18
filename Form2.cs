using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BasisData01
{
    public partial class Form2 : Form
    {
        int idSiswaDipilih = 0;

        MySqlConnection koneksi = new MySqlConnection(
            "server=localhost;database=db_bp_bk;uid=root;pwd=;");

        public Form2()
        {
            InitializeComponent();
        }

        public void TampilkanData()
        {
            dataGridView1.Rows.Clear();

            db.crud("SELECT id_siswa, nisn, nama_siswa, kelas, point_pelanggaran FROM siswa");

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id_siswa = baris["id_siswa"].ToString();
                string nisn = baris["nisn"].ToString();
                string nama_siswa = baris["nama_siswa"].ToString();
                string kelas = baris["kelas"].ToString();
                string point_pelanggaran = baris["point_pelanggaran"].ToString();

                int index = dataGridView1.Rows.Add(
                    nisn,
                    nama_siswa,
                    kelas,
                    point_pelanggaran
                );

                dataGridView1.Rows[index].Tag = id_siswa;
            }
        }

        public void CariData()
        {
            string cari = txtCari.Text.Trim();

            dataGridView1.Rows.Clear();

            string queryCari = "SELECT id_siswa, nisn, nama_siswa, kelas, point_pelanggaran FROM siswa WHERE nisn LIKE @cari OR nama_siswa LIKE @cari OR kelas LIKE @cari";

            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=db_bp_bk;uid=root;pwd=;"))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(queryCari, conn))
                {
                    cmd.Parameters.AddWithValue("@cari", $"%{cari}%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int index = dataGridView1.Rows.Add(
                                reader["nisn"].ToString(),
                                reader["nama_siswa"].ToString(),
                                reader["kelas"].ToString(),
                                reader["point_pelanggaran"].ToString()
                            );

                            dataGridView1.Rows[index].Tag = reader["id_siswa"].ToString();
                        }
                    }
                }
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
            if (txtnisn.Text.Trim() == "" ||
                txtnmsiswa.Text.Trim() == "" ||
                txtkls.Text.Trim() == "" ||
                txtpp.Text.Trim() == "")
            {
                MessageBox.Show("Lengkapi data terlebih dahulu!");
                return;
            }

            if (!int.TryParse(txtpp.Text.Trim(), out int point))
            {
                MessageBox.Show("Point pelanggaran harus berupa angka!");
                txtpp.Focus();
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=db_bp_bk;uid=root;pwd=;"))
            {
                conn.Open();

                string cekQuery = "SELECT COUNT(*) FROM siswa WHERE nisn = @nisn";

                using (MySqlCommand cekCmd = new MySqlCommand(cekQuery, conn))
                {
                    cekCmd.Parameters.AddWithValue("@nisn", txtnisn.Text.Trim());

                    int jumlah = Convert.ToInt32(cekCmd.ExecuteScalar());

                    if (jumlah > 0)
                    {
                        MessageBox.Show("NISN sudah terdaftar!");
                        return;
                    }
                }

                string queryTambah = "INSERT INTO siswa (nisn, nama_siswa, kelas, point_pelanggaran) VALUES (@nisn, @nama, @kelas, @point)";

                using (MySqlCommand cmd = new MySqlCommand(queryTambah, conn))
                {
                    cmd.Parameters.AddWithValue("@nisn", txtnisn.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", txtnmsiswa.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", txtkls.Text.Trim());
                    cmd.Parameters.AddWithValue("@point", point);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data berhasil ditambahkan!");

            bersih();
            TampilkanData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (idSiswaDipilih == 0)
            {
                MessageBox.Show("Pilih data siswa yang ingin diedit terlebih dahulu!");
                return;
            }

            if (txtnisn.Text.Trim() == "" ||
                txtnmsiswa.Text.Trim() == "" ||
                txtkls.Text.Trim() == "" ||
                txtpp.Text.Trim() == "")
            {
                MessageBox.Show("Lengkapi data terlebih dahulu!");
                return;
            }

            if (!int.TryParse(txtpp.Text.Trim(), out int point))
            {
                MessageBox.Show("Point pelanggaran harus berupa angka!");
                txtpp.Focus();
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(
                "server=localhost;database=db_bp_bk;uid=root;pwd=;"))
            {
                conn.Open();

                string cekQuery = "SELECT COUNT(*) FROM siswa WHERE nisn = @nisn AND id_siswa <> @id";

                using (MySqlCommand cekCmd = new MySqlCommand(cekQuery, conn))
                {
                    cekCmd.Parameters.AddWithValue("@nisn", txtnisn.Text.Trim());
                    cekCmd.Parameters.AddWithValue("@id", idSiswaDipilih);

                    int jumlah = Convert.ToInt32(cekCmd.ExecuteScalar());

                    if (jumlah > 0)
                    {
                        MessageBox.Show("NISN sudah digunakan siswa lain!");
                        return;
                    }
                }

                string queryUpdate = "UPDATE siswa SET nisn = @nisn, nama_siswa = @nama, kelas = @kelas, point_pelanggaran = @point WHERE id_siswa = @id";

                using (MySqlCommand cmd = new MySqlCommand(queryUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@nisn", txtnisn.Text.Trim());
                    cmd.Parameters.AddWithValue("@nama", txtnmsiswa.Text.Trim());
                    cmd.Parameters.AddWithValue("@kelas", txtkls.Text.Trim());
                    cmd.Parameters.AddWithValue("@point", point);
                    cmd.Parameters.AddWithValue("@id", idSiswaDipilih);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Data berhasil diupdate!");

            idSiswaDipilih = 0;

            bersih();

            TampilkanData();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            idSiswaDipilih = 0;

            bersih();

            TampilkanData();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
                return;

            DataGridViewRow baris = dataGridView1.Rows[e.RowIndex];

            if (baris.Tag == null)
                return;

            idSiswaDipilih = Convert.ToInt32(baris.Tag);

            txtnisn.Text = baris.Cells[0].Value?.ToString();
            txtnmsiswa.Text = baris.Cells[1].Value?.ToString();
            txtkls.Text = baris.Cells[2].Value?.ToString();
            txtpp.Text = baris.Cells[3].Value?.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (idSiswaDipilih == 0)
            {
                MessageBox.Show("Pilih data siswa yang ingin dihapus terlebih dahulu!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data siswa ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (hasil != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(
                    "server=localhost;database=db_bp_bk;uid=root;pwd=;"))
                {
                    conn.Open();

                    string queryHapus = "DELETE FROM siswa WHERE id_siswa = @id";

                    using (MySqlCommand cmd = new MySqlCommand(queryHapus, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idSiswaDipilih);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data berhasil dihapus!");

                idSiswaDipilih = 0;

                bersih();

                TampilkanData();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"Data siswa tidak dapat dihapus.\n\nKemungkinan siswa masih digunakan pada data lain.\n\nDetail: {ex.Message}",
                    "Gagal Menghapus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            CariData();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
