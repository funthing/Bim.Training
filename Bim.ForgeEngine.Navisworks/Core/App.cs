using Bimangle.ForgeEngine.Navisworks;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Navisworks.Core
{
    static class App
    {
        public const string CLIENT_ID = @"BimAngle";
        public const string PRODUCT_NAME = @"Forge Engine Samples";

        public static LicenseSession CreateSession()
        {
            return new LicenseSession(CLIENT_ID, PRODUCT_NAME);
        }

        public static void ShowLicenseDialog(IWin32Window parent = null)
        {
            LicenseSession.ShowLicenseDialog(CLIENT_ID, PRODUCT_NAME, parent);
        }

        /// <summary>
        /// 获得主路径
        /// </summary>
        /// <returns></returns>
        public static string GetHomePath()
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                @"Bimangle",
                @"Bimcc.BimEngine.Navisworks");

            if (Directory.Exists(path))
            {
                //do nothing
            }
            else
            {
                path = Assembly.GetExecutingAssembly().Location;
            }

            return path;
        }
    }
}
