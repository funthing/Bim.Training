using System.Reflection;
using Autodesk.Revit.UI;
using Bimcc.BimEngine.Revit.Properties;
using Bimcc.BimEngine.Revit.Utility;

namespace Bimcc.BimEngine.Revit
{
    class Application : IExternalApplication
    {
        public static string licenseKey = string.Empty;

        public Result OnStartup(UIControlledApplication application)
        {
            licenseKey = Tools.GetLicenseKey();

            string Assembly_path = Assembly.GetExecutingAssembly().Location;

            application.CreateRibbonTab("轻量化与上传");

            RibbonPanel BimccRibbon = application.CreateRibbonPanel("轻量化与上传", "BIMCC Export");

            (BimccRibbon.AddItem(new PushButtonData("export", "模型轻量化", Assembly_path, "Bimcc.BimEngine.Revit.Commands.Command")) as PushButton).LargeImage = Tools.GetImage(Resources.home.GetHbitmap());

            (BimccRibbon.AddItem(new PushButtonData("setting", "应用授权", Assembly_path, "Bimcc.BimEngine.Revit.Commands.Command_setting")) as PushButton).LargeImage = Tools.GetImage(Resources.setting.GetHbitmap());

            (BimccRibbon.AddItem(new PushButtonData("user", "用户信息", Assembly_path, "Bimcc.BimEngine.Revit.Commands.Command_user")) as PushButton).LargeImage = Tools.GetImage(Resources.user.GetHbitmap());

            (BimccRibbon.AddItem(new PushButtonData("platform", "BIM应用中心", Assembly_path, "Bimcc.BimEngine.Revit.Commands.Command_platform")) as PushButton).LargeImage = Tools.GetImage(Resources.platform.GetHbitmap());

            (BimccRibbon.AddItem(new PushButtonData("about", "关于我们", Assembly_path, "Bimcc.BimEngine.Revit.Commands.Command_about")) as PushButton).LargeImage = Tools.GetImage(Resources.about.GetHbitmap());

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application) => Result.Succeeded;
    }
}
