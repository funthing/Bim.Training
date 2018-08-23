﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bimangle.ForgeEngine.Navisworks.Core;

namespace Bimcc.BimEngine.Navisworks.Config
{
    [Serializable]
    class AppLocalConfig
    {
        public string LastTargetPath { get; set; }

        public string VisualStyle { get; set; }

        public bool AutoOpenAllow { get; set; }

        public string AutoOpenAppName { get; set; }

        public List<FeatureType> Features { get; set; }

        public AppLocalConfig()
        {
            LastTargetPath = string.Empty;
            VisualStyle = null;
            AutoOpenAllow = true;
            AutoOpenAppName = null;
            Features = new List<FeatureType>();
        }

        public AppLocalConfig Clone()
        {
            return new AppLocalConfig
            {
                LastTargetPath = LastTargetPath,
                VisualStyle = VisualStyle,
                AutoOpenAllow = AutoOpenAllow,
                AutoOpenAppName = AutoOpenAppName,
                Features = Features?.ToList() ?? new List<FeatureType>()
            };
        }
    }
}
