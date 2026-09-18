
namespace BasisData01
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHapus = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnTambah = new Guna.UI2.WinForms.Guna2Button();
            this.cmbStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpJamMulai = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpJamSelesai = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbGuru = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbHari = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnHapus);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnTambah);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.dtpJamMulai);
            this.panel1.Controls.Add(this.dtpJamSelesai);
            this.panel1.Controls.Add(this.cmbGuru);
            this.panel1.Controls.Add(this.cmbHari);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 487);
            this.panel1.TabIndex = 0;
            // 
            // btnHapus
            // 
            this.btnHapus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHapus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHapus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHapus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHapus.FillColor = System.Drawing.Color.Red;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHapus.ForeColor = System.Drawing.Color.Black;
            this.btnHapus.Location = new System.Drawing.Point(565, 170);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(127, 36);
            this.btnHapus.TabIndex = 11;
            this.btnHapus.Text = "Delete";
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click_1);
            // 
            // btnReset
            // 
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(385, 170);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(127, 36);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            // 
            // btnEdit
            // 
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(214, 170);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(127, 36);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTambah.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTambah.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTambah.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTambah.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnTambah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTambah.ForeColor = System.Drawing.Color.Black;
            this.btnTambah.Location = new System.Drawing.Point(39, 170);
            this.btnTambah.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(127, 36);
            this.btnTambah.TabIndex = 8;
            this.btnTambah.Text = "Tambah";
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbStatus.BorderRadius = 7;
            this.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbStatus.ItemHeight = 30;
            this.cmbStatus.Location = new System.Drawing.Point(39, 71);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(113, 36);
            this.cmbStatus.TabIndex = 6;
            // 
            // dtpJamMulai
            // 
            this.dtpJamMulai.BorderRadius = 7;
            this.dtpJamMulai.Checked = true;
            this.dtpJamMulai.FillColor = System.Drawing.SystemColors.Highlight;
            this.dtpJamMulai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJamMulai.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpJamMulai.Location = new System.Drawing.Point(363, 21);
            this.dtpJamMulai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpJamMulai.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpJamMulai.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpJamMulai.Name = "dtpJamMulai";
            this.dtpJamMulai.Size = new System.Drawing.Size(149, 23);
            this.dtpJamMulai.TabIndex = 5;
            this.dtpJamMulai.Value = new System.DateTime(2026, 9, 12, 19, 27, 26, 842);
            this.dtpJamMulai.ValueChanged += new System.EventHandler(this.dtpJamMulai_ValueChanged);
            // 
            // dtpJamSelesai
            // 
            this.dtpJamSelesai.BorderRadius = 7;
            this.dtpJamSelesai.Checked = true;
            this.dtpJamSelesai.FillColor = System.Drawing.SystemColors.Highlight;
            this.dtpJamSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpJamSelesai.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpJamSelesai.Location = new System.Drawing.Point(363, 71);
            this.dtpJamSelesai.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpJamSelesai.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpJamSelesai.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpJamSelesai.Name = "dtpJamSelesai";
            this.dtpJamSelesai.Size = new System.Drawing.Size(149, 23);
            this.dtpJamSelesai.TabIndex = 4;
            this.dtpJamSelesai.Value = new System.DateTime(2026, 9, 12, 19, 27, 26, 842);
            this.dtpJamSelesai.ValueChanged += new System.EventHandler(this.dtpJamSelesai_ValueChanged);
            // 
            // cmbGuru
            // 
            this.cmbGuru.BackColor = System.Drawing.Color.Transparent;
            this.cmbGuru.BorderRadius = 7;
            this.cmbGuru.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGuru.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGuru.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGuru.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGuru.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGuru.ItemHeight = 30;
            this.cmbGuru.Location = new System.Drawing.Point(39, 21);
            this.cmbGuru.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGuru.Name = "cmbGuru";
            this.cmbGuru.Size = new System.Drawing.Size(113, 36);
            this.cmbGuru.TabIndex = 2;
            this.cmbGuru.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // cmbHari
            // 
            this.cmbHari.BackColor = System.Drawing.Color.Transparent;
            this.cmbHari.BorderRadius = 7;
            this.cmbHari.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHari.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHari.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbHari.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbHari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbHari.ItemHeight = 30;
            this.cmbHari.Location = new System.Drawing.Point(192, 21);
            this.cmbHari.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbHari.Name = "cmbHari";
            this.cmbHari.Size = new System.Drawing.Size(113, 36);
            this.cmbHari.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(913, 234);
            this.dataGridView1.TabIndex = 12;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 487);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form5";
            this.Text = "Form5";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbStatus;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpJamMulai;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpJamSelesai;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGuru;
        private Guna.UI2.WinForms.Guna2ComboBox cmbHari;
        private Guna.UI2.WinForms.Guna2Button btnHapus;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnTambah;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}