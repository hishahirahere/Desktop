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
    public partial class FTPembayaran : Form
    {
        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);
        private readonly Color WARNA_AMBER = Color.FromArgb(133, 79, 11);
        private readonly Color WARNA_MERAH = Color.FromArgb(163, 45, 45);
        private readonly Color WARNA_HIJAU = Color.FromArgb(15, 110, 86);

        public FTPembayaran()
        {
            InitializeComponent();
            dgvVerifikasi.CellClick += dgvVerifikasi_CellClick;
        }

        private void FTPembayaran_Load(object sender, EventArgs e)
        {
            SetupTabel();
            SetupKolomAksi();
            TampilkanDaftarPembayaran();
        }

        private void SetupTabel()
        {
            dgvVerifikasi.BorderStyle = BorderStyle.None;
            dgvVerifikasi.BackgroundColor = Color.White;
            dgvVerifikasi.RowHeadersVisible = false;
            dgvVerifikasi.AllowUserToAddRows = false;
            dgvVerifikasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVerifikasi.MultiSelect = false;
            dgvVerifikasi.RowTemplate.Height = 36;

            dgvVerifikasi.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvVerifikasi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVerifikasi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvVerifikasi.EnableHeadersVisualStyles = false;

            dgvVerifikasi.DefaultCellStyle.ForeColor = WARNA_TEKS_GELAP;
            dgvVerifikasi.DefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvVerifikasi.DefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
            dgvVerifikasi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvVerifikasi.AlternatingRowsDefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvVerifikasi.AlternatingRowsDefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
        }

        private void SetupKolomAksi()
        {
            if (dgvVerifikasi.Columns["colAksi"] is DataGridViewButtonColumn kolomAksi)
            {
                kolomAksi.Text = "Cek Bukti";
                kolomAksi.UseColumnTextForButtonValue = true;
            }
        }

        private string TeksStatus(string status)
        {
            switch (status)
            {
                case "berhasil": return "Diterima";
                case "menolak": return "Ditolak";
                default: return "Menunggu";
            }
        }

        private Color WarnaStatus(string status)
        {
            switch (status)
            {
                case "berhasil": return WARNA_HIJAU;
                case "menolak": return WARNA_MERAH;
                default: return WARNA_AMBER;
            }
        }

        // ============ AMBIL SEMUA BUKTI PEMBAYARAN YANG MASUK, DIPANGGIL ULANG SETELAH BALIK DARI DETAIL ============
        public void TampilkanDaftarPembayaran()
        {
            string query = "SELECT tp.id_pembayaran, u.nama_lengkap AS pemesan, " +
                           "k.nama_kereta AS kereta, pm.total_harga AS total, tp.metode, tp.status " +
                           "FROM t_pembayaran tp " +
                           "JOIN t_pemesanan pm ON tp.id_pemesanan = pm.id_pemesanan " +
                           "JOIN t_users u ON pm.id_users = u.id_users " +
                           "JOIN t_jadwal j ON pm.id_jadwal = j.id_jadwal " +
                           "JOIN t_kereta k ON j.id_kereta = k.id_kereta " +
                           "ORDER BY tp.tanggal_bayar DESC";

            db.crud(query);
            dgvVerifikasi.Rows.Clear();

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string status = baris["status"].ToString();

                int indexBaris = dgvVerifikasi.Rows.Add(
                    baris["pemesan"],
                    baris["kereta"],
                    "Rp" + Convert.ToInt32(baris["total"]).ToString("N0"),
                    baris["metode"],
                    TeksStatus(status),
                    "Cek Bukti"
                );

                DataGridViewRow rowGrid = dgvVerifikasi.Rows[indexBaris];
                rowGrid.Cells["colStatus"].Style.ForeColor = WarnaStatus(status);
                rowGrid.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                // simpan id_pembayaran doang, sisanya biar FDPembayaran yang query ulang
                rowGrid.Tag = baris["id_pembayaran"].ToString();
            }

            if (dgvVerifikasi.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada pembayaran yang masuk.");
            }
        }

        // ============ KLIK "CEK BUKTI" -> BUKA FORM DETAIL ============
        private void dgvVerifikasi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvVerifikasi.Columns[e.ColumnIndex].Name != "colAksi") return;
            if (dgvVerifikasi.Rows[e.RowIndex].Tag == null) return;

            string idPembayaranDipilih = dgvVerifikasi.Rows[e.RowIndex].Tag.ToString();

            FDPembayaran f = new FDPembayaran(idPembayaranDipilih);
            f.ShowDialog(this);

            // refresh tabel abis form detail ditutup, siapa tau statusnya berubah
            TampilkanDaftarPembayaran();
        }
    }
}