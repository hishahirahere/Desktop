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
    public partial class FKelas : Form
    {
        // WARNA TABEL
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);

        public FKelas()
        {
            InitializeComponent();

            // ENTER PADA TXT KELAS
            txtkelas.KeyDown += PindahDenganEnter;
        }


        // STYLE DATAGRIDVIEW
        private void SetupTabel()
        {
            // TAMPILAN DASAR
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;

            // BARIS
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.AllowUserToResizeRows = false;

            // HEADER BIRU
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ISI TABEL
            dataGridView1.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // SAAT BARIS DIPILIH
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // BARIS SELANG-SELING
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // GARIS TABEL
            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(229, 231, 235);
        }

        // MEMBERSIHKAN INPUT
        public void bersih()
        {
            txtkelas.Text = "";
            nomoR.Text = "";

            txtkelas.Focus();
        }

        // TAMPIL DATA
        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            db.crud("SELECT * FROM t_kelas");

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_kelas"];
                string kelas = "" + baris["nama_kelas"];

                dataGridView1.Rows.Add(id, kelas);
            }
        }

        // BUTTON SIMPAN
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kelas = txtkelas.Text;

            db.crud($"INSERT INTO t_kelas VALUES(null,'{kelas}');");

            bersih();
            tampildata();
        }

        // BUTTON TAMPIL DATA
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        // BUTTON UPDATE
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kelas = txtkelas.Text;
            string idkelas = nomoR.Text;

            db.crud(
                $"UPDATE t_kelas SET nama_kelas = '{kelas}' " +
                $"WHERE id_kelas = '{idkelas}'"
            );

            bersih();
            tampildata();
        }

        // ENTER
        private void PindahDenganEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Kalau nomoR kosong = TAMBAH
                if (nomoR.Text == "")
                {
                    guna2Button1.PerformClick();
                }
                // Kalau nomoR ada isi = UPDATE
                else
                {
                    guna2Button2.PerformClick();
                }
            }
        }

        // EDIT / DELETE
        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Supaya tidak error ketika klik header
            if (e.RowIndex < 0)
            {
                return;
            }

            // Supaya tidak error ketika klik baris kosong
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value == null)
            {
                return;
            }

            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;

            string idnya =
                dataGridView1.Rows[baris].Cells[0].Value.ToString();

            // EDIT
            if (kolom == 2)
            {
                db.crud(
                    $"SELECT * FROM t_kelas WHERE id_kelas = '{idnya}'"
                );

                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_kelas"];
                    string kelas = "" + bariss["nama_kelas"];

                    nomoR.Text = id;
                    txtkelas.Text = kelas;
                }

                // Fokus ke input
                txtkelas.Focus();
            }

            // DELETE
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
                        $"DELETE FROM t_kelas WHERE id_kelas = '{idnya}'"
                    );

                    bersih();
                    tampildata();
                }
            }
        }

        private void FKelas_Load(object sender, EventArgs e)
        {
            SetupTabel();
        }
    }
}