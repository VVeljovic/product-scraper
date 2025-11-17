namespace ProductScraper.Models.Filters;

public class BaseProductFilters
{
    public decimal MinCena { get; set; }
    
    public decimal MaxCena { get; set; }

    public List<string> Brend { get; set; }
}
