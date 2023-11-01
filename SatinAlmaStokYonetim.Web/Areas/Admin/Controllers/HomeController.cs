using Microsoft.AspNetCore.Mvc;

namespace SatinAlmaStokYonetim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult RegisterUser() => View();
    }
}
