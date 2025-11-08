using ProductScraper.Models.Filters;

namespace ProductScraper.Scrapers;

public interface IScrape
{
    public List<string> Scrape(string category, BaseProductFilters selectedFilters);
}
