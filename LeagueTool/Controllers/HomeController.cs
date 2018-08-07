using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using LeagueTool.Models;
using LeagueTool.Models.ViewModels;
using LeagueTool.Services;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDataDragonService _dataDragon;
        private readonly IConfigService _config;

        public HomeController(IMapper mapper, IDataDragonService dataDragon, IConfigService config)
        {
            _mapper = mapper;
            _dataDragon = dataDragon;
            _config = config;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Index()
        {
            var region = _config.DefaultRegion.Name;

            var realm = await _dataDragon.GetRealm(region).ConfigureAwait(false);

            return Redirect($"{region}/{realm.L}/{realm.N.Champion}/champions");
        }

        [HttpPost]
        [Route("redirect-to-champion-list")]
        public async Task<ActionResult> RedirectToChampionList(ChampionListQuery query)
        {
            if (query.Language != Language.Default.Name)
            {
                return Redirect($"{query.Region}/{query.Language}/{query.Version}/champions");
            }

            var realm = await _dataDragon.GetRealm(query.Region).ConfigureAwait(false);

            return Redirect($"{query.Region}/{realm.L}/{query.Version}/champions");
        }

        [HttpGet]
        [Route("{query.Region}/{query.Language}/{query.Version}/champions")]
        public async Task<ActionResult> ChampionList(ChampionListQuery query)
        {
            if (!ModelState.IsValid)
            {
                return new HttpNotFoundResult();
            }

            var realm = await _dataDragon.GetRealm(query.Region).ConfigureAwait(false);

            var allChampionsDto = await _dataDragon.GetAllChampions(realm.Cdn, query.Language, query.Version).ConfigureAwait(false);

            var model = new ChampionListModel
            {
                Title = "Champions",
                Subtitle = $"showing all {allChampionsDto.Data.Count} champions",
                Champions = _mapper.Map<IEnumerable<ChampionListItemModel>>(allChampionsDto),
                DropdownGroup = new DropdownGroupModel
                {
                    Regions = Region.All(),
                    Languages = Language.All(),
                    Versions = await _dataDragon.GetVersionsAsync(),
                    Selected = query
                }
            };

            return View(model);
        }

        [HttpPost]
        [Route("redirect-to-champion-detail")]
        public async Task<ActionResult> RedirectToChampionDetail(ChampionDetailQuery query)
        {
            if (query.Language != Language.Default.Name)
            {
                return Redirect($"{query.Region}/{query.Language}/{query.Version}/{query.ChampionName}");
            }

            var realm = await _dataDragon.GetRealm(query.Region).ConfigureAwait(false);

            return Redirect($"{query.Region}/{realm.L}/{query.Version}/{query.ChampionName}");
        }

        [HttpGet]
        [Route("{query.Region}/{query.Language}/{query.Version}/{query.ChampionName}")]
        public async Task<ActionResult> ChampionDetail(ChampionDetailQuery query)
        {
            if (!ModelState.IsValid)
            {
                return new HttpNotFoundResult();
            }

            var realm = await _dataDragon.GetRealm(query.Region).ConfigureAwait(false);

            var individualChampionDto = await _dataDragon.GetIndividualChampion(realm.Cdn, query.Language, query.Version, query.ChampionName).ConfigureAwait(false);

            var champion = _mapper.Map<ChampionModel>(individualChampionDto.Data.Single().Value);

            var model = new ChampionDetailModel
            {
                Title = champion.Name,
                Subtitle = champion.Title,
                Champion = champion,
                DropdownGroup = new DropdownGroupModel
                {
                    Regions = Region.All(),
                    Languages = Language.All(),
                    Versions = await _dataDragon.GetVersionsAsync(),
                    Selected = query
                }
            };

            return View(model);
        }
    }
}