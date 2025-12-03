namespace ProductScraper.Models
{
    public sealed record ScrapedResult(List<Product> Products, List<SitenameAndNexturlPair> SitenameAndNexturlPairs, string AppliedFiltersSerialized);
}
