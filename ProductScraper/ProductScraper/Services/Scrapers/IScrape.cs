using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Services.Scrapers;

public interface IScrape
{
    public Task<ScrapedResult> Scrape(string category, BaseProductFilters selectedFilters);
}
