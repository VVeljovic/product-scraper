namespace ProductScraper.Models.Filters;

public sealed class TabletsFilters : BaseProductFilters
{
    public List<string> RAMMemorija { get; set; }

    public List<string> DijagonalaEkrana { get; set; }

    public List<string> RezolucijaEkrana { get; set; }

    public List<string> InternaMemorija { get; set; }

}
