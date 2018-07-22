using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeagueTool.Models.Views;
using MediatR;
using RiotNet;

namespace LeagueTool.Commands
{
    public class GetHomeViewModelHandler : IRequestHandler<GetHomeViewModel, HomeViewModel>
    {
        private readonly IRiotClient _riotClient;

        public GetHomeViewModelHandler(IRiotClient riotClient)
        {
            _riotClient = riotClient;
        }

        public async Task<HomeViewModel> Handle(GetHomeViewModel request, CancellationToken cancellationToken)
        {
            var champList = await _riotClient.GetStaticChampionsAsync(
                request.Local,
                request.Version,
                false,
                new[] { "all" },
                request.PlatformId,
                cancellationToken
            ).ConfigureAwait(false);

            var champs = champList.Data.Select(c => new ChampionListItemViewModel
            {
                Id = c.Value.Id,
                Name = c.Value.Name,
                SquareImage = GetSquareImage(request.Version, c.Value.Image.Full),
                Title = c.Value.Title
            }).OrderBy(c => c.Name).ToArray();

            return new HomeViewModel
            {
                Champions = champs
            };
        }

        private static string GetSquareImage(string version, string image)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{image}";
        }
    }
}