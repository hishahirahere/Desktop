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
    public partial class FStasiun : Form
    {
        private readonly Color WARNA_BIRU =
            Color.FromArgb(37, 99, 235);

        private readonly Color WARNA_BIRU_MUDA =
            Color.FromArgb(239, 246, 255);

        private readonly Color WARNA_TEKS_GELAP =
            Color.FromArgb(30, 41, 59);


        public FStasiun()
        {
            InitializeComponent();

            txtkdstasiun.KeyDown += PindahDenganEnter;
            txtnmstasiun.KeyDown += PindahDenganEnter;
            txtkota.KeyDown += PindahDenganEnter;
        }

        private void FStasiun_Load(object sender, EventArgs e)
        {
            SetupTabel();
        }


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

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(229, 231, 235);
        }

        public void bersih()
        {
            txtkdstasiun.Text = "";
            txtnmstasiun.Text = "";
            txtkota.Text = "";
            nomor.Text = "";

            txtkdstasiun.Focus();
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            db.crud(
                "SELECT * FROM t_stasiun"
            );

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id =
                    "" + baris["id_stasiun"];

                string kode =
                    "" + baris["kode_stasiun"];

                string nm =
                    "" + baris["nama_stasiun"];

                string kota =
                    "" + baris["kota"];


                dataGridView1.Rows.Add(
                    id,
                    kode,
                    nm,
                    kota
                );
            }
        }

        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            string kode =
                txtkdstasiun.Text;

            string nm =
                txtnmstasiun.Text;

            string kota =
                txtkota.Text;


            db.crud(
                $"INSERT INTO t_stasiun " +
                $"VALUES(null,'{kode}','{nm}','{kota}');"
            );

            bersih();
            tampildata();
        }

        private void guna2Button3_Click(
            object sender,
            EventArgs e)
        {
            tampildata();
        }


        private void guna2Button2_Click(
            object sender,
            EventArgs e)
        {
            string kode =
                txtkdstasiun.Text;

            string nm =
                txtnmstasiun.Text;

            string kota =
                txtkota.Text;

            string idstasiun =
                nomor.Text;


            db.crud(
                $"UPDATE t_stasiun SET " +
                $"kode_stasiun = '{kode}', " +
                $"nama_stasiun = '{nm}', " +
                $"kota = '{kota}' " +
                $"WHERE id_stasiun = '{idstasiun}'"
            );

            bersih();
            tampildata();
        }

        private void PindahDenganEnter(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (sender == txtkdstasiun)
                {
                    txtnmstasiun.Focus();
                }

                else if (sender == txtnmstasiun)
                {
                    txtkota.Focus();
                }


                else if (sender == txtkota)
                {
                    // Kalau nomor kosong = TAMBAH
                    if (nomor.Text == "")
                    {
                        guna2Button1.PerformClick();
                    }

                    // Kalau nomor ada isi = UPDATE
                    else
                    {
                        guna2Button2.PerformClick();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Jangan error kalau klik header
            if (e.RowIndex < 0)
            {
                return;
            }


            // Jangan error kalau baris kosong
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

            if (kolom == 4)
            {
                db.crud(
                    $"SELECT * FROM t_stasiun " +
                    $"WHERE id_stasiun = '{idnya}'"
                );


                foreach (DataRow bariss
                    in db.ds.Tables[0].Rows)
                {
                    string id =
                        "" + bariss["id_stasiun"];

                    string kode =
                        "" + bariss["kode_stasiun"];

                    string nm =
                        "" + bariss["nama_stasiun"];

                    string kota =
                        "" + bariss["kota"];


                    nomor.Text = id;

                    txtkdstasiun.Text =
                        kode;

                    txtnmstasiun.Text =
                        nm;

                    txtkota.Text =
                        kota;
                }


                // Fokus ke input pertama
                txtkdstasiun.Focus();
            }

            if (kolom == 5)
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
                        $"DELETE FROM t_stasiun " +
                        $"WHERE id_stasiun = '{idnya}'"
                    );

                    bersih();
                    tampildata();
                }
            }
        }
    }
}