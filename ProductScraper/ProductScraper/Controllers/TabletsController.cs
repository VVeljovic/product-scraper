using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class TabletsController(IConfiguration configuration, IScrape scraper) : Controller
    {
        public IActionResult Index()
        {
            var tabletFilters = configuration.GetSection("Tablets").Get<TabletsFilters>();

            return PartialView("~/Views/Scrape/TabletsFilters.cshtml", new TabletViewModel { Filters = tabletFilters });
        }

        public ActionResult ScrapeTablets(TabletsFilters model)
        {
            var lista = scraper.Scrape("Tablets", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
