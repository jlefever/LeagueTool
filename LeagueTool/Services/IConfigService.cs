using LeagueTool.Models;

namespace LeagueTool.Services
{
    public interface IConfigService
    {
        string DataDragonBaseUrl { get; }
        Region DefaultRegion { get; }
    }
}