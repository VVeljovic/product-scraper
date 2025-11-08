using ProductScraper.Scrapers;

namespace ProductScraper.Factory;

public sealed class ScraperFactory
{
    public static IScrape Create(string siteName)
    {
        return siteName switch
        {
            "ananas" => new AnanasScraper(),
            "gigatron" => new GigatronScraper(),
            "eplanet" => new EPlanetScraper(),
            _ => throw new KeyNotFoundException(),
        };
    }
}
    