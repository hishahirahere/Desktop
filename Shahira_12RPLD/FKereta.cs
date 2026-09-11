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
    public partial class FKereta : Form
    {
        public FKereta()
        {
            InitializeComponent();
        }
        public void bersih()
        {
            txtkdkereta.Text = "";
            txtnmkereta.Text = "";
            txtjnskereta.Text = "";
            txtkpskereta.Text = "";
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_kereta");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_kereta"];
                string kode = "" + baris["kode_kereta"];
                string nm = "" + baris["nama_kereta"];
                string jenis = "" + baris["jenis_kereta"];
                int kapasitas = Convert.ToInt32(baris["kapasitas"]);
                string kapasitasformat = kapasitas.ToString("N0");
                dataGridView1.Rows.Add(id, kode, nm, jenis, kapasitasformat);
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kode = txtkdkereta.Text;
            string nm = txtnmkereta.Text;
            string jenis = txtjnskereta.Text;
            string kapasitas = txtkpskereta.Text;
            db.crud($"INSERT INTO t_kereta VALUES(null,'{kode}','{nm}','{jenis}','{kapasitas}');");
            bersih();
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kode = txtkdkereta.Text;
            string nm = txtnmkereta.Text;
            string jenis = txtjnskereta.Text;
            string kapasitas = txtkpskereta.Text;
            string idkereta = nomor.Text;
            db.crud($"UPDATE t_kereta SET kode_kereta = '{kode}', nama_kereta = '{nm}', jenis_kereta = '{jenis}', kapasitas = '{kapasitas}' where id_kereta = '{idkereta}'");
            bersih();
            tampildata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = dataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 5)
            {
                db.crud($"SELECT * FROM t_kereta  WHERE id_kereta = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_kereta"];
                    string kode = "" + bariss["kode_kereta"];
                    string nm = "" + bariss["nama_kereta"];
                    string jenis = "" + bariss["jenis_kereta"];
                    string kapasitas = "" + bariss["kapasitas"];

                    nomor.Text = id;
                    txtkdkereta.Text = kode;
                    txtnmkereta.Text = nm;
                    txtjnskereta.Text = jenis;
                    txtkpskereta.Text = kapasitas;
                }

            }

            if (kolom == 6)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_kereta WHERE id_kereta = '{idnya}' ");
                    tampildata();
                }

            }
        }
    }
}
