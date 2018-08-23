using System.Diagnostics;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Navisworks.UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27) { Close(); return; }
        }

        private void linkLabel_company_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.bimcc.cn/");
        }
    }
}
