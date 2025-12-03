namespace ProductScraper.Models
{
    public sealed record ScrapedResult(List<Product> Products, List<string> NextUrls);
}
