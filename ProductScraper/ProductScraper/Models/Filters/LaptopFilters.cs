namespace ProductScraper.Models.Filters;

public sealed class LaptopFilters : BaseProductFilters
{
    public List<string> RAMMemorija { get; set; }

    public List<string> DijagonalaEkrana { get; set; }

    public List<string> TipProcesora { get; set; }

    public List<string> RezolucijaEkrana { get; set; }

    public List<string> SSD { get; set; }
}