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
    public partial class DashboardUser : Form
    {
        public DashboardUser()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FCariJadwal Cari = new FCariJadwal() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(Cari, pnlcontent);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            pnlcontent.Controls.Clear();
            pnlcontent.Controls.Add(pnldashboard);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            FPembayaran Cari = new FPembayaran() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(Cari, pnlcontent);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FProfile profile = new FProfile() { TopLevel = false, TopMost = true };
            KFKereta.formkereta(profile, pnlcontent);
        }
    }
}
