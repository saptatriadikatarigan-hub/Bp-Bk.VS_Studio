using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BasisData01
{
    public partial class Form5 : Form
    {
        private MySqlConnection koneksi = new MySqlConnection(
            "server=localhost;database=db_bp_bk;uid=root;pwd=;"
        );

        private int idJadwal = 0;

        public Form5()
        {
            InitializeComponent();

            Load += Form5_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            btnTambah.Click += btnTambah_Click;
            btnEdit.Click += btnEdit_Click;
            btnHapus.Click += btnHapus_Click;
            btnReset.Click += btnReset_Click;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dtpJamMulai.Format = DateTimePickerFormat.Custom;
            dtpJamMulai.CustomFormat = "HH:mm";
            dtpJamMulai.ShowUpDown = true;
            dtpJamMulai.Value = DateTime.Today.AddHours(8);

            dtpJamSelesai.Format = DateTimePickerFormat.Custom;
            dtpJamSelesai.CustomFormat = "HH:mm";
            dtpJamSelesai.ShowUpDown = true;
            dtpJamSelesai.Value = DateTime.Today.AddHours(10);

            IsiGuru();
            IsiHari();
            IsiStatus();
            TampilkanData();
        }

        private void IsiGuru()
        {
            try
            {
                koneksi.Open();

                string query = "SELECT id_guru, nama_guru FROM guru ORDER BY nama_guru";

                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();

                adapter.Fill(table);

                cmbGuru.DataSource = table;
                cmbGuru.DisplayMember = "nama_guru";
                cmbGuru.ValueMember = "id_guru";
                cmbGuru.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data guru.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }

        private void IsiHari()
        {
            cmbHari.Items.Clear();

            cmbHari.Items.Add("Senin");
            cmbHari.Items.Add("Selasa");
            cmbHari.Items.Add("Rabu");
            cmbHari.Items.Add("Kamis");
            cmbHari.Items.Add("Jumat");
            cmbHari.Items.Add("Sabtu");

            cmbHari.SelectedIndex = -1;
        }

        private void IsiStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Tersedia");
            cmbStatus.Items.Add("Tidak Tersedia");

            cmbStatus.SelectedIndex = -1;
        }

        private void TampilkanData()
        {
            try
            {
                koneksi.Open();

                string query = @"
                    SELECT
                        j.id_jadwal_guru AS ID,
                        j.id_guru AS IDGuru,
                        g.nama_guru AS Guru,
                        j.hari AS Hari,
                        TIME_FORMAT(j.jam_mulai, '%H:%i') AS `Jam Mulai`,
                        TIME_FORMAT(j.jam_selesai, '%H:%i') AS `Jam Selesai`,
                        j.status AS Status
                    FROM jadwal_guru j
                    LEFT JOIN guru g
                        ON j.id_guru = g.id_guru
                    ORDER BY j.id_jadwal_guru DESC";

                MySqlCommand cmd = new MySqlCommand(query, koneksi);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();

                adapter.Fill(table);

                dataGridView1.DataSource = table;

                if (dataGridView1.Columns["ID"] != null)
                    dataGridView1.Columns["ID"].Visible = false;

                if (dataGridView1.Columns["IDGuru"] != null)
                    dataGridView1.Columns["IDGuru"].Visible = false;

                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;
                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan data.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (!Validasi())
                return;

            try
            {
                koneksi.Open();

                string query = @"
                    INSERT INTO jadwal_guru
                    (id_guru, hari, jam_mulai, jam_selesai, status)
                    VALUES
                    (@idGuru, @hari, @jamMulai, @jamSelesai, @status)";

                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@idGuru", cmbGuru.SelectedValue);
                cmd.Parameters.AddWithValue("@hari", cmbHari.Text);
                cmd.Parameters.AddWithValue(
                    "@jamMulai",
                    dtpJamMulai.Value.ToString("HH:mm:ss")
                );
                cmd.Parameters.AddWithValue(
                    "@jamSelesai",
                    dtpJamSelesai.Value.ToString("HH:mm:ss")
                );
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menambahkan jadwal.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }

            TampilkanData();
            ResetForm();

            MessageBox.Show(
                "Jadwal berhasil ditambahkan.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (idJadwal == 0)
            {
                MessageBox.Show(
                    "Pilih data yang mau diedit.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (!Validasi())
                return;

            try
            {
                koneksi.Open();

                string query = @"
                    UPDATE jadwal_guru
                    SET
                        id_guru = @idGuru,
                        hari = @hari,
                        jam_mulai = @jamMulai,
                        jam_selesai = @jamSelesai,
                        status = @status
                    WHERE id_jadwal_guru = @id";

                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@idGuru", cmbGuru.SelectedValue);
                cmd.Parameters.AddWithValue("@hari", cmbHari.Text);
                cmd.Parameters.AddWithValue(
                    "@jamMulai",
                    dtpJamMulai.Value.ToString("HH:mm:ss")
                );
                cmd.Parameters.AddWithValue(
                    "@jamSelesai",
                    dtpJamSelesai.Value.ToString("HH:mm:ss")
                );
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@id", idJadwal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memperbarui jadwal.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }

            TampilkanData();
            ResetForm();

            MessageBox.Show(
                "Jadwal berhasil diperbarui.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idJadwal == 0)
            {
                MessageBox.Show(
                    "Pilih data yang ingin dihapus.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus jadwal ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (hasil != DialogResult.Yes)
                return;

            try
            {
                koneksi.Open();

                string query = @"
                    DELETE FROM jadwal_guru
                    WHERE id_jadwal_guru = @id";

                MySqlCommand cmd = new MySqlCommand(query, koneksi);

                cmd.Parameters.AddWithValue("@id", idJadwal);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus jadwal.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                    koneksi.Close();
            }

            TampilkanData();
            ResetForm();

            MessageBox.Show(
                "Jadwal berhasil dihapus.",
                "Berhasil",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            if (row.Cells["ID"].Value == null)
                return;

            if (row.Cells["IDGuru"].Value == null)
                return;

            idJadwal = Convert.ToInt32(row.Cells["ID"].Value);

            cmbGuru.SelectedValue =
                Convert.ToInt32(row.Cells["IDGuru"].Value);

            cmbHari.Text =
                row.Cells["Hari"].Value.ToString();

            cmbStatus.Text =
                row.Cells["Status"].Value.ToString();

            TimeSpan jamMulai =
                TimeSpan.Parse(row.Cells["Jam Mulai"].Value.ToString());

            TimeSpan jamSelesai =
                TimeSpan.Parse(row.Cells["Jam Selesai"].Value.ToString());

            dtpJamMulai.Value =
                DateTime.Today.Add(jamMulai);

            dtpJamSelesai.Value =
                DateTime.Today.Add(jamSelesai);
        }

        private bool Validasi()
        {
            if (cmbGuru.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih guru terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbGuru.Focus();
                return false;
            }

            if (cmbHari.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih hari terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbHari.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih status terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbStatus.Focus();
                return false;
            }

            if (dtpJamSelesai.Value <= dtpJamMulai.Value)
            {
                MessageBox.Show(
                    "Jam selesai harus lebih besar dari jam mulai.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            idJadwal = 0;

            cmbGuru.SelectedIndex = -1;
            cmbHari.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dtpJamMulai.Value =
                DateTime.Today.AddHours(8);

            dtpJamSelesai.Value =
                DateTime.Today.AddHours(10);

            dataGridView1.ClearSelection();
        }

        private void guna2ComboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void dataGridView1_Click(
            object sender,
            EventArgs e)
        {
        }

        private void btnHapus_Click_1(
            object sender,
            EventArgs e)
        {
        }
    }
}