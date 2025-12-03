using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Services.Scrapers;

public interface IScrape
{
    public Task<ScrapedResult> ScrapeProducts(string category, BaseProductFilters selectedFilters);

    public Task<ScrapedResult> ScrapeProducts(ScrapedResult scrapedResult);
}
