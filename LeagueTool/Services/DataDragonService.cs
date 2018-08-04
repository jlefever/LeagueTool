using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LeagueTool.Models.DataDragonDtos;
using System.Linq;
using LeagueTool.Models;

namespace LeagueTool.Services
{
    public class DataDragonService
    {
        private readonly Uri _dataDragonBaseUrl;
        private readonly IRestService _rest;

        public DataDragonService(IConfigService configService, IRestService rest)
        {
            _dataDragonBaseUrl = new Uri(configService.DataDragonBaseUrl);
            _rest = rest;
        }

        public async Task<IEnumerable<string>> GetVersionsAsync()
        {
            var url = _dataDragonBaseUrl + "api/versions.json";

            var versions = await _rest.GetAsync<IEnumerable<string>>(url).ConfigureAwait(false);

            return versions.Where(v => !v.Contains("lolpatch"));
        }

        public async Task<RealmDto> GetRealm(string region)
        {
            var url = _dataDragonBaseUrl + $"realms/{region}.json";

            return await _rest.GetAsync<RealmDto>(url).ConfigureAwait(false);
        }

        public async Task<AllChampionsDto> GetAllChampions(string cdn, string language, string version)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/data/{language}/champion.json");

            return await _rest.GetAsync<AllChampionsDto>(builder.Uri.AbsoluteUri).ConfigureAwait(false);
        }

        public async Task<AllChampionsDto> GetIndividualChampion(string cdn, string version, string language, string champion)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/data/{language}/champion/{champion}.json");

            return await _rest.GetAsync<AllChampionsDto>(builder.Uri.AbsoluteUri).ConfigureAwait(false);
        }

        private static string GetSquareImageUrl(string cdn, string version, string image)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/img/champion/{image}");

            return builder.Uri.AbsoluteUri;
        }

        private static string GetLoadingImageUrl(string cdn, string champion, string skinNum)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"img/champion/loading/{champion}_{skinNum}.jpg");

            return builder.Uri.AbsoluteUri;
        }

        private static string GetSplashImageUrl(string cdn, string champion, string skinNum)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"img/champion/splash/{champion}_{skinNum}.jpg");

            return builder.Uri.AbsoluteUri;
        }
    }
}