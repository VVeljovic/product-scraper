using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Services.Scrapers;
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

        public async Task<IActionResult> ScrapeTablets(TabletsFilters model)
        {
            var lista = await scraper.Scrape("Tablets", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
