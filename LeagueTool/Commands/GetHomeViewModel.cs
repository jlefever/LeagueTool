using LeagueTool.Models.Views;
using MediatR;
using RiotSharp.Misc;

namespace LeagueTool.Commands
{
    public class GetHomeViewModel : IRequest<HomeViewModel>
    {
        public Region Region { get; }
        public string Version { get; set; }

        public GetHomeViewModel(Region region, string version)
        {
            Region = region;
            Version = version;
        }
    }
}