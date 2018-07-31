using System;
using System.Linq;
using System.Web.Configuration;
using LeagueTool.Models;

namespace LeagueTool.Services
{
    public class ConfigService : IConfigService
    {
        public string DataDragonBaseUrl { get; }
        public Region DefaultRegion { get; }

        public ConfigService()
        {
            DataDragonBaseUrl = GetAppSetting<string>("DataDragonBaseUrl");
            DefaultRegion = Region.All().Single(r => r.Name == GetAppSetting<string>("DefaultRegion"));
        }

        private static T GetAppSetting<T>(string key)
        {
            var value = WebConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}