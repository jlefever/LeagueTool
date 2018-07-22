using LeagueTool.Models.Views;
using MediatR;

namespace LeagueTool.Commands
{
    public class GetHomeViewModel : IRequest<HomeViewModel>
    {
        public string Local { get; }
        public string Version { get; }
        public string PlatformId { get; }

        public GetHomeViewModel(string local, string version, string platformId)
        {
            Local = local;
            Version = version;
            PlatformId = platformId;
        }
    }
}