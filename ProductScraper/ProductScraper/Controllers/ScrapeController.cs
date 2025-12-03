using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Services.Scrapers;

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

        [HttpPost("scrape-products/{category}")]
        public async Task<IActionResult> ScrapeProducts(string category, BaseProductFilters filters)
        {
            if (filters is DesktopFilters df)
            {
                var products = await scraper.Scrape(category, df);

                return PartialView($"~/Views/Scrape/ProductsList.cshtml", products);
            }

            return Ok();
        }
    }
}
