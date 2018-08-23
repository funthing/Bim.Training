using System;
using System.Collections.Generic;
using System.Linq;
using Bimangle.ForgeEngine.Revit.Core;

namespace Bimcc.BimEngine.Revit.Config
{
    [Serializable]
    class AppLocalConfig
    {
        public string LastTargetPath { get; set; }

        public string VisualStyle { get; set; }

        public int LevelOfDetail { get; set; }

        public List<FeatureType> Features { get; set; }

        public AppLocalConfig()
        {
            LastTargetPath = string.Empty;
            VisualStyle = null;
            LevelOfDetail = -1;
            Features = new List<FeatureType>();
        }

        public AppLocalConfig Clone()
        {
            return new AppLocalConfig
            {
                LastTargetPath = LastTargetPath,
                VisualStyle = VisualStyle,
                LevelOfDetail = LevelOfDetail,
                Features = Features?.ToList() ?? new List<FeatureType>()
            };
        }
    }
}
