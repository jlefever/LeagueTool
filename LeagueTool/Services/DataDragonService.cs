using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LeagueTool.Models.DataDragonDtos;
using System.Linq;

namespace LeagueTool.Services
{
    public class DataDragonService : IDataDragonService
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

        public async Task<IndividualChampionDto> GetIndividualChampion(string cdn, string language, string version, string champion)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/data/{language}/champion/{champion}.json");

            return await _rest.GetAsync<IndividualChampionDto>(builder.Uri.AbsoluteUri).ConfigureAwait(false);
        }
    }
}