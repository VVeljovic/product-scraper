namespace ProductScraper.Helpers;

public sealed record ScrapingElements(string Url, string QueryAttribut, ScrapingSelectors ScrapingSelectors);


public sealed record ScrapingSelectors(string DivClass, string LinkClass, string TitleClass, string PriceClass, string ProductsNotFoundClass, string PaginationClass);