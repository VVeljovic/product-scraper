namespace ProductScraper.Models;

public sealed record Product(string Title, string Price, string SourceLink, string? SiteName);
