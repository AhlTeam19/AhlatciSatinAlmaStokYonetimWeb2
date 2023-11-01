using Microsoft.AspNetCore.Mvc;
using SatinAlmaStokYonetim.Web.Models;
using System.Diagnostics;

namespace SatinAlmaStokYonetim.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllRequests()
        {
            return View();
        }

        public IActionResult ControlRequest()
        {
            return View();
        }
        public IActionResult CreateRequest()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Calender()
        {
            return View();
        }

        public IActionResult Stock()
        {
            return View();
        }

        public IActionResult StockDetail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}