using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shahira_12RPLD
{
    class KFKereta
    {
        public static Form1 loginKerets = new Form1();
        public static dashboard admin = new dashboard();
        public static void formkereta(Form formappkereta, Panel pnlkereta)
        {
            pnlkereta.Controls.Clear();
            pnlkereta.Controls.Add(formappkereta);
            formappkereta.FormBorderStyle = FormBorderStyle.None;
            formappkereta.Dock = DockStyle.Fill;
            formappkereta.Show();
        }
    }
}