using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using LeagueTool.Models;
using LeagueTool.Models.Views;
using LeagueTool.Services;
using MediatR;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDragonService _dataDragon;

        public HomeController(IMediator mediator, DataDragonService dataDragon)
        {
            _dataDragon = dataDragon;
        }

        [Route("")]
        public ActionResult Index()
        {
            return Redirect($"{Region.Na.Name}/latest/champions");
        }

        [Route("{region}/latest/champions")]
        public async Task<ActionResult> Index(string region)
        {
            region = region.ToLower();

            if (!Region.IsValidRegion(region))
            {
                return new HttpNotFoundResult();
            }

            var realm = await _dataDragon.GetRealm(region).ConfigureAwait(false);

            var allChampionsDto = await _dataDragon.GetAllChampions(realm).ConfigureAwait(false);

            var champions = allChampionsDto.Data.Select(c => new ChampionListItemViewModel
            {
                Id = Convert.ToInt32(c.Value.Key),
                Name = c.Value.Name,
                SquareImage = GetSquareImage(realm.N.Champion, c.Value.Image.Full),
                Title = c.Value.Title
            }).OrderBy(c => c.Name).ToArray();

            return View(new HomeViewModel
            {
                Champions = champions
            });
        }

        [Route("versions")]
        public async Task<ActionResult> Versions()
        {
            var versions = await _dataDragon.GetVersionsAsync().ConfigureAwait(false);

            return Json(versions, JsonRequestBehavior.AllowGet);
        }

        private static string GetSquareImage(string version, string image)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{image}";
        }
    }
}