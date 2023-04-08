using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration; 

namespace AzureSearchQuickstart_v11
{
    public class AppUtils
    {
        public static string GetValue(string key)
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = @"w:\github\github.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            var value = config.AppSettings.Settings[key].Value;
            return value;
        }

    }
}
