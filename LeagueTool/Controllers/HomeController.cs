using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStaticRiotApi _staticRiotApi;

        public HomeController(IRiotApi riotApi, IStaticRiotApi staticRiotApi)
        {
            _staticRiotApi = staticRiotApi;
        }

        public async Task<ActionResult> Index()
        {
            var champList = await _staticRiotApi.GetChampionsAsync(Region.na).ConfigureAwait(false);
            ViewBag.Champions = champList.Champions.Select(c => c.Value).OrderBy(c => c.Name);
            ViewBag.Versions = _staticRiotApi.GetVersions(Region.na);
            return View();
        }
    }
}