using ProductScraper.Models;
using ProductScraper.Models.Filters;

namespace ProductScraper.Scrapers;

public interface IScrape
{
    public Task<List<Product>> Scrape(string category, string siteName, BaseProductFilters selectedFilters);
}
