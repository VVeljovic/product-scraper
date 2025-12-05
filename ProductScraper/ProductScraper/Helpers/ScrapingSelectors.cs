using static ProductScraper.Helpers.Constants;

namespace ProductScraper.Helpers;

public sealed record ScrapingSelectors(string DivClass, string LinkClass, string TitleClass, string PriceClass, string ProductsNotFoundClass, string CurrentPage)
{
    public static ScrapingSelectors GetScrapingSelectors(string url)
    {
        return url switch
        {
            Ananas.Name =>  new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass),
            Gigatron.Name => new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass),
            EPlaneta.Name => new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass),
            _ => throw new Exception(),
        };
    }
}
