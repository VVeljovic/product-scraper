using Microsoft.AspNetCore.Mvc;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using ProductScraper.Views.Models;

namespace ProductScraper.Controllers
{
    public class PhonesController(IConfiguration configuration, IScrape scraper) : Controller
    {
        public IActionResult Index()
        {
            var phonesFilter = configuration.GetSection("Phones").Get<PhonesFilters>();

            return PartialView("~/Views/Scrape/PhonesFilters.cshtml", new PhoneViewModel { Filters = phonesFilter });
        }

        public async Task<IActionResult> ScrapePhones(PhonesFilters model)
        {
            var lista = await scraper.Scrape("Phones", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
