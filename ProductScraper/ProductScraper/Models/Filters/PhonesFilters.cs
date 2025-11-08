namespace ProductScraper.Models.Filters;

public class PhonesFilters : BaseProductFilters
{
    public List<string> DijagonalaEkrana { get; set; }

    public List<string> InternaMemorija { get; set; }

    public List<string> PrednjaKamera { get; set; }
 
    public List<string> ZadnjaKamera { get; set; }
}
