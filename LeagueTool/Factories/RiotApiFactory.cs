using LeagueTool.Services;
using RiotSharp;
using RiotSharp.Interfaces;

namespace LeagueTool.Factories
{
    public class RiotApiFactory
    {
        private readonly ConfigService _configService;

        public RiotApiFactory(ConfigService configService)
        {
            _configService = configService;
        }

        public IRiotApi CreateRiotApi()
        {
            return RiotApi.GetDevelopmentInstance(
                _configService.RiotGamesApiKey,
                _configService.RiotGamesApiRateLimitPer1S,
                _configService.RiotGamesApiRateLimitPer2M
            );
        }

        public IStaticRiotApi CreateStaticRiotApi()
        {
            return StaticRiotApi.GetInstance(_configService.RiotGamesApiKey);
        }
    }
}