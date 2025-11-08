namespace ProductScraper.Models.Filters;

public class DesktopFilters : BaseProductFilters
{
    public List<string> RAMMemorija { get; set; }

    public List<string> TipProcesora { get; set; }

    public List<string> SSD { get; set; }

    public List<string> GrafickaKartica { get; set; }
}
