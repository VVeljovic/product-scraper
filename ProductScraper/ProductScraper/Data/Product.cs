namespace ProductScraper.Data;

public sealed class Product
{
    public Guid Id { get; set; }
    public string FilterHash { get; set; }
    public string Title { get; set; }
    public string Price { get; set; }
    public string SourceLink { get; set; }
}
