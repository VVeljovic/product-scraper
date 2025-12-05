using ProductScraper.Helpers;
using ProductScraper.Models;

namespace ProductScraper.Services.UrlBuilders.Strategy
{
    public interface IUrlBuilderStrategy
    {
        public string BuildUrl(ScrapingElements scrapingElements, Dictionary<string, List<string>> urlQueryParams);

        public string BuildUrl(QueryScrapingModel queryScrapingModel);
    }
}
