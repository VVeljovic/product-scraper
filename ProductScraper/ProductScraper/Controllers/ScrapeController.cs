using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using System.Web;

namespace ProductScraper.Controllers
{
    public class ScrapeController(IConfiguration config) : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Scrape/Index.cshtml");
        }
        
        public ActionResult Start(string category)
        {
            Console.WriteLine(category);
            var desktopFilters = config.GetSection("Phones").Get<PhonesFilters>();
            
            return PartialView("~/Views/Scrape/PhonesFilters.cshtml", desktopFilters);
        }

        public ActionResult ApplyFilters(PhonesFilters model)
        {
            var ananasScraper = new AnanasScraper();

            ananasScraper.Scrape("Phones", model);

            return Ok();
        }
    }
}
