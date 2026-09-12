using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BasisData01
{
    public partial class Form4 : Form
    {
        private int idSiswa;
        private MySqlConnection koneksi;

        public Form4(int idSiswa)
        {
            InitializeComponent();

            this.idSiswa = idSiswa;

            koneksi = new MySqlConnection(
                "server=localhost;database=db_bp_bk;uid=root;pwd=;");

            this.Load += Form4_Load_1;
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("ID Siswa: " + idSiswa);

                koneksi.Open();

                TampilkanDashboard();
                TampilkanJadwal();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Gagal terhubung ke database.\n\n" + ex.Message,
                    "Error Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Terjadi kesalahan.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (koneksi != null &&
                    koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
            }
        }

        public void TampilkanDashboard()
        {
            string query = "SELECT COUNT(*) AS total, COALESCE(SUM(status = 'Menunggu'), 0) AS menunggu, COALESCE(SUM(status = 'Disetujui'), 0) AS disetujui, COALESCE(SUM(status = 'Ditolak'), 0) AS ditolak FROM jadwal_konseling WHERE id_siswa = @idSiswa";

            using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
            {
                cmd.Parameters.AddWithValue("@idSiswa", idSiswa);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lbTotalJadwal.Text = reader["total"].ToString();
                        lbMenunggu.Text = reader["menunggu"].ToString();
                        lbDisetujui.Text = reader["disetujui"].ToString();
                        lbDitolak.Text = reader["ditolak"].ToString();
                    }
                }
            }
        }

        public void TampilkanJadwal()
        {
            string query = "SELECT g.nama_guru AS Guru, DATE_FORMAT(j.tanggal, '%Y-%m-%d') AS Tanggal, TIME_FORMAT(j.jam, '%H:%i') AS Jam, j.status AS Status FROM jadwal_konseling j INNER JOIN guru g ON j.id_guru = g.id_guru WHERE j.id_siswa = @idSiswa ORDER BY j.tanggal DESC";

            using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
            {
                cmd.Parameters.AddWithValue("@idSiswa", idSiswa);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dataGridView1.DataSource = table;
                }
            }
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

        private void lbDitolak_Click(object sender, EventArgs e)
        {
        }
    }
}
