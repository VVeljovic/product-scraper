namespace ProductScraper.Models
{
    public sealed record ScrapedResult
    {
        public ScrapedResult() { }

        public ScrapedResult(List<Product> products, List<SiteAndUrlPair> siteAndUrlPairs, string appliedFilters)
        {
            Products = products;
            SitenameAndNexturlPairs = siteAndUrlPairs;
            AppliedFiltersSerialized = appliedFilters;
        }
        public List<Product> Products { get; init; } = new();
        public List<SiteAndUrlPair> SitenameAndNexturlPairs { get; init; } = new();
        public string AppliedFiltersSerialized { get; init; } = string.Empty;
    }
}
