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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // =========================
            // ENTER
            // =========================
            TXTUSER.KeyDown += PindahDenganEnter;
            TXTPASS.KeyDown += PindahDenganEnter;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // =========================
        // MD5 PASSWORD
        // =========================
        public static string MD5Hash(string text)
        {
            MD5 md5 = MD5.Create();

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

        // =========================
        // LOGIN
        // =========================
        private void BTNLOGIN_Click(
            object sender,
            EventArgs e)
        {
            string pass =
                MD5Hash(TXTPASS.Text);

            db.crud(
                $"SELECT * FROM t_users " +
                $"WHERE username = '{TXTUSER.Text}' " +
                $"AND password = '{pass}'"
            );

            int cekjumlahbaris =
                db.ds.Tables[0].Rows.Count;

            if (cekjumlahbaris == 1)
            {
                int role =
                    Convert.ToInt32(
                        db.ds.Tables[0]
                        .Rows[0]["id_role"]
                    );

                db.idUserLogin =
                    db.ds.Tables[0]
                    .Rows[0]["id_users"]
                    .ToString();

                // =========================
                // ADMIN
                // =========================
                if (role == 1)
                {
                    dashboard admin =
                        new dashboard();

                    admin.Show();

                    this.Hide();
                }

                // =========================
                // USER
                // =========================
                else if (role == 2)
                {
                    DashboardUser user =
                        new DashboardUser();

                    user.Show();

                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show(
                    "Username / Password salah"
                );
            }
        }

        // =========================
        // ENTER
        // =========================
        private void PindahDenganEnter(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            // Supaya bunyi/beep Enter hilang
            e.SuppressKeyPress = true;

            // =========================
            // USERNAME
            // =========================
            if (sender == TXTUSER)
            {
                TXTPASS.Focus();
            }

            // =========================
            // PASSWORD
            // =========================
            else if (sender == TXTPASS)
            {
                BTNLOGIN.PerformClick();
            }
        }

        private void pictureBox5_Click(
            object sender,
            EventArgs e)
        {

        }
    }
}