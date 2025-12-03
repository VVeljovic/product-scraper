namespace ProductScraper.Helpers;

public static class Constants
{
    public static List<string> SiteNames = [ "Ananas", "Gigatron", "EPlaneta"];

    public static class Filters
    {
        public static class Laptops
        {
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "DijagonalaEkrana";
            public const string RezolucijaEkrana = "RezolucijaEkrana";
            public const string RAMMemorija = "RAMMemorija";
            public const string TipProcesora = "TipProcesora";
            public const string SSD = "SSD";
            public const string MinCena = "MinCena";
            public const string MaxCena = "MaxCena";
        }
        public static class Desktops
        {
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAMMemorija";
            public const string TipProcesora = "TipProcesora";
            public const string SSD = "SSD";
            public const string GrafickaKartica = "GrafickaKartica";
            public const string MinCena = "MinCena";
            public const string MaxCena = "MaxCena";
        }
        public static class Phones
        {
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "DijagonalaEkrana";
            public const string InternaMemorija = "InternaMemorija";
            public const string PrednjaKamera = "PrednjaKamera";
            public const string ZadnjaKamera = "ZadnjaKamera";
            public const string MinCena = "MinCena";
            public const string MaxCena = "MaxCena";
        }
        public static class Tablets
        {
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "DijagonalaEkrana";
            public const string RezolucijaEkrana = "RezolucijaEkrana";
            public const string InternaMemorija = "InternaMemorija";
            public const string RamMemorija = "RamMemorija";
            public const string MinCena = "MinCena";
            public const string MaxCena = "MaxCena";
        }
    }

    public static class Ananas
    {
        public const string Name = "Ananas";
        public const string BaseUrl = "https://ananas.rs/";
        public const string LaptopsRelativeUrl = "kategorije/it-shop/racunari-i-racunarska-oprema/laptop-racunari?";
        public const string DesktopsRelativeUrl = "kategorije/it-shop/racunari-i-racunarska-oprema/desktop-racunari?";
        public const string PhonesRelativeUrl = "kategorije/telefoni-i-foto/mobilni-telefoni/smart-mobilni-telefoni?";
        public const string TabletsRelativeUrl = "kategorije/telefoni-i-foto/tableti?";

        public const string DivClass = "div.ais-Hits-item";
        public const string LinkClass = ".sc-v9wo15-0";
        public const string TitleClass = "h3.sc-14no49n-0";
        public const string PriceClass = "span.sc-1arj7wv-2";
        public const string ItemsNotFoundClass = "h6.sc-4ai9u1-0";
        public const string PaginationClass = "li.sc-hj4qyi-0.ePTEKu";
        public const string NextPageQuery = "page";

        public static class Laptops
        {
            public const string Name = "AnanasLaptops";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string RezolucijaEkrana = "DisplayResolution";
            public const string RAMMemorija = "RamCapacity";
            public const string TipProcesora = "ProcessorModel";
            public const string SSD = "SsdHdd";
            public const string MinCena = "price";
            public const string MaxCena = "MaxPrice";

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
        }

        public static class Desktops
        {
            public const string Name = "AnanasDesktops";
            public const string Brend = "brand";
            public const string RAMMemorija = "RamCapacity";
            public const string TipProcesora = "ProcessorModel";
            public const string GrafickaKartica = "GraphicCard";
            public const string SSD = "SsdHdd";
            public const string MinCena = "price";
            public const string MaxCena = "MaxPrice";

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
        }
        public static class Phones
        {
            public const string Name = "AnanasPhones";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string InternaMemorija = "InternalMemory";
            public const string PrednjaKamera = "FrontCamera";
            public const string ZadnjaKamera = "RearCamera";
            public const string MinCena = "price";
            public const string MaxCena = "MaxPrice";

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
        }
        public static class Tablets
        {
            public const string Name = "AnanasTablets";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string RezolucijaEkrana = "DisplayResolution";
            public const string InternaMemorija = "InternalMemory";
            public const string RamMemorija = "RamCapacity";
            public const string MinCena = "price";
            public const string MaxCena = "MaxPrice";

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
        }
    }

    public static class Gigatron
    {
        public const string Name = "Gigatron";
        public const string BaseUrl = "https://gigatron.rs/";
        public const string LaptopsRelativeUrl = "racunari-i-komponente/laptop-racunari?";
        public const string DesktopRelativeUrl = "racunari-i-komponente/desktop-racunari?";
        public const string PhonesRelativeUrl = "mobilni-telefoni-tableti-i-oprema/mobilni-telefoni?";
        public const string TabletsRelativeUrl = "mobilni-telefoni-tableti-i-oprema/tablet-racunari?";

