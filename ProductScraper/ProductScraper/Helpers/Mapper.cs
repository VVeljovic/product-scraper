namespace ProductScraper.Helpers;

public static class Mapper
{
    public static Dictionary<string, Dictionary<string, string>> PropertyNameUrlParamMap = new Dictionary<string, Dictionary<string, string>>
    {
        [Constants.Ananas.Laptops.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Laptops.Brend] = Constants.Ananas.Laptops.Brend,
            [Constants.Filters.Laptops.DijagonalaEkrana] = Constants.Ananas.Laptops.DijagonalaEkrana,
            [Constants.Filters.Laptops.RezolucijaEkrana] = Constants.Ananas.Laptops.RezolucijaEkrana,
            [Constants.Filters.Laptops.RAMMemorija] = Constants.Ananas.Laptops.RAMMemorija,
            [Constants.Filters.Laptops.TipProcesora] = Constants.Ananas.Laptops.TipProcesora,
            [Constants.Filters.Laptops.SSD] = Constants.Ananas.Laptops.SSD
        },
        [Constants.Ananas.Desktops.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Desktops.Brend] = Constants.Ananas.Desktops.Brend,
            [Constants.Filters.Desktops.RAMMemorija] = Constants.Ananas.Desktops.RAMMemorija,
            [Constants.Filters.Desktops.TipProcesora] = Constants.Ananas.Desktops.TipProcesora,
            [Constants.Filters.Desktops.SSD] = Constants.Ananas.Desktops.SSD,
            [Constants.Filters.Desktops.GrafickaKartica] = Constants.Ananas.Desktops.SSD
        },
        [Constants.Ananas.Phones.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Phones.Brend] = Constants.Ananas.Phones.Brend,
            [Constants.Filters.Phones.DijagonalaEkrana] = Constants.Ananas.Phones.DijagonalaEkrana,
            [Constants.Filters.Phones.InternaMemorija] = Constants.Ananas.Phones.InternaMemorija,
            [Constants.Filters.Phones.PrednjaKamera] = Constants.Ananas.Phones.PrednjaKamera,
            [Constants.Filters.Phones.ZadnjaKamera] = Constants.Ananas.Phones.ZadnjaKamera
        },
        [Constants.Ananas.Tablets.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Tablets.DijagonalaEkrana] = Constants.Ananas.Tablets.DijagonalaEkrana,
            [Constants.Filters.Tablets.Brend] = Constants.Ananas.Tablets.Brend,
            [Constants.Filters.Tablets.InternaMemorija] = Constants.Ananas.Tablets.InternaMemorija,
            [Constants.Filters.Tablets.RezolucijaEkrana] = Constants.Ananas.Tablets.RezolucijaEkrana,
            [Constants.Filters.Tablets.DijagonalaEkrana] = Constants.Ananas.Tablets.DijagonalaEkrana
        },


        [Constants.Gigatron.Laptops.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Laptops.Brend] = Constants.Gigatron.Laptops.Brend,
            [Constants.Filters.Laptops.DijagonalaEkrana] = Constants.Gigatron.Laptops.DijagonalaEkrana,
            [Constants.Filters.Laptops.RezolucijaEkrana] = Constants.Gigatron.Laptops.RezolucijaEkrana,
            [Constants.Filters.Laptops.RAMMemorija] = Constants.Gigatron.Laptops.RAMMemorija,
            [Constants.Filters.Laptops.TipProcesora] = Constants.Gigatron.Laptops.TipProcesora,
            [Constants.Filters.Laptops.SSD] = Constants.Gigatron.Laptops.SSD
        },

        [Constants.Gigatron.Desktops.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Desktops.Brend] = Constants.Gigatron.Desktops.Brend,
            [Constants.Filters.Desktops.GrafickaKartica] = Constants.Gigatron.Desktops.GrafickaKartica,
            [Constants.Filters.Desktops.RAMMemorija] = Constants.Gigatron.Desktops.RAMMemorija,
            [Constants.Filters.Desktops.TipProcesora] = Constants.Gigatron.Desktops.TipProcesora,
            [Constants.Filters.Desktops.SSD] = Constants.Gigatron.Desktops.SSD
        },
        [Constants.Gigatron.Phones.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Phones.Brend] = Constants.Gigatron.Phones.Brend,
            [Constants.Filters.Phones.DijagonalaEkrana] = Constants.Gigatron.Phones.DijagonalaEkrana,
            [Constants.Filters.Phones.InternaMemorija] = Constants.Gigatron.Phones.InternaMemorija,
            [Constants.Filters.Phones.PrednjaKamera] = Constants.Gigatron.Phones.PrednjaKamera,
            [Constants.Filters.Phones.ZadnjaKamera] = Constants.Gigatron.Phones.ZadnjaKamera
        },
        [Constants.Gigatron.Tablets.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Tablets.DijagonalaEkrana] = Constants.Gigatron.Tablets.DijagonalaEkrana,
            [Constants.Filters.Tablets.Brend] = Constants.Gigatron.Tablets.Brend,
            [Constants.Filters.Tablets.InternaMemorija] = Constants.Gigatron.Tablets.InternaMemorija,
            [Constants.Filters.Tablets.RezolucijaEkrana] = Constants.Gigatron.Tablets.RezolucijaEkrana,
            [Constants.Filters.Tablets.DijagonalaEkrana] = Constants.Gigatron.Tablets.DijagonalaEkrana
        },

        [Constants.JakovSistem.Laptops.Name] = new Dictionary<string, string>
        {
            [Constants.Filters.Laptops.Brend] = Constants.JakovSistem.Laptops.Brend,
            [Constants.Filters.Laptops.DijagonalaEkrana] = Constants.JakovSistem.Laptops.DijagonalaEkrana,
            [Constants.Filters.Laptops.RezolucijaEkrana] = Constants.JakovSistem.Laptops.RezolucijaEkrana,
            [Constants.Filters.Laptops.RAMMemorija] = Constants.JakovSistem.Laptops.RAMMemorija,
            [Constants.Filters.Laptops.TipProcesora] = Constants.JakovSistem.Laptops.TipProcesora,
            [Constants.Filters.Laptops.SSD] = Constants.JakovSistem.Laptops.SSD
        },
    };
}
