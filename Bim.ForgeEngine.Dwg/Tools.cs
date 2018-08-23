using System;
using System.IO;
using System.Windows;

namespace Bimcc.BimEngine.Dwg
{
    class Tools
    {        
        public static void DeployLicenseFile(byte[] buffer)
        {
            var versions = new[] { "2014", "2015", "2016", "2017", "2018" };

            var programDataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            var revitAddinsPath = Path.Combine(programDataPath, @"Autodesk", @"Revit", @"Addins");
            if (Directory.Exists(revitAddinsPath) == false) return;

            foreach (var version in versions)
            {
                var path = Path.Combine(revitAddinsPath, version);
                if (Directory.Exists(path))
                {
                    var licFilePath = Path.Combine(path, "Bimcc.BimEngine.lic");
                    File.WriteAllBytes(licFilePath, buffer);
                }
            }
        }

    }
}
