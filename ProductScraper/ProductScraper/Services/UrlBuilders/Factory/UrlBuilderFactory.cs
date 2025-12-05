using ProductScraper.Services.UrlBuilders.Strategy;

namespace ProductScraper.Services.UrlBuilders.Factory
{
    public class UrlBuilderFactory(IReadOnlyDictionary<string, Func<IUrlBuilderStrategy>> strategyResolver) : IUrlBuilderFactory
    {
        public IUrlBuilderStrategy GetStrategy(string sitename)
        {
            if(strategyResolver.TryGetValue(sitename, out var resolver))
            {
                return resolver();
            }

            throw new ArgumentOutOfRangeException(nameof(sitename), $"Unsupported sitename {sitename}");
        }
    }
}
