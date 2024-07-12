using Microsoft.AspNetCore.Mvc;
using Squad.Models;
using Squad.Services;
using System.Diagnostics;

namespace Squad.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public TeamsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Teams(string? Id)
        {
            if (Id != null)
                return View(TeamLeagueService.Leagues.Join(PlayerTeamService.Teams.Where(team => team.Name == Id).ToList(), league => league.LeagueCode+ league.TeamCode, team => team.Code, (league, team) => new Team(league.TeamCode, league.LeagueCode,team.Picture)).ToList());
            else
                return View(TeamService.Teams);
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