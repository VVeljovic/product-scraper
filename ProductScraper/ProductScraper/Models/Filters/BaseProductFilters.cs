namespace ProductScraper.Models.Filters;

public class BaseProductFilters
{
    public List<string> Brend { get; set; }

    public List<string> SiteNames { get; set; }

    public decimal MinCena { get; set; }
    
    public decimal MaxCena { get; set; }
}
