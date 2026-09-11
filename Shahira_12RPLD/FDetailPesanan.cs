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
    public partial class FDetailPesanan : Form
    {
        private string idPemesanan;

        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_AMBER = Color.FromArgb(133, 79, 11);
        private readonly Color WARNA_MERAH = Color.FromArgb(163, 45, 45);
        private readonly Color WARNA_HIJAU = Color.FromArgb(15, 110, 86);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);

        public FDetailPesanan(string idPemesananTerpilih)
        {
            InitializeComponent();
            idPemesanan = idPemesananTerpilih;

            btnTutup.Click -= btnTutup_Click;
            btnTutup.Click += btnTutup_Click;
        }

        private void FDetailPesanan_Load(object sender, EventArgs e)
        {
            SetupTabel();
            TampilkanInfoPemesanan();
            TampilkanTabelPenumpang();
        }

        // ============ HEADER BIRU TUA + INFO PEMESANAN ============
        private void TampilkanInfoPemesanan()
        {
            panelHeader.BackColor = WARNA_BIRU_TUA;

            string query = "SELECT u.nama_lengkap AS pemesan, k.nama_kereta, kl.nama_kelas, " +
                           "asal.nama_stasiun AS stasiun_asal, tujuan.nama_stasiun AS stasiun_tujuan, " +
                           "j.tanggal, j.jam_berangkat, p.total_harga, p.status " +
                           "FROM t_pemesanan p " +
                           "JOIN t_users u ON p.id_users = u.id_users " +
                           "JOIN t_jadwal j ON p.id_jadwal = j.id_jadwal " +
                           "JOIN t_kereta k ON j.id_kereta = k.id_kereta " +
                           "JOIN t_kelas kl ON j.id_kelas = kl.id_kelas " +
                           "JOIN t_stasiun asal ON j.id_stasiunAsal = asal.id_stasiun " +
                           "JOIN t_stasiun tujuan ON j.id_stasiunTujuan = tujuan.id_stasiun " +
                           "WHERE p.id_pemesanan = '" + idPemesanan + "'";

            db.crud(query);

            if (db.ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data pemesanan tidak ditemukan");
                return;
            }

            DataRow baris = db.ds.Tables[0].Rows[0];

            lblPemesan.Text = baris["pemesan"] + " - " + baris["nama_kereta"] + " (" + baris["nama_kelas"] + ")";
            lblPemesan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPemesan.ForeColor = Color.White;
            lblPemesan.BackColor = Color.Transparent;

            lblRute.Text = baris["stasiun_asal"] + "  ->  " + baris["stasiun_tujuan"];
            lblRute.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblRute.ForeColor = Color.FromArgb(219, 234, 254);
            lblRute.BackColor = Color.Transparent;

            lblTanggal.Text = Convert.ToDateTime(baris["tanggal"]).ToString("dd-MM-yyyy") +
                               "   |   " + baris["jam_berangkat"];
            lblTanggal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTanggal.ForeColor = Color.White;
            lblTanggal.BackColor = Color.Transparent;

            string status = baris["status"].ToString();
            int totalHarga = Convert.ToInt32(baris["total_harga"]);

            lblStatus.Text = "Status Pemesanan: " + TeksStatus(status);
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = WarnaStatus(status);

            lblTotalHarga.Text = "Total Harga: Rp" + totalHarga.ToString("N0");
            lblTotalHarga.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalHarga.ForeColor = WARNA_BIRU;
        }

        private string TeksStatus(string status)
        {
            switch (status)
            {
                case "berhasil": return "Berhasil";
                case "dibatalkan": return "Dibatalkan";
                default: return "Menunggu";
            }
        }

        private Color WarnaStatus(string status)
        {
            switch (status)
            {
                case "berhasil": return WARNA_HIJAU;
                case "dibatalkan": return WARNA_MERAH;
                default: return WARNA_AMBER;
            }
        }

        // ============ STYLING TABEL (samain kayak FDataPemesanan/FPembayaran) ============
        private void SetupTabel()
        {
            dgvDetailPesanan.BorderStyle = BorderStyle.None;
            dgvDetailPesanan.BackgroundColor = Color.White;
            dgvDetailPesanan.RowHeadersVisible = false;
            dgvDetailPesanan.AllowUserToAddRows = false;
            dgvDetailPesanan.ReadOnly = true;
            dgvDetailPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetailPesanan.MultiSelect = false;
            dgvDetailPesanan.RowTemplate.Height = 36;

            dgvDetailPesanan.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvDetailPesanan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDetailPesanan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvDetailPesanan.EnableHeadersVisualStyles = false;

            dgvDetailPesanan.DefaultCellStyle.ForeColor = WARNA_TEKS_GELAP;
            dgvDetailPesanan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
        }

        // ============ ISI TABEL PENUMPANG DARI t_detailpenumpang + t_kursi ============
        private void TampilkanTabelPenumpang()
        {
            string query = "SELECT k.no_kursi, dp.nama_penumpang, dp.NIK " +
                           "FROM t_detailpenumpang dp " +
                           "JOIN t_kursi k ON dp.id_kursi = k.id_kursi " +
                           "WHERE dp.id_pesanan = '" + idPemesanan + "' " +
                           "ORDER BY LENGTH(k.no_kursi), k.no_kursi";

            db.crud(query);
            dgvDetailPesanan.Rows.Clear();

            int no = 1;
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                dgvDetailPesanan.Rows.Add(
                    no,
                    baris["no_kursi"],
                    baris["nama_penumpang"],
                    baris["NIK"]
                );
                no++;
            }

            lblJumlahPenumpang.Text = "Jumlah Penumpang: " + dgvDetailPesanan.Rows.Count;
            lblJumlahPenumpang.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblJumlahPenumpang.ForeColor = WARNA_TEKS_GELAP;
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}