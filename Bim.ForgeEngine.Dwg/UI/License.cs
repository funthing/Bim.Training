using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bimangle.ForgeEngine.Dwg;
using Bimangle.Libs.License.Types;
using Bimcc.BimEngine.Dwg.Utility;

namespace Bimcc.BimEngine.Dwg.UI
{
    public partial class License : Form
    {
        public static string LicenseKey;

        public License()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void License_Load(object sender, EventArgs e)
        {
            var filename = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Bimcc.BimEngine.lic";

            if (File.Exists(filename))
            {
                LicenseKey = LicenseSession.LoadLicenseKeyFromFile(filename);

                File.WriteAllText(@"C:\Users\Administrator\Desktop\error.txt", LicenseKey);

                LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", LicenseKey);

                textBox1.Text = "Bimcc.BimEngine.Revit";
                textBox2.Text = licenseInfo.ProductVersion.ToString();
                textBox3.Text = licenseInfo.ReleaseDate.ToString();
                textBox4.Text = licenseInfo.IsActivated.ToString();
                textBox5.Text = licenseInfo.LicenseMode.ToString();
                textBox6.Text = licenseInfo.LicenseStatus.ToString();
                textBox7.Text = licenseInfo.HardwareId.ToString();
                textBox8.Text = licenseInfo.ClientName.ToString();
                textBox9.Text = licenseInfo.LicenseExpiration.ToString();
                textBox10.Text = licenseInfo.SubscriptionExpiration.ToString();
                if (licenseInfo.IsActivated == false)
                {
                    textBox4.BackColor = Color.OrangeRed;
                    textBox5.BackColor = Color.OrangeRed;
                    textBox6.BackColor = Color.OrangeRed;
                    textBox3.BackColor = Color.OrangeRed;
                    textBox9.BackColor = Color.OrangeRed;
                    textBox10.BackColor = Color.OrangeRed;
                    button_ok.Enabled = false;
                }
                else
                {
                    button_ok.Enabled = true;
                    textBox4.BackColor = Color.MediumSpringGreen;
                    textBox5.BackColor = Color.MediumSpringGreen;
                    textBox6.BackColor = Color.MediumSpringGreen;
                    textBox3.BackColor = Color.WhiteSmoke;
                    textBox9.BackColor = Color.WhiteSmoke;
                    textBox10.BackColor = Color.WhiteSmoke;
                }

            }
            else
            {
                LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine");

                textBox1.Text = "Bimcc.BimEngine.Revit";
                textBox2.Text = licenseInfo.ProductVersion.ToString();
                textBox3.Text = licenseInfo.ReleaseDate.ToString();
                textBox4.Text = licenseInfo.IsActivated.ToString();
                textBox5.Text = licenseInfo.LicenseMode.ToString();
                textBox6.Text = licenseInfo.LicenseStatus.ToString();
                textBox7.Text = licenseInfo.HardwareId.ToString();
                textBox8.Text = licenseInfo.ClientName.ToString();
                textBox9.Text = licenseInfo.LicenseExpiration.ToString();
                textBox10.Text = licenseInfo.SubscriptionExpiration.ToString();
                if (licenseInfo.IsActivated == false)
                {
                    textBox4.BackColor = Color.OrangeRed;
                    textBox5.BackColor = Color.OrangeRed;
                    textBox6.BackColor = Color.OrangeRed;
                    textBox3.BackColor = Color.OrangeRed;
                    textBox9.BackColor = Color.OrangeRed;
                    textBox10.BackColor = Color.OrangeRed;
                    button_ok.Enabled = false;
                }
                else
                {
                    button_ok.Enabled = true;
                    textBox4.BackColor = Color.MediumSpringGreen;
                    textBox5.BackColor = Color.MediumSpringGreen;
                    textBox6.BackColor = Color.MediumSpringGreen;
                    textBox3.BackColor = Color.WhiteSmoke;
                    textBox9.BackColor = Color.WhiteSmoke;
                    textBox10.BackColor = Color.WhiteSmoke;
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "授权文件(*.lic)|*.lic|所有文件(*.*)|*.*";

            openFileDialog.FileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null)
                {
                    var path = Path.GetFullPath(openFileDialog.FileName);

                    string LicenseKey = LicenseSession.LoadLicenseKeyFromFile(path);

                    File.WriteAllText(@"C:\Users\Administrator\Desktop\error.txt", LicenseKey);

                    LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", LicenseKey);

                    textBox1.Text = "Bimcc.BimEngine.Revit";
                    textBox2.Text = licenseInfo.ProductVersion.ToString();
                    textBox3.Text = licenseInfo.ReleaseDate.ToString();
                    textBox4.Text = licenseInfo.IsActivated.ToString();
                    textBox5.Text = licenseInfo.LicenseMode.ToString();
                    textBox6.Text = licenseInfo.LicenseStatus.ToString();
                    textBox7.Text = licenseInfo.HardwareId.ToString();
                    textBox8.Text = licenseInfo.ClientName.ToString();
                    textBox9.Text = licenseInfo.LicenseExpiration.ToString();
                    textBox10.Text = licenseInfo.SubscriptionExpiration.ToString();

                    if (licenseInfo.IsActivated == false)
                    {
                        textBox4.BackColor = Color.OrangeRed;
                        textBox5.BackColor = Color.OrangeRed;
                        textBox6.BackColor = Color.OrangeRed;
                        textBox3.BackColor = Color.OrangeRed;
                        textBox9.BackColor = Color.OrangeRed;
                        textBox10.BackColor = Color.OrangeRed;
                        button_ok.Enabled = false;
                    }
                    else
                    {
                        button_ok.Enabled = true;
                        textBox4.BackColor = Color.MediumSpringGreen;
                        textBox5.BackColor = Color.MediumSpringGreen;
                        textBox6.BackColor = Color.MediumSpringGreen;
                        textBox3.BackColor = Color.WhiteSmoke;
                        textBox9.BackColor = Color.WhiteSmoke;
                        textBox10.BackColor = Color.WhiteSmoke;
                    }
                }
            }

        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                var buffer = File.ReadAllBytes(Path.GetFullPath(openFileDialog.FileName));

                Tools.DeployLicenseFile(buffer);

                this.Close();
            }
            catch (Exception) { this.Close(); }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
