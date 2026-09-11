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
    public partial class FUser : Form
    {
        public FUser()
        {
            InitializeComponent();
        }
        public void bersih()
        {
            txtuser.Text = "";
            txtpass.Text = "";
            txtnm.Text = "";
            txtemail.Text = "";
            txtnohp.Text = "";
            txtalamat.Text = "";
            cmbrole.SelectedIndex = -1;
            nomor.Text = "";

            txtuser.Focus();
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();
            db.crud("SELECT * FROM t_users");
            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id = "" + baris["id_users"];
                string user = "" + baris["username"];
                string nm = "" + baris["nama_lengkap"];
                string email = "" + baris["email"];
                string no_hp = "" + baris["no_hp"];
                string alamat = "" + baris["alamat"];
                string role = "" + baris["id_role"];
                dataGridView1.Rows.Add(id, user, nm, email, no_hp, alamat, role);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            string nm = txtnm.Text;
            string email = txtemail.Text;
            string no_hp = txtnohp.Text;
            string alamat = txtalamat.Text;
            string role = cmbrole.SelectedValue.ToString();
            db.crud($"INSERT INTO t_users VALUES(null,'{user}','{pass}','{nm}','{email}','{no_hp}','{alamat}','{role}');");
            bersih();
            tampildata();
        }

        private void guna2Button2_Click_2(object sender, EventArgs e)
        {
            string user = txtuser.Text;
            string pass = txtpass.Text;
            string nm = txtnm.Text;
            string email = txtemail.Text;
            string no_hp = txtnohp.Text;
            string alamat = txtalamat.Text;
            string role = cmbrole.SelectedValue.ToString();
            string idu = nomor.Text;
            db.crud($"UPDATE t_users SET username = '{user}', password = '{pass}', nama_lengkap = '{nm}', email = '{email}', no_hp = '{no_hp}', alamat = '{alamat}', id_role = '{role}' where id_users = '{idu}'");
            bersih();
            tampildata();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            tampildata();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            int kolom = e.ColumnIndex;
            string idnya = dataGridView1.Rows[baris].Cells[0].Value.ToString();
            if (kolom == 7)
            {
                db.crud($"SELECT * FROM t_users  WHERE id_users = '{idnya}'");
                foreach (DataRow bariss in db.ds.Tables[0].Rows)
                {
                    string id = "" + bariss["id_users"];
                    string user = "" + bariss["username"];
                    string pass = "" + bariss["password"];
                    string nm = "" + bariss["nama_lengkap"];
                    string email = "" + bariss["email"];
                    string no_hp = "" + bariss["no_hp"];
                    string alamat = "" + bariss["alamat"];
                    string role = bariss["id_role"].ToString();

                    nomor.Text = id;
                    txtuser.Text = user;
                    txtpass.Text = pass;
                    txtnm.Text = nm;
                    txtemail.Text = email;
                    txtnohp.Text = no_hp;
                    txtalamat.Text = alamat;

                    cmbrole.SelectedValue = role;
                }

            }

            if (kolom == 8)
            {
                DialogResult ya = MessageBox.Show("apakah ingin menghapus data?", "pemberitahuan", MessageBoxButtons.YesNo);
                if (ya == DialogResult.Yes)
                {
                    db.crud($"DELETE FROM t_users WHERE id_users = '{idnya}' ");
                    tampildata();
                }

            }
        }

        private void PindahDenganEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (sender == cmbrole)
                {
                    guna2Button1.PerformClick();
                }
                else
                {
                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
        }
        private void FUser_Load(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM t_role");

            cmbrole.DataSource = db.ds.Tables[0];
            cmbrole.DisplayMember = "nama_role";
            cmbrole.ValueMember = "id_role";

            txtuser.TabIndex = 0;
            txtpass.TabIndex = 1;
            txtnm.TabIndex = 2;
            txtemail.TabIndex = 3;
            txtnohp.TabIndex = 4;
            txtalamat.TabIndex = 5;
            cmbrole.TabIndex = 6;
            guna2Button1.TabIndex = 7;

            txtuser.KeyDown += PindahDenganEnter;
            txtpass.KeyDown += PindahDenganEnter;
            txtnm.KeyDown += PindahDenganEnter;
            txtemail.KeyDown += PindahDenganEnter;
            txtnohp.KeyDown += PindahDenganEnter;
            txtalamat.KeyDown += PindahDenganEnter;
            cmbrole.KeyDown += PindahDenganEnter;

            txtuser.Focus();
        }

    }
 }
