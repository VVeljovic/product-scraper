using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Services.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class DesktopsController(IConfiguration configuration, IScrape scraper) : Controller
    {
        public IActionResult Index()
        {
            var desktopFilters = configuration.GetSection("Desktops").Get<DesktopFilters>();

            return PartialView("~/Views/Scrape/DesktopsFilters.cshtml", new DesktopViewModel { Filters = desktopFilters });
        }

        [HttpPost]
        public async Task<IActionResult> ScrapeDesktops(DesktopFilters model)
        {
            var scrapedResult = await scraper.ScrapeProducts("Desktops", model);

            return PartialView("~/Views/Scrape/ScrapeResults.cshtml", scrapedResult);
        }
    }
}
