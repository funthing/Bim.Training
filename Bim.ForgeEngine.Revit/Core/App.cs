using Bimangle.ForgeEngine.Revit;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.Core
{
    static class App
    {
        public const string CLIENT_ID = @"BimAngle";
        public const string PRODUCT_NAME = @"Forge Engine Samples";

        public static LicenseSession CreateSession(string licenseKey = null)
        {
            return new LicenseSession(CLIENT_ID, PRODUCT_NAME, licenseKey);
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
                @"Bimcc.BimEngine.Revit");

            if (Directory.Exists(path))
            {
                return path;
            }

            return Assembly.GetExecutingAssembly().Location;
        }
    }
}
