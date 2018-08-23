using System;
using System.Windows.Forms;
using Bimcc.BimEngine.Dwg.Config;
using Bimcc.BimEngine.Dwg.UI;

namespace Bimcc.BimEngine.Dwg
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Login.LoginSuccess)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var appConfig = AppConfigManager.Load();
                Application.Run(new FormAppXp(appConfig));
            }
            else
            {
                new Login().ShowDialog();
            }
        }
    }
}
