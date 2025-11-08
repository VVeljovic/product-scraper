namespace ProductScraper.Helpers;

public static class Constants
{
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
            public const string ClassSelector = "sc-14no49n-0";
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
            public const string ClassSelector = "sc-14no49n-0";
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
            public const string ClassSelector = "sc-14no49n-0";
        }
        public static class Tablets
        {
            public const string Name = "AnanasTablets";
            public const string Brend = "brand";
            public const string DijagonalaEkrana = "DisplayDiagonal";
            public const string RezolucijaEkrana = "DisplayResolution";
            public const string InternaMemorija = "InternalMemory";

            public const string QueryAttibut = "refinementList[product.selectAttributes.";
            public const string ClassSelector = "sc-14no49n-0";
        }
    }

    public static ScrapingElements GetUrlForScraping(string siteAndProductName)
    {
        return siteAndProductName switch
        {
            Ananas.Laptops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.LaptopsRelativeUrl, Ananas.Laptops.QueryAttibut, Ananas.Laptops.ClassSelector),
            Ananas.Desktops.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.DesktopsRelativeUrl, Ananas.Desktops.QueryAttibut, Ananas.Desktops.ClassSelector),
            Ananas.Phones.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.PhonesRelativeUrl, Ananas.Phones.QueryAttibut, Ananas.Phones.ClassSelector),
            Ananas.Tablets.Name => new ScrapingElements(Ananas.BaseUrl + Ananas.TabletsRelativeUrl, Ananas.Tablets.QueryAttibut, Ananas.Tablets.ClassSelector),
            _ => throw new Exception(),
        };
    }

}
