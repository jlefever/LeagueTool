﻿using System.Threading.Tasks;
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

        public HomeController(IMapper mapper, DataDragonService dataDragon)
        {
            _mapper = mapper;
            _dataDragon = dataDragon;
        }

        [Route("")]
        public ActionResult Index()
        {
            return Redirect($"{Region.Na.Name}/latest/champions");
        }

        [Route("{region}/latest/champions")]
        public async Task<ActionResult> ChampionList(string region)
        {
            if (!Region.IsValidRegion(region))
            {
                return new HttpNotFoundResult();
            }

            var realm = await _dataDragon.GetRealm(region).ConfigureAwait(false);

            var allChampionsDto = await _dataDragon.GetAllChampions(realm).ConfigureAwait(false);

            return View(_mapper.Map<ChampionListModel>(allChampionsDto));
        }

        [Route("versions")]
        public async Task<ActionResult> Versions()
        {
            var versions = await _dataDragon.GetVersionsAsync().ConfigureAwait(false);

            return Json(versions, JsonRequestBehavior.AllowGet);
        }
    }
}