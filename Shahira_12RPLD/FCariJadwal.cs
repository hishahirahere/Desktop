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
    public partial class FCariJadwal : Form
    {
        private string idJadwalTerpilih = "";

        // WARNA TABEL
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);

        public FCariJadwal()
        {
            InitializeComponent();
        }

        private void FCariJadwal_Load(object sender, EventArgs e)
        {
            // STYLE TABEL
            SetupTabel();

            // Isi combo Stasiun Asal
            db.crud("SELECT * FROM t_stasiun");

            cmbAsal.DataSource = db.ds.Tables[0];
            cmbAsal.DisplayMember = "nama_stasiun";
            cmbAsal.ValueMember = "id_stasiun";
            cmbAsal.SelectedIndex = -1;

            // Isi combo Stasiun Tujuan
            db.crud("SELECT * FROM t_stasiun");

            cmbTujuan.DataSource = db.ds.Tables[0];
            cmbTujuan.DisplayMember = "nama_stasiun";
            cmbTujuan.ValueMember = "id_stasiun";
            cmbTujuan.SelectedIndex = -1;

            dtTanggal.Value = DateTime.Now;

            // Tombol pilih belum aktif
            btnPilihJadwal.Enabled = false;
        }

        // STYLE DATAGRIDVIEW
        private void SetupTabel()
        {
            // TAMPILAN DASAR
            dgvJadwal.BorderStyle = BorderStyle.None;
            dgvJadwal.BackgroundColor = Color.White;
            dgvJadwal.RowHeadersVisible = false;

            // BARIS
            dgvJadwal.AllowUserToAddRows = false;
            dgvJadwal.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvJadwal.MultiSelect = false;
            dgvJadwal.RowTemplate.Height = 36;
            dgvJadwal.AllowUserToResizeRows = false;

            // HEADER BIRU
            dgvJadwal.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dgvJadwal.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvJadwal.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvJadwal.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvJadwal.EnableHeadersVisualStyles = false;

            dgvJadwal.ColumnHeadersHeight = 40;

            dgvJadwal.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ISI TABEL
            dgvJadwal.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dgvJadwal.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvJadwal.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // SAAT DIPILIH
            dgvJadwal.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dgvJadwal.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // BARIS SELANG-SELING
            dgvJadwal.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dgvJadwal.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dgvJadwal.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // GARIS TABEL
            dgvJadwal.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvJadwal.GridColor =
                Color.FromArgb(229, 231, 235);
        }

        // BUTTON CARI
        private void btnCari_Click(object sender, EventArgs e)
        {
            if (cmbAsal.SelectedIndex == -1 ||
                cmbTujuan.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Pilih stasiun asal dan tujuan dulu"
                );

                return;
            }

            if (cmbAsal.SelectedValue.ToString() ==
                cmbTujuan.SelectedValue.ToString())
            {
                MessageBox.Show(
                    "Stasiun asal dan tujuan tidak boleh sama"
                );

                return;
            }

            string asal =
                cmbAsal.SelectedValue.ToString();

            string tujuan =
                cmbTujuan.SelectedValue.ToString();

            string tanggal =
                dtTanggal.Value.ToString("yyyy-MM-dd");

            string query = $@"
                SELECT
                    t_jadwal.id_jadwal,
                    t_kereta.nama_kereta,
                    t_kelas.nama_kelas,
                    t_jadwal.jam_berangkat,
                    t_jadwal.jam_tiba,
                    t_jadwal.harga,
                    t_jadwal.sisa_kursi

                FROM t_jadwal

                JOIN t_kereta
                    ON t_jadwal.id_kereta =
                       t_kereta.id_kereta

                JOIN t_kelas
                    ON t_jadwal.id_kelas =
                       t_kelas.id_kelas

                WHERE t_jadwal.id_stasiunAsal =
                      '{asal}'

                AND t_jadwal.id_stasiunTujuan =
                    '{tujuan}'

                AND t_jadwal.tanggal =
                    '{tanggal}'

                AND t_jadwal.sisa_kursi > 0
            ";

            db.crud(query);

            dgvJadwal.Rows.Clear();

            // RESET JADWAL TERPILIH
            idJadwalTerpilih = "";

            btnPilihJadwal.Enabled = false;

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                dgvJadwal.Rows.Add(
                    baris["id_jadwal"],
                    baris["nama_kereta"],
                    baris["nama_kelas"],
                    baris["jam_berangkat"],
                    baris["jam_tiba"],
                    baris["harga"],
                    baris["sisa_kursi"]
                );
            }

            if (dgvJadwal.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Tidak ada jadwal tersedia untuk rute dan tanggal ini"
                );
            }
        }

        // PILIH DATA DI TABEL
        private void dgvJadwal_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // Kalau klik header
            if (e.RowIndex < 0)
            {
                return;
            }

            // Kalau baris kosong
            if (dgvJadwal.Rows[e.RowIndex]
                .Cells["colIdJadwal"].Value == null)
            {
                return;
            }

            // Ambil ID jadwal
            int baris = e.RowIndex;

            idJadwalTerpilih =
                dgvJadwal.Rows[baris]
                .Cells["colIdJadwal"]
                .Value
                .ToString();

            // Aktifkan tombol pilih
            btnPilihJadwal.Enabled = true;
        }

        // BUTTON PILIH JADWAL
        private void btnPilihJadwal_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrEmpty(idJadwalTerpilih))
            {
                MessageBox.Show(
                    "Pilih salah satu jadwal dulu dari daftar"
                );

                return;
            }

            // Buka form Pilih Kursi
            FPilihKursi f =
                new FPilihKursi(idJadwalTerpilih);

            f.Show();

            this.Hide();
        }
    }
}