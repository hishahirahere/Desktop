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
        public FPenumpang(string idJadwalTerpilih, List<string> kursiDipilih)
        {
            InitializeComponent();

            idJadwal = idJadwalTerpilih;
            kursiTerpilih = kursiDipilih;
        }

        private void FPenumpang_Load(object sender, EventArgs e)
        {
            AmbilHargaJadwal();
            TampilkanTabelPenumpang();
        }
        
        private void AmbilHargaJadwal()
        {
            db.crud("SELECT harga FROM t_jadwal WHERE id_jadwal = '" + idJadwal + "'");

            if (db.ds.Tables[0].Rows.Count > 0)
            {
                hargaSatuan = Convert.ToInt32(db.ds.Tables[0].Rows[0]["Harga"]);
            }
            lblRingkasan.Text = "Jumlah kursi: " + kursiTerpilih.Count +
                                 " | Harga per kursi: Rp" + hargaSatuan +
                                 " | Total: Rp" + (hargaSatuan * kursiTerpilih.Count);
        }

        private void TampilkanTabelPenumpang()
        {
            dgvPenumpang.Rows.Clear();

            int no = 1;
            foreach (string item in kursiTerpilih)
            {
                string[] pecah = item.Split('|');
                string idKursi = pecah[0];
                string noKursi = pecah[1];

                dgvPenumpang.Rows.Add(no, idKursi, noKursi, "", "");
                no++;
            }
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
        private void btnSelanjutnya_Click(object sender, EventArgs e)
        {
            List<string> dataPenumpang = new List<string>();
            foreach (DataGridViewRow row in dgvPenumpang.Rows)
            {
                if (row.IsNewRow) continue;
                string idKursi = row.Cells["colIdKursi"].Value?.ToString();
                string noKursi = row.Cells["colKursi"].Value?.ToString();
                string nama = row.Cells["colNama"].Value?.ToString();
                string nik = row.Cells["colNIK"].Value?.ToString();

                // Validasi nama & NIK harus diisi
                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(nik))
                {
                    MessageBox.Show("Nama penumpang dan NIK harus diisi semua.",
                                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi NIK harus 16 digit angka
                if (nik.Length != 16 || !nik.All(char.IsDigit))
                {
                    MessageBox.Show("NIK harus terdiri dari 16 digit angka.",
                                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Simpan lengkap: id_kursi|no_kursi|nama|nik
                dataPenumpang.Add(idKursi + "|" + noKursi + "|" + nama + "|" + nik);
            }

            int totalHarga = hargaSatuan * kursiTerpilih.Count;

            // Lanjut ke form Konfirmasi, bawa id_jadwal + data penumpang lengkap + total harga
            FKonfirmasi f = new FKonfirmasi(idJadwal, dataPenumpang, totalHarga);
            f.Show();
            this.Hide();
        }
    }
}