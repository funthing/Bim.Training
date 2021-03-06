﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Bimcc.BimEngine.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bimcc.BimEngine.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    class Command_login : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (Login.LoginSuccess)
            {
                new User_info().ShowDialog();
            }
            else
            {
                new Login().ShowDialog();
            }

            return Result.Succeeded;
        }
    }
}
