using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using ProductScraper.Views;
using ProductScraper.Views.Models;

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
            var desktopFilters = config.GetSection("Laptops").Get<LaptopFilters>();
            
            return PartialView("~/Views/Scrape/LaptopsFilters.cshtml", new LaptopViewModel { Filters = desktopFilters});
        }

        public ActionResult ApplyFilters(LaptopFilters model)
        {
            var ananasScraper = new Scraper();

            var lista = ananasScraper.Scrape("Laptops","Ananas", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
