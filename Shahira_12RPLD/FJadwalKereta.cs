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
    public partial class FJadwalKereta : Form
    {
        // WARNA TABEL
        private readonly Color WARNA_BIRU = Color.FromArgb(37, 99, 235);
        private readonly Color WARNA_BIRU_MUDA = Color.FromArgb(239, 246, 255);
        private readonly Color WARNA_TEKS_GELAP = Color.FromArgb(30, 41, 59);

        public FJadwalKereta()
        {
            InitializeComponent();

            // ENTER
            cmbkereta.KeyDown += PindahDenganEnter;
            cmbkelas.KeyDown += PindahDenganEnter;
            cmbasal.KeyDown += PindahDenganEnter;
            cmbtujuan.KeyDown += PindahDenganEnter;
            dttanggal.KeyDown += PindahDenganEnter;
            dtberangkat.KeyDown += PindahDenganEnter;
            dttiba.KeyDown += PindahDenganEnter;
            txtharga.KeyDown += PindahDenganEnter;

            // EVENT KERETA
            cmbkereta.SelectedIndexChanged +=
                cmbkereta_SelectedIndexChanged;
        }

        // LOAD FORM
        private void FJadwalKereta_Load(object sender, EventArgs e)
        {
            // STYLE TABEL
            SetupTabel();

            // LOAD DATA KERETA
            db.crud("SELECT * FROM t_kereta");

            cmbkereta.DataSource = db.ds.Tables[0];
            cmbkereta.DisplayMember = "nama_kereta";
            cmbkereta.ValueMember = "id_kereta";
            cmbkereta.SelectedIndex = -1;

            // LOAD DATA KELAS
            db.crud("SELECT * FROM t_kelas");

            cmbkelas.DataSource = db.ds.Tables[0];
            cmbkelas.DisplayMember = "nama_kelas";
            cmbkelas.ValueMember = "id_kelas";
            cmbkelas.SelectedIndex = -1;

            // LOAD STASIUN ASAL
            db.crud("SELECT * FROM t_stasiun");

            cmbasal.DataSource = db.ds.Tables[0];
            cmbasal.DisplayMember = "nama_stasiun";
            cmbasal.ValueMember = "id_stasiun";
            cmbasal.SelectedIndex = -1;

            // LOAD STASIUN TUJUAN
            db.crud("SELECT * FROM t_stasiun");

            cmbtujuan.DataSource = db.ds.Tables[0];
            cmbtujuan.DisplayMember = "nama_stasiun";
            cmbtujuan.ValueMember = "id_stasiun";
            cmbtujuan.SelectedIndex = -1;

            // FORMAT TANGGAL
            dttanggal.Format = DateTimePickerFormat.Short;

            // FORMAT JAM BERANGKAT
            dtberangkat.Format =
                DateTimePickerFormat.Custom;

            dtberangkat.CustomFormat = "HH:mm";
            dtberangkat.ShowUpDown = true;

            // FORMAT JAM TIBA
            dttiba.Format =
                DateTimePickerFormat.Custom;

            dttiba.CustomFormat = "HH:mm";
            dttiba.ShowUpDown = true;

            // KURSI READ ONLY
            txtkursi.ReadOnly = true;

            // TAB INDEX
            cmbkereta.TabIndex = 0;
            cmbkelas.TabIndex = 1;
            cmbasal.TabIndex = 2;
            cmbtujuan.TabIndex = 3;
            dttanggal.TabIndex = 4;
            dtberangkat.TabIndex = 5;
            dttiba.TabIndex = 6;
            txtharga.TabIndex = 7;
            txtkursi.TabIndex = 8;

            guna2Button1.TabIndex = 10;

            // BERSIHKAN FORM
            bersih();

            // KOSONGKAN TABEL SAAT AWAL
            dataGridView1.Rows.Clear();
        }

        // STYLE DATAGRIDVIEW
        private void SetupTabel()
        {
            // TAMPILAN DASAR
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.RowHeadersVisible = false;

            // BARIS
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView1.RowTemplate.Height = 36;
            dataGridView1.AllowUserToResizeRows = false;

            // HEADER BIRU
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersHeight = 40;

            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ISI TABEL
            dataGridView1.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.DefaultCellStyle.Font =
                new Font("Segoe UI", 9F);

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // SAAT DIPILIH
            dataGridView1.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // BARIS SELANG-SELING
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            // GARIS TABEL
            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(229, 231, 235);
        }

        // MEMBERSIHKAN INPUT
        public void bersih()
        {
            cmbkereta.SelectedIndex = -1;
            cmbkelas.SelectedIndex = -1;
            cmbasal.SelectedIndex = -1;
            cmbtujuan.SelectedIndex = -1;

            dttanggal.Value = DateTime.Now;
            dtberangkat.Value = DateTime.Now;
            dttiba.Value = DateTime.Now;

            txtharga.Text = "";
            txtkursi.Text = "";
            nomor.Text = "";

            cmbkereta.Focus();
        }

        // TAMPIL DATA
        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            string query = @"
                SELECT
                    j.id_jadwal,
                    k.nama_kereta,
                    kl.nama_kelas,
                    sa.nama_stasiun AS stasiun_asal,
                    st.nama_stasiun AS stasiun_tujuan,
                    j.tanggal,
                    j.jam_berangkat,
                    j.jam_tiba,
                    j.harga,
                    j.sisa_kursi
                FROM t_jadwal j

                INNER JOIN t_kereta k
                    ON j.id_kereta = k.id_kereta

                INNER JOIN t_kelas kl
                    ON j.id_kelas = kl.id_kelas

                INNER JOIN t_stasiun sa
                    ON j.id_stasiunAsal = sa.id_stasiun

                INNER JOIN t_stasiun st
                    ON j.id_stasiunTujuan = st.id_stasiun

                ORDER BY j.id_jadwal ASC
            ";

            db.crud(query);

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_jadwal"];
                string kereta = "" + baris["nama_kereta"];
                string kelas = "" + baris["nama_kelas"];
                string awal = "" + baris["stasiun_asal"];
                string tujuan = "" + baris["stasiun_tujuan"];
                string tanggal = "" + baris["tanggal"];
                string berangkat = "" + baris["jam_berangkat"];
                string tiba = "" + baris["jam_tiba"];
                string harga = "" + baris["harga"];
                string kursi = "" + baris["sisa_kursi"];

                dataGridView1.Rows.Add(
                    id,
                    kereta,
                    kelas,
                    awal,
                    tujuan,
                    tanggal,
                    berangkat,
                    tiba,
                    harga,
                    kursi
                );
            }
        }

        // BUTTON SIMPAN
        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            // CEK KERETA
            if (cmbkereta.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih kereta terlebih dahulu",
                    "Peringatan"
                );

                cmbkereta.Focus();
                return;
            }

            // CEK KELAS
            if (cmbkelas.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih kelas terlebih dahulu",
                    "Peringatan"
                );

                cmbkelas.Focus();
                return;
            }

            // CEK STASIUN ASAL
            if (cmbasal.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih stasiun asal terlebih dahulu",
                    "Peringatan"
                );

                cmbasal.Focus();
                return;
            }

            // CEK STASIUN TUJUAN
            if (cmbtujuan.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih stasiun tujuan terlebih dahulu",
                    "Peringatan"
                );

                cmbtujuan.Focus();
                return;
            }

            // CEK HARGA
            if (txtharga.Text == "")
            {
                MessageBox.Show(
                    "Harga belum diisi",
                    "Peringatan"
                );

                txtharga.Focus();
                return;
            }

            // CEK KURSI
            if (txtkursi.Text == "")
            {
                MessageBox.Show(
                    "Kapasitas kursi belum tersedia",
                    "Peringatan"
                );

                return;
            }

            string kereta =
                cmbkereta.SelectedValue.ToString();

            string kelas =
                cmbkelas.SelectedValue.ToString();

            string asal =
                cmbasal.SelectedValue.ToString();

            string tujuan =
                cmbtujuan.SelectedValue.ToString();

            string tanggal =
                dttanggal.Value.ToString("yyyy-MM-dd");

            string berangkat =
                dtberangkat.Value.ToString("HH:mm:ss");

            string tiba =
                dttiba.Value.ToString("HH:mm:ss");

            string harga =
                txtharga.Text;

            int kapasitas;

            if (!int.TryParse(
                txtkursi.Text,
                out kapasitas))
            {
                MessageBox.Show(
                    "Kapasitas kursi harus berupa angka",
                    "Peringatan"
                );

                txtkursi.Focus();
                return;
            }

            db.crud(
                $"INSERT INTO t_jadwal " +
                $"VALUES(" +
                $"null," +
                $"'{kereta}'," +
                $"'{kelas}'," +
                $"'{asal}'," +
                $"'{tujuan}'," +
                $"'{tanggal}'," +
                $"'{berangkat}'," +
                $"'{tiba}'," +
                $"'{harga}'," +
                $"'{kapasitas}'" +
                $");"
            );

            db.crud(
                "SELECT LAST_INSERT_ID() AS id"
            );

            string idJadwalBaru =
                db.ds.Tables[0]
                .Rows[0]["id"]
                .ToString();

            for (int i = 1; i <= kapasitas; i++)
            {
                string noKursi =
                    "A" + i.ToString("00");

                db.crud(
                    $"INSERT INTO t_kursi " +
                    $"VALUES(" +
                    $"null," +
                    $"'{idJadwalBaru}'," +
                    $"'{noKursi}'," +
                    $"'kosong'" +
                    $")"
                );
            }

            MessageBox.Show(
                "Data jadwal berhasil ditambahkan",
                "Informasi"
            );

            bersih();
            tampildata();
        }

        // BUTTON UPDATE
        private void guna2Button2_Click(
            object sender,
            EventArgs e)
        {
            // CEK DATA YANG DIPILIH
            if (nomor.Text == "")
            {
                MessageBox.Show(
                    "Silakan pilih data yang ingin diubah",
                    "Peringatan"
                );

                return;
            }

            // CEK KERETA
            if (cmbkereta.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih kereta terlebih dahulu",
                    "Peringatan"
                );

                cmbkereta.Focus();
                return;
            }

            // CEK KELAS
            if (cmbkelas.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih kelas terlebih dahulu",
                    "Peringatan"
                );

                cmbkelas.Focus();
                return;
            }

            // CEK STASIUN ASAL
            if (cmbasal.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih stasiun asal terlebih dahulu",
                    "Peringatan"
                );

                cmbasal.Focus();
                return;
            }

            // CEK STASIUN TUJUAN
            if (cmbtujuan.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih stasiun tujuan terlebih dahulu",
                    "Peringatan"
                );

                cmbtujuan.Focus();
                return;
            }

            // CEK HARGA
            if (txtharga.Text == "")
            {
                MessageBox.Show(
                    "Harga belum diisi",
                    "Peringatan"
                );

                txtharga.Focus();
                return;
            }

            string kereta =
                cmbkereta.SelectedValue.ToString();

            string kelas =
                cmbkelas.SelectedValue.ToString();

            string asal =
                cmbasal.SelectedValue.ToString();

            string tujuan =
                cmbtujuan.SelectedValue.ToString();

            string tanggal =
                dttanggal.Value.ToString("yyyy-MM-dd");

            string berangkat =
                dtberangkat.Value.ToString("HH:mm:ss");

            string tiba =
                dttiba.Value.ToString("HH:mm:ss");

            string harga =
                txtharga.Text;

            string idj =
                nomor.Text;

            db.crud(
                $"UPDATE t_jadwal SET " +
                $"id_kereta = '{kereta}', " +
                $"id_kelas = '{kelas}', " +
                $"id_stasiunAsal = '{asal}', " +
                $"id_stasiunTujuan = '{tujuan}', " +
                $"tanggal = '{tanggal}', " +
                $"jam_berangkat = '{berangkat}', " +
                $"jam_tiba = '{tiba}', " +
                $"harga = '{harga}' " +
                $"WHERE id_jadwal = '{idj}'"
            );

            MessageBox.Show(
                "Data jadwal berhasil diubah",
                "Informasi"
            );

            bersih();
            tampildata();
        }

        // BUTTON TAMPIL DATA
        private void guna2Button3_Click_1(
            object sender,
            EventArgs e)
        {
            tampildata();
        }

        // EDIT / DELETE
        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            // JANGAN PROSES HEADER
            if (e.RowIndex < 0)
            {
                return;
            }

            // BARIS KOSONG
            if (
                dataGridView1.Rows[e.RowIndex]
                .Cells[0].Value == null
            )
            {
                return;
            }

            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;

            // ID JADWAL
            string idnya =
                dataGridView1
                .Rows[baris]
                .Cells[0]
                .Value
                .ToString();

            // EDIT
            if (kolom == 10)
            {
                db.crud(
                    $"SELECT * FROM t_jadwal " +
                    $"WHERE id_jadwal = '{idnya}'"
                );

                foreach (
                    DataRow bariss
                    in db.ds.Tables[0].Rows
                )
                {
                    string id =
                        "" + bariss["id_jadwal"];

                    string kereta =
                        "" + bariss["id_kereta"];

                    string kelas =
                        "" + bariss["id_kelas"];

                    string asal =
                        "" + bariss["id_stasiunAsal"];

                    string tujuan =
                        "" + bariss["id_stasiunTujuan"];

                    string tanggal =
                        "" + bariss["tanggal"];

                    string berangkat =
                        "" + bariss["jam_berangkat"];

                    string tiba =
                        "" + bariss["jam_tiba"];

                    string harga =
                        "" + bariss["harga"];

                    string kursi =
                        "" + bariss["sisa_kursi"];

                    nomor.Text = id;

                    cmbkereta.SelectedValue = kereta;
                    cmbkelas.SelectedValue = kelas;
                    cmbasal.SelectedValue = asal;
                    cmbtujuan.SelectedValue = tujuan;

                    dttanggal.Value =
                        Convert.ToDateTime(tanggal);

                    dtberangkat.Value =
                        DateTime.Today.Add(
                            TimeSpan.Parse(berangkat)
                        );

                    dttiba.Value =
                        DateTime.Today.Add(
                            TimeSpan.Parse(tiba)
                        );

                    txtharga.Text = harga;
                    txtkursi.Text = kursi;
                }
            }

            // DELETE
            if (kolom == 11)
            {
                DialogResult ya =
                    MessageBox.Show(
                        "Apakah ingin menghapus data?",
                        "Pemberitahuan",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (ya == DialogResult.Yes)
                {
                    // HAPUS KURSI DULU
                    db.crud(
                        $"DELETE FROM t_kursi " +
                        $"WHERE id_jadwal = '{idnya}'"
                    );

                    // HAPUS JADWAL
                    db.crud(
                        $"DELETE FROM t_jadwal " +
                        $"WHERE id_jadwal = '{idnya}'"
                    );

                    MessageBox.Show(
                        "Data jadwal berhasil dihapus",
                        "Informasi"
                    );

                    bersih();
                    tampildata();
                }
            }
        }

        // SAAT KERETA DIPILIH
        private void cmbkereta_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cmbkereta.SelectedIndex == -1)
            {
                txtkursi.Text = "";
                return;
            }

            DataRowView baris =
                cmbkereta.SelectedItem
                as DataRowView;

            if (baris != null)
            {
                string kapasitas =
                    "" + baris["kapasitas"];

                txtkursi.Text =
                    kapasitas;
            }
        }

        // ENTER
        private void PindahDenganEnter(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Kalau sampai harga
                // ENTER = SIMPAN
                if (sender == txtharga)
                {
                    guna2Button1.PerformClick();
                }
                else
                {
                    SelectNextControl(
                        (Control)sender,
                        true,
                        true,
                        true,
                        true
                    );
                }
            }
        }
    }
}