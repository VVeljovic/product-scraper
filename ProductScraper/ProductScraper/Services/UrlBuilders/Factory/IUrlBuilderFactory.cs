using ProductScraper.Services.UrlBuilders.Strategy;

namespace ProductScraper.Services.UrlBuilders.Factory
{
    public interface IUrlBuilderFactory
    {
        public IUrlBuilderStrategy GetStrategy(string sitename);
    }
}