        public const string DivClass = "div.min-w-\\[230px\\]";
        public const string LinkClass = "a[href*='/proizvod/']";
        public const string TitleClass = ".line-clamp-2.h-\\[38px\\].font-bold.leading-tight.dark\\:text-gpurple-50";
        public const string PriceClass = "span.block.truncate.font-bold";
        public const string ItemsNotFoundClass = "h2.mb-7.mt-16.text-2xl.font-black";
        public const string PaginationClass = "button.text-gblue-50";
        public const string NextPageQuery = "page";

        public static class Laptops
        {
            public const string Name = "GigatronLaptops";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "SSD";
            public const string TipProcesora = "Tip procesora";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }
        public static class Desktops
        {
            public const string Name = "GigatronDesktops";
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "Tip procesora";
            public const string GrafickaKartica = "Tip grafike";
            public const string SSD = "SSD";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }

        public static class Phones
        {
            public const string Name = "GigatronPhones";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }
        public static class Tablets
        {
            public const string Name = "GigatronTablets";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
            public const string RAMMemorija = "RAM memorija";
        }
    }

    public static class EPlaneta
    {
        public const string Name = "EPlaneta";
        public const string BaseUrl = "https://eplaneta.rs/";
        public const string LaptopsRelativeUrl = "it-oprema/laptopovi-i-tableti/laptopovi.html?";
        public const string DesktopRelativeUrl = "racunari-i-komponente/desktop-racunari?";
        public const string PhonesRelativeUrl = "mobilni-telefoni-tableti-i-oprema/mobilni-telefoni?";
        public const string TabletsRelativeUrl = "mobilni-telefoni-tableti-i-oprema/tablet-racunari?";

        public const string DivClass = "div.product-item-info";
        public const string LinkClass = "a[href$='.html']";
        public const string TitleClass = "strong.product-item-name a";
        public const string PriceClass = "span.special-price";
        public const string ItemsNotFoundClass = "span.special-pricee";
        public const string PaginationClass = "li.item.current";
        public const string NextPageQuery = "p";

        public static class Laptops
        {
            public const string Name = "EPlanetaLaptops";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "SSD";
            public const string TipProcesora = "Tip procesora";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }
        public static class Desktops
        {
            public const string Name = "EPlanetaDesktops";
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "Tip procesora";
            public const string GrafickaKartica = "Tip grafike";
            public const string SSD = "SSD";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }

        public static class Phones
        {
            public const string Name = "EPlanetaPhones";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
        }
        public static class Tablets
        {
            public const string Name = "EPlanetaTablets";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string MinCena = "cena";
            public const string MaxCena = "MaxCena";
            public const string RAMMemorija = "RAM memorija";
        }
    }
   

    public static ScrapingElements GetElementsForScraping(string siteAndProductName)
    {
        return siteAndProductName switch
        {
            Ananas.Laptops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.LaptopsRelativeUrl, Ananas.Laptops.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.Desktops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.DesktopsRelativeUrl, Ananas.Desktops.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.Phones.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.PhonesRelativeUrl, Ananas.Phones.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),
            Ananas.Tablets.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.TabletsRelativeUrl, Ananas.Tablets.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass, Ananas.ItemsNotFoundClass, Ananas.PaginationClass)),

            Gigatron.Laptops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.LaptopsRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.Desktops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.DesktopRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.Phones.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.PhonesRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
            Gigatron.Tablets.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.TabletsRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass, Gigatron.ItemsNotFoundClass, Gigatron.PaginationClass)),
           
            EPlaneta.Laptops.Name => new ScrapingElements(EPlaneta.BaseUrl + EPlaneta.LaptopsRelativeUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.Desktops.Name => new ScrapingElements(EPlaneta.BaseUrl + EPlaneta.DesktopRelativeUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.Phones.Name => new ScrapingElements(EPlaneta.BaseUrl + EPlaneta.PhonesRelativeUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),
            EPlaneta.Tablets.Name => new ScrapingElements(EPlaneta.BaseUrl + EPlaneta.TabletsRelativeUrl, string.Empty, new ScrapingSelectors(EPlaneta.DivClass, EPlaneta.LinkClass, EPlaneta.TitleClass, EPlaneta.PriceClass, EPlaneta.ItemsNotFoundClass, EPlaneta.PaginationClass)),

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
