using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyProjectApi.Wrappers.ConfigurationManagerWrapper
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}