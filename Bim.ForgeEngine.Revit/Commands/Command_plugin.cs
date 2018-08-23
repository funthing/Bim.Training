using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Bimcc.BimEngine.Revit.UI;

namespace Bimcc.BimEngine.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    class Command_plugin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            new Plugin_manage().ShowDialog();
            return Result.Succeeded;
        }
    }
}
