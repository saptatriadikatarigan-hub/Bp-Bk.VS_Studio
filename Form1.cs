
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BasisData01
{
    public partial class Form1 : Form
    {
        MySqlConnection koneksi = new MySqlConnection("server=localhost;database=db_bp_bk;uid=root;pwd=;");

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
            string username = txtuser.Text.Trim();
            string password = txtpass.Text;

            if (username == "")
            {
                MessageBox.Show("Username wajib diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtuser.Focus();
                return;
            }

            if (password == "")
            {
                MessageBox.Show("Password wajib diisi!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpass.Focus();
                return;
            }

            try
            {
                koneksi.Open();

                string query = "SELECT id_user, role FROM login WHERE user = @user AND password = @password";

                using (MySqlCommand cmd = new MySqlCommand(query, koneksi))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();

                            if (role == "admin" || role == "anggota")
                            {
                                MessageBox.Show("Login berhasil!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                reader.Close();

                                dashboard F2 = new dashboard();
                                F2.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Role akun tidak valid!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username atau Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtpass.Clear();
                            txtpass.Focus();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database tidak dapat terhubung.\n\nDetail: {ex.Message}", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (koneksi.State == ConnectionState.Open)
                {
                    koneksi.Close();
                }
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

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

