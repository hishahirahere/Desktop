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
    public partial class FStasiun : Form
    {
        public FStasiun()
        {
            InitializeComponent();
        }
        public void bersih()
        {
            txtkdstasiun.Text = "";
            txtnmstasiun.Text = "";
            txtkota.Text = "";
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_stasiun");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_stasiun"];
                string kode = "" + baris["kode_stasiun"];
                string nm = "" + baris["nama_stasiun"];
                string kota = "" + baris["kota"];
                dataGridView1.Rows.Add(id, kode, nm,kota);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kode = txtkdstasiun.Text;
            string nm = txtnmstasiun.Text;
            string kota = txtkota.Text;
            db.crud($"INSERT INTO t_stasiun VALUES(null,'{kode}','{nm}','{kota}');");
            bersih();
            tampildata();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kode = txtkdstasiun.Text;
            string nm = txtnmstasiun.Text;
            string kota = txtkota.Text;
            string idstasiun = nomor.Text;
            db.crud($"UPDATE t_stasiun SET kode_stasiun = '{kode}', nama_stasiun = '{nm}', kota = '{kota}' where id_stasiun = '{idstasiun}'");
            bersih();
            tampildata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = dataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 4)
            {
                db.crud($"SELECT * FROM t_stasiun  WHERE id_stasiun = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_stasiun"];
                    string kode = "" + bariss["kode_stasiun"];
                    string nm = "" + bariss["nama_stasiun"];
                    string kota = "" + bariss["kota"];

                    nomor.Text = id;
                    txtkdstasiun.Text = kode;
                    txtnmstasiun.Text = nm;
                    txtkota.Text = kota;
                }

            }

            if (kolom == 5)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_stasiun WHERE id_stasiun = '{idnya}' ");
                    tampildata();
                }

            }
        }
    }
}
