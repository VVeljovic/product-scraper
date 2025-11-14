using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
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

        public ActionResult ScrapeDesktops(DesktopFilters model)
        {
            var lista = scraper.Scrape("Desktops", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
