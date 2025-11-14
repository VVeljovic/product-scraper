using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class LaptopsController(IConfiguration configuration, IScrape scraper) : Controller
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
    }
}
