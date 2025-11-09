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

    public static class Gigatron
    {
        public const string Name = "Gigatron";
        public const string BaseUrl = "https://gigatron.rs/";
        public const string LaptopsRelativeUrl = "racunari-i-komponente/laptop-racunari?";
        public const string DesktopRelativeUrl = "racunari-i-komponente/desktop-racunari?";
        public const string PhonesRelativeUrl = "mobilni-telefoni-tableti-i-oprema/mobilni-telefoni?";
        public const string TabletsRelativeUrl = "mobilni-telefoni-tableti-i-oprema/tablet-racunari?";
        public static class Laptops
        {
            public const string Name = "GigatronLaptops";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "SSD";
            public const string TipProcesora = "Tip procesora";

            public const string ClassSelector = "mt-[12px]";
        }
        public static class Desktops
        {
            public const string Name = "GigatronDesktops";
            public const string Brend = "Brend";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "Tip procesora";
            public const string GrafickaKartica = "Tip grafike";
            public const string SSD = "SSD";

            public const string ClassSelector = "mt-[12px]";
        }

        public static class Phones
        {
            public const string Name = "GigatronPhones";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";

            public const string ClassSelector = "mt-[12px]";
        }
        public static class Tablets
        {
            public const string Name = "GigatronTablets";
            public const string Brend = "Brend";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";

            public const string ClassSelector = "mt-[12px]";
        }
    }

    public static class JakovSistem
    {
        public const string Name = "JakovSistem";
        public const string BaseUrl = "https://jakov.rs/";
        public const string LaptopsRelativeUrl = "kategorije/laptop-racunari?";
        public static class Laptops
        {
            public const string Name = "JakovSistemLaptops";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija";
            public const string RAMMemorija = "RAM memorija";
            public const string SSD = "Kapacitet hard diska";
            public const string TipProcesora = "CPU tip";

            public const string ClassSelector = "line-clamp-3";
        }
        public static class Desktops
        {
            public const string Name = "JakovSistemDesktops";
            public const string Brend = "Proizvođač";
            public const string RAMMemorija = "RAM memorija";
            public const string TipProcesora = "CPU tip";
            public const string GrafickaKartica = "Integrisana grafika";
            public const string SSD = "Kapacitet SSDa";

            public const string ClassSelector = "mt-[12px]";
        }
        public static class Phones
        {
            public const string Name = "JakovSistemPhones";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string InternaMemorija = "Interna memorija";
            public const string PrednjaKamera = "Prednja kamera";
            public const string ZadnjaKamera = "Zadnja kamera";

            public const string ClassSelector = "mt-[12px]";
        }
        public static class Tablets
        {
            public const string Name = "JakovSistemTablets";
            public const string Brend = "Proizvođač";
            public const string DijagonalaEkrana = "Dijagonala ekrana";
            public const string RezolucijaEkrana = "Rezolucija ekrana";
            public const string InternaMemorija = "Interna memorija";

            public const string ClassSelector = "mt-[12px]";
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
            
            Gigatron.Laptops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.LaptopsRelativeUrl, string.Empty, Gigatron.Laptops.ClassSelector),
            Gigatron.Desktops.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.DesktopRelativeUrl, string.Empty, Gigatron.Desktops.ClassSelector),
            Gigatron.Phones.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.PhonesRelativeUrl, string.Empty, Gigatron.Phones.ClassSelector),
            Gigatron.Tablets.Name => new ScrapingElements(Gigatron.BaseUrl + Gigatron.TabletsRelativeUrl, string.Empty, Gigatron.Tablets.ClassSelector),
            
            JakovSistem.Laptops.Name => new ScrapingElements(JakovSistem.BaseUrl + JakovSistem.LaptopsRelativeUrl, string.Empty, JakovSistem.Laptops.ClassSelector),
            _ => throw new Exception(),
        };
    }

}
