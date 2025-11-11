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

        public ActionResult ScrapePhones(PhonesFilters model)
        {
            var lista = scraper.Scrape("Phones", "Ananas", model);

            return PartialView("~/Views/Scrape/ProductsList.cshtml", lista);
        }
    }
}
