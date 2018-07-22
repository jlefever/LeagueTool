using System;
using System.Web.Configuration;

namespace LeagueTool.Services
{
    public class ConfigService
    {
        public bool DummySetting { get; }

        public ConfigService()
        {
            DummySetting = GetAppSetting<bool>("DummySetting");
        }

        private T GetAppSetting<T>(string key)
        {
            var value = WebConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}