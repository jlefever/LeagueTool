using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LeagueTool.Models.Views;
using MediatR;
using RiotSharp.Interfaces;

namespace LeagueTool.Commands
{
    public class GetHomeViewModelHandler : IRequestHandler<GetHomeViewModel, HomeViewModel>
    {
        private readonly IStaticRiotApi _staticRiotApi;

        public GetHomeViewModelHandler(IStaticRiotApi staticRiotApi)
        {
            _staticRiotApi = staticRiotApi;
        }

        public async Task<HomeViewModel> Handle(GetHomeViewModel request, CancellationToken cancellationToken)
        {
            var champList = await _staticRiotApi.GetChampionsAsync(request.Region).ConfigureAwait(false);

            var champs = champList.Champions.Select(c => new ChampionListItemViewModel
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