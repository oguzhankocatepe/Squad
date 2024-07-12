using Microsoft.AspNetCore.Mvc;
using Squad.Models;
using Squad.Services;
using System.Diagnostics;
using System.Linq;

namespace Squad.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public CountriesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Countries(string? Id)
        {
            if (Id != null)
                return View(CountryService.Countries.Join(CupCountryService.CupCountries.Where(cup => cup.CupCode == Id).ToList(), country => country.Code, cup => cup.CountryCode, (country, cup) => new Country(cup.CupCode+cup.CountryCode, country.Name)).ToList());
            else
                return View(CountryService.Countries);
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