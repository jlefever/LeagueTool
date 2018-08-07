using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueTool.Models.DataDragonDtos;

namespace LeagueTool.Services
{
    public interface IDataDragonService
    {
        Task<IEnumerable<string>> GetVersionsAsync();
        Task<RealmDto> GetRealm(string region);
        Task<AllChampionsDto> GetAllChampions(string cdn, string language, string version);
        Task<IndividualChampionDto> GetIndividualChampion(string cdn, string language, string version, string champion);
    }
}