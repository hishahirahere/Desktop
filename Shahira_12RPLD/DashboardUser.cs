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
    }
}
