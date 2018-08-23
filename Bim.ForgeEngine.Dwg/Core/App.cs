using Bimangle.ForgeEngine.Dwg;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Bimcc.BimEngine.Dwg
{
    class App
    {
        public const string CLIENT_ID = @"BimAngle";
        public const string APP_NAME = @"BimAngle Forge Engine Dwg - Examples";

        public static LicenseSession CreateLicenseSession(string licenseKey = null)
        {
            LicenseSession.Init();

            return new LicenseSession(CLIENT_ID, APP_NAME, licenseKey);
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
                @"Bimangle.ForgeEngine.Dwg");
            return path;
        }

        public static void ShowLicenseDialog(LicenseSession session, IWin32Window parent)
        {
            LicenseSession.ShowLicenseDialog(session.ClientId, session.AppName, parent);
        }

        public static void ShowLicenseDialog(IWin32Window parent)
        {
            LicenseSession.ShowLicenseDialog(CLIENT_ID, APP_NAME, parent);
        }

        public static string GetFontFolderPath()
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);

            return Path.Combine(folderPath, @"Fonts");
        }
    }
}
