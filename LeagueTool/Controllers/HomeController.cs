using LeagueTool.Services;
using System.Web.Mvc;

namespace LeagueTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConfigService _configService;

        public HomeController(ConfigService configService)
        {
            _configService = configService;
        }

        public ActionResult Index()
        {
            ViewBag.DummySetting = _configService.DummySetting;
            return View();
        }
    }
}