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
    public partial class FPenumpang : Form
    {
        private string idJadwal;
        private List<string> kursiTerpilih;
        private int hargaSatuan;

        // WARNA TEMA
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_TUA = Color.FromArgb(30, 58, 138);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);

        public FPenumpang(string idJadwalTerpilih, List<string> kursiDipilih)
        {
            InitializeComponent();

            idJadwal = idJadwalTerpilih;
            kursiTerpilih = kursiDipilih;
        }

        // =========================================================
        // LOAD FORM
        // =========================================================
        private void FPenumpang_Load(object sender, EventArgs e)
        {
            SetupHeader();
            SetupTabel();

            AmbilHargaJadwal();
            TampilkanTabelPenumpang();
        }

        // =========================================================
        // HEADER GRADIENT BIRU
        // =========================================================
        private void SetupHeader()
        {
            panelHeader.Paint -= panelHeader_Paint;
            panelHeader.Paint += panelHeader_Paint;

            panelHeader.Invalidate();
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush =
                new System.Drawing.Drawing2D.LinearGradientBrush(
                    panelHeader.ClientRectangle,
                    WARNA_BIRU_TUA,
                    WARNA_BIRU,
                    45F))
            {
                e.Graphics.FillRectangle(
                    brush,
                    panelHeader.ClientRectangle
                );
            }
        }

        // =========================================================
        // STYLE DATAGRIDVIEW
        // =========================================================
        private void SetupTabel()
        {
            // TAMPILAN DASAR
            dgvPenumpang.BorderStyle = BorderStyle.None;
            dgvPenumpang.BackgroundColor = Color.White;
            dgvPenumpang.RowHeadersVisible = false;

            // BARIS
            dgvPenumpang.AllowUserToAddRows = false;
            dgvPenumpang.AllowUserToDeleteRows = false;
            dgvPenumpang.AllowUserToResizeRows = false;

            dgvPenumpang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPenumpang.MultiSelect = false;

            dgvPenumpang.RowTemplate.Height = 38;

            // HEADER BIRU
            dgvPenumpang.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dgvPenumpang.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvPenumpang.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvPenumpang.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvPenumpang.EnableHeadersVisualStyles = false;

            dgvPenumpang.ColumnHeadersHeight = 40;

            dgvPenumpang.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ISI TABEL
            dgvPenumpang.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dgvPenumpang.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dgvPenumpang.DefaultCellStyle.BackColor =
                Color.White;

            dgvPenumpang.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvPenumpang.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dgvPenumpang.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // BARIS SELANG-SELING
            dgvPenumpang.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dgvPenumpang.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dgvPenumpang.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // GARIS TABEL
            dgvPenumpang.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPenumpang.GridColor =
                Color.FromArgb(229, 231, 235);
        }

        // =========================================================
        // AMBIL HARGA JADWAL
        // =========================================================
        private void AmbilHargaJadwal()
        {
            db.crud(
                "SELECT harga FROM t_jadwal WHERE id_jadwal = '" +
                idJadwal +
                "'"
            );

            if (db.ds.Tables[0].Rows.Count > 0)
            {
                hargaSatuan =
                    Convert.ToInt32(
                        db.ds.Tables[0].Rows[0]["Harga"]
                    );
            }

            lblRingkasan.Text =
                "Jumlah kursi: " +
                kursiTerpilih.Count +
                " | Harga per kursi: Rp" +
                hargaSatuan +
                " | Total: Rp" +
                (hargaSatuan * kursiTerpilih.Count);
        }

        // =========================================================
        // TAMPILKAN TABEL PENUMPANG
        // =========================================================
        private void TampilkanTabelPenumpang()
        {
            dgvPenumpang.Rows.Clear();

            int no = 1;

            foreach (string item in kursiTerpilih)
            {
                string[] pecah = item.Split('|');

                string idKursi = pecah[0];
                string noKursi = pecah[1];

                dgvPenumpang.Rows.Add(
                    no,
                    idKursi,
                    noKursi,
                    "",
                    ""
                );

                no++;
            }

            // KOLOM YANG TIDAK BOLEH DIUBAH
            foreach (DataGridViewRow row in dgvPenumpang.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells["colNo"].ReadOnly = true;
                    row.Cells["colIdKursi"].ReadOnly = true;
                    row.Cells["colKursi"].ReadOnly = true;
                }
            }
        }

        // =========================================================
        // TOMBOL SELANJUTNYA
        // =========================================================
        private void btnSelanjutnya_Click(object sender, EventArgs e)
        {
            List<string> dataPenumpang =
                new List<string>();

            foreach (DataGridViewRow row in dgvPenumpang.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string idKursi =
                    row.Cells["colIdKursi"].Value?.ToString();

                string noKursi =
                    row.Cells["colKursi"].Value?.ToString();

                string nama =
                    row.Cells["colNama"].Value?.ToString();

                string nik =
                    row.Cells["colNIK"].Value?.ToString();

                // VALIDASI NAMA DAN NIK
                if (string.IsNullOrWhiteSpace(nama) ||
                    string.IsNullOrWhiteSpace(nik))
                {
                    MessageBox.Show(
                        "Nama penumpang dan NIK harus diisi semua.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // VALIDASI NIK 16 DIGIT
                if (nik.Length != 16 ||
                    !nik.All(char.IsDigit))
                {
                    MessageBox.Show(
                        "NIK harus terdiri dari 16 digit angka.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                // SIMPAN DATA
                dataPenumpang.Add(
                    idKursi +
                    "|" +
                    noKursi +
                    "|" +
                    nama +
                    "|" +
                    nik
                );
            }

            int totalHarga =
                hargaSatuan * kursiTerpilih.Count;

            // LANJUT KE FORM KONFIRMASI
            FKonfirmasi f =
                new FKonfirmasi(
                    idJadwal,
                    dataPenumpang,
                    totalHarga
                );

            f.Show();
            this.Hide();
        }

        // =========================================================
        // EVENT KOSONG DARI DESIGNER
        // =========================================================
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dgvPenumpang_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void lblRingkasan_Click(object sender, EventArgs e)
        {
        }
    }
}