using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bimangle.ForgeEngine.Navisworks;
using Bimangle.Libs.License.Types;
using Bimcc.BimEngine.Navisworks.Utility;

namespace Bimcc.BimEngine.Navisworks.UI
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            var filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Bimcc.BimEngine.lic";

            string LicenseKey = string.Empty;

            LicenseInfo licenseInfo = new LicenseInfo();

            if (File.Exists(filename))
            {
                LicenseKey = LicenseSession.LoadLicenseKeyFromFile(filename);
            }

            licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", LicenseKey);

            Fresh(licenseInfo);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "授权文件(*.lic)|*.lic|所有文件(*.*)|*.*";

            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path_file = Path.GetFullPath(openFileDialog.FileName);

                string LicenseKey = LicenseSession.LoadLicenseKeyFromFile(path_file);

                LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", LicenseKey);

                Fresh(licenseInfo);
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Write();

            Close();
        }

        public void Write()
        {
            if (openFileDialog.FileName == null)
            {
                //do nothing
            }
            else
            {
                var buffer = File.ReadAllBytes(Path.GetFullPath(openFileDialog.FileName));

                var licensePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Bimcc.BimEngine.lic";

                File.WriteAllBytes(licensePath, buffer);
            }
        }

        public void Fresh(LicenseInfo licenseInfo)
        {
            textBox1.Text = "Bimcc.BimEngine.Revit";
            textBox2.Text = licenseInfo.ProductVersion.ToString();
            textBox3.Text = licenseInfo.ReleaseDate.ToLongDateString();
            textBox4.Text = licenseInfo.IsActivated.ToString();
            textBox5.Text = licenseInfo.LicenseMode.ToString();
            textBox6.Text = licenseInfo.LicenseStatus.ToString();
            textBox7.Text = licenseInfo.HardwareId.ToString();
            textBox8.Text = licenseInfo.ClientName.ToString();
            textBox9.Text = licenseInfo.LicenseExpiration.ToLongDateString();
            textBox10.Text = licenseInfo.SubscriptionExpiration.ToLongDateString();

            if (licenseInfo.IsActivated == false)
            {
                button_ok.Enabled = false;
                textBox4.BackColor = Color.Red;
                textBox5.BackColor = Color.Red;
                textBox6.BackColor = Color.Red;
            }
            else
            {
                button_ok.Enabled = true;
                textBox4.BackColor = Color.MediumSpringGreen;
                textBox5.BackColor = Color.MediumSpringGreen;
                textBox6.BackColor = Color.MediumSpringGreen;
            }
        }
    }
}
