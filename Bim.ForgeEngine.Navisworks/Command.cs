using Autodesk.Navisworks.Api.Plugins;
using Bimcc.BimEngine.Navisworks.Config;
using Bimcc.BimEngine.Navisworks.UI;

namespace Bimcc.BimEngine.Navisworks
{
    [Plugin("CustomRibbonCommandHandler", "ADSK", DisplayName = "Custom Ribbon")]
    [RibbonLayout("CustomRibbonBimcc.xaml")]
    [RibbonTab("ID_CustomTab_1", DisplayName = "轻量化")]
    [Command("ID_Button_1_Logo", DisplayName = "模型轻量化", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_2_License", DisplayName = "授权申请", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_3_Update", DisplayName = "检查更新", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_4_Video", DisplayName = "教学视频", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_5_Qq", DisplayName = "QQ支持", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_6_Bbs", DisplayName = "论坛", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_7_Home", DisplayName = "官方网站", ToolTip = "", ExtendedToolTip = "")]
    //[Command("ID_Button_8_Platform", DisplayName = "打开平台", ToolTip = "", ExtendedToolTip = "")]
    [Command("ID_Button_9_About", DisplayName = "关于我们", ToolTip = "", ExtendedToolTip = "")]

    public class CustomRibbonCommandHandler : CommandHandlerPlugin
    {
        public const string TITLE = @"Bimcc.BimEngine.Navisworks";

        public override int ExecuteCommand(string commandId, params string[] parameters)
        {
            switch (commandId)
            {
                case "ID_Button_1_Logo":

                    if (Login.LoginSuccess)
                    {
                        var mainWindow = Autodesk.Navisworks.Api.Application.Gui.MainWindow;

                        var appConfig = AppConfigManager.Load();

                        var dialog = new FormExportSvfzipXp(appConfig);

                        dialog.ShowDialog(mainWindow);
                    }
                    else
                    {
                        new Login().ShowDialog();
                    }

                    break;

                case "ID_Button_2_License":

                    new Submit().ShowDialog();

                    break;

                case "ID_Button_9_About":

                    new About().ShowDialog();

                    break;
            }

            return 0;
        }
    }
}




