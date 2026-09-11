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
    public partial class FCariJadwal : Form
    {
        private string idJadwalTerpilih = "";
        public FCariJadwal()
        {
            InitializeComponent();
        }

        private void FCariJadwal_Load(object sender, EventArgs e)
        {
            // Isi combo Stasiun Asal
            db.crud("SELECT * FROM t_stasiun");
            cmbAsal.DataSource = db.ds.Tables[0];
            cmbAsal.DisplayMember = "nama_stasiun";
            cmbAsal.ValueMember = "id_stasiun";
            cmbAsal.SelectedIndex = -1;

            // Isi combo Stasiun Tujuan
            db.crud("SELECT * FROM t_stasiun");
            cmbTujuan.DataSource = db.ds.Tables[0];
            cmbTujuan.DisplayMember = "nama_stasiun";
            cmbTujuan.ValueMember = "id_stasiun";
            cmbTujuan.SelectedIndex = -1;

            dtTanggal.Value = DateTime.Now;
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            if (cmbAsal.SelectedIndex == -1 || cmbTujuan.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih stasiun asal dan tujuan dulu");
                return;
            }

            if (cmbAsal.SelectedValue.ToString() == cmbTujuan.SelectedValue.ToString())
            {
                MessageBox.Show("Stasiun asal dan tujuan tidak boleh sama");
                return;
            }

            string asal = cmbAsal.SelectedValue.ToString();
            string tujuan = cmbTujuan.SelectedValue.ToString();
            string tanggal = dtTanggal.Value.ToString("yyyy-MM-dd");

            string query = $@"SELECT t_jadwal.id_jadwal, t_kereta.nama_kereta, t_kelas.nama_kelas, 
                               t_jadwal.jam_berangkat, t_jadwal.jam_tiba, t_jadwal.harga, t_jadwal.sisa_kursi
                               FROM t_jadwal
                               JOIN t_kereta ON t_jadwal.id_kereta = t_kereta.id_kereta
                               JOIN t_kelas ON t_jadwal.id_kelas = t_kelas.id_kelas
                               WHERE t_jadwal.id_stasiunAsal = '{asal}' 
                               AND t_jadwal.id_stasiunTujuan = '{tujuan}' 
                               AND t_jadwal.tanggal = '{tanggal}'
                               AND t_jadwal.sisa_kursi > 0";

            db.crud(query);
            dgvJadwal.Rows.Clear();

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                dgvJadwal.Rows.Add(
                    baris["id_jadwal"],
                    baris["nama_kereta"],
                    baris["nama_kelas"],
                    baris["jam_berangkat"],
                    baris["jam_tiba"],
                    baris["harga"],
                    baris["sisa_kursi"]
                );
            }

            if (dgvJadwal.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada jadwal tersedia untuk rute dan tanggal ini");
            }

        }

        private void dgvJadwal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            if (baris < 0) return; // supaya tidak error kalau yang diklik header kolom

            // Ambil id_jadwal dari kolom pertama (colIdJadwal), simpan ke variable
            idJadwalTerpilih = dgvJadwal.Rows[baris].Cells["colIdJadwal"].Value.ToString();

            // Aktifkan tombol lanjut, kalau sebelumnya di-disable
            btnPilihJadwal.Enabled = true;
        }

        private void btnPilihJadwal_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idJadwalTerpilih))
            {
                MessageBox.Show("Pilih salah satu jadwal dulu dari daftar");
                return;
            }

            // Buka form berikutnya (Pilih Kursi), kirim id_jadwal yang dipilih
            FPilihKursi f = new FPilihKursi(idJadwalTerpilih);
            f.Show();
            this.Hide();
        }
    }
}
