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
    public partial class FKereta : Form
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


        public FKereta()
        {
            InitializeComponent();

            // =========================
            // ENTER
            // =========================
            txtkdkereta.KeyDown += PindahDenganEnter;
            txtnmkereta.KeyDown += PindahDenganEnter;
            txtjnskereta.KeyDown += PindahDenganEnter;
            txtkpskereta.KeyDown += PindahDenganEnter;
        }


        // =========================
        // LOAD FORM
        // =========================
        private void FKereta_Load(object sender, EventArgs e)
        {
            SetupTabel();
        }


        // =========================
        // STYLE DATAGRIDVIEW
        // =========================
        private void SetupTabel()
        {
            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.BackgroundColor =
                Color.White;

            // Hilangkan nomor baris di sebelah kiri
            dataGridView1.RowHeadersVisible =
                false;

            // Tidak boleh tambah baris manual
            dataGridView1.AllowUserToAddRows =
                false;

            // Klik satu baris penuh
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect =
                false;

            // Tinggi baris
            dataGridView1.RowTemplate.Height =
                36;

            // Tidak bisa resize tinggi baris
            dataGridView1.AllowUserToResizeRows =
                false;


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

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersHeight =
                40;

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

            // Saat baris dipilih
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
        // MEMBERSIHKAN INPUT
        // =========================
        public void bersih()
        {
            txtkdkereta.Text = "";
            txtnmkereta.Text = "";
            txtjnskereta.Text = "";
            txtkpskereta.Text = "";
            nomor.Text = "";

            txtkdkereta.Focus();
        }


        // =========================
        // TAMPIL DATA
        // =========================
        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            db.crud("SELECT * FROM t_kereta");

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id =
                    "" + baris["id_kereta"];

                string kode =
                    "" + baris["kode_kereta"];

                string nm =
                    "" + baris["nama_kereta"];

                string jenis =
                    "" + baris["jenis_kereta"];

                int kapasitas =
                    Convert.ToInt32(baris["kapasitas"]);

                string kapasitasformat =
                    kapasitas.ToString("N0");


                dataGridView1.Rows.Add(
                    id,
                    kode,
                    nm,
                    jenis,
                    kapasitasformat
                );
            }
        }


        // =========================
        // BUTTON TAMPIL DATA
        // =========================
        private void guna2Button3_Click(
            object sender,
            EventArgs e)
        {
            tampildata();
        }


        // =========================
        // BUTTON SIMPAN
        // =========================
        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            string kode =
                txtkdkereta.Text;

            string nm =
                txtnmkereta.Text;

            string jenis =
                txtjnskereta.Text;

            string kapasitas =
                txtkpskereta.Text;


            db.crud(
                $"INSERT INTO t_kereta " +
                $"VALUES(null,'{kode}','{nm}','{jenis}','{kapasitas}');"
            );

            bersih();
            tampildata();
        }


        // =========================
        // BUTTON UPDATE
        // =========================
        private void guna2Button2_Click(
            object sender,
            EventArgs e)
        {
            string kode =
                txtkdkereta.Text;

            string nm =
                txtnmkereta.Text;

            string jenis =
                txtjnskereta.Text;

            string kapasitas =
                txtkpskereta.Text;

            string idkereta =
                nomor.Text;


            db.crud(
                $"UPDATE t_kereta SET " +
                $"kode_kereta = '{kode}', " +
                $"nama_kereta = '{nm}', " +
                $"jenis_kereta = '{jenis}', " +
                $"kapasitas = '{kapasitas}' " +
                $"WHERE id_kereta = '{idkereta}'"
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


                // =========================
                // KODE KERETA
                // =========================
                if (sender == txtkdkereta)
                {
                    txtnmkereta.Focus();
                }


                // =========================
                // NAMA KERETA
                // =========================
                else if (sender == txtnmkereta)
                {
                    txtjnskereta.Focus();
                }


                // =========================
                // JENIS KERETA
                // =========================
                else if (sender == txtjnskereta)
                {
                    txtkpskereta.Focus();
                }


                // =========================
                // KAPASITAS
                // =========================
                else if (sender == txtkpskereta)
                {
                    // Jika nomor kosong
                    // berarti tambah data
                    if (nomor.Text == "")
                    {
                        guna2Button1.PerformClick();
                    }

                    // Jika nomor ada
                    // berarti edit data
                    else
                    {
                        guna2Button2.PerformClick();
                    }
                }
            }
        }


        // =========================
        // CLICK DATA GRID
        // =========================
        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Supaya tidak error
            // kalau klik header
            if (e.RowIndex < 0)
            {
                return;
            }


            // Supaya tidak error
            // kalau baris kosong
            if (dataGridView1.Rows[e.RowIndex]
                .Cells[0].Value == null)
            {
                return;
            }


            int baris =
                e.RowIndex;

            int kolom =
                e.ColumnIndex;


            string idnya =
                dataGridView1.Rows[baris]
                .Cells[0]
                .Value
                .ToString();


            // =========================
            // EDIT
            // =========================
            if (kolom == 5)
            {
                db.crud(
                    $"SELECT * FROM t_kereta " +
                    $"WHERE id_kereta = '{idnya}'"
                );


                foreach (
                    DataRow bariss
                    in db.ds.Tables[0].Rows)
                {
                    string id =
                        "" + bariss["id_kereta"];

                    string kode =
                        "" + bariss["kode_kereta"];

                    string nm =
                        "" + bariss["nama_kereta"];

                    string jenis =
                        "" + bariss["jenis_kereta"];

                    string kapasitas =
                        "" + bariss["kapasitas"];


                    nomor.Text =
                        id;

                    txtkdkereta.Text =
                        kode;

                    txtnmkereta.Text =
                        nm;

                    txtjnskereta.Text =
                        jenis;

                    txtkpskereta.Text =
                        kapasitas;
                }


                // Setelah klik edit,
                // fokus kembali ke input pertama
                txtkdkereta.Focus();
            }


            // =========================
            // DELETE
            // =========================
            if (kolom == 6)
            {
                DialogResult ya =
                    MessageBox.Show(
                        "apakah ingin menghapus data?",
                        "pemberitahuan",
                        MessageBoxButtons.YesNo
                    );


                if (ya == DialogResult.Yes)
                {
                    db.crud(
                        $"DELETE FROM t_kereta " +
                        $"WHERE id_kereta = '{idnya}'"
                    );

                    bersih();
                    tampildata();
                }
            }
        }
    }
}