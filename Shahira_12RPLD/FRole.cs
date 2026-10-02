using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FRole : Form
    {
        // =========================
        // WARNA TABEL
        // =========================
        private readonly Color WARNA_BIRU =
            Color.FromArgb(37, 99, 235);

        private readonly Color WARNA_BIRU_MUDA =
            Color.FromArgb(239, 246, 255);

        private readonly Color WARNA_TEKS_GELAP =
            Color.FromArgb(30, 41, 59);


        public FRole()
        {
            InitializeComponent();

            // =========================
            // ENTER PADA TXTROLE
            // =========================
            txtrole.KeyDown += PindahDenganEnter;
        }


        // =========================
        // LOAD FORM
        // =========================
        private void FRole_Load(object sender, EventArgs e)
        {
            SetupTabel();
        }


        // =========================
        // STYLE DATAGRIDVIEW
        // =========================
        private void SetupTabel()
        {
            dataGridView1.BorderStyle = BorderStyle.None;

            dataGridView1.BackgroundColor =
                Color.White;

            // Hilangkan nomor baris di sebelah kiri
            dataGridView1.RowHeadersVisible = false;

            // Tidak boleh tambah baris manual
            dataGridView1.AllowUserToAddRows = false;

            // Klik satu baris penuh
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;

            // Tinggi baris
            dataGridView1.RowTemplate.Height = 36;

            // Tidak bisa resize tinggi baris
            dataGridView1.AllowUserToResizeRows = false;


            // =========================
            // HEADER BIRU
            // =========================
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold
                );

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // =========================
            // ISI TABEL
            // =========================
            dataGridView1.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Warna saat baris dipilih
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;


            // =========================
            // BARIS SELANG-SELING
            // =========================
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;


            // =========================
            // GARIS TABEL
            // =========================
            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(229, 231, 235);
        }


        // =========================
        // BERSIHKAN INPUT
        // =========================
        public void bersih()
        {
            txtrole.Text = "";
            nomoR.Text = "";

            txtrole.Focus();
        }


        // =========================
        // TAMPIL DATA
        // =========================
        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            db.crud("SELECT * FROM t_role");

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_role"];
                string role = "" + baris["nama_role"];

                dataGridView1.Rows.Add(
                    id,
                    role
                );
            }
        }


        // =========================
        // BUTTON TAMBAH / SIMPAN
        // =========================
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string role = txtrole.Text.Trim();

            if (role == "")
            {
                MessageBox.Show(
                    "Nama role belum diisi!"
                );

                txtrole.Focus();
                return;
            }

            db.crud(
                $"INSERT INTO t_role VALUES(null,'{role}');"
            );

            bersih();
            tampildata();
        }


        // =========================
        // BUTTON TAMPIL DATA
        // =========================
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }


        // =========================
        // BUTTON UPDATE
        // =========================
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string role = txtrole.Text.Trim();
            string idu = nomoR.Text;

            if (idu == "")
            {
                MessageBox.Show(
                    "Silakan pilih data yang ingin diubah terlebih dahulu."
                );

                return;
            }

            if (role == "")
            {
                MessageBox.Show(
                    "Nama role belum diisi!"
                );

                txtrole.Focus();
                return;
            }

            db.crud(
                $"UPDATE t_role SET nama_role = '{role}' " +
                $"WHERE id_role = '{idu}'"
            );

            bersih();
            tampildata();
        }


        // =========================
        // ENTER
        // =========================
        private void PindahDenganEnter(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Kalau nomoR kosong = TAMBAH
                if (nomoR.Text == "")
                {
                    guna2Button1.PerformClick();
                }

                // Kalau nomoR ada isinya = UPDATE
                else
                {
                    guna2Button2.PerformClick();
                }
            }
        }


        // =========================
        // EDIT / HAPUS
        // =========================
        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Jangan error kalau klik header
            if (e.RowIndex < 0)
                return;

            // Jangan error kalau baris kosong
            if (dataGridView1.Rows[e.RowIndex]
                .Cells[0].Value == null)
                return;

            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;

            string idnya =
                dataGridView1.Rows[baris]
                .Cells[0]
                .Value
                .ToString();


            // =========================
            // EDIT
            // =========================
            if (kolom == 2)
            {
                db.crud(
                    $"SELECT * FROM t_role " +
                    $"WHERE id_role = '{idnya}'"
                );

                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    nomoR.Text =
                        "" + bariss["id_role"];

                    txtrole.Text =
                        "" + bariss["nama_role"];
                }

                txtrole.Focus();
            }


            // =========================
            // DELETE
            // =========================
            if (kolom == 3)
            {
                DialogResult ya = MessageBox.Show(
                    "apakah ingin menghapus data?",
                    "pemberitahuan",
                    MessageBoxButtons.YesNo
                );

                if (ya == DialogResult.Yes)
                {
                    db.crud(
                        $"DELETE FROM t_role " +
                        $"WHERE id_role = '{idnya}'"
                    );

                    bersih();
                    tampildata();
                }
            }
        }
    }
}