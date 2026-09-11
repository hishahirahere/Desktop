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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FUser DataUser = new FUser() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataUser, pnlcontent);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            pnlcontent.Controls.Clear();
            pnlcontent.Controls.Add(pnldashboard);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FRole DataRole = new FRole() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataRole, pnlcontent);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FKereta DataKereta = new FKereta() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataKereta, pnlcontent);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            FStasiun DataStasiun = new FStasiun() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataStasiun, pnlcontent);
        }

        private void label12_Click(object sender, EventArgs e)
        {
            FKelas DataKelas = new FKelas() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataKelas, pnlcontent);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FJadwalKereta DataJKereta = new FJadwalKereta() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataJKereta, pnlcontent);
        }

        private void label14_Click(object sender, EventArgs e)
        {
            FDataPemesanan DataPesanan = new FDataPemesanan() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataPesanan, pnlcontent);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            FTPembayaran DataPembayaran = new FTPembayaran() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(DataPembayaran, pnlcontent);
        }
    }
}
