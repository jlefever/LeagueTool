using System.Collections.Generic;
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
        private readonly DataDragonService _dataDragon;
        private readonly IConfigService _config;

        public HomeController(IMapper mapper, DataDragonService dataDragon, IConfigService config)
        {
            _mapper = mapper;
            _dataDragon = dataDragon;
            _config = config;
        }

        [Route("")]
        public async Task<ActionResult> Index()
        {
            var region = _config.DefaultRegion.Name;

            var realm = await _dataDragon.GetRealm(region).ConfigureAwait(false);

            return Redirect($"{region}/{realm.L}/{realm.N.Champion}/champions");
        }

        [HttpPost]
        [Route("redirect-to-champions")]
        public async Task<ActionResult> ChampionList(ChampionQuery query)
        {
            var realm = await _dataDragon.GetRealm(query.Region).ConfigureAwait(false);

            var language = query.Language == Language.Default.Name ? realm.L : query.Language;

            return Redirect($"{query.Region}/{language}/{query.Version}/champions");
        }

        [Route("{region}/{language}/{version}/champions")]
        public async Task<ActionResult> ChampionList(string region, string language, string version)
        {
            var realm = await _dataDragon.GetRealm(region).ConfigureAwait(false);

            var allChampionsDto = await _dataDragon.GetAllChampions(realm.Cdn, language, version).ConfigureAwait(false);

            var model = new ChampionListModel
            {
                Champions = _mapper.Map<IEnumerable<ChampionListItemModel>>(allChampionsDto),
                Regions = Region.All(),
                Languages = Language.All(),
                Versions = await _dataDragon.GetVersionsAsync(),
                SelectedRegion = region,
                SelectedLanguage = language,
                SelectedVersion = version
            };

            return View(model);
        }
    }
}