using System.Diagnostics;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel_company_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.bimcc.cn/");
        }

        private void linkLabel_mail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(string.Format("mailto:{0}", linkLabel_mail.Text));
        }

        private void pictureBox_logo_Click(object sender, System.EventArgs e)
        {
            Process.Start("http://www.bimcc.cn/");
        }
    }
}
