using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FLaporan : Form
    {
        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_ABU_MUDA = Color.FromArgb(249, 250, 251);
        private readonly Color WARNA_HIJAU = Color.FromArgb(21, 128, 61);
        private readonly Color WARNA_KUNING = Color.FromArgb(161, 98, 7);
        private readonly Color WARNA_MERAH = Color.FromArgb(185, 28, 28);

        // ============ DATA UNTUK KEPERLUAN CETAK ============
        private class BarisLaporan
        {
            public string TanggalPesan, Pemesan, Kereta, Rute, TanggalBerangkat, Status;
            public int JumlahKursi, TotalHarga;
        }
        private List<BarisLaporan> daftarLaporan = new List<BarisLaporan>();
        private int indexCetak = 0;

        private PrintDocument printDoc = new PrintDocument();

        public FLaporan()
        {
            InitializeComponent();
        }

        // ============ SETUP FILTER TANGGAL & STATUS ============
        private void SetupFilter()
        {
            dtDari.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtSampai.Value = DateTime.Now;

            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList; // pastikan selalu ada item terpilih
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Semua Status");
            cmbStatus.Items.Add("menunggu");
            cmbStatus.Items.Add("berhasil");
            cmbStatus.Items.Add("dibatalkan");
            cmbStatus.SelectedIndex = 0;
        }

        // Ambil status yang dipilih dengan aman, tidak akan pernah crash
        private string AmbilStatusFilter()
        {
            // Pengaman: kalau ComboBox ternyata masih kosong (belum ke-setup),
            // isi dulu di sini juga supaya tidak error saat set SelectedIndex
            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbStatus.Items.Add("Semua Status");
                cmbStatus.Items.Add("menunggu");
                cmbStatus.Items.Add("berhasil");
                cmbStatus.Items.Add("dibatalkan");
            }

            if (cmbStatus.SelectedItem == null)
            {
                cmbStatus.SelectedIndex = 0;
            }

            return cmbStatus.SelectedItem != null ? cmbStatus.SelectedItem.ToString() : "Semua Status";
        }

        // ============ STYLING TABEL LAPORAN ============
        private void SetupTabel()
        {
            dgvLaporan.BorderStyle = BorderStyle.None;
            dgvLaporan.BackgroundColor = Color.White;
            dgvLaporan.RowHeadersVisible = false;
            dgvLaporan.AllowUserToAddRows = false;
            dgvLaporan.ReadOnly = true;
            dgvLaporan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLaporan.GridColor = Color.FromArgb(229, 231, 235);
            dgvLaporan.RowTemplate.Height = 34;

            dgvLaporan.ColumnHeadersDefaultCellStyle.BackColor = WARNA_BIRU;
            dgvLaporan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLaporan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvLaporan.ColumnHeadersHeight = 38;
            dgvLaporan.EnableHeadersVisualStyles = false;

            dgvLaporan.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvLaporan.AlternatingRowsDefaultCellStyle.BackColor = WARNA_ABU_MUDA;
        }


        // ============ SETUP PRINTDOCUMENT ============
        private void SetupPrint()
        {
            printDoc.DefaultPageSettings.Landscape = true;
            printDoc.PrintPage += PrintDoc_PrintPage;
        }

        // ============ AMBIL & TAMPILKAN DATA LAPORAN ============
        private void TampilkanLaporan()
        {
            string dari = dtDari.Value.ToString("yyyy-MM-dd 00:00:00");
            string sampai = dtSampai.Value.ToString("yyyy-MM-dd 23:59:59");
            string statusFilter = AmbilStatusFilter();

            string query = "SELECT t_pemesanan.id_pemesanan, t_pemesanan.tanggal_pemesanan, " +
                           "t_users.nama_lengkap, t_kereta.nama_kereta, " +
                           "asal.nama_stasiun AS stasiun_asal, tujuan.nama_stasiun AS stasiun_tujuan, " +
                           "t_jadwal.tanggal AS tanggal_berangkat, " +
                           "t_pemesanan.total_harga, t_pemesanan.status, " +
                           "(SELECT COUNT(*) FROM t_detailpenumpang " +
                           " WHERE t_detailpenumpang.id_pesanan = t_pemesanan.id_pemesanan) AS jumlah_kursi " +
                           "FROM t_pemesanan " +
                           "JOIN t_users ON t_pemesanan.id_users = t_users.id_users " +
                           "JOIN t_jadwal ON t_pemesanan.id_jadwal = t_jadwal.id_jadwal " +
                           "JOIN t_kereta ON t_jadwal.id_kereta = t_kereta.id_kereta " +
                           "JOIN t_stasiun asal ON t_jadwal.id_stasiunAsal = asal.id_stasiun " +
                           "JOIN t_stasiun tujuan ON t_jadwal.id_stasiunTujuan = tujuan.id_stasiun " +
                           "WHERE t_pemesanan.tanggal_pemesanan BETWEEN '" + dari + "' AND '" + sampai + "' ";

            if (statusFilter != "Semua Status")
            {
                query += "AND t_pemesanan.status = '" + statusFilter + "' ";
            }

            query += "ORDER BY t_pemesanan.tanggal_pemesanan DESC";

            db.crud(query);

            dgvLaporan.Rows.Clear();
            daftarLaporan.Clear();

            int totalTransaksi = 0;
            long totalPendapatan = 0;

            int no = 1;
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string tanggalPesan = Convert.ToDateTime(baris["tanggal_pemesanan"]).ToString("dd-MM-yyyy HH:mm");
                string namaPemesan = baris["nama_lengkap"].ToString();
                string kereta = baris["nama_kereta"].ToString();
                string rute = baris["stasiun_asal"] + " -> " + baris["stasiun_tujuan"];
                string tanggalBerangkat = Convert.ToDateTime(baris["tanggal_berangkat"]).ToString("dd-MM-yyyy");
                int jumlahKursi = Convert.ToInt32(baris["jumlah_kursi"]);
                int totalHarga = Convert.ToInt32(baris["total_harga"]);
                string status = baris["status"].ToString();

                int idxBaris = dgvLaporan.Rows.Add(
                    no, tanggalPesan, namaPemesan, kereta, rute, tanggalBerangkat,
                    jumlahKursi, "Rp" + totalHarga.ToString("N0"), status
                );

                DataGridViewCell selStatus = dgvLaporan.Rows[idxBaris].Cells["colStatus"];
                if (status == "berhasil")
                {
                    selStatus.Style.ForeColor = WARNA_HIJAU;
                    selStatus.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "menunggu")
                {
                    selStatus.Style.ForeColor = WARNA_KUNING;
                    selStatus.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (status == "dibatalkan")
                {
                    selStatus.Style.ForeColor = WARNA_MERAH;
                    selStatus.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }

                daftarLaporan.Add(new BarisLaporan
                {
                    TanggalPesan = tanggalPesan,
                    Pemesan = namaPemesan,
                    Kereta = kereta,
                    Rute = rute,
                    TanggalBerangkat = tanggalBerangkat,
                    JumlahKursi = jumlahKursi,
                    TotalHarga = totalHarga,
                    Status = status
                });

                totalTransaksi++;
                if (status == "berhasil")
                {
                    totalPendapatan += totalHarga;
                }

                no++;
            }

            lblTotalTransaksi.Text = "Total Transaksi : " + totalTransaksi;
            lblTotalTransaksi.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblTotalTransaksi.ForeColor = Color.FromArgb(75, 85, 99);

            lblTotalPendapatan.Text = "Total Pendapatan (Berhasil) : Rp" + totalPendapatan.ToString("N0");
            lblTotalPendapatan.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalPendapatan.ForeColor = WARNA_HIJAU;

            if (dgvLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data transaksi pada rentang tanggal dan status yang dipilih");
            }
        }

        // ============ PROSES MENGGAMBAR HALAMAN CETAK ============
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font fontJudul = new Font("Segoe UI", 14F, FontStyle.Bold);
            Font fontSubJudul = new Font("Segoe UI", 9F, FontStyle.Regular);
            Font fontHeaderTabel = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            Font fontIsi = new Font("Segoe UI", 8F, FontStyle.Regular);

            int marginKiri = e.MarginBounds.Left;
            int marginAtas = e.MarginBounds.Top;
            int lebarHalaman = e.MarginBounds.Width;
            int y = marginAtas;

            int[] kolomX = {
                marginKiri,
                marginKiri + 110,
                marginKiri + 260,
                marginKiri + 380,
                marginKiri + 560,
                marginKiri + 660,
                marginKiri + 730,
                marginKiri + 850
            };

            if (indexCetak == 0)
            {
                g.DrawString("Laporan Pemesanan & Pendapatan", fontJudul, Brushes.Black, marginKiri, y);
                y += 28;

                string statusUntukCetak = AmbilStatusFilter();
                string periode = "Periode : " + dtDari.Value.ToString("dd-MM-yyyy") +
                                  " s/d " + dtSampai.Value.ToString("dd-MM-yyyy") +
                                  "   |   Status : " + statusUntukCetak;
                g.DrawString(periode, fontSubJudul, Brushes.Black, marginKiri, y);
                y += 25;
            }

            g.DrawString("Tgl Pesan", fontHeaderTabel, Brushes.Black, kolomX[0], y);
            g.DrawString("Pemesan", fontHeaderTabel, Brushes.Black, kolomX[1], y);
            g.DrawString("Kereta", fontHeaderTabel, Brushes.Black, kolomX[2], y);
            g.DrawString("Rute", fontHeaderTabel, Brushes.Black, kolomX[3], y);
            g.DrawString("Tgl Berangkat", fontHeaderTabel, Brushes.Black, kolomX[4], y);
            g.DrawString("Kursi", fontHeaderTabel, Brushes.Black, kolomX[5], y);
            g.DrawString("Total", fontHeaderTabel, Brushes.Black, kolomX[6], y);
            g.DrawString("Status", fontHeaderTabel, Brushes.Black, kolomX[7], y);
            y += 18;
            g.DrawLine(Pens.Black, marginKiri, y, marginKiri + lebarHalaman, y);
            y += 6;

            while (indexCetak < daftarLaporan.Count)
            {
                if (y > e.MarginBounds.Bottom - 60)
                {
                    e.HasMorePages = true;
                    return;
                }

                BarisLaporan item = daftarLaporan[indexCetak];

                g.DrawString(item.TanggalPesan, fontIsi, Brushes.Black, kolomX[0], y);
                g.DrawString(item.Pemesan, fontIsi, Brushes.Black, kolomX[1], y);
                g.DrawString(item.Kereta, fontIsi, Brushes.Black, kolomX[2], y);
                g.DrawString(item.Rute, fontIsi, Brushes.Black, kolomX[3], y);
                g.DrawString(item.TanggalBerangkat, fontIsi, Brushes.Black, kolomX[4], y);
                g.DrawString(item.JumlahKursi.ToString(), fontIsi, Brushes.Black, kolomX[5], y);
                g.DrawString("Rp" + item.TotalHarga.ToString("N0"), fontIsi, Brushes.Black, kolomX[6], y);
                g.DrawString(item.Status, fontIsi, Brushes.Black, kolomX[7], y);

                y += 20;
                indexCetak++;
            }

            int totalTransaksi = daftarLaporan.Count;
            long totalPendapatan = 0;
            foreach (BarisLaporan item in daftarLaporan)
            {
                if (item.Status == "berhasil") totalPendapatan += item.TotalHarga;
            }

            y += 15;
            g.DrawLine(Pens.Black, marginKiri, y, marginKiri + lebarHalaman, y);
            y += 10;

            Font fontTotal = new Font("Segoe UI", 10F, FontStyle.Bold);
            g.DrawString("Total Transaksi : " + totalTransaksi, fontTotal, Brushes.Black, marginKiri, y);
            g.DrawString("Total Pendapatan (Berhasil) : Rp" + totalPendapatan.ToString("N0"),
                         fontTotal, Brushes.Black, kolomX[4], y);

            e.HasMorePages = false;
        }

        private void FLaporan_Load(object sender, EventArgs e)
        {
            SetupFilter();
            SetupTabel();
            SetupPrint();

            TampilkanLaporan();
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            if (dtDari.Value > dtSampai.Value)
            {
                MessageBox.Show("Tanggal 'Dari' tidak boleh lebih besar dari tanggal 'Sampai'");
                return;
            }

            TampilkanLaporan();
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (daftarLaporan.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak. Tampilkan laporan terlebih dahulu.");
                return;
            }

            indexCetak = 0;

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDoc;
            preview.Width = 1000;
            preview.Height = 700;
            preview.ShowDialog();
        }
    }
}