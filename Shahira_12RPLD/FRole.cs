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
    public partial class FRole : Form
    {
        public FRole()
        {
            InitializeComponent();
        }
        public void bersih()
        {
            txtrole.Text = "";
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_role");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_role"];
                string role = "" + baris["nama_role"];
                dataGridView1.Rows.Add(id, role);
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string role = txtrole.Text;
            db.crud($"INSERT INTO t_role VALUES(null,'{role}');");
            bersih();
            tampildata();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tampildata();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string role = txtrole.Text;
            string idu = nomoR.Text;
            db.crud($"UPDATE t_role SET nama_role = '{role}' where id_role = '{idu}'");
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
                db.crud($"SELECT * FROM t_role  WHERE id_role = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_role"];
                    string role = "" + bariss["nama_role"];
                    nomoR.Text = id;
                    txtrole.Text = role;
                }

            }

            if (kolom == 3)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_role WHERE id_role = '{idnya}' ");
                    tampildata();
                }
            }
        }
    }
}
