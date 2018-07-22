using LeagueTool.Services;
using RiotNet;

namespace LeagueTool.Factories
{
    public class RiotClientFactory
    {
        private readonly ConfigService _configService;

        public RiotClientFactory(ConfigService configService)
        {
            _configService = configService;
        }

        public IRiotClient CreateRiotClient()
        {
            return new RiotClient(new RiotClientSettings
            {
                ApiKey = _configService.RiotGamesApiKey
            });
        }
    }
}