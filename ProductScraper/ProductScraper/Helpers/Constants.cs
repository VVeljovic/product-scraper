namespace ProductScraper.Helpers;

public static class Constants
{
    public static List<string> SiteNames = [ "Ananas", "Gigatron", "EPlaneta"];

    public static Dictionary<string, string> SitenameUrlPairs =
    new Dictionary<string, string>
    {
        { "Ananas", "https://ananas.rs/search?query=queryValue&price=priceValue" },
        { "Gigatron", "https://gigatron.rs/pretraga?q=queryValue&cena=priceValue" },
        { "EPlaneta", "https://eplaneta.rs/rezultati-pretrage/?q=queryValue&product_list_order=relevance&product_list_dir=descending&sort_range_price=priceValue" }
    };

    public static class Ananas
    {
        public const string Name = "Ananas";
        public const string AnanasLaptops = "AnanasLaptops";
        public const string AnanasDesktops = "AnanasDesktops";
        public const string AnanasPhones = "AnanasPhones";
        public const string AnanasTablets = "AnanasTablets";

        public const string BaseUrl = "https://ananas.rs/";
        public const string LaptopsUrl = "https://ananas.rs/kategorije/it-shop/racunari-i-racunarska-oprema/laptop-racunari?";
        public const string DesktopsUrl = "https://ananas.rs/kategorije/it-shop/racunari-i-racunarska-oprema/desktop-racunari?";
        public const string PhonesUrl = "https://ananas.rs/kategorije/telefoni-i-foto/mobilni-telefoni/smart-mobilni-telefoni?";
        public const string TabletsUrl = "https://ananas.rs/kategorije/telefoni-i-foto/tableti?";

        public const string SearchUrl = "https://ananas.rs/search?query=";


        public const string DivClass = "div.ais-Hits-item";
        public const string LinkClass = ".sc-v9wo15-0";
        public const string TitleClass = "h3.sc-14no49n-0";
        public const string PriceClass = "span.sc-1arj7wv-2";
        public const string ItemsNotFoundClass = "h6.sc-4ai9u1-0";
        public const string PaginationClass = "li.sc-hj4qyi-0.ePTEKu";
        public const string NextPageQuery = "page";
        public const string QueryAttibut = "refinementList[product.selectAttributes.";
    }

    public static class Gigatron
    {
        public const string Name = "Gigatron";
        public const string GigatronLaptops = "GigatronLaptops";
        public const string GigatronDesktops = "GigatronDesktops";
        public const string GigatronPhones = "GigatronPhones";
        public const string GigatronTablets = "GigatronTablets";

        public const string BaseUrl = "https://gigatron.rs/";
        public const string LaptopsUrl = "https://gigatron.rs/racunari-i-komponente/laptop-racunari?";
        public const string DesktopsUrl = "https://gigatron.rs/racunari-i-komponente/desktop-racunari?";
        public const string PhonesUrl = "https://gigatron.rs/mobilni-telefoni-tableti-i-oprema/mobilni-telefoni?";
        public const string TabletsUrl = "https://gigatron.rs/mobilni-telefoni-tableti-i-oprema/tablet-racunari?";

        public const string SearchUrl = "https://gigatron.rs/pretraga?q=";

        public const string DivClass = "div.min-w-\\[230px\\]";
        public const string LinkClass = "a[href*='/proizvod/']";
        public const string TitleClass = ".line-clamp-2.h-\\[38px\\].font-bold.leading-tight.dark\\:text-gpurple-50";
        public const string PriceClass = "span.block.truncate.font-bold";
        public const string ItemsNotFoundClass = "h2.mb-7.mt-16.text-2xl.font-black";
        public const string PaginationClass = "button.text-gblue-50";

        public const string NextPageQuery = "page";
    }

    public static class EPlaneta
    {
        public const string Name = "EPlaneta";
        public const string EPlanetaLaptops = "EPlanetaLaptops";
        public const string EPlanetaDesktops = "EPlanetaDesktops";
        public const string EPlanetaPhones = "EPlanetaPhones";
        public const string EPlanetaTablets = "EPlanetaTablets";

        public const string BaseUrl = "https://eplaneta.rs/";
        public const string LaptopsUrl = "https://eplaneta.rs/it-oprema/laptopovi-i-tableti/laptopovi.html?";
        public const string DesktopsUrl = "https://eplaneta.rs/it-oprema/racunari/desktop-racunari.html?";
        public const string PhonesUrl = "https://eplaneta.rs/telefoni-i-oprema/smart-telefoni/smart-telefoni.html?";
        public const string TabletsUrl = "https://eplaneta.rs/it-oprema/laptopovi-i-tableti/tableti.html?";
        public const string SearchUrl = "https://eplaneta.rs/rezultati-pretrage/?q=";


        public const string DivClass = "div.product-item-info";
        public const string LinkClass = "a[href$='.html']";
        public const string TitleClass = "strong.product-item-name a";
        public const string PriceClass = "span.special-price";
        public const string ItemsNotFoundClass = "span.special-pricee";
        public const string PaginationClass = "li.item.current";
        public const string NextPageQuery = "p";
    }
}
