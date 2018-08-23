using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Bimcc.BimEngine.Revit.UI;

namespace Bimcc.BimEngine.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command_about : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            new About().ShowDialog();

            return Result.Succeeded;
        }
    }
}
