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
    public partial class FPilihKursi : Form
    {
        private string idJadwal;
        private List<string> kursiTerpilih = new List<string>();

        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_ABU = Color.FromArgb(229, 231, 235);
        private readonly Color WARNA_ABU_TEKS = Color.FromArgb(156, 163, 175);
        public FPilihKursi(string idJadwalTerpilih)
        {
            InitializeComponent();
            idJadwal = idJadwalTerpilih;
        }

        private void btnLanjut_Click(object sender, EventArgs e)
        {
            kursiTerpilih.Clear();

            foreach (Control kontrol in flowLayoutPanel1.Controls)
            {
                if (kontrol is Button btn && btn.BackColor.ToArgb() == WARNA_BIRU.ToArgb())
                {
                    // simpan gabungan id_kursi dan no_kursi, dipisah tanda |
                    kursiTerpilih.Add(btn.Tag.ToString() + "|" + btn.Text);
                }
            }

            if (kursiTerpilih.Count == 0)
            {
                MessageBox.Show("Pilih minimal 1 kursi terlebih dahulu");
                return;
            }

            // Buka form berikutnya (Data Penumpang), kirim id_jadwal + daftar kursi terpilih
            FPenumpang f = new FPenumpang(idJadwal, kursiTerpilih);
            f.Show();
            this.Hide();
        }

        private void FPilihKursi_Load(object sender, EventArgs e)
        {
            TampilkanInfoJadwal();
            TampilkanKursi();
        }
        private void TampilkanInfoJadwal()
        {
            string query = "SELECT t_kereta.nama_kereta, t_kereta.kapasitas, " +
                           "asal.nama_stasiun AS stasiun_asal, " +
                           "tujuan.nama_stasiun AS stasiun_tujuan, " +
                           "t_jadwal.tanggal, t_jadwal.jam_berangkat, t_jadwal.jam_tiba, " +
                           "t_kelas.nama_kelas, t_jadwal.harga, t_jadwal.sisa_kursi " +
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
                lblInfoJadwal.Text = "";
                return;
            }

            DataRow baris = db.ds.Tables[0].Rows[0];

            string namaKereta = baris["nama_kereta"].ToString();
            string kapasitas = baris["kapasitas"].ToString();
            string stasiunAsal = baris["stasiun_asal"].ToString();
            string stasiunTujuan = baris["stasiun_tujuan"].ToString();
            string tanggal = Convert.ToDateTime(baris["tanggal"]).ToString("dd-MM-yyyy");
            string jamBerangkat = baris["jam_berangkat"].ToString();
            string jamTiba = baris["jam_tiba"].ToString();
            string kelas = baris["nama_kelas"].ToString();
            string harga = baris["harga"].ToString();
            string sisaKursi = baris["sisa_kursi"].ToString();

            lblInfoJadwal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInfoJadwal.ForeColor = Color.FromArgb(31, 41, 55);
            lblInfoJadwal.Text = namaKereta + " (" + kelas + ")\n" +
                                 stasiunAsal + " -> " + stasiunTujuan + "\n" +
                                 tanggal + " | " + jamBerangkat + " - " + jamTiba + "\n" +
                                 "Harga: Rp" + harga + " | Kapasitas: " + kapasitas +
                                 " | Sisa: " + sisaKursi;
    }

        private void TampilkanKursi()
        {
            db.crud("SELECT * FROM t_kursi WHERE id_jadwal = '" + idJadwal + "' ORDER BY LENGTH(no_kursi), no_kursi");

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.BackColor = Color.White;

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string status = baris["status"].ToString();

                Button btn = new Button(); 
                btn.Text = baris["no_kursi"].ToString();
                btn.Tag = baris["id_kursi"].ToString(); // simpan id_kursi untuk dipakai nanti
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Width = 55;
                btn.Height = 55;
                btn.Margin = new Padding(5);
                btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;

                BuatSudutMembulat(btn, 10); // sudut membulat

                if(status == "terisi")
                {
                    // Kursi sudah terisi: abu-abu, tidak bisa diklik
                    btn.Enabled = false;
                    btn.BackColor = WARNA_ABU;
                    btn.ForeColor = WARNA_ABU_TEKS;
                }
                else
                {
                    // Kursi kosong: putih dengan garis biru, bisa diklik untuk toggle pilih
                    btn.BackColor = Color.White;
                    btn.ForeColor = WARNA_BIRU;
                    btn.FlatAppearance.BorderSize = 2;
                    btn.FlatAppearance.BorderColor = WARNA_BIRU;
                    btn.Click += (s, e) => ToggleKursi((Button)s);
                }

                flowLayoutPanel1.Controls.Add(btn);
            }

            if (flowLayoutPanel1.Controls.Count == 0)
            {
                MessageBox.Show("Data kursi untuk jadwal ini belum tersedia.\n" +
                                 "Pastikan admin sudah membuat jadwal ini dengan benar " +
                                 "(kursi otomatis dibuat sesuai kapasitas kereta saat jadwal disimpan).");
            }
        }
        private void ToggleKursi(Button btn)
        {
            bool sedangDipilih = btn.BackColor.ToArgb() == WARNA_BIRU.ToArgb();

            if (sedangDipilih)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = WARNA_BIRU;
                btn.FlatAppearance.BorderSize = 2;
            }
            else
            {
                btn.BackColor = WARNA_BIRU;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
            }

            PerbaruiTeksTombolLanjut();
        }
        private void PerbaruiTeksTombolLanjut()
        {
            int jumlahDipilih = 0;
            foreach (Control kontrol in flowLayoutPanel1.Controls)
            {
                if (kontrol is Button btn && btn.BackColor.ToArgb() == WARNA_BIRU.ToArgb())
                {
                    jumlahDipilih++;
                }
            }

            btnLanjut.Text = jumlahDipilih == 0
                ? "Lanjut ke Data Penumpang"
                : "Lanjut ke Data Penumpang (" + jumlahDipilih + " kursi)";
        }
        private void BuatSudutMembulat(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(0, 0, d, d, 180, 90);
            path.AddArc(btn.Width - d, 0, d, d, 270, 90);
            path.AddArc(btn.Width - d, btn.Height - d, d, d, 0, 90);
            path.AddArc(0, btn.Height - d, d, d, 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);
        }
    }
}