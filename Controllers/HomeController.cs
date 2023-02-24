using Microsoft.AspNetCore.Mvc;
using Preparation.Models;
using System.Diagnostics;

namespace Preparation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         PreparationContext _pc;
        public HomeController(ILogger<HomeController> logger, PreparationContext pc)
        {
            _logger = logger;
            _pc = pc;
        }

        public IActionResult Index()
        {
            var list = _pc.Parents.ToList();
            return View();
        }

        public IActionResult Privacy()
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