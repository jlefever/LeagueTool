using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using LeagueTool.Commands;
using MediatR;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaticRiotApi _staticRiotApi;
        private readonly IMediator _mediator;

        public HomeController(IStaticRiotApi staticRiotApi, IMediator mediator)
        {
            _staticRiotApi = staticRiotApi;
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            var region = Region.na;

            var versions = await _staticRiotApi.GetVersionsAsync(region).ConfigureAwait(false);

            var request = new GetHomeViewModel(region, versions.First());

            var model = await _mediator.Send(request);

            return View(model);
        }
    }
}