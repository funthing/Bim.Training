using Bimangle.ForgeEngine.Navisworks;
using Bimangle.Libs.License.Types;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Navisworks.UI
{
    public partial class Submit : Form
    {
        public Submit()
        {
            InitializeComponent();
        }

        private void Log_setting_Load(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("BIMCC", "BIMCC.BIMEngine");

            textbox_HardwareId.Text = licenseInfo.HardwareId.ToString();

            Check_export_licence();
        }

        private void button_submit_Click(object sender, EventArgs e)
        {

        }

        public void Check_export_licence()
        {
            var file_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Bimcc.BimEngine.lic";

            LicenseInfo licenseInfo = new LicenseInfo();

            if (File.Exists(file_path))
            {
                string LicenseKey = LicenseSession.LoadLicenseKeyFromFile(file_path);

                licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", LicenseKey);
            }
            else
            {
                licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine");
            }

            if (licenseInfo.IsActivated)
            {
                textBox_company.Enabled = false; textBox_data.Enabled = false;

                textBox_mail.Enabled = false; textbox_HardwareId.Enabled = false;

                textbox_HardwareId.BackColor = Color.MediumSpringGreen;
            }
        }

        public void Check_user_licence()
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Submit_Load(object sender, EventArgs e)
        {

        }
    }
}
