namespace ProductScraper.Models;

public sealed record QueryScrapingModel(string Query, Decimal MinPrice, Decimal MaxPrice);
