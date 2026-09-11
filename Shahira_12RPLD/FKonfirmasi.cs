using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Shahira_12RPLD
{
    public partial class FKonfirmasi : Form
    {
        private string idJadwal;
        private List<string> dataPenumpang; // format tiap item: "id_kursi|no_kursi|nama|nik"
        private int totalHarga;
        public FKonfirmasi(string idJadwalTerpilih, List<string> dataPenumpangnya, int total)
        {
            InitializeComponent();
            idJadwal = idJadwalTerpilih;
            dataPenumpang = dataPenumpangnya;
            totalHarga = total;
        }

        private void FKonfirmasi_Load(object sender, EventArgs e)
        {
            TampilkanInfoJadwal();
            TampilkanTabelPenumpang();
        }

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

            lblKereta.Text = "Kereta : " + baris["nama_kereta"];
            lblRute.Text = "Rute : " + baris["stasiun_asal"] + " -> " + baris["stasiun_tujuan"];
            lblTanggal.Text = "Tanggal : " + Convert.ToDateTime(baris["tanggal"]).ToString("dd-MM-yyyy");
            lblJam.Text = "Jam : " + baris["jam_berangkat"] + " - " + baris["jam_tiba"];
            lblKelas.Text = "Kelas : " + baris["nama_kelas"];
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
            // PERBAIKAN: format yang benar adalah "N0" (huruf N + angka NOL), bukan "NO"
            lblTotalHarga.Text = "Total Harga : Rp" + totalHarga.ToString("N0");
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            DialogResult ya = MessageBox.Show(
                 "Pastikan data penumpang sudah benar. Lanjutkan pemesanan?",
                 "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ya != DialogResult.Yes) return;
            string idUserLogin = db.idUserLogin; // ganti sesuai cara kamu simpan sesi login
            string tanggalPesan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            // 1. Insert ke t_pemesanan, status awal "menunggu" (menunggu pembayaran)
            db.crud("INSERT INTO t_pemesanan VALUES(null, '" + idUserLogin + "', '" + idJadwal + "', " +
                     "'" + tanggalPesan + "', '" + totalHarga + "', 'menunggu')");
            // 2. Ambil id_pemesanan yang baru dibuat
            db.crud("SELECT LAST_INSERT_ID() as id");
            string idPemesananBaru = db.ds.Tables[0].Rows[0]["id"].ToString();

            // 3. Insert tiap penumpang ke t_detailpenumpang + update status kursi jadi terisi
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

            // 4. Kurangi sisa_kursi di t_jadwal sesuai jumlah kursi yang dipesan
            int jumlahKursi = dataPenumpang.Count;
            db.crud("UPDATE t_jadwal SET sisa_kursi = sisa_kursi - " + jumlahKursi +
                     " WHERE id_jadwal = '" + idJadwal + "'");

            MessageBox.Show("Pemesanan berhasil dibuat. Silakan lanjutkan pembayaran.",
                             "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Lanjut ke form Pembayaran, bawa id_pemesanan + total harga yang harus dibayar
            // FPembayaran f = new FPembayaran(idPemesananBaru, totalHarga);
            //f.Show();
            this.Hide();
        }
    }
}
