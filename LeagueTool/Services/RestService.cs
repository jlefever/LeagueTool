using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueTool.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _httpClient;

        public RestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}