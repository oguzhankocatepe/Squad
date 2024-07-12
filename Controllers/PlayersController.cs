using Microsoft.AspNetCore.Mvc;
using Squad.Models;
using Squad.Services;
using System.Diagnostics;

namespace Squad.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public PlayersController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Players(string? Id)
        {
            if (Id != null)
                return View(CupPlayerService.Players.Where(player => player.CupCode == Id).ToList());
            else
                return View(CupPlayerService.Players.ToList());
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