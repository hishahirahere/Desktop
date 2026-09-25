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
    public partial class FDataPemesanan : Form
    {
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);
        private readonly Color WARNA_AMBER = Color.FromArgb(133, 79, 11);
        private readonly Color WARNA_MERAH = Color.FromArgb(163, 45, 45);
        private readonly Color WARNA_HIJAU = Color.FromArgb(15, 110, 86);

        public FDataPemesanan()
        {
            InitializeComponent();
            dgvDPemesanan.CellClick += dgvDPemesanan_CellClick;
        }

        private void FDataPemesanan_Load(object sender, EventArgs e)
        {
            SetupTabel();
            SetupKolomAksi();
            TampilkanDataPemesanan();
        }

        // ============ STYLING TABEL ============
        private void SetupTabel()
        {
            dgvDPemesanan.BorderStyle = BorderStyle.None;
            dgvDPemesanan.BackgroundColor = Color.White;
            dgvDPemesanan.RowHeadersVisible = false;
            dgvDPemesanan.AllowUserToAddRows = false;
            dgvDPemesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDPemesanan.MultiSelect = false;
            dgvDPemesanan.RowTemplate.Height = 36;

            dgvDPemesanan.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvDPemesanan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDPemesanan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDPemesanan.EnableHeadersVisualStyles = false;

            dgvDPemesanan.DefaultCellStyle.ForeColor = WARNA_TEKS_GELAP;
            dgvDPemesanan.DefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvDPemesanan.DefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
            dgvDPemesanan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvDPemesanan.AlternatingRowsDefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvDPemesanan.AlternatingRowsDefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
        }

        // Kolom Aksi jadi tombol "Detail Pesanan"
        private void SetupKolomAksi()
        {
            if (dgvDPemesanan.Columns["colAksi"] is DataGridViewButtonColumn kolomAksi)
            {
                kolomAksi.Text = "Detail Pesanan";
                kolomAksi.UseColumnTextForButtonValue = true;
            }
        }

        // ============ WARNA TEKS STATUS BIAR GAMPANG DIBACA SEKILAS ============
        private Color WarnaStatus(string status)
        {
            switch (status)
            {
                case "berhasil": return WARNA_HIJAU;
                case "dibatalkan": return WARNA_MERAH;
                default: return WARNA_AMBER; // "menunggu"
            }
        }

        // ============ AMBIL SEMUA DATA PEMESANAN (SISI ADMIN, SEMUA USER) ============
        // Catatan: status yang ditampilkan di sini adalah status di t_pemesanan,
        // yang HARUS selalu sinkron dengan hasil verifikasi di halaman Pembayaran.
        // Halaman ini murni untuk LIHAT & DETAIL, tidak ada ubah status manual.
        private void TampilkanDataPemesanan()
        {
            string query = "SELECT p.id_pemesanan, u.nama_lengkap AS pemesan, k.nama_kereta AS kereta, " +
                           "(SELECT COUNT(*) FROM t_detailpenumpang dp WHERE dp.id_pesanan = p.id_pemesanan) AS jumlah, " +
                           "p.total_harga AS total, p.status " +
                           "FROM t_pemesanan p " +
                           "JOIN t_users u ON p.id_users = u.id_users " +
                           "JOIN t_jadwal j ON p.id_jadwal = j.id_jadwal " +
                           "JOIN t_kereta k ON j.id_kereta = k.id_kereta " +
                           "ORDER BY p.tanggal_pemesanan DESC";

            db.crud(query);
            dgvDPemesanan.Rows.Clear();

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string status = baris["status"].ToString();

                int indexBaris = dgvDPemesanan.Rows.Add(
                    baris["pemesan"],
                    baris["kereta"],
                    baris["jumlah"],
                    "Rp" + Convert.ToInt32(baris["total"]).ToString("N0"),
                    status,
                    "Detail Pesanan"
                );

                DataGridViewRow rowGrid = dgvDPemesanan.Rows[indexBaris];
                rowGrid.Cells["colStatus"].Style.ForeColor = WarnaStatus(status);
                rowGrid.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                // simpan id_pemesanan di Tag baris (dipakai buat buka detail)
                rowGrid.Tag = baris["id_pemesanan"].ToString();
            }

            if (dgvDPemesanan.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada data pemesanan.");
            }
        }

        // ============ KLIK "DETAIL PESANAN" -> BUKA FORM DETAIL (READ-ONLY) ============
        private void dgvDPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDPemesanan.Columns[e.ColumnIndex].Name != "colAksi") return;
            if (dgvDPemesanan.Rows[e.RowIndex].Tag == null) return;

            string idPemesananDipilih = dgvDPemesanan.Rows[e.RowIndex].Tag.ToString();

            FDetailPesanan f = new FDetailPesanan(idPemesananDipilih);
            f.ShowDialog(this);

            // refresh tabel setelah detail ditutup, siapa tau status berubah
            // (misalnya karena admin baru saja verifikasi pembayaran terkait)
            TampilkanDataPemesanan();
        }
    }
}