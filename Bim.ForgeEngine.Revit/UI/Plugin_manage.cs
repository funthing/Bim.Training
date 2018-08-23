using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Bimangle.ForgeEngine.Revit;
using Bimangle.Libs.License.Types;
using Bimcc.BimEngine.Revit.Utility;

namespace Bimcc.BimEngine.Revit.UI
{
    public partial class Plugin_manage : Form
    {
        public Plugin_manage()
        {
            InitializeComponent();
        }

        private void License_Load(object sender, EventArgs e)
        {
            LicenseInfo licenseInfo = new LicenseInfo();

            if (Application.licenseKey.Length == 0)
            {
                Application.licenseKey = Tools.GetLicenseKey();
            }

            licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", Application.licenseKey);

            Fresh_form(licenseInfo);
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "授权文件(*.lic)|*.lic|所有文件(*.*)|*.*";

            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path_file = Path.GetFullPath(openFileDialog.FileName);

                Application.licenseKey = LicenseSession.LoadLicenseKeyFromFile(path_file);

                LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", Application.licenseKey);

                Fresh_form(licenseInfo);
            }
        }

        public void Fresh_form(LicenseInfo licenseInfo)
        {
            textBox1.Text = "Bimcc.BimEngine.Revit";
            textBox2.Text = licenseInfo.ProductVersion.ToString();
            textBox3.Text = licenseInfo.ReleaseDate.ToLongDateString();
            textBox4.Text = licenseInfo.IsActivated.ToString();
            textBox5.Text = licenseInfo.LicenseMode.ToString();
            textBox6.Text = licenseInfo.LicenseStatus;
            textBox7.Text = licenseInfo.HardwareId;
            textBox8.Text = licenseInfo.ClientName;
            textBox9.Text = licenseInfo.LicenseExpiration.ToLongDateString();
            textBox10.Text = licenseInfo.SubscriptionExpiration.ToLongDateString();

            if (licenseInfo.IsActivated == true)
            {
                button_ok.Enabled = true;
                textBox4.BackColor = Color.MediumSpringGreen;
                textBox5.BackColor = Color.MediumSpringGreen;
                textBox6.BackColor = Color.MediumSpringGreen;
                textBox3.BackColor = Color.WhiteSmoke;
                textBox9.BackColor = Color.WhiteSmoke;
                textBox10.BackColor = Color.WhiteSmoke;
            }
            else
            {
                button_ok.Enabled = false;
                textBox4.BackColor = Color.Red;
                textBox5.BackColor = Color.Red;
                textBox6.BackColor = Color.Red;
                textBox3.BackColor = Color.Red;
                textBox9.BackColor = Color.Red;
                textBox10.BackColor = Color.Red;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Move_file()
        {
            if (openFileDialog.FileName.Length > 0)
            {
                var buffer = File.ReadAllBytes(Path.GetFullPath(openFileDialog.FileName));

                File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Bimcc.BimEngine.lic"), buffer);
            }
        }

        private void Plugin_manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Move_file();

            var licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", Application.licenseKey);

            if (licenseInfo.IsActivated)
            {
                Setting.plugin.Text = "已授权";
            }
            else
            {
                Setting.plugin.Text = "未授权";
            }
        }
    }
}
