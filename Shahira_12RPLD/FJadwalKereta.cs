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
        public FJadwalKereta()
        {
            InitializeComponent();
        }
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
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_jadwal");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_jadwal"];
                string kereta = "" + baris["id_kereta"];
                string kelas = "" + baris["id_kelas"];
                string awal = "" + baris["id_stasiunAsal"];
                string tujuan = "" + baris["id_stasiunTujuan"];
                string tanggal = "" + baris["tanggal"];
                string berangkat = "" + baris["jam_berangkat"];
                string tiba = "" + baris["jam_tiba"];
                string harga = "" + baris["harga"];
                string kursi = "" + baris["sisa_kursi"];
                dataGridView1.Rows.Add(id, kereta, kelas, awal, tujuan, tanggal, berangkat, tiba, harga, kursi);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kereta = cmbkereta.SelectedValue.ToString();
            string kelas = cmbkelas.SelectedValue.ToString();
            string asal = cmbasal.SelectedValue.ToString();
            string tujuan = cmbtujuan.SelectedValue.ToString();

            string tanggal = dttanggal.Value.ToString("yyyy-MM-dd");
            string berangkat = dtberangkat.Value.ToString("HH:mm-ss");
            string tiba = dttiba.Value.ToString("HH:mm:ss");

            string harga = txtharga.Text;
            int kapasitas = int.Parse(txtkursi.Text);
            db.crud($"INSERT INTO t_jadwal VALUES(null,'{kereta}','{kelas}','{asal}','{tujuan}','{tanggal}','{berangkat}','{tiba}','{harga}', '{kapasitas}');");
            
            db.crud("SELECT LAST_INSERT_ID() as id");
            string idJadwalBaru = db.ds.Tables[0].Rows[0]["id"].ToString();

            for (int i = 1; i < kapasitas; i++)
            {
                string noKursi = "A" + i.ToString("00");
                db.crud($"INSERT INTO t_kursi VALUES(null, '{idJadwalBaru}', '{noKursi}', 'kosong')");
            }

            MessageBox.Show("Data jadwal berhasil ditambahkan");
            bersih();
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kereta = cmbkereta.SelectedValue.ToString();
            string kelas = cmbkelas.SelectedValue.ToString();
            string asal = cmbasal.SelectedValue.ToString();
            string tujuan = cmbtujuan.SelectedValue.ToString();

            string tanggal = dttanggal.Value.ToString("yyyy-MM-dd");
            string berangkat = dtberangkat.Value.ToString("HH:mm:ss");
            string tiba = dttiba.Value.ToString("HH:mm:ss");

            string harga = txtharga.Text;
            string idj = nomor.Text;
            db.crud($"UPDATE t_jadwal SET id_kereta = '{kereta}', id_kelas = '{kelas}', id_stasiunAsal = '{asal}', id_stasiunTujuan = '{tujuan}', tanggal = '{tanggal}', jam_berangkat = '{berangkat}', jam_tiba = '{tiba}', harga = '{harga}' where id_jadwal = '{idj}'");

            MessageBox.Show("Data jadwal berhasil diubah");
            bersih();
            tampildata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = dataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 10)
            {
                db.crud($"SELECT * FROM t_jadwal  WHERE id_jadwal = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_jadwal"];
                    string kereta = "" + bariss["id_kereta"];
                    string kelas = "" + bariss["id_kelas"];
                    string asal = "" + bariss["id_stasiunAsal"];
                    string tujuan = "" + bariss["id_stasiunTujuan"];
                    string tanggal = "" + bariss["tanggal"];
                    string berangkat = "" + bariss["jam_berangkat"];
                    string tiba = "" + bariss["jam_tiba"];
                    string harga = "" + bariss["harga"];
                    string kursi = "" + bariss["sisa_kursi"];

                    nomor.Text = id;

                    cmbkereta.SelectedValue = kereta;
                    cmbkelas.SelectedValue = kelas;
                    cmbasal.SelectedValue = asal;
                    cmbtujuan.SelectedValue = tujuan;

                    dttanggal.Value = Convert.ToDateTime(tanggal);
                    dtberangkat.Value = DateTime.Today.Add(TimeSpan.Parse(berangkat));
                    dttiba.Value = DateTime.Today.Add(TimeSpan.Parse(tiba));

                    txtharga.Text = harga;
                    txtkursi.Text = kursi;
                }

            }

            if (kolom == 11)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_kursi WHERE id_jadwal = '{idnya}' ");
                    db.crud($"DELETE FROM t_jadwal WHERE id_jadwal = '{idnya}' ");
                    tampildata();
                }

            }
        }

        private void cmbkereta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbkereta.SelectedIndex == -1)
            {
                txtkursi.Text = "";
                return;
            }
            DataRowView baris = cmbkereta.SelectedItem as DataRowView;

            if (baris != null)
            {
                string kapasitas = "" + baris["kapasitas"];

                txtkursi.Text = kapasitas;
            }
        }
        private void PindahDenganEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (sender == txtharga)
                {
                    guna2Button1.PerformClick();
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }

        private void FJadwalKereta_Load(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM t_kereta");

            cmbkereta.DataSource = db.ds.Tables[0];
            cmbkereta.DisplayMember = "nama_kereta";
            cmbkereta.ValueMember = "id_kereta";
            cmbkereta.SelectedIndex = -1;

            db.crud("SELECT * FROM t_kelas");

            cmbkelas.DataSource = db.ds.Tables[0];
            cmbkelas.DisplayMember = "nama_kelas";
            cmbkelas.ValueMember = "id_kelas";
            cmbkelas.SelectedIndex = -1;

            db.crud("SELECT * FROM t_stasiun");

            cmbasal.DataSource = db.ds.Tables[0];
            cmbasal.DisplayMember = "nama_stasiun";
            cmbasal.ValueMember = "id_stasiun";
            cmbasal.SelectedIndex = -1;

            db.crud("SELECT * FROM t_stasiun");

            cmbtujuan.DataSource = db.ds.Tables[0];
            cmbtujuan.DisplayMember = "nama_stasiun";
            cmbtujuan.ValueMember = "id_stasiun";
            cmbtujuan.SelectedIndex = -1;

            dttanggal.Format = DateTimePickerFormat.Short;

            dtberangkat.Format = DateTimePickerFormat.Custom;
            dtberangkat.CustomFormat = "HH:mm";
            dtberangkat.ShowUpDown = true;

            dttiba.Format = DateTimePickerFormat.Custom;
            dttiba.CustomFormat = "HH:mm";
            dttiba.ShowUpDown = true;

            txtkursi.ReadOnly = true;

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

            cmbkereta.KeyDown += PindahDenganEnter;
            cmbkelas.KeyDown += PindahDenganEnter;
            cmbasal.KeyDown += PindahDenganEnter;
            cmbtujuan.KeyDown += PindahDenganEnter;
            dttanggal.KeyDown += PindahDenganEnter;
            dtberangkat.KeyDown += PindahDenganEnter;
            dttiba.KeyDown += PindahDenganEnter;
            txtharga.KeyDown += PindahDenganEnter;

            cmbkereta.SelectedIndexChanged += cmbkereta_SelectedIndexChanged;

            tampildata();
            bersih();
        }
    }
}
