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
        public async Task<IActionResult> ScrapeProducts(ScrapedResult scrapedResult)
        {
            var scrapedResults = await scraper.ScrapeProducts(scrapedResult);

            return PartialView($"~/Views/Scrape/ProductsList.cshtml", scrapedResults);
        }

        [HttpGet("search-scraping")]
        public async Task<IActionResult> ScrapeProducts(QueryScrapingModel queryScrapingModel)
        {
            var scrapedResults = await scraper.ScrapeProducts(queryScrapingModel);

            return PartialView($"~/Views/Scrape/ScrapeResults.cshtml", scrapedResults);
        }
    }
}
