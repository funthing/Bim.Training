using Bimangle.ForgeEngine.Revit;
using Bimangle.Libs.License.Types;
using Bimcc.BimEngine.Revit.Utility;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.UI
{
    public partial class Setting : Form
    {
        public static Label plugin;
        public static Label platform;


        public Setting()
        {
            InitializeComponent();
            plugin = label_plugin;
            platform = label_platform;
        }

        public LicenseInfo Check_export_licence()
        {
            return LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", Application.licenseKey);
        }

        private void label_plugin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Plugin_manage().ShowDialog();
        }

        private void label_platform_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseInfo licenseInfo = LicenseSession.GetLicenseInfo("Bimcc", "Bimcc.BimEngine", Application.licenseKey);

            if (licenseInfo.IsActivated)
            {
                new Platform_check().ShowDialog();
            }
            else
            {
                Tools.ShowMessageBox("请先对轻量化插件授权");
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            if (Check_export_licence().IsActivated)
            {
                label_plugin.Text = "已授权";
            }
            else
            {
                label_plugin.Text = "未授权";
            }

            var key = Tools.GetSetting("platform_check");
            if (key != null)
            {
                if (key == "true")
                {
                    label_platform.Text = "已授权";
                }
                else
                {
                    label_platform.Text = "未授权";
                }
            }
        }
    }
}
