using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class ScrapeController(IConfiguration configuration, IScrape scraper) : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Scrape/Index.cshtml");
        }

        [HttpGet]
        public ActionResult FilterLaptops(LaptopFilters model)
        {
            var lista = scraper.Scrape("Laptops", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
