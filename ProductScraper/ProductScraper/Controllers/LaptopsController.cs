using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models;
using ProductScraper.Models.Filters;
using ProductScraper.Services.LLM;
using ProductScraper.Services.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class LaptopsController(IConfiguration configuration, IScrape scraper, IRecommendationService recommendationService) : Controller
    {
        public IActionResult Index()
        {
            var laptopFilters = configuration.GetSection("Laptops").Get<LaptopFilters>();

            return PartialView("~/Views/Scrape/LaptopsFilters.cshtml", new LaptopViewModel { Filters = laptopFilters });
        }

        public async Task<IActionResult> ScrapeLaptops(LaptopFilters model)
        {
            var lista = await scraper.Scrape("Laptops", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateRecommendation([FromBody]List<Product> products)
        {
            var response = await recommendationService.GenerateRecommendation(products);

            return Ok(new { recommendation = response });
        }
    }
}
