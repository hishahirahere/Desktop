using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    public partial class FUser : Form
    {
        private readonly Color WARNA_BIRU =
            Color.FromArgb(37, 99, 235);

        private readonly Color WARNA_BIRU_MUDA =
            Color.FromArgb(239, 246, 255);

        private readonly Color WARNA_TEKS_GELAP =
            Color.FromArgb(30, 41, 59);

        private string passwordLama = "";

        public FUser()
        {
            InitializeComponent();
        }

        private void FUser_Load(object sender, EventArgs e)
        {
            db.crud("SELECT * FROM t_role");

            cmbrole.DataSource =
                db.ds.Tables[0];

            cmbrole.DisplayMember =
                "nama_role";

            cmbrole.ValueMember =
                "id_role";

            cmbrole.SelectedIndex = -1;

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

            SetupTabel();

            txtuser.Focus();
        }

        public static string MD5Hash(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes =
                    Encoding.ASCII.GetBytes(text);

                byte[] hashBytes =
                    md5.ComputeHash(inputBytes);

                StringBuilder sb =
                    new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(
                        b.ToString("x2")
                    );
                }

                return sb.ToString();
            }
        }

        private void SetupTabel()
        {
            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.BackgroundColor =
                Color.White;

            dataGridView1.RowHeadersVisible =
                false;

            dataGridView1.AllowUserToAddRows =
                false;

            dataGridView1.AllowUserToResizeRows =
                false;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect =
                false;

            dataGridView1.RowTemplate.Height =
                36;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor =
                WARNA_BIRU;

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Bold
                );

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersHeight =
                40;

            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dataGridView1.DefaultCellStyle.ForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    9F
                );

            dataGridView1.DefaultCellStyle.BackColor =
                Color.White;

            dataGridView1.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(249, 250, 251);

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionBackColor =
                WARNA_BIRU_MUDA;

            dataGridView1.AlternatingRowsDefaultCellStyle.SelectionForeColor =
                WARNA_TEKS_GELAP;

            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dataGridView1.GridColor =
                Color.FromArgb(229, 231, 235);
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

            // Password lama dikosongkan
            passwordLama = "";

            txtuser.Focus();
        }

        public void tampildata()
        {
            dataGridView1.Rows.Clear();

            db.crud(
                "SELECT t_users.id_users, " +
                "t_users.username, " +
                "t_users.nama_lengkap, " +
                "t_users.email, " +
                "t_users.no_hp, " +
                "t_users.alamat, " +
                "t_role.nama_role " +
                "FROM t_users " +
                "LEFT JOIN t_role " +
                "ON t_users.id_role = t_role.id_role"
            );

            foreach (DataRow baris in db.ds.Tables[0].Rows)
            {
                string id =
                    "" + baris["id_users"];

                string user =
                    "" + baris["username"];

                string nm =
                    "" + baris["nama_lengkap"];

                string email =
                    "" + baris["email"];

                string no_hp =
                    "" + baris["no_hp"];

                string alamat =
                    "" + baris["alamat"];

                // TAMPILKAN NAMA ROLE
                string role =
                    "" + baris["nama_role"];

                dataGridView1.Rows.Add(
                    id,
                    user,
                    nm,
                    email,
                    no_hp,
                    alamat,
                    role
                );
            }
        }

        private void guna2Button1_Click(
            object sender,
            EventArgs e)
        {
            if (cmbrole.SelectedIndex == -1 ||
                cmbrole.SelectedValue == null)
            {
                MessageBox.Show(
                    "Silakan pilih role terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbrole.Focus();
                return;
            }

            string user =
                txtuser.Text;

            string pass =
                txtpass.Text;

            string nm =
                txtnm.Text;

            string email =
                txtemail.Text;

            string no_hp =
                txtnohp.Text;

            string alamat =
                txtalamat.Text;

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show(
                    "Password harus diisi.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtpass.Focus();
                return;
            }

            string passMD5 =
                MD5Hash(pass);

            string role =
                cmbrole.SelectedValue.ToString();

            db.crud(
                $"INSERT INTO t_users " +
                $"VALUES(null," +
                $"'{user}'," +
                $"'{passMD5}'," +
                $"'{nm}'," +
                $"'{email}'," +
                $"'{no_hp}'," +
                $"'{alamat}'," +
                $"'{role}');"
            );

            MessageBox.Show(
                "Data user berhasil ditambahkan.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            bersih();
            tampildata();
        }

        private void guna2Button2_Click_2(
            object sender,
            EventArgs e)
        {
            if (cmbrole.SelectedIndex == -1 ||
                cmbrole.SelectedValue == null)
            {
                MessageBox.Show(
                    "Silakan pilih role terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbrole.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(nomor.Text))
            {
                MessageBox.Show(
                    "Pilih data user yang ingin diubah terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string user =
                txtuser.Text;

            string nm =
                txtnm.Text;

            string email =
                txtemail.Text;

            string no_hp =
                txtnohp.Text;

            string alamat =
                txtalamat.Text;

            string role =
                cmbrole.SelectedValue.ToString();

            string idu =
                nomor.Text;

            string passMD5;

            // Kalau password tidak diubah
            // gunakan password lama
            if (string.IsNullOrWhiteSpace(txtpass.Text))
            {
                passMD5 =
                    passwordLama;
            }
            else
            {
                // Kalau password baru diisi
                // MD5 password baru
                passMD5 =
                    MD5Hash(txtpass.Text);
            }

            db.crud(
                $"UPDATE t_users SET " +
                $"username = '{user}', " +
                $"password = '{passMD5}', " +
                $"nama_lengkap = '{nm}', " +
                $"email = '{email}', " +
                $"no_hp = '{no_hp}', " +
                $"alamat = '{alamat}', " +
                $"id_role = '{role}' " +
                $"WHERE id_users = '{idu}'"
            );

            MessageBox.Show(
                "Data user berhasil diubah.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            bersih();
            tampildata();
        }

        private void guna2Button3_Click_1(
            object sender,
            EventArgs e)
        {
            tampildata();
        }

        private void dataGridView1_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Rows[e.RowIndex]
                .Cells[0].Value == null)
            {
                return;
            }

            int baris =
                e.RowIndex;

            int kolom =
                e.ColumnIndex;

            string idnya =
                dataGridView1.Rows[baris]
                .Cells[0]
                .Value
                .ToString();

            if (kolom == 7)
            {
                db.crud(
                    $"SELECT * FROM t_users " +
                    $"WHERE id_users = '{idnya}'"
                );

                foreach (
                    DataRow bariss
                    in db.ds.Tables[0].Rows)
                {
                    string id =
                        "" + bariss["id_users"];

                    string user =
                        "" + bariss["username"];

                    string pass =
                        "" + bariss["password"];

                    string nm =
                        "" + bariss["nama_lengkap"];

                    string email =
                        "" + bariss["email"];

                    string no_hp =
                        "" + bariss["no_hp"];

                    string alamat =
                        "" + bariss["alamat"];

                    string role =
                        "" + bariss["id_role"];

                    nomor.Text =
                        id;
                    txtuser.Text =
                        user;

                    txtnm.Text =
                        nm;

                    txtemail.Text =
                        email;

                    txtnohp.Text =
                        no_hp;

                    txtalamat.Text =
                        alamat;

                    passwordLama =
                        pass;

                    txtpass.Text = "";

                    cmbrole.SelectedValue =
                        role;
                }

                txtuser.Focus();
            }

            if (kolom == 8)
            {
                DialogResult ya =
                    MessageBox.Show(
                        "apakah ingin menghapus data?",
                        "pemberitahuan",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                if (ya == DialogResult.Yes)
                {
                    db.crud(
                        $"DELETE FROM t_users " +
                        $"WHERE id_users = '{idnya}'"
                    );

                    bersih();
                    tampildata();
                }
            }
        }

        private void PindahDenganEnter(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;

            if (sender == txtuser)
            {
                txtpass.Focus();
            }

            else if (sender == txtpass)
            {
                txtnm.Focus();
            }

            else if (sender == txtnm)
            {
                txtemail.Focus();
            }

            else if (sender == txtemail)
            {
                txtnohp.Focus();
            }

            // =========================
            // NO HP
            // =========================
            else if (sender == txtnohp)
            {
                txtalamat.Focus();
            }

            else if (sender == txtalamat)
            {
                cmbrole.Focus();
            }

            else if (sender == cmbrole)
            {
                // Role belum dipilih
                if (cmbrole.SelectedIndex == -1 ||
                    cmbrole.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Silakan pilih role terlebih dahulu.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbrole.DroppedDown = true;

                    return;
                }

                if (nomor.Text == "")
                {
                    guna2Button1.PerformClick();
                }

                else
                {
                    guna2Button2.PerformClick();
                }
            }
        }
    }
}