using static ProductScraper.Helpers.Constants;

namespace ProductScraper.Helpers;

public sealed record ScrapingElements(string Url, string QueryAttribut, ScrapingSelectors ScrapingSelectors)
{
    public static ScrapingElements GetElementsForScraping(string siteAndProductName)
    {
        return siteAndProductName switch
        {
            Ananas.AnanasLaptops => new ScrapingElements(Ananas.LaptopsUrl, Ananas.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.AnanasDesktops => new ScrapingElements(Ananas.DesktopsUrl, Ananas.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.AnanasPhones => new ScrapingElements(Ananas.PhonesUrl, Ananas.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.AnanasTablets => new ScrapingElements(Ananas.TabletsUrl, Ananas.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),

            Gigatron.GigatronLaptops => new ScrapingElements(Gigatron.LaptopsUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.GigatronDesktops => new ScrapingElements(Gigatron.DesktopsUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.GigatronPhones => new ScrapingElements(Gigatron.PhonesUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.GigatronTablets => new ScrapingElements(Gigatron.TabletsUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),

            EPlaneta.EPlanetaLaptops => new ScrapingElements(EPlaneta.LaptopsUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.EPlanetaDesktops => new ScrapingElements(EPlaneta.DesktopsUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.EPlanetaPhones => new ScrapingElements(EPlaneta.PhonesUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.EPlanetaTablets => new ScrapingElements(EPlaneta.TabletsUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),

            _ => throw new Exception(),
        };
    }

    public static string GetNextPageQueryParameter(string siteName)
    {
        return siteName switch
        {
            Ananas.Name => Ananas.NextPageQuery,
            Gigatron.Name => Gigatron.NextPageQuery,
            EPlaneta.Name => EPlaneta.NextPageQuery
        };
    }
}