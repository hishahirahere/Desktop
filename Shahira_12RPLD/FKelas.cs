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
    public partial class FKelas : Form
    {
        public FKelas()
        {
            InitializeComponent();
        }
        public void bersih()
        {
            txtkelas.Text = "";
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_kelas");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_kelas"];
                string kelas = "" + baris["nama_kelas"];
                dataGridView1.Rows.Add(id, kelas);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string kelas = txtkelas.Text;
            db.crud($"INSERT INTO t_kelas VALUES(null,'{kelas}');");
            bersih();
            tampildata();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string kelas = txtkelas.Text;
            string idkelas = nomoR.Text;
            db.crud($"UPDATE t_kelas SET nama_kelas = '{kelas}' where id_kelas = '{idkelas}'");
            bersih();
            tampildata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = dataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 2)
            {
                db.crud($"SELECT * FROM t_kelas  WHERE id_kelas = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_kelas"];
                    string role = "" + bariss["nama_kelas"];
                    nomoR.Text = id;
                    txtkelas.Text = role;
                }

            }

            if (kolom == 3)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_kelas WHERE id_kelas = '{idnya}' ");
                    tampildata();
                }
            }
        }
    }
}
