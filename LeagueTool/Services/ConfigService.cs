using System;
using System.Web.Configuration;

namespace LeagueTool.Services
{
    public class ConfigService
    {
        public string RiotGamesApiKey { get; }

        public ConfigService()
        {
            RiotGamesApiKey = GetAppSetting<string>("RiotGamesApiKey");
        }

        private static T GetAppSetting<T>(string key)
        {
            var value = WebConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}