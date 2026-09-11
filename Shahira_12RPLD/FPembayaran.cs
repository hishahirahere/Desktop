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
    public partial class FPembayaran : Form
    {
        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(219, 234, 254);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);
        private readonly Color WARNA_AMBER = Color.FromArgb(133, 79, 11);
        private readonly Color WARNA_MERAH = Color.FromArgb(163, 45, 45);
        private readonly Color WARNA_HIJAU = Color.FromArgb(15, 110, 86);

        // ============ STATE PEMESANAN & BUKTI YANG SEDANG DIPILIH ============
        private string idPemesananTerpilih = "";
        private string statusBayarTerpilih = ""; // "", "belum", "menunggu", "menolak"
        private string pathBuktiTerpilih = "";

        public FPembayaran()
        {
            InitializeComponent();
            dgvPembayaran.CellClick += dgvPembayaran_CellClick;
            btnPilihBukti.Click += btnPilihBukti_Click;
            cmbMetode.SelectedIndexChanged += (s, e) => CekTombolBayar();

            // Jaga-jaga kalau event Click belum tersambung lewat Form Designer.
            // Kalau di Designer.cs SUDAH ada baris "this.btnBayar.Click += ...",
            // HAPUS baris di bawah ini supaya tidak terpanggil dua kali.
            btnBayar.Click -= btnBayar_Click;
            btnBayar.Click += btnBayar_Click;
        }

        private void FPembayaran_Load(object sender, EventArgs e)
        {
            panelHeader.BackColor = WARNA_BIRU_TUA;
            SetupTabel();
            SetupComboMetode();
            TampilkanDaftarPemesanan();
            SetupTombol();
            ResetPanelBukti();
        }

        // ============ ISI COMBOBOX METODE PEMBAYARAN SESUAI ENUM DI DATABASE ============
        private void SetupComboMetode()
        {
            cmbMetode.Items.Clear();
            cmbMetode.Items.Add("transfer bank");
            cmbMetode.Items.Add("QRIS");
            cmbMetode.Items.Add("e-wallet");
            cmbMetode.SelectedIndex = 0;
            cmbMetode.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // ============ AMBIL PEMESANAN STATUS 'menunggu' MILIK USER LOGIN, + CEK STATUS PEMBAYARAN TERAKHIR ============
        private void TampilkanDaftarPemesanan()
        {
            string idUserLogin = db.idUserLogin;

            string query = "SELECT t_pemesanan.id_pemesanan, t_kereta.nama_kereta, " +
                           "asal.nama_stasiun AS stasiun_asal, tujuan.nama_stasiun AS stasiun_tujuan, " +
                           "t_jadwal.tanggal, t_jadwal.jam_berangkat, t_pemesanan.total_harga, " +
                           "(SELECT tp.status FROM t_pembayaran tp WHERE tp.id_pemesanan = t_pemesanan.id_pemesanan " +
                           " ORDER BY tp.id_pembayaran DESC LIMIT 1) AS status_bayar " +
                           "FROM t_pemesanan " +
                           "JOIN t_jadwal ON t_pemesanan.id_jadwal = t_jadwal.id_jadwal " +
                           "JOIN t_kereta ON t_jadwal.id_kereta = t_kereta.id_kereta " +
                           "JOIN t_stasiun asal ON t_jadwal.id_stasiunAsal = asal.id_stasiun " +
                           "JOIN t_stasiun tujuan ON t_jadwal.id_stasiunTujuan = tujuan.id_stasiun " +
                           "WHERE t_pemesanan.id_users = '" + idUserLogin + "' " +
                           "AND t_pemesanan.status = 'menunggu' " +
                           "ORDER BY t_pemesanan.tanggal_pemesanan DESC";

            db.crud(query);
            dgvPembayaran.Rows.Clear();

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string idPemesanan = baris["id_pemesanan"].ToString();
                string totalHarga = baris["total_harga"].ToString();
                string statusBayar = baris["status_bayar"] == DBNull.Value ? "belum" : baris["status_bayar"].ToString();

                int indexBaris = dgvPembayaran.Rows.Add(
                    baris["nama_kereta"],
                    baris["stasiun_asal"] + " -> " + baris["stasiun_tujuan"],
                    Convert.ToDateTime(baris["tanggal"]).ToString("dd-MM-yyyy"),
                    baris["jam_berangkat"],
                    "Rp" + Convert.ToInt32(totalHarga).ToString("N0"),
                    TeksStatusBayar(statusBayar)
                );

                DataGridViewRow rowGrid = dgvPembayaran.Rows[indexBaris];
                rowGrid.Tag = idPemesanan + "|" + totalHarga + "|" + statusBayar;
                rowGrid.Cells["colStatusBayar"].Style.ForeColor = WarnaStatusBayar(statusBayar);
                rowGrid.Cells["colStatusBayar"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            ResetPanelBukti();

            if (dgvPembayaran.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada pemesanan yang menunggu pembayaran.");
            }
        }

        private string TeksStatusBayar(string status)
        {
            switch (status)
            {
                case "menunggu": return "Menunggu verifikasi";
                case "menolak": return "Ditolak, kirim ulang";
                default: return "Belum bayar";
            }
        }

        private Color WarnaStatusBayar(string status)
        {
            switch (status)
            {
                case "menunggu": return WARNA_AMBER;
                case "menolak": return WARNA_MERAH;
                default: return WARNA_TEKS_GELAP;
            }
        }

        // ============ STYLING TABEL ============
        private void SetupTabel()
        {
            dgvPembayaran.BorderStyle = BorderStyle.None;
            dgvPembayaran.BackgroundColor = Color.White;
            dgvPembayaran.RowHeadersVisible = false;
            dgvPembayaran.AllowUserToAddRows = false;
            dgvPembayaran.ReadOnly = true;
            dgvPembayaran.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPembayaran.MultiSelect = false;
            dgvPembayaran.RowTemplate.Height = 36;

            dgvPembayaran.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvPembayaran.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPembayaran.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPembayaran.EnableHeadersVisualStyles = false;

            dgvPembayaran.DefaultCellStyle.ForeColor = WARNA_TEKS_GELAP;
            dgvPembayaran.DefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvPembayaran.DefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
            dgvPembayaran.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvPembayaran.AlternatingRowsDefaultCellStyle.SelectionBackColor = WARNA_BIRU_MUDA;
            dgvPembayaran.AlternatingRowsDefaultCellStyle.SelectionForeColor = WARNA_TEKS_GELAP;
        }

        private void SetupTombol()
        {
            btnPilihBukti.Text = "Pilih Bukti Transfer";
        }

        // ============ SAAT BARIS DIKLIK: TAMPILKAN TOTAL & STATUS, ATUR TOMBOL SESUAI KONDISI ============
        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPembayaran.Rows[e.RowIndex].Tag == null) return;

            string[] data = dgvPembayaran.Rows[e.RowIndex].Tag.ToString().Split('|');
            idPemesananTerpilih = data[0];
            int totalHarga = Convert.ToInt32(data[1]);
            statusBayarTerpilih = data[2];

            lblTotalBayar.Text = "Total yang harus dibayar: Rp" + totalHarga.ToString("N0");
            lblTotalBayar.ForeColor = WARNA_BIRU_TUA;
            lblTotalBayar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            pathBuktiTerpilih = "";
            picBukti.Image = null;
            lblNamaFile.Text = "";

            if (statusBayarTerpilih == "menunggu")
            {
                lblStatusBayar.Text = "Bukti sudah dikirim. Menunggu verifikasi admin, mohon ditunggu.";
                lblStatusBayar.ForeColor = WARNA_AMBER;
                btnPilihBukti.Enabled = false;
            }
            else if (statusBayarTerpilih == "menolak")
            {
                lblStatusBayar.Text = "Bukti sebelumnya ditolak admin. Silakan unggah ulang bukti pembayaran.";
                lblStatusBayar.ForeColor = WARNA_MERAH;
                btnPilihBukti.Enabled = true;
            }
            else
            {
                lblStatusBayar.Text = "Pilih metode, lalu unggah bukti transfer untuk melanjutkan.";
                lblStatusBayar.ForeColor = WARNA_TEKS_GELAP;
                btnPilihBukti.Enabled = true;
            }

            CekTombolBayar();
        }

        // ============ PILIH GAMBAR BUKTI TRANSFER (LANGSUNG DI-PREVIEW) ============
        private void btnPilihBukti_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idPemesananTerpilih))
            {
                MessageBox.Show("Pilih pemesanan yang mau dibayar dulu.");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Gambar (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Pilih Bukti Transfer";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pathBuktiTerpilih = ofd.FileName;

                    picBukti.SizeMode = PictureBoxSizeMode.Zoom;
                    picBukti.Image = Image.FromFile(pathBuktiTerpilih);

                    lblNamaFile.Text = "File dipilih: " + Path.GetFileName(pathBuktiTerpilih);
                    lblNamaFile.ForeColor = WARNA_HIJAU;

                    lblStatusBayar.Text = "Bukti siap dikirim. Cek dulu gambarnya sebelum klik kirim.";
                    lblStatusBayar.ForeColor = WARNA_HIJAU;

                    CekTombolBayar();
                }
            }
        }

        // ============ AKTIFKAN TOMBOL BAYAR HANYA KALAU SEMUA SYARAT TERPENUHI ============
        private void CekTombolBayar()
        {
            bool pesananDipilih = !string.IsNullOrEmpty(idPemesananTerpilih);
            bool metodeDipilih = cmbMetode.SelectedItem != null;
            bool buktiDipilih = !string.IsNullOrEmpty(pathBuktiTerpilih);
            bool belumMenunggu = statusBayarTerpilih != "menunggu";

            btnBayar.Enabled = pesananDipilih && metodeDipilih && buktiDipilih && belumMenunggu;
        }

        private void ResetPanelBukti()
        {
            idPemesananTerpilih = "";
            statusBayarTerpilih = "";
            pathBuktiTerpilih = "";
            picBukti.Image = null;
            lblNamaFile.Text = "";
            lblTotalBayar.Text = "";
            lblStatusBayar.Text = "Pilih salah satu pemesanan di tabel bawah untuk mulai membayar.";
            lblStatusBayar.ForeColor = WARNA_TEKS_GELAP;
            btnPilihBukti.Enabled = false;
            btnBayar.Enabled = false;
        }

        // ============ TOMBOL KIRIM: SIMPAN FILE BUKTI + INSERT KE t_pembayaran STATUS 'menunggu' ============
        // Catatan: status t_pemesanan TIDAK diubah di sini. Itu tugas admin setelah verifikasi bukti.
        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idPemesananTerpilih))
            {
                MessageBox.Show("Pilih pemesanan yang mau dibayar dulu.");
                return;
            }
            if (cmbMetode.SelectedItem == null)
            {
                MessageBox.Show("Pilih metode pembayaran dulu.");
                return;
            }
            if (string.IsNullOrEmpty(pathBuktiTerpilih))
            {
                MessageBox.Show("Unggah bukti transfer dulu.");
                return;
            }

            string metode = cmbMetode.SelectedItem.ToString();

            DialogResult ya = MessageBox.Show(
                "Kirim bukti pembayaran via " + metode + "?\n" +
                "Setelah dikirim, pemesanan akan berstatus 'menunggu verifikasi admin'.",
                "Konfirmasi Pengiriman Bukti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ya != DialogResult.Yes) return;

            try
            {
                string folderBukti = Path.Combine(Application.StartupPath, "BuktiBayar");
                if (!Directory.Exists(folderBukti)) Directory.CreateDirectory(folderBukti);

                string namaFileBaru = idPemesananTerpilih + "_" + DateTime.Now.Ticks + Path.GetExtension(pathBuktiTerpilih);
                string tujuanFile = Path.Combine(folderBukti, namaFileBaru);
                File.Copy(pathBuktiTerpilih, tujuanFile, true);

                string tanggalBayar = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                db.crud("INSERT INTO t_pembayaran VALUES(null, '" + idPemesananTerpilih + "', " +
                         "'" + metode + "', '" + tanggalBayar + "', '" + namaFileBaru + "', 'menunggu')");

                MessageBox.Show(
                    "Bukti pembayaran berhasil dikirim.\nMohon tunggu verifikasi dari admin.",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TampilkanDaftarPemesanan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengirim bukti pembayaran: " + ex.Message,
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}