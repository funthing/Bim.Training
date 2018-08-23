using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Bimcc.BimEngine.Revit.UI;
using static Bimcc.BimEngine.Revit.UI.Login;

namespace Bimcc.BimEngine.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command_setting : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            new Setting().ShowDialog();

            return Result.Succeeded;
        }
    }

}
