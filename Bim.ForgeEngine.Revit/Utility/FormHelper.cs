﻿using System.Windows.Forms;

namespace Bimcc.BimEngine.Revit.Utility
{
    static class FormHelper
    {
        public static void ShowMessageBox(this Form form, string message)
        {
            MessageBox.Show(message, form.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
