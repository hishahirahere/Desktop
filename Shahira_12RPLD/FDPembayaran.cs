using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FDPembayaran : Form
    {
        private string idPembayaran;
        private string idPemesanan = "";
        private string statusSekarang = "";

        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_HIJAU = Color.FromArgb(15, 110, 86);
        private readonly Color WARNA_MERAH = Color.FromArgb(163, 45, 45);
        private readonly Color WARNA_AMBER = Color.FromArgb(133, 79, 11);

        public FDPembayaran(string idPembayaranTerpilih)
        {
            InitializeComponent();
            idPembayaran = idPembayaranTerpilih;

            btnTerima.Click -= btnTerima_Click;
            btnTerima.Click += btnTerima_Click;

            btnTolak.Click -= btnTolak_Click;
            btnTolak.Click += btnTolak_Click;
        }

        private void FDPembayaran_Load(object sender, EventArgs e)
        {
            panelHeader.BackColor = WARNA_BIRU_TUA;
            SetupTombol();
            TampilkanDetailPembayaran();
        }

        private void SetupTombol()
        {
            btnTerima.Text = "Terima";
            btnTerima.FillColor = WARNA_HIJAU;
            btnTerima.ForeColor = Color.White;
            btnTerima.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTerima.Cursor = Cursors.Hand;
            btnTerima.BorderRadius = 8;

            btnTolak.Text = "Tolak";
            btnTolak.FillColor = WARNA_MERAH;
            btnTolak.ForeColor = Color.White;
            btnTolak.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTolak.Cursor = Cursors.Hand;
            btnTolak.BorderRadius = 8;
        }

        // ============ AMBIL DETAIL PEMBAYARAN + BUKTI TRANSFER ============
        private void TampilkanDetailPembayaran()
        {
            string query = "SELECT tp.id_pemesanan, tp.metode, tp.bukti_bayar, tp.status, " +
                           "u.nama_lengkap AS pemesan, pm.total_harga AS total " +
                           "FROM t_pembayaran tp " +
                           "JOIN t_pemesanan pm ON tp.id_pemesanan = pm.id_pemesanan " +
                           "JOIN t_users u ON pm.id_users = u.id_users " +
                           "WHERE tp.id_pembayaran = '" + idPembayaran + "'";

            db.crud(query);

            if (db.ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Data pembayaran tidak ditemukan");
                return;
            }

            DataRow baris = db.ds.Tables[0].Rows[0];

            idPemesanan = baris["id_pemesanan"].ToString();
            statusSekarang = baris["status"].ToString();
            string namaFileBukti = baris["bukti_bayar"].ToString();
            int total = Convert.ToInt32(baris["total"]);

            lblPemesanDetail.Text = "Pemesan: " + baris["pemesan"];
            lblTotalDetail.Text = "Total: Rp" + total.ToString("N0");
            lblMetodeDetail.Text = "Metode: " + baris["metode"];

            string pathBukti = Path.Combine(Application.StartupPath, "BuktiBayar", namaFileBukti);
            if (File.Exists(pathBukti))
            {
                picBukti.SizeMode = PictureBoxSizeMode.Zoom;
                picBukti.Image = Image.FromFile(pathBukti);
            }

            // Kalau statusnya udah gak "menunggu", tombol Terima/Tolak gak perlu aktif lagi
            bool masihMenunggu = statusSekarang == "menunggu";
            btnTerima.Enabled = masihMenunggu;
            btnTolak.Enabled = masihMenunggu;
        }

        // ============ TOMBOL TERIMA: UPDATE STATUS PEMBAYARAN + PEMESANAN JADI 'berhasil' ============
        private void btnTerima_Click(object sender, EventArgs e)
        {
            DialogResult ya = MessageBox.Show(
                "Terima bukti pembayaran ini? Pemesanan akan berstatus 'berhasil'.",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ya != DialogResult.Yes) return;

            db.crud("UPDATE t_pembayaran SET status = 'berhasil' WHERE id_pembayaran = '" + idPembayaran + "'");
            db.crud("UPDATE t_pemesanan SET status = 'berhasil' WHERE id_pemesanan = '" + idPemesanan + "'");

            MessageBox.Show("Pembayaran diterima.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // ============ TOMBOL TOLAK: UPDATE STATUS PEMBAYARAN JADI 'menolak' ============
        private void btnTolak_Click(object sender, EventArgs e)
        {
            DialogResult ya = MessageBox.Show(
                "Tolak bukti pembayaran ini? User perlu mengunggah ulang bukti transfer.",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ya != DialogResult.Yes) return;

            db.crud("UPDATE t_pembayaran SET status = 'menolak' WHERE id_pembayaran = '" + idPembayaran + "'");

            MessageBox.Show("Pembayaran ditolak.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}