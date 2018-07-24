using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using LeagueTool.Models;
using LeagueTool.Models.DataDragonDtos;
using Newtonsoft.Json;

namespace LeagueTool.Services
{
    public class DataDragonService
    {
        private readonly Uri _dataDragonBaseUrl;
        private readonly HttpClient _httpClient;

        public DataDragonService(ConfigService configService)
        {
            _dataDragonBaseUrl = new Uri(configService.DataDragonBaseUrl);
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<string>> GetVersionsAsync()
        {
            var url = _dataDragonBaseUrl + "api/versions.json";

            return await Get<IEnumerable<string>>(url).ConfigureAwait(false);
        }

        public async Task<RealmDto> GetRealm(string region)
        {
            var url = _dataDragonBaseUrl + $"realms/{region}.json";

            return await Get<RealmDto>(url).ConfigureAwait(false);
        }

        public async Task<AllChampionsDto> GetAllChampions(RealmDto realm)
        {
            return await GetAllChampions(realm.Cdn, realm.N.Champion, realm.L).ConfigureAwait(false);
        }

        public async Task<AllChampionsDto> GetAllChampions(string cdn, string version, string language)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/data/{language}/champion.json");

            return await Get<AllChampionsDto>(builder.Uri.AbsoluteUri).ConfigureAwait(false);
        }

        public async Task<AllChampionsDto> GetIndividualChampion(string cdn, string version, string language, string champion)
        {
            var builder = new UriBuilder(cdn);

            builder.Path = Path.Combine(builder.Path, $"{version}/data/{language}/champion/{champion}.json");

            return await Get<AllChampionsDto>(builder.Uri.AbsoluteUri).ConfigureAwait(false);
        }

        private async Task<T> Get<T>(string url)
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}