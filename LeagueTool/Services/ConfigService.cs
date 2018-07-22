using System;
using System.Web.Configuration;

namespace LeagueTool.Services
{
    public class ConfigService
    {
        public string RiotGamesApiKey { get; }
        public int RiotGamesApiRateLimitPer1S { get; }
        public int RiotGamesApiRateLimitPer2M { get; }

        public ConfigService()
        {
            RiotGamesApiKey = GetAppSetting<string>("RiotGamesApiKey");
            RiotGamesApiRateLimitPer1S = GetAppSetting<int>("RiotGamesApiRateLimitPer1S");
            RiotGamesApiRateLimitPer2M = GetAppSetting<int>("RiotGamesApiRateLimitPer2M");
        }

        private static T GetAppSetting<T>(string key)
        {
            var value = WebConfigurationManager.AppSettings[key];
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}