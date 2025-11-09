using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductScraper.Helpers;
using ProductScraper.Models.Filters;
using ProductScraper.Scrapers;
using System.Web;

namespace ProductScraper.Controllers
{
    public class ScrapeController(IConfiguration config) : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Scrape/Index.cshtml");
        }
        
        public ActionResult Start(string category)
        {
            Console.WriteLine(category);
            var desktopFilters = config.GetSection("Laptops").Get<LaptopFilters>();
            
            return PartialView("~/Views/Scrape/LaptopsFilters.cshtml", desktopFilters);
        }

        public ActionResult ApplyFilters(LaptopFilters model)
        {
            var ananasScraper = new Scraper();

            ananasScraper.Scrape("Laptops","JakovSistem", model);

            return Ok();
        }
    }
}
