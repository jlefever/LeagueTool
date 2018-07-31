using System.Threading.Tasks;

namespace LeagueTool.Services
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string url);
    }
}