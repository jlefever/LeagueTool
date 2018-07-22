using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using LeagueTool.Commands;
using MediatR;
using RiotNet;
using RiotNet.Models;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRiotClient _riotClient;
        private readonly IMediator _mediator;

        public HomeController(IRiotClient riotClient, IMediator mediator)
        {
            _riotClient = riotClient;
            _mediator = mediator;
        }

        public async Task<ActionResult> Index()
        {
            var platformId = PlatformId.NA1;

            var locals = await _riotClient.GetStaticLanguagesAsync(platformId).ConfigureAwait(false);

            var local = locals.First();

            var versions = await _riotClient.GetVersionsAsync(platformId: platformId).ConfigureAwait(false);

            var request = new GetHomeViewModel(local, versions.First(), platformId);

            var model = await _mediator.Send(request);

            return View(model);
        }
    }
}