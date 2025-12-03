using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models;
using ProductScraper.Models.Filters;
using ProductScraper.Services.Scrapers;

namespace ProductScraper.Controllers
{
    [Route("Scrape")]
    public class ScrapeController(IConfiguration configuration, IScrape scraper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Scrape/Index.cshtml");
        }

        [HttpPost("scrape-products")]
        public async Task<IActionResult> ScrapeProducts([FromBody]ScrapedResult scrapedResult)
        {
            var products = await scraper.ScrapeProducts(scrapedResult);

            return PartialView($"~/Views/Scrape/ProductsList.cshtml", products);
        }
    }
}
