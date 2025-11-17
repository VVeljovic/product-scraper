namespace ProductScraper.Helpers;

public static class Constants
{
    public static List<string> SiteNames = [ "Ananas", "Gigatron", "JakovSistem" ];

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
        }
        public static class Desktops
        {
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAMMemorija";
            public const string TipProcesora = "TipProcesora";
            public const string SSD = "SSD";
            public const string GrafickaKartica = "GrafickaKartica";
        }
        public static class Phones
        {
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "DijagonalaEkrana";
            public const string InternaMemorija = "InternaMemorija";
            public const string PrednjaKamera = "PrednjaKamera";
            public const string ZadnjaKamera = "ZadnjaKamera";
        }
        public static class Tablets
        {
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "DijagonalaEkrana";
            public const string RezolucijaEkrana = "RezolucijaEkrana";
            public const string InternaMemorija = "InternaMemorija";
            public const string RamMemorija = "RamMemorija";
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
        public static class Laptops
        {
            public const string Name = "AnanasLaptops";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string RezolucijaEkrana = "DisplayResolution";
            public const string RAMMemorija = "RamCapacity";
            public const string TipProcesora = "ProcessorModel";
            public const string SSD = "SsdHdd";

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

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
        }
        public static class Tablets
        {
            public const string Name = "AnanasTablets";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string RezolucijaEkrana = "DisplayResolution";
            public const string InternaMemorija = "InternalMemory";

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
        public const string TitleClass = ".mt-\\[12px\\].line-clamp-2.h-\\[38px\\].font-bold.leading-tight.dark\\:text-gpurple-50";
        public const string PriceClass = "span.block.truncate";
        public static class Laptops
        {
            public const string Name = "GigatronLaptops";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "SSD";
            public const string TipProcesora = "Tip procesora";

        }
        public static class Desktops
        {
            public const string Name = "GigatronDesktops";
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "Tip procesora";
            public const string GrafickaKartica = "Tip grafike";
            public const string SSD = "SSD";

        }

        public static class Phones
        {
            public const string Name = "GigatronPhones";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";

        }
        public static class Tablets
        {
            public const string Name = "GigatronTablets";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";

        }
    }

    public static class JakovSistem
    {
        public const string Name = "JakovSistem";
        public const string BaseUrl = "https://jakov.rs/";
        public const string LaptopsRelativeUrl = "kategorije/laptop-racunari?";
        public const string DesktopsRelativeUrl = "kategorije/desktop-racunari?";
        public const string PhonesRelativeUrl = "kategorije/mobilni-smart-telefoni?";
        public const string TabletsRelativeUrl = "kategorije/tableti?";
        public const string DivClass = "div.p-1";
        public const string LinkClass = "a[href*='/kategorije/laptop-racunari/proizvodi/']";
        public const string TitleClass = "h3.font-semibold";
        public const string PriceClass = "span.text-xl";

        public static class Laptops
        {
            public const string Name = "JakovSistemLaptops";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "Kapacitet hard diska";
            public const string TipProcesora = "CPU tip";
        }
        public static class Desktops
        {
            public const string Name = "JakovSistemDesktops";
            public const string Brend = "Proizvođač";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "CPU tip";
            public const string GrafickaKartica = "Integrisana grafika";
            public const string SSD = "Kapacitet SSDa";
        }
        public static class Phones
        {
            public const string Name = "JakovSistemPhones";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";
        }
        public static class Tablets
        {
            public const string Name = "JakovSistemTablets";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";
        }
    }

    public static ScrapingElements GetElementsForScraping(string siteAndProductName)
    {
        return siteAndProductName switch
        {
            Ananas.Laptops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.LaptopsRelativeUrl, Ananas.Laptops.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass)),
            Ananas.Desktops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.DesktopsRelativeUrl, Ananas.Desktops.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass)),
            Ananas.Phones.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.PhonesRelativeUrl, Ananas.Phones.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass)),
            Ananas.Tablets.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.TabletsRelativeUrl, Ananas.Tablets.QueryAttibut, new ScrapingSelectors(Ananas.DivClass, Ananas.LinkClass, Ananas.TitleClass, Ananas.PriceClass)),

            Gigatron.Laptops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.LaptopsRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass)),
            Gigatron.Desktops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.DesktopRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass)),
            Gigatron.Phones.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.PhonesRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass)),
            Gigatron.Tablets.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.TabletsRelativeUrl, string.Empty, new ScrapingSelectors(Gigatron.DivClass, Gigatron.LinkClass, Gigatron.TitleClass, Gigatron.PriceClass)),

            JakovSistem.Laptops.Name => new ScrapingElements(JakovSistem.BaseUrl + JakovSistem.LaptopsRelativeUrl, string.Empty, new ScrapingSelectors(JakovSistem.DivClass, JakovSistem.LinkClass, JakovSistem.TitleClass, JakovSistem.PriceClass)),
            JakovSistem.Desktops.Name => new ScrapingElements(JakovSistem.BaseUrl + JakovSistem.DesktopsRelativeUrl, string.Empty, new ScrapingSelectors(JakovSistem.DivClass, JakovSistem.LinkClass, JakovSistem.TitleClass, JakovSistem.PriceClass)),
            JakovSistem.Phones.Name => new ScrapingElements(JakovSistem.BaseUrl + JakovSistem.PhonesRelativeUrl, string.Empty, new ScrapingSelectors(JakovSistem.DivClass, JakovSistem.LinkClass, JakovSistem.TitleClass, JakovSistem.PriceClass)),
            JakovSistem.Tablets.Name => new ScrapingElements(JakovSistem.BaseUrl + JakovSistem.TabletsRelativeUrl, string.Empty, new ScrapingSelectors(JakovSistem.DivClass, JakovSistem.LinkClass, JakovSistem.TitleClass, JakovSistem.PriceClass)),
            
            _ => throw new Exception(),
        };
    }

}
