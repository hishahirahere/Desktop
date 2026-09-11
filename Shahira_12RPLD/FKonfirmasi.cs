using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FKonfirmasi : Form
    {
        private string idJadwal;
        private List<string> dataPenumpang; // format tiap item: "id_kursi|no_kursi|nama|nik"
        private int totalHarga;

        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);

        public FKonfirmasi(string idJadwalTerpilih, List<string> dataPenumpangnya, int total)
        {
            InitializeComponent();
            idJadwal = idJadwalTerpilih;
            dataPenumpang = dataPenumpangnya;
            totalHarga = total;
        }

        private void FKonfirmasi_Load(object sender, EventArgs e)
        {
            SetupHeader();
            TampilkanInfoJadwal();
            SetupTabel();
            TampilkanTabelPenumpang();
            SetupTombol();
        }

        // ============ HEADER BIRU SOLID (JUDUL + INFO JADWAL JADI SATU) ============
        private void SetupHeader()
        {
            panelHeader.BackColor = WARNA_BIRU_TUA;

        }

        // ============ AMBIL & TAMPILKAN INFO JADWAL (DI DALAM PANEL BIRU) ============
        private void TampilkanInfoJadwal()
        {
            string query = "SELECT t_kereta.nama_kereta, " +
                           "asal.nama_stasiun AS stasiun_asal, " +
                           "tujuan.nama_stasiun AS stasiun_tujuan, " +
                           "t_jadwal.tanggal, t_jadwal.jam_berangkat, t_jadwal.jam_tiba, " +
                           "t_kelas.nama_kelas " +
                           "FROM t_jadwal " +
                           "JOIN t_kereta ON t_jadwal.id_kereta = t_kereta.id_kereta " +
                           "JOIN t_stasiun asal ON t_jadwal.id_stasiunAsal = asal.id_stasiun " +
                           "JOIN t_stasiun tujuan ON t_jadwal.id_stasiunTujuan = tujuan.id_stasiun " +
                           "JOIN t_kelas ON t_jadwal.id_kelas = t_kelas.id_kelas " +
                           "WHERE t_jadwal.id_jadwal = '" + idJadwal + "'";

            db.crud(query);

            if (db.ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data jadwal tidak ditemukan");
                return;
            }

            DataRow baris = db.ds.Tables[0].Rows[0];

            // Semua label info ditaruh DI DALAM panelHeader yang sama (biru solid),
            // teks putih semua, mengikuti gaya FPilihKursi
            lblKereta.Text = baris["nama_kereta"] + " (" + baris["nama_kelas"] + ")";
            lblRute.Text = baris["stasiun_asal"] + "  ->  " + baris["stasiun_tujuan"];
            lblTanggal.Text = Convert.ToDateTime(baris["tanggal"]).ToString("dd-MM-yyyy") +
                               "   |   " + baris["jam_berangkat"] + " - " + baris["jam_tiba"];

            lblKereta.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblKereta.ForeColor = Color.White;
            lblKereta.BackColor = WARNA_BIRU_TUA;

            lblRute.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblRute.ForeColor = Color.FromArgb(219, 234, 254);
            lblRute.BackColor = WARNA_BIRU_TUA;

            lblTanggal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTanggal.ForeColor = Color.White;
            lblTanggal.BackColor = WARNA_BIRU_TUA;

            // lblJam dan lblKelas tidak dipakai lagi (info sudah digabung ke lblTanggal)
            lblJam.Visible = false;
            lblKelas.Visible = false;
        }

        // ============ STYLING TABEL PENUMPANG ============
        private void SetupTabel()
        {
            dgvKonfirmasi.BorderStyle = BorderStyle.None;
            dgvKonfirmasi.BackgroundColor = Color.White;
            dgvKonfirmasi.RowHeadersVisible = false;
            dgvKonfirmasi.AllowUserToAddRows = false;
            dgvKonfirmasi.ReadOnly = true;
            dgvKonfirmasi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKonfirmasi.GridColor = Color.FromArgb(229, 231, 235);
            dgvKonfirmasi.RowTemplate.Height = 36;

            dgvKonfirmasi.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvKonfirmasi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKonfirmasi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvKonfirmasi.ColumnHeadersHeight = 38;
            dgvKonfirmasi.EnableHeadersVisualStyles = false;

            dgvKonfirmasi.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvKonfirmasi.DefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvKonfirmasi.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvKonfirmasi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
        }

        private void TampilkanTabelPenumpang()
        {
            dgvKonfirmasi.Rows.Clear();
            foreach (string data in dataPenumpang)
            {
                // format: id_kursi|no_kursi|nama|nik
                string[] bagian = data.Split('|');
                string noKursi = bagian[1];
                string nama = bagian[2];
                string nik = bagian[3];
                dgvKonfirmasi.Rows.Add(noKursi, nama, nik);
            }

            int jumlahKursi = dataPenumpang.Count;

            lblJumKursi.Text = "Jumlah Kursi : " + jumlahKursi;
            lblJumKursi.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblJumKursi.ForeColor = Color.FromArgb(75, 85, 99);

            lblTotalHarga.Text = "Total Harga : Rp" + totalHarga.ToString("N0");
            lblTotalHarga.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalHarga.ForeColor = WARNA_BIRU;
        }

        // ============ STYLING TOMBOL KONFIRMASI (Guna2Button) ============
        private void SetupTombol()
        {
            btnKonfirmasi.Text = "Konfirmasi dan Pesan";
            btnKonfirmasi.FillColor = WARNA_BIRU_TUA;
            btnKonfirmasi.ForeColor = Color.White;
            btnKonfirmasi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKonfirmasi.Cursor = Cursors.Hand;
            btnKonfirmasi.Height = 45;
            btnKonfirmasi.BorderRadius = 20;
        }

        // ============ TOMBOL KONFIRMASI & PESAN ============
        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            DialogResult ya = MessageBox.Show(
                 "Pastikan data penumpang sudah benar. Lanjutkan pemesanan?",
                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ya != DialogResult.Yes) return;

            string idUserLogin = db.idUserLogin;
            string tanggalPesan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            db.crud("INSERT INTO t_pemesanan VALUES(null, '" + idUserLogin + "', '" + idJadwal + "', " +
                     "'" + tanggalPesan + "', '" + totalHarga + "', 'menunggu')");

            db.crud("SELECT LAST_INSERT_ID() as id");
            string idPemesananBaru = db.ds.Tables[0].Rows[0]["id"].ToString();

            foreach (string data in dataPenumpang)
            {
                string[] bagian = data.Split('|');
                string idKursi = bagian[0];
                string nama = bagian[2];
                string nik = bagian[3];

                db.crud("INSERT INTO t_detailpenumpang VALUES(null, '" + idPemesananBaru + "', " +
                         "'" + idKursi + "', '" + nama + "', '" + nik + "')");

                db.crud("UPDATE t_kursi SET status = 'terisi' WHERE id_kursi = '" + idKursi + "'");
            }

            int jumlahKursi = dataPenumpang.Count;
            db.crud("UPDATE t_jadwal SET sisa_kursi = sisa_kursi - " + jumlahKursi +
                     " WHERE id_jadwal = '" + idJadwal + "'");

            MessageBox.Show("Pemesanan berhasil dibuat. Silakan lanjutkan pembayaran.",
                             "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FPembayaran f = new FPembayaran();
            f.Show();
            this.Close();
        }
    }
}